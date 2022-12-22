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

        public string GetData()
        {
            string command = "select * from good";
            return command;
            //return new List<Part>
            //{
            //    new Part
            //    {
            //        Id = 111,
            //        Name = "کالا 1"
            //    },
            //    new Part
            //    {
            //        Id = 211,
            //        Name = "کالا 2"
            //    }
            //};
        }

        public string SaveAction(IReadOnlyCollection<IEntity> Lists)
        {
            throw new NotImplementedException();
        }
    }
}
