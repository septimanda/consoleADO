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
        public List<TB_M_Supplier> Get()
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

        public TB_M_Supplier Get(int id)
        {
            var get = myContext.TB_M_Supplier.Find(id);
            return get;
        }
        
        public bool Insert(TB_M_Supplier supplier)
        {
            myContext.TB_M_Supplier.Add(supplier);
            return go.saved();
        }


        public bool Update(int id, TB_M_Supplier supplier)
        {
            if (Get(id) != null)
            {
                Get(id).Name = supplier.Name;
                Get(id).isDelete = supplier.isDelete;
                myContext.Entry(Get(id)).State = EntityState.Modified;
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
            if (Get(id) != null)
            {
                myContext.Entry(Get(id)).State = EntityState.Deleted;
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
