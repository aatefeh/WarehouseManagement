﻿using StoreManagement.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace StoreManagement.Model
{
    public partial class Part : IEntity
    {
        public string UnitName { get; set; }
    }

    public class PartProvider : IDataProvider
    {
        public int Order => 2;

        public string ButtonText => "کالا";

        public IEnumerable<IEntity> GetData()
        {
            using (var context = new HREntitiesStore())
            {
                return (from part in context.Parts
                        join unit in context.UnitParts
                        on part.unit_id equals unit.ID
                        select new Part
                        {
                            ID = part.ID,
                            part_name = part.part_name,
                            UnitName = unit.unit_name
                        }).ToList();
            }
        }

        public IReadOnlyCollection<ColumnInfo> GetColumns()
        {
            return new ColumnInfo[]
            {
                new ColumnInfo
                {
                    Name = nameof(Part.ID),
                    Title = "شناسه"
                },
                new ColumnInfo
                {
                    Name = nameof(Part.part_name),
                    Title = "نام کالا"
                },
                new ColumnInfo
                {
                    Name = nameof(Part.UnitName),
                    Title = "نام واحد سنجش"
                }
            };
        }

        public void Save()
        {
            //context.SaveChanges();

        }
    }
}
