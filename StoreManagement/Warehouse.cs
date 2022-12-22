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
        }

        public string SaveAction()
        {
            string command = "UPDATE warehouse SET warehouse_id=@warehouse_id,warehouse_name=@warehouse_name";
            return command;
        }
    }
}

