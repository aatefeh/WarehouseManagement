using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace VoucherProcessing
{
    public class Factor : IDataProvider<IEntity>, IEntity
    {
        public int Order => 4;

        public string ButtonText => "فاکتور";

        public object Data => "atefeh";

        public List<IEntity> GetData()
        {
            var ListOfData = new List<IEntity>();
            ListOfData.Add((IEntity)Data);
            return ListOfData;
        }
        public void SaveAction(List<IEntity> List)
        {
            throw new NotImplementedException();
        }
    }
}
 