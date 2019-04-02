using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    public interface iItem
    {
        List<TB_M_Item> Get();
        TB_M_Item Get(int id);
        bool Insert(TB_M_Item item);
        bool Update(int id, TB_M_Item item);
        bool Delete(int id);
    }
}
