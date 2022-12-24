﻿using StoreManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace StoreManagement
{
    public class Warehouse : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class WarehouseProvider : IDataProvider
    {
        public int Order => 1;

        public string ButtonText => "انبار";

        public IReadOnlyCollection<IEntity> GetData()
        {
            using (var context = new HREntitiesStore())
            {
                var allWarehouse = context.warehouses.Select(x => x).ToList();
                return (IReadOnlyCollection<IEntity>)allWarehouse;
            }
        }

        public string Save()
        {
            string command = "UPDATE warehouse SET warehouse_id=@warehouse_id,warehouse_name=@warehouse_name";
            return command;
        }
    }
}
