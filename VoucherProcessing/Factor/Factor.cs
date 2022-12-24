using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoucherProcessing.Model;
using WarehouseManagement;

namespace VoucherProcessing.Factor
{
    public class Factor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FactorProvider : IDataProvider
    {
        public int Order => 4;

        public string ButtonText => "فاکتور";

        public IEnumerable<IEntity> GetData()
        {
            using (var context = new HREntitiesVoucher())
            {
                var allFactor = context.factors.ToList();
                return (IEnumerable<IEntity>)allFactor;
            }
        }

        public string Save()
        {
            string command = "UPDATE factor SET factor_id=@factor_id,factor_date=@factor_date,factor_type=@factor_type,customer_id=@customer_id";
            return command;
        }
    }
}
