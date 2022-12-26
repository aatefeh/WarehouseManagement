using StoreManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace StoreManagement.Model
{
    public partial class Warehouse : IEntity
    {
    }

    public class WarehouseProvider : IDataProvider
    {
        public int Order => 1;

        public string ButtonText => "انبار";

        public IList GetData()
        {
            using (var context = new HREntitiesStore())
            {
                var allWarehouses = context.Warehouses.ToList();
                return allWarehouses;
            }
        }

        public void Save(IEnumerable<IEntity> List)
        {
        }
    }
}

