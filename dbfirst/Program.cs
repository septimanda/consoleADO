using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    class Program
    {
        static void Main(string[] args)
        {
            int supplier_id, item_id, sell_id, trans_id, price, stock, menu, submenu;
            string name, order;

            My_Context myContext = new My_Context();

            TB_M_Supplier supplier = new TB_M_Supplier();
            iSupplier mySupplier = new ControllerSupplier();

            TB_M_Item item = new TB_M_Item();
            iItem myItem = new ControllerItem();

            TB_M_Sell sell = new TB_M_Sell();     
            iSell mySell = new ControllerSell();

            TB_T_TransactionDetail TDetail = new TB_T_TransactionDetail();
            iTransaction myTDetail = new ControllerTransaction();

            Console.WriteLine("=====: Select Menu :=====");
            Console.WriteLine("1. Supplier.");
            Console.WriteLine("2. Item.");
            Console.WriteLine("3. Sell.");
            Console.WriteLine("Which One? ");
            Console.WriteLine();
            menu = Convert.ToInt16(Console.ReadLine());

            switch (menu)
            {
                case 1:
                    //SUPPLIER
                    Console.WriteLine("=====: Select Sub Menu :=====");
                    Console.WriteLine("1. Get All.");
                    Console.WriteLine("2. Get by Supplier Id.");
                    Console.WriteLine("3. Insert Data.");
                    Console.WriteLine("4. Update Data.");
                    Console.WriteLine("5. Delete Data.");
                    Console.WriteLine();
                    submenu = Convert.ToInt16(Console.ReadLine());

                    switch (submenu)
                    {
                        case 1:
                            //GETALL
                            mySupplier.Get();
                            break;

                        case 2:
                            //GETBYID
                            Console.WriteLine("Insert Id Supplier : ");
                            supplier_id = Convert.ToInt16(Console.ReadLine());
                            mySupplier.Get(supplier_id);
                            break;

                        case 3:
                            //INSERT
                            Console.Write("Insert your name: ");
                            name = Console.ReadLine();
                            supplier.Name = name;
                            mySupplier.Insert(supplier);
                            break;

                        case 4:
                            //UPDATE
                            Console.Write("Insert your Id : ");
                            supplier_id = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insert your name: ");
                            name = Console.ReadLine();
                            supplier.Name = name;

                            mySupplier.Update(supplier_id, supplier);
                            break;

                        case 5:
                            //DELETE
                            Console.Write("Insert your Id : ");
                            supplier_id = Convert.ToInt16(Console.ReadLine());
                            mySupplier.Delete(supplier_id);
                            break;

                        default:
                            break;
                    }
                    break;

                case 2:
                    //ITEM
                    Console.WriteLine("=====: Select Sub Menu :=====");
                    Console.WriteLine("1. Get All.");
                    Console.WriteLine("2. Get by Item Id.");
                    Console.WriteLine("3. Insert Data.");
                    Console.WriteLine("4. Update Data.");
                    Console.WriteLine("5. Delete Data.");
                    Console.WriteLine();
                    submenu = Convert.ToInt16(Console.ReadLine());

                    switch (submenu)
                    {
                        case 1:
                            //GETALL
                            myItem.Get();
                            break;

                        case 2:
                            //GETBYID
                            Console.WriteLine("Insert Id Item : ");
                            item_id = Convert.ToInt16(Console.ReadLine());
                            myItem.Get(item_id);
                            break;

                        case 3:
                            //INSERT
                            Console.Write("Insert your name: ");
                            name = Console.ReadLine();
                            Console.Write("Insert your Price: ");
                            price = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insert your stock: ");
                            stock = Convert.ToInt16(Console.ReadLine());
                            
                            item.Name = name;
                            item.price = price;
                            item.stock = stock;
                            myItem.Insert(item);
                            break;

                        case 4:
                            //UPDATE
                            Console.Write("Insert Item ID: ");
                            item_id = Convert.ToInt16(Console.ReadLine());

                            Console.Write("Insert your name: ");
                            name = Console.ReadLine();
                            Console.Write("Insert your Price: ");
                            price = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insert your stock: ");
                            stock = Convert.ToInt16(Console.ReadLine());
                            item.Name = name;
                            item.price = price;
                            item.stock = stock;

                            myItem.Update(item_id, item);
                            break;

                        case 5:
                            //DELETE
                            Console.Write("Insert your Id : ");
                            item_id = Convert.ToInt16(Console.ReadLine());
                            myItem.Delete(item_id);
                            break;

                        default:
                            break;
                    }
                    break;

                case 3:
                    
                    Console.WriteLine("=====: Select Sub Menu :=====");
                    Console.WriteLine("1. Get All.");
                    Console.WriteLine("2. Get by Sell ID.");
                    Console.WriteLine("3. Insert Data.");
                    Console.WriteLine("4. Update Data.");
                    Console.WriteLine("5. Delete Data.");
                    Console.WriteLine();
                    submenu = Convert.ToInt16(Console.ReadLine());

                    switch (submenu)
                    {
                        case 1:
                            //GETALL
                            mySell.Get();
                            break;

                        case 2:
                            //GETBYID
                            Console.WriteLine("Insert Id Sell : ");
                            sell_id = Convert.ToInt16(Console.ReadLine());
                            mySell.Get(sell_id);
                            break;

                        case 3:
                            //INSERT
                            Console.Write("Insert Order Date: ");
                            order = Console.ReadLine();
                            sell.OrderDate = DateTime.Parse(order);
                            mySell.Insert(sell);
                            
                            Console.Write("Insert Quantity: ");
                            TDetail.Quantity = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insert Item ID: ");
                            TDetail.TB_M_Item_id = Convert.ToInt16(Console.ReadLine());
                            TDetail.TB_M_Sell_id = sell.Id;
                                                        
                            myTDetail.Insert(TDetail);
                            break;

                        case 4:
                            //UPDATE
                            Console.Write("Insert Transaction ID: ");
                            trans_id = Convert.ToInt16(Console.ReadLine());

                            Console.Write("Insert New Quantity: ");
                            TDetail.Quantity = Convert.ToInt16(Console.ReadLine());
                            Console.Write("Insert New Item ID: ");
                            TDetail.TB_M_Item_id = Convert.ToInt16(Console.ReadLine());

                            myTDetail.Update(trans_id, TDetail);
                            break;

                        case 5:
                            //DELETE
                            Console.Write("Insert Sell Id : ");
                            sell_id = Convert.ToInt16(Console.ReadLine());
                            myTDetail.Delete(sell_id);

                            mySell.Delete(sell_id);                
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
            Console.Read();
        }
    }
}
