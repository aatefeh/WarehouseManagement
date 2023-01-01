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
                return (IEnumerable<IEntity>)(from unit in context.Set<UnitPart>()
                                              join part in context.Set<Part>()
                                              on unit.ID equals part.unit_id
                                              select new
                                              {
                                                  UnitID = unit.ID,
                                                  UnitName = unit.unit_name
                                              }).ToList()
                        .Select(x => new UnitPart
                        {
                            ID = x.UnitID,
                            unit_name = x.UnitName
                        });
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
