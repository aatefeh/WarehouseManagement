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
    public partial class UnitPart : IEntity
    {
    }

    public class UnitPartProvider : IDataProvider
    {
        public int Order => 3;

        public string ButtonText => "واحد سنجش";


        public DataTable GetData()
        {
            using (var context = new HREntitiesStore())
            {
                DataTable dbTable = new DataTable();
                var unitPartsQuery = (from unit_part in context.UnitParts
                                   join part in context.Parts on unit_part.ID equals part.unit_id
                                    select new { کد = unit_part.ID, واحد_سنجش = unit_part.unit_name }).ToList();
                dbTable.Columns.Add("کد");
                dbTable.Columns.Add("واحد_سنجش");
                foreach (var item in unitPartsQuery)
                {
                    dbTable.Rows.Add(item.کد,item.واحد_سنجش);
                }
                return dbTable;
            }
        }

        public void Save()
        {
        }
    }
}
