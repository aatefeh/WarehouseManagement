using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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

        public DataTable GetData()
        {
            using (var context = new HREntitiesVoucher())
            {
                DataTable dbTable = new DataTable();
                var factoreItemQuery = (from factor_item in context.FactorItems
                                        join factor in context.Factors on factor_item.ID equals factor.ID
                                        select new { کد_فاکتور = factor_item.ID, کد_انبار = factor_item.warehouse_id, کد_کالا = factor_item.part_id, تعداد_کالا = factor_item.part_number}).ToList();
                dbTable.Columns.Add("کد_فاکتور");
                dbTable.Columns.Add("کد_انبار");
                dbTable.Columns.Add("کد_کالا");
                dbTable.Columns.Add("تعداد_کالا");
                foreach (var item in factoreItemQuery)
                {
                    dbTable.Rows.Add(item.کد_فاکتور, item.کد_انبار, item.کد_کالا, item.تعداد_کالا);
                }
                return dbTable;
            }
        }
        public void Save()
        {
        }
    }
}

