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
        public string CustomerName { get; set; }
    }

    public class FactorProvider : IDataProvider
    {
        public int Order => 4;

        public string ButtonText => "فاکتور";

        public IEnumerable<IEntity> GetData()
        {
            using (var context = new HREntitiesVoucher())
            {
                return (from factor in context.Factors
                        join item in context.FactorItems on factor.ID equals item.ID
                        select new Factor
                        {
                            ID = factor.ID,
                            factor_date = factor.factor_date,
                            factor_type = factor.factor_type,
                            customer_id = factor.customer_id
                        }).ToList();
            }
        }

        //public IReadOnlyCollection<ColumnInfo> GetColumns()
        //{
        //    return new ColumnInfo[]
        //    {
        //        new ColumnInfo
        //        {
        //            Name = nameof(Factor.ID),
        //            Title = "شناسه"
        //        },
        //        new ColumnInfo
        //        {
        //            Name = nameof(Factor.factor_date),
        //            Title = "تاریخ فاکتور"
        //        },
        //        new ColumnInfo
        //        {
        //            Name = nameof(Factor.factor_type),
        //            Title = "نوع فاکتور"
        //        },
        //        new ColumnInfo
        //        {
        //            Name = nameof(Factor.customer_id),
        //            Title = "شناسه مشتری"
        //        }
        //    };
        //}
        public void Save()
        {
        }
    }
}
