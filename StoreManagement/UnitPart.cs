using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace StoreManagement
{
    public class UnitPart : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UnitPartProvider : IDataProvider
    {
        public int Order => 3;

        public string ButtonText => "واحد سنجش";

        public string GetData()
        {
            string command = "select * from unit";
            return command;
        }

        public string SaveAction(IReadOnlyCollection<IEntity> Lists)
        {
            throw new NotImplementedException();
        }
    }
}
