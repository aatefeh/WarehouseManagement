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
    public class Part : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PartProvider : IDataProvider
    {
        public int Order => 2;

        public string ButtonText => "کالا";

        public IReadOnlyCollection<IEntity> GetData()
        {
            using (var context = new HREntitiesStore())
            {
                var allPart = context.goods.Select(x => x).ToList();
                return (IReadOnlyCollection<IEntity>)allPart;
            }
        }

        public string Save()
        {
            string command = "UPDATE good SET good_id=@good_id,good_name=@good_name,unit_id=@unit_id";
            return command;
        }
    }
}
