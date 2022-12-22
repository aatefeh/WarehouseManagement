using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics;

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

        public string GetData()
        {
            string command = "select * from factor";
            return command;
            //return new List<Factor>
            //{
            //    new Factor
            //    {
            //        Id = 115,
            //        Name = "فاکتور 1"
            //    },
            //    new Factor
            //    {
            //        Id = 215,
            //        Name = "فاکتور 2"
            //    }
            //};
        }

        public string SaveAction(/*IReadOnlyCollection<IEntity> Lists*/)
        {
            string command = "UPDATE factor Table";
            return command;
        }
    }
}
 