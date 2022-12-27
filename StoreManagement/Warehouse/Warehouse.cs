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

        public DataTable GetData()
        {
            using (var context = new HREntitiesStore())
            {
                DataTable dbTable = new DataTable();
                var warehousesQuery = (from warehouse in context.Warehouses
                                      select new {کد_انبار=warehouse.ID,نام_انبار=warehouse.warehouse_name}).ToList();
                dbTable.Columns.Add("کد_انبار");
                dbTable.Columns.Add("نام_انبار");
                foreach (var item in warehousesQuery)
                {
                    dbTable.Rows.Add(item.کد_انبار, item.نام_انبار);
                }
                return dbTable;
            }
        }

        public void Save()
        {
        }
    }
}

