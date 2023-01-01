using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement
{
    public interface IDataProvider
    {
        int Order { get; }
        string ButtonText { get; }
        IEnumerable<IEntity> GetData();
        //IReadOnlyCollection<ColumnInfo> GetColumns();
        void Save();

    }
}
