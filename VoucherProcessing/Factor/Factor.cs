using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
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

        public DataTable GetData()
        {
            using (var context = new HREntitiesVoucher())
            {
                DataTable dbTable = new DataTable();
                var factoreQuery = (from factor in context.Factors
                                  join factor_item in context.FactorItems on factor.ID equals factor_item.ID
                                  select new { کد_فاکتور = factor.ID, تاریخ_فاکتور = factor.factor_date, نوع_فاکتور=factor.factor_type,کد_مشتری = factor.customer_id}).ToList();
                dbTable.Columns.Add("کد_فاکتور");
                dbTable.Columns.Add("تاریخ_فاکتور");
                dbTable.Columns.Add("نوع_فاکتور");
                dbTable.Columns.Add("کد_مشتری");
                foreach (var item in factoreQuery)
                {
                    dbTable.Rows.Add(item.کد_فاکتور, item.تاریخ_فاکتور, item.نوع_فاکتور, item.کد_مشتری);
                }
                return dbTable;
            }
        }

        public void Save()
        {
        }
    }
}
