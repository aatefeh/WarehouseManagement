using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            var impls = allAssemblies
                .SelectMany(assemble => assemble.GetTypes())
                .Where(mytype => mytype.GetInterfaces().Contains(typeof(IDataProvider<IEntity>))).ToList();
            return impls;

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            var impls = GetAllAssembly();
            //Button
            foreach (var implType in impls)
            {
                var dataProvider = (IDataProvider<IEntity>)Activator.CreateInstance(implType);
                ButtonProviderName = (Type)dataProvider.GetType();
                var button = new System.Windows.Forms.Button { Text = dataProvider.ButtonText, Tag=dataProvider.Order};
                button.Left = 20;
                button.Top= (((int)button.Tag*10)+(((int)button.Tag-1)*button.Height));
                button.Click += Button_Click;
                this.panel1.Controls.Add(button);
            }
        }

        private Type ButtonProviderName { get; set; }
        private void Button_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            var providerName = (Type)ButtonProviderName;
            var impls = GetAllAssembly();
            foreach (var implType in impls)
            {
                if(implType==providerName) 
                {
                    var dataProvider = (IDataProvider<IEntity>)Activator.CreateInstance(implType);
                    var dataList = new List<IEntity>();
                    dataList = dataProvider.GetData();
                    dataGridView1.DataSource = dataList;
                }
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            var newDataGridview = new DataGridView();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                newDataGridview.Rows.Add(row);
            }

        }
    }
}