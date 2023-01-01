using StoreManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
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

        public IEnumerable<IEntity> GetData()
        {
            using (var context = new HREntitiesVoucher())
            {
                return (IEnumerable<IEntity>)(from factor in context.Set<Factor>()
                                              join item in context.Set<FactorItem>()
                                              on factor.ID equals item.ID
                                              select new
                                              {
                                                  FactorID = factor.ID,
                                                  FactorDate = factor.factor_date,
                                                  FactorType = factor.factor_type,
                                                  CustomerID=factor.customer_id
                                              }).ToList()
                        .Select(x => new Factor
                        {
                            ID=x.FactorID,
                            factor_date= x.FactorDate,
                            factor_type= x.FactorType,
                            customer_id= x.CustomerID
                        });
            }
        }

        public IReadOnlyCollection<ColumnInfo> GetColumns()
        {
            return new ColumnInfo[]
            {
                new ColumnInfo
                {
                    Name = nameof(Factor.ID),
                    Title = "شناسه"
                },
                new ColumnInfo
                {
                    Name = nameof(Factor.factor_date),
                    Title = "تاریخ فاکتور"
                },
                new ColumnInfo
                {
                    Name = nameof(Factor.factor_type),
                    Title = "نوع فاکتور"
                },
                new ColumnInfo
                {
                    Name = nameof(Factor.customer_id),
                    Title = "شناسه مشتری"
                }
            };
        }
        public void Save()
        {
        }
    }
}
