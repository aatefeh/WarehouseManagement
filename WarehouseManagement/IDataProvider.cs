﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement
{
    public interface IDataProvider<T>
    {
        int Order { get; }
        string ButtonText { get; }
        List<T> GetData();
        void SaveAction(List<T> Lists);

    }
}
