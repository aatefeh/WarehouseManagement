using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace StoreManagement
{
    public class Warehouse : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class WarehouseProvider : IDataProvider
    {
        public int Order => 1;

        public string ButtonText => "انبار";

        public string GetData()
        {
            string command = "select * from warehouse";
            return command;
            //return new DataSet();
            //return new List<Warehouse>
            //{
            //    new Warehouse
            //    {
            //        Id = 1111,
            //        Name = "انبار 1"
            //    },
            //    new Warehouse
            //    {
            //        Id = 2111,
            //        Name = "انبار 2"
            //    }
            //};
        }

        public string SaveAction(IReadOnlyCollection<IEntity> Lists)
        {
            string command = "select * from Table";
            return command;
        }
    }
}
