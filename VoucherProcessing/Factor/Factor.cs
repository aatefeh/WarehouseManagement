using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VoucherProcessing.Model;
using WarehouseManagement;

namespace VoucherProcessing.Model
{
    public partial class Factor : IEntity
    {
    }

    public class FactorProvider : IDataProvider
    {
        public int Order => 4;

        public string ButtonText => "فاکتور";

        public IList GetData()
        {
            using (var context = new HREntitiesVoucher())
            {
                var factoreQuery = (from factor in context.Factors
                                  join factor_item in context.FactorItems on factor.ID equals factor_item.ID
                                  select new { Id = factor.ID, Date = factor.factor_date, Type=factor.factor_type,CoustomerId = factor.customer_id}).ToList();
                return factoreQuery;
            }
        }

        public void Save(IEnumerable<IEntity> List)
        {
        }
    }
}
