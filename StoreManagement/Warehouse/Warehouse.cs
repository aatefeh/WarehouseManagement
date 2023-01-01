using StoreManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace StoreManagement.Model
{
    public partial class Warehouse : IEntity
    {
    }

    public class WarehouseProvider : IDataProvider
    {
        public int Order => 1;

        public string ButtonText => "انبار";

        public IEnumerable<IEntity> GetData()
        {
            using (var context = new HREntitiesStore())
            {
                return (from warehouse in context.Warehouses
                        select new Warehouse
                        {
                            ID = warehouse.ID,
                            warehouse_name = warehouse.warehouse_name
                        }
                        ).ToList();
            }
        }

        //public IReadOnlyCollection<ColumnInfo> GetColumns()
        //{
        //    return new ColumnInfo[]
        //    {
        //        new ColumnInfo
        //        {
        //            Name = nameof(Warehouse.ID),
        //            Title = "شناسه"
        //        },
        //        new ColumnInfo
        //        {
        //            Name = nameof(Warehouse.warehouse_name),
        //            Title = "نام انبار"
        //        }
        //    };
        //}
        public void Save()
        {
        }
    }
}

