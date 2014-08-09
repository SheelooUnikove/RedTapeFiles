using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAL;
using System.Data;

namespace DAL
{
    class DAOOrders
    {

        public DataTable CheckUseEmailAddress(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_SHOPPINGCART", objUsers.emailAddress);
        }
       
    }
}
