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
    public partial class UnitPart : IEntity
    {
    }

    public class UnitPartProvider : IDataProvider
    {
        public int Order => 3;

        public string ButtonText => "واحد سنجش";

        public IList GetData()
        {
            using (var context = new HREntitiesStore())
            {
                var allUnitParts = (from unit_part in context.UnitParts
                                   join part in context.Parts on unit_part.ID equals part.unit_id
                                    select new { Id = unit_part.ID, Name = unit_part.unit_name }).ToList();
                return allUnitParts;
            }
        }

        public void Save(IEnumerable<IEntity> List)
        {
        }
    }
}
