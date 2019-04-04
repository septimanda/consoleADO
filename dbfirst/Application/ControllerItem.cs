using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    public class ControllerItem : iItem
    {
        static My_Context myContext = new My_Context();
        SaveChange go = new SaveChange(myContext);
        int supplier_id;
        bool status = false;

        public List<TB_M_Item> Get()
        {
            var get = myContext.TB_M_Item.ToList();
            Console.WriteLine("=====: <<< List >>> :=====");
            foreach (var list in get)
            {
                Console.WriteLine(list.id);
                Console.WriteLine(list.Name);
                Console.WriteLine(list.price);
                Console.WriteLine(list.stock);
                Console.WriteLine(list.TB_M_Suppliers_id);
            }
            return get;
        }

        public TB_M_Item Get(int id)
        {
            var get = myContext.TB_M_Item.Find(id);
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
                Console.WriteLine("Cant Find The ID.");
            }
            return status;
        }

        public bool Insert(TB_M_Item item)
        {
            Console.Write("Insert supplier id: ");
            supplier_id = Convert.ToInt16(Console.ReadLine());
            var getSupplier = myContext.TB_M_Supplier.Find(supplier_id);
            item.TB_M_Supplier = getSupplier;

            myContext.TB_M_Item.Add(item);
            return go.saved();
            
        }

        public bool Update(int id, TB_M_Item item)
        {
            if (Get(id) != null)
            {
                Get(id).Name = item.Name;
                Get(id).price = item.price;
                Get(id).stock = item.stock;

                Console.Write("Insert supplier id: ");
                supplier_id = Convert.ToInt16(Console.ReadLine());
                var getSupplier = myContext.TB_M_Supplier.Find(supplier_id);
                Get(id).TB_M_Supplier = getSupplier;

                myContext.Entry(Get(id)).State = EntityState.Modified;
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
