using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagement
{
    class IEntityBusiness : IEntity
    {
        public List<object> DTList()
        {
            var ListOfData = new List<object>();
            ListOfData.Add("Atefeh");
            ListOfData.Add("Malek");
            ListOfData.Add(1);
            return ListOfData;
        }
        public List<object> DataList { get => DTList() }
    }
}
