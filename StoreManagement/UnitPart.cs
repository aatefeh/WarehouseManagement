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
            //return new DataSet();
            //return new List<UnitPart>
            //{
            //    new UnitPart
            //    {
            //        Id = 5552,
            //        Name = "واحد سنجش 1"
            //    },
            //    new UnitPart
            //    {
            //        Id = 5558,
            //        Name = "واحد سنجش 2"
            //    }
            //};
        }

        public string SaveAction(IReadOnlyCollection<IEntity> Lists)
        {
            throw new NotImplementedException();
        }
    }
}
