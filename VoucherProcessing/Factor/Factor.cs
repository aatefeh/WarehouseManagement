using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using VoucherProcessing.Model;
using WarehouseManagement;

namespace VoucherProcessing.Model
{
    public partial class Factor : IEntity
    {
    }

    public class FactorProvider : IDataProvider
    {
        public int Order => 4;

        public string ButtonText => "فاکتور";

        public IEnumerable<IEntity> GetData()
        {

            using (var Context = new HREntitiesVoucher())
            {
                var allFactors = Context.factors.ToList();
                //var list = new List<factor>();
                //foreach (var factor in allFactors)
                //{
                //    list.Add(factor);
                //}
                return (IEnumerable<IEntity>)allFactors;
            }
        }

        public string Save()
        {
            string a = "dsssd";
            return a;
        //    var changes = dbContext.GetChangeSet();
        //    dbContext.SubmitChanges();
        }
    }
}
