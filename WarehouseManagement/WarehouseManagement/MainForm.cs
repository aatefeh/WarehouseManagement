using System.Reflection;

namespace WarehouseManagement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
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
                .Where(mytype => mytype.GetInterfaces().Contains(typeof(IDataProvider))).ToList();
            //Button
            foreach (var implType in impls)
            {
                var dataProvider = (IDataProvider)Activator.CreateInstance(implType);
                var button = new Button { Text = dataProvider.LinkText };
                button.Click += Button_Click;
                Controls.Add(button);
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            mainGridView.DataSource = EntityBusinessFactory.Create().GetAll();
        }
    }
}