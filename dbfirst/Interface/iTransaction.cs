using dbfirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dbfirst
{
    interface iTransaction
    {
        List<TB_T_TransactionDetail> Get();
        TB_T_TransactionDetail Get(int id);
        bool Insert(TB_T_TransactionDetail TDetail);
        bool Update(int id, TB_T_TransactionDetail TDetail);
        bool Delete(int id);
    }
}
