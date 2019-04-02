using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    interface iSell
    {
        List<TB_M_Sell> Get();
        TB_M_Sell Get(int id);
        bool Insert(TB_M_Sell sell);
        bool Update(int id, TB_M_Sell sell);
        bool Delete(int id);
    }
}
