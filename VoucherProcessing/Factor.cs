using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace VoucherProcessing
{
    public class Factor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FactorProvider : IDataProvider
    {
        public int Order =>4;

        public string ButtonText => "فاکتور";

        public IReadOnlyCollection<IEntity> GetData()
        {
            //SqlConnection con = new SqlConnection("Data Source=DESKTOP-D26MECS;Initial Catalog=HR;Integrated Security=True");
            //con.Open();
            //SqlDataAdapter da = new SqlDataAdapter("select * from Factor", con);
            //DataSet ds = new DataSet();
            //da.Fill(ds, "FACTOR");
            //con.Close();
            //return ds;
            ////dataGridView1.DataSource = ds;
            ////dataGridView1.DataMember = "FACTOR";

            return new List<Factor>
            {
                new Factor
                {
                    Id = 115,
                    Name = "فاکتور 1"
                },
                new Factor
                {
                    Id = 215,
                    Name = "فاکتور 2"
                }
            };
        }

        public void SaveAction(IReadOnlyCollection<IEntity> Lists)
        {
            throw new NotImplementedException();
        }
    }
}
 