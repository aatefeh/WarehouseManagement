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
        string ButtonText { get; }
        IReadOnlyCollection<IEntity> GetData();
        void SaveAction(IReadOnlyCollection<IEntity> Lists);

    }
}
