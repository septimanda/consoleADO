using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    public class ControllerSupplier : iSupplier
    {
        static My_Context myContext = new My_Context();
        SaveChange go = new SaveChange(myContext);
        bool status = false;
        List<TB_M_Supplier> iSupplier.Get()
        {
          var get = myContext.TB_M_Supplier.ToList();
          Console.WriteLine("=====: <<< List >>> :=====");
          foreach (var list in get)
          {
              Console.WriteLine(list.id);
              Console.WriteLine(list.Name);
          }
          return get;
        }

        TB_M_Supplier iSupplier.Get(int id)
        {
            var get = myContext.TB_M_Supplier.SingleOrDefault(xo => xo.id == id);
            Console.WriteLine(get.id);
            Console.WriteLine(get.Name);
            return get;
        }
        
        public bool Insert(TB_M_Supplier supplier)
        {
            myContext.TB_M_Supplier.Add(supplier);
            return go.saved();
        }


        public bool Update(int id, TB_M_Supplier supplier)
        {
            var getSupplier = myContext.TB_M_Supplier.Find(id);
            if (getSupplier != null)
            {
                getSupplier.Name = supplier.Name;
                getSupplier.isDelete = supplier.isDelete;
                myContext.Entry(getSupplier).State = EntityState.Modified;
                return go.saved();
            }
            else
            {
                Console.WriteLine("Cant Find The ID.");
            }
            return status;
        }

        public bool Delete(int id)
        {
            var get = myContext.TB_M_Supplier.SingleOrDefault(x => x.id == id);
            if (get != null)
            {
                myContext.Entry(get).State = EntityState.Deleted;
                return go.saved();
            }
            else
            {
                Console.WriteLine("Cant Find The ID.");
            }
            return status;
        }
    }
}
