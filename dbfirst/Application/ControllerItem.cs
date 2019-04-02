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

        List<TB_M_Item> iItem.Get()
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

        TB_M_Item iItem.Get(int id)
        {
            var getby = myContext.TB_M_Item.SingleOrDefault(xo => xo.id == id);
            Console.WriteLine(getby.id);
            Console.WriteLine(getby.Name);
            Console.WriteLine(getby.price);
            Console.WriteLine(getby.stock);
            Console.WriteLine(getby.TB_M_Suppliers_id);
            return getby;
        }

        public bool Delete(int id)
        {
            var getItem = myContext.TB_M_Item.SingleOrDefault(x => x.id == id);
            if (getItem != null)
            {
                myContext.Entry(getItem).State = EntityState.Deleted;
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
            var get = myContext.TB_M_Item.Find(id);
            if (get != null)
            {
                get.Name = item.Name;
                get.price = item.price;
                get.stock = item.stock;

                Console.Write("Insert supplier id: ");
                supplier_id = Convert.ToInt16(Console.ReadLine());
                var getSupplier = myContext.TB_M_Supplier.Find(supplier_id);
                get.TB_M_Supplier = getSupplier;

                myContext.Entry(get).State = EntityState.Modified;
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
