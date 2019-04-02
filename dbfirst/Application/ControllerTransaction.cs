using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    public class ControllerTransaction : iTransaction
    {
        static My_Context myContext = new My_Context();
        SaveChange go = new SaveChange(myContext);
        bool status = false;

        List<TB_T_TransactionDetail> iTransaction.Get()
        {
            var get = myContext.TB_T_TransactionDetail.ToList();
            Console.WriteLine("=====: <<< List >>> :=====");
            foreach (var list in get)
            {
                Console.WriteLine(list.Id);
                Console.WriteLine(list.Quantity);
                Console.WriteLine(list.TB_M_Sell_id);
                Console.WriteLine(list.TB_M_Item_id);
            }
            return get;
        }

        TB_T_TransactionDetail iTransaction.Get(int id)
        {
            var get = myContext.TB_T_TransactionDetail.SingleOrDefault(xo => xo.Id == id);
            Console.WriteLine(get.Id);
            Console.WriteLine(get.Quantity);
            Console.WriteLine(get.TB_M_Sell_id);
            Console.WriteLine(get.TB_M_Item_id);
            return get;
        }

        public bool Delete(int id)
        {
            var get = myContext.TB_T_TransactionDetail.SingleOrDefault(x => x.TB_M_Sell_id == id);
            if (get != null)
            {
                myContext.Entry(get).State = EntityState.Deleted;
                return go.saved();
            }
            else
            {
                return status;
            }
        }

        public bool Insert(TB_T_TransactionDetail TDetail)
        {
            myContext.TB_T_TransactionDetail.Add(TDetail);
            return go.saved();
        }

        public bool Update(int id, TB_T_TransactionDetail TDetail)
        {
            var get = myContext.TB_T_TransactionDetail.Find(id);
            if (get != null)
            {
                get.Quantity = TDetail.Quantity;
                get.TB_M_Item_id = TDetail.TB_M_Item_id;
                myContext.Entry(get).State = EntityState.Modified;
                return go.saved();
            }
            else
            {
                return status;
            }
        }
    }
}
