using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace WarehouseManagement
{
    public partial class MainForm : Form
    {
        private Dictionary<int,Type> ButtonWasClicked = new Dictionary<int, Type>();
        private int i = 0;
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-D26MECS;Initial Catalog=HR;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        private Type LastClickeTable;
        public MainForm()
        {
            InitializeComponent();
        }
        private List<Type> GetAllAssembly()
        {
            var currentBinPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var allAssemblies = new List<Assembly>
            {
                Assembly.GetExecutingAssembly()
            };
            foreach (var dll in Directory.GetFiles(currentBinPath, "*.dll"))
            {
                allAssemblies.Add(Assembly.LoadFile(dll));
            }

            var allTypes = allAssemblies
                .SelectMany(assemble => assemble.GetTypes());

            var impls = allTypes
                .Where(mytype => mytype.GetInterfaces().Contains(typeof(IDataProvider))).ToList();
            return impls;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var impls = GetAllAssembly();
            //Button
            foreach (var implType in impls)
            {
                var dataProvider = (IDataProvider)Activator.CreateInstance(implType);
                var button = new System.Windows.Forms.Button { Text = dataProvider.ButtonText, Tag = dataProvider.Order };
                ButtonWasClicked.Add((int)button.Tag, (Type)dataProvider.GetType());
                button.Left = 20;
                button.Top= (((int)button.Tag*10)+(((int)button.Tag-1)*button.Height));
                button.Click += Button_Click;
                this.panel1.Controls.Add(button);
                i++;
            }
        }
        private void Button_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btnsender = (System.Windows.Forms.Button)sender;
            var d = (int)btnsender.Tag;
            foreach (var clicked in ButtonWasClicked)
            {
                if (clicked.Key == d)
                {
                    dataGridView1.DataSource = null;
                    var impls = GetAllAssembly();
                    foreach (var implType in impls)
                    {
                        if (implType == clicked.Value)
                        {
                            LastClickeTable = clicked.Value;
                            var dataProvider = (IDataProvider)Activator.CreateInstance(implType);
                            con.Open();
                            string command=(string)dataProvider.GetData();
                            da = new SqlDataAdapter(command, con);
                            ds = new DataSet();
                            da.Fill(ds,"Table");
                            dataGridView1.DataSource = ds;
                            dataGridView1.DataMember= "Table";
                            con.Close();
                            break;
                        }
                    }
                    break;
                }
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            var impls = GetAllAssembly();
            foreach (var implType in impls)
            {
                if (implType == LastClickeTable)
                {
                    var dataProvider = (IDataProvider)Activator.CreateInstance(implType);
                    string commandsave = (string)dataProvider.SaveAction();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(commandsave, con);
                    SqlCommandBuilder sqlCB = new SqlCommandBuilder(da);
                    da.Update(ds, "Table");
                    break;
                }
            }
            //SqlDataAdapter dataAdapter=new SqlDataAdapter("select * from Table")
        }
        }
}