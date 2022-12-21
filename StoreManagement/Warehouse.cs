using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace StoreManagement
{
    public class Warehouse : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class WarehouseProvider : IDataProvider
    {
        public int Order => 1;

        public string ButtonText => "انبار";

        public IReadOnlyCollection<IEntity> GetData()
        {
            return new List<Warehouse>
            {
                new Warehouse
                {
                    Id = 1,
                    Name = "انبار 1"
                },
                new Warehouse
                {
                    Id = 2,
                    Name = "انبار 2"
                }
            };
        }

        public void SaveAction(IReadOnlyCollection<IEntity> Lists)
        {
            throw new NotImplementedException();
        }
    }
}
