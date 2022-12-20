using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace VoucherProcessing
{
    public class Factor: IDataProvider<IEntity>
    {
        public int Order => 4;

        public string ButtonText => "فاکتور";
        public List<IEntity> GetData()
        {
            //var TestList = new List<IEntity>();
            //TestList.Add(new IEntity("atefeh", "malek"));
            return new List<IEntity>();
        }
        public void SaveAction(List<IEntity> List)
        {
            //throw new NotImplementedException();
        }
    }
}
 