using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    class SaveChange
    {
        bool status = false;
        My_Context myContext = new My_Context();

        public SaveChange(My_Context context)
        {
            myContext = context;
        }

        public bool saved(){
            var result = myContext.SaveChanges();
            if (result > 0)
            {
                status = true;
                Console.WriteLine("Processed Successfully");
            }
            else
            {
                Console.WriteLine("Failed");
            }
            return status;
        }
    }
}
