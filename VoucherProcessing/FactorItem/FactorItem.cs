using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoucherProcessing.Model;
using WarehouseManagement;

namespace VoucherProcessing.Model
{
    public partial class FactorItem : IEntity
    {
    }

    public class FactorItemProvider : IDataProvider
    {
        public int Order => 5;

        public string ButtonText => "آیتم فاکتور";

        public IList GetData()
        {
            using (var context = new HREntitiesVoucher())
            {
                var allFactorItems = context.FactorItems.ToList();
                return allFactorItems;
            }
        }

        public void Save(IEnumerable<IEntity> List)
        {
        }
    }
}

