using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace VoucherProcessing
{
    public class Factor: IDataProvider<Factor>
    {
        public int Order => 4;

        public string ButtonText => "فاکتور";
        public List<Factor> GetData()
        {
            return new List<Factor>();
        }
        public void SaveAction(List<Factor> List)
        {
            throw new NotImplementedException();
        }
    }
}
 