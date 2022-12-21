using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace VoucherProcessing
{
    public class Factor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FactorProvider : IDataProvider
    {
        public int Order =>4;

        public string ButtonText => "فاکتور";

        public IReadOnlyCollection<IEntity> GetData()
        {
            return new List<Factor>
            {
                new Factor
                {
                    Id = 115,
                    Name = "فاکتور 1"
                },
                new Factor
                {
                    Id = 215,
                    Name = "فاکتور 2"
                }
            };
        }

        public void SaveAction(IReadOnlyCollection<IEntity> Lists)
        {
            throw new NotImplementedException();
        }
    }
}
 