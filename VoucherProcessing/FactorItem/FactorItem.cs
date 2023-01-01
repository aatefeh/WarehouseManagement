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
                return (IEnumerable<IEntity>)(from item in context.Set<FactorItem>()
                                              join factor in context.Set<Factor>()
                                              on item.ID equals factor.ID
                                              select new
                                              {
                                                  ItemID = item.ID,
                                                  WarehouseID = item.warehouse_id,
                                                  PartID = item.part_id,
                                                  PartNumber = item.part_number
                                              }).ToList()
                       .Select(x => new FactorItem
                       {
                           ID=x.ItemID,
                           warehouse_id=x.WarehouseID,
                           part_id=x.PartID,
                           part_number=x.PartNumber
                       });
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

