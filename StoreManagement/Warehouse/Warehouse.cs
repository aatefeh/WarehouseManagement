using StoreManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace StoreManagement
{
    public partial class Warehouse : IEntity
    {
    }

    public class WarehouseProvider : IDataProvider
    {
        public int Order => 1;

        public string ButtonText => "انبار";

        public IEnumerable<IEntity> GetData()
        {
            using (var context = new HREntitiesStore())
            {
                var allWarehouse = context.warehouses.ToList();
                return (IEnumerable<IEntity>)allWarehouse;
            }
        }

        public string Save()
        {
            string command = "UPDATE warehouse SET warehouse_id=@warehouse_id,warehouse_name=@warehouse_name";
            return command;
        }
    }
}

