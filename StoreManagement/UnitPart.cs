using System;
using System.Collections.Generic;
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

        public IReadOnlyCollection<IEntity> GetData()
        {
            return new List<UnitPart>
            {
                new UnitPart
                {
                    Id = 1,
                    Name = "واحد سنجش 1"
                },
                new UnitPart
                {
                    Id = 2,
                    Name = "واحد سنجش 2"
                }
            };
        }

        public void SaveAction(IReadOnlyCollection<IEntity> Lists)
        {
            throw new NotImplementedException();
        }
    }
}
