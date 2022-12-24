using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoucherProcessing.Model;
using WarehouseManagement;

namespace VoucherProcessing.Factoritem
{
    public class Factoritem : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FactorItemProvider : IDataProvider
    {
        public int Order => 5;

        public string ButtonText => "آیتم های فاکتور";

        public IReadOnlyCollection<IEntity> GetData()
        {
            using (var context = new HREntitiesVoucher())
            {
                var allFactorItem = context.factor_item.Select(x => x).ToList();
                return (IReadOnlyCollection<IEntity>)allFactorItem;
            }
        }

        public string Save()
        {
            string command = "UPDATE factor SET factor_id=@factor_id,factor_date=@factor_date,factor_type=@factor_type,customer_id=@customer_id";
            return command;
        }
    }
}

