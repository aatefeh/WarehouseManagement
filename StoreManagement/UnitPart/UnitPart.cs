using StoreManagement.Model;
using System;
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

        public IEnumerable<IEntity> GetData()
        {
            using (var context = new HREntitiesStore())
            {
                var allUnit = context.units.ToList();
                return (IEnumerable<IEntity>)allUnit;
            }
        }

        public string Save()
        {
            string command = "UPDATE unit SET unit_id=@unit_id,unit_name=@unit_name";
            return command;
        }
    }
}
