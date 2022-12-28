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


        public IEnumerable<IEntity> GetData()
        {
            using (var context = new HREntitiesStore())
            {
                return (from unit in context.UnitParts
                        join part in context.Parts on unit.ID equals part.unit_id
                        select new UnitPart
                        {
                            ID = unit.ID,
                            unit_name = unit.unit_name
                        }).ToList();
            }
        }

        public IReadOnlyCollection<ColumnInfo> GetColumns()
        {
            return new ColumnInfo[]
            {
                new ColumnInfo
                {
                    Name = nameof(UnitPart.ID),
                    Title = "شناسه"
                },
                new ColumnInfo
                {
                    Name = nameof(UnitPart.unit_name),
                    Title = "نام واحد سنجش"
                }
            };
        }
        public void Save()
        {
        }
    }
}
