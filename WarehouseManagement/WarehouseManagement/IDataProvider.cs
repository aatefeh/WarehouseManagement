using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement
{
    public interface IDataProvider
    {
        int Order { get; }
        string LinkText { get; }
        Type EntityType { get; set; }
    }
}
