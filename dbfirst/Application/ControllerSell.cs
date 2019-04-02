using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    public class ControllerSell : iSell
    {
        static My_Context myContext = new My_Context();
        SaveChange go = new SaveChange(myContext);
        bool status = false;
        List<TB_M_Sell> iSell.Get()
        {
            var get = myContext.TB_M_Sell.ToList();
            Console.WriteLine("=====: <<< List >>> :=====");
            foreach (var list in get)
            {
                Console.WriteLine(list.Id);
                Console.WriteLine(list.OrderDate);
            }
            return get;
        }

        TB_M_Sell iSell.Get(int id)
        {
            var getby = myContext.TB_M_Sell.SingleOrDefault(xo => xo.Id == id);
            Console.WriteLine(getby.Id);
            Console.WriteLine(getby.OrderDate);
            return getby;
        }

        public bool Delete(int id)
        {
            var get = myContext.TB_M_Sell.SingleOrDefault(x => x.Id == id);
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

        public bool Insert(TB_M_Sell sell)
        {
            myContext.TB_M_Sell.Add(sell);
            return go.saved();
        }

        public bool Update(int id, TB_M_Sell sell)
        {
            var get = myContext.TB_M_Sell.Find(id);
            if (get != null)
            {
                get.OrderDate = sell.OrderDate;
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
