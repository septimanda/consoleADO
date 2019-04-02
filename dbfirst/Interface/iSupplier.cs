using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    public interface iSupplier
    {
        List<TB_M_Supplier> Get();
        TB_M_Supplier Get(int id);
        bool Insert(TB_M_Supplier supplier);
        bool Update(int id, TB_M_Supplier supplier);
        bool Delete(int id);
    }
}
