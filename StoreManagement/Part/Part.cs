using StoreManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace StoreManagement.Model
{
    public partial class Part : IEntity
    {
    }

    public class PartProvider : IDataProvider
    {
        public int Order => 2;

        public string ButtonText => "کالا";

        public IList GetData()
        {
            using (var context = new HREntitiesStore())
            {
                var partsQuery = (from part_item in context.Parts
                                  join unit_item in context.UnitParts on part_item.unit_id equals unit_item.ID
                                  select new { Id = part_item.ID, Name = part_item.part_name, UnitId = part_item.unit_id }).ToList();
                return partsQuery;
            }
        }

        public void Save(IEnumerable<IEntity> List)
        {

        }
    }
}
