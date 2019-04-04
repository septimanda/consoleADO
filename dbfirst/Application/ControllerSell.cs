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
        public List<TB_M_Sell> Get()
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

        public TB_M_Sell Get(int id)
        {
            var get = myContext.TB_M_Sell.SingleOrDefault(xo => xo.Id == id);
            return get;
        }

        public bool Delete(int id)
        {
            if (Get(id) != null)
            {
                myContext.Entry(Get(id)).State = EntityState.Deleted;
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
            if (Get(id) != null)
            {
                Get(id).OrderDate = sell.OrderDate;
                myContext.Entry(Get(id)).State = EntityState.Modified;
                return go.saved();
            }
            else
            {
                return status;
            }
        }

        
    }
}
