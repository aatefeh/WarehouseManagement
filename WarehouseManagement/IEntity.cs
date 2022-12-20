using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement
{
    public interface IEntity
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
