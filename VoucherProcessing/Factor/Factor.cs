using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagement;

namespace VoucherProcessing.Factor
{
    public class Factor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class FactorProvider : IDataProvider
    {
        public int Order => 4;

        public string ButtonText => "فاکتور";

        public string GetData()
        {
            using(var context = new HREntitiesVocher())
            //using (var context = new HREntities())
                //{
                //    context.factors.Add(); 

                //    context.SaveChanges();
                ////}
                string command = "select * from factor";
            return command;
        }

        public string Save()
        {
            string command = "UPDATE factor SET factor_id=@factor_id,factor_date=@factor_date,factor_type=@factor_type,customer_id=@customer_id";
            return command;
        }
    }
}
