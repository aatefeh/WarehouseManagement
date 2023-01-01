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

        public IEnumerable<IEntity> GetData()
        {
            using (var context = new HREntitiesVoucher())
            {
                return (from factor_item in context.FactorItems
                        join factor in context.Factors on factor_item.ID equals factor.ID
                        select new FactorItem
                        {
                            ID = factor_item.ID,
                            warehouse_id = factor_item.warehouse_id,
                            part_id = factor_item.part_id,
                            part_number = factor_item.part_number
                        }).ToList();
            }
        }
        public IReadOnlyCollection<ColumnInfo> GetColumns()
        {
            return new ColumnInfo[]
            {
                new ColumnInfo
                {
                    Name = nameof(FactorItem.ID),
                    Title = "شناسه"
                },
                new ColumnInfo
                {
                    Name = nameof(FactorItem.warehouse_id),
                    Title = "شناسه انبار"
                },
                new ColumnInfo
                {
                    Name = nameof(FactorItem.part_id),
                    Title = "شناسه کالا"
                },
                new ColumnInfo
                {
                    Name = nameof(FactorItem.part_number),
                    Title = "تعداد کالا"
                }
            };
        }
        public void Save()
        {
        }
    }
}

