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
                return (from w in context.Set<Warehouse>()
                        select new
                        {
                            ID = w.ID,
                            warehouse_name = w.warehouse_name
                        }
                        ).ToList()
                        .Select(x => new Warehouse
                        {
                            ID = x.ID,
                            warehouse_name = x.warehouse_name

                        });
            }
        }

        public IReadOnlyCollection<ColumnInfo> GetColumns()
        {
            return new ColumnInfo[]
            {
                new ColumnInfo
                {
                    Name = nameof(Warehouse.ID),
                    Title = "شناسه"
                },
                new ColumnInfo
                {
                    Name = nameof(Warehouse.warehouse_name),
                    Title = "نام انبار"
                }
            };
        }
        public void Save()
        {
        }
    }
}

