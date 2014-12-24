using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAL;
using System.Data;

namespace DAL
{
   
    public class DAOOrders
    {
        BAOUsers objBAOUsers = new BAOUsers();
        /// <summary>
        /// SaveUserorderBillingShippingDetails
        /// </summary>
        /// <returns>BilingAddressId(INT)</returns>
        public int SaveUserorderBillingShippingDetails(BAOUsers objUsers)
        {
            return Convert.ToInt32(MsAppDataUtility.ExecuteDataTable("sp_SaveUserorderBillingShippingDetails", objUsers.OrderIdSTR, objUsers.S_OR_B, objUsers.Membership_No, objUsers.firstName, objUsers.lastName, objUsers.mobileNo, objUsers.emailAddress, objUsers.street1, objUsers.street2, objUsers.country, objUsers.state,
                                                                                   objUsers.city, objUsers.pincode).Rows[0][0]);
        }
        /// <summary>
        /// DeleteUserViewProducts
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns></returns>
        public int DeleteUserViewProducts(BAOUsers objUsers)
        {
            objUsers.CurrentSeesionId = System.Web.HttpContext.Current.Session["CurrentSessionId"].ToString();
            return Convert.ToInt32(MsAppDataUtility.ExecuteDataTable("sp_DeleteUserViewProducts", objUsers.Membership_No, objUsers.viewType, objUsers.CurrentSeesionId).Rows[0][0]);
        }
        /// <summary>
        /// Save payment params 
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns></returns>
        public int SavePaymentParams(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteNonQuery("sp_SavePaymentParams", objUsers.OrderIdSTR, objUsers.Membership_No, objUsers.TrackingId, objUsers.firstName, objUsers.OSHIP_AMT, objUsers.Currency, objUsers.Status, objUsers.PaymentType, objUsers.BankInfo,objUsers.creationDate);
        }
 /// <summary>
        ///update order after successfull
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns></returns>
        public int UpdateOrder(string orderid)
        {
            return MsAppDataUtility.ExecuteNonQuery("sp_UpdatePaymentStatus", orderid);
        }
        /// <summary>
        /// SaveOrderValues
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns></returns>
        public string SaveOrderValues(BAOUsers objUsers)
        {
            objUsers.CurrentSeesionId = System.Web.HttpContext.Current.Session["CurrentSessionId"].ToString();
            return (MsAppDataUtility.ExecuteDataTable("sp_SaveOrderDetails", 
                objUsers.OrderIdSTR,
                objUsers.Membership_No,
                objUsers.shipAddressId, 
                objUsers.bilingAddressId, 
                objUsers.ONET_AMT,
                objUsers.OTAX_AMT,
                objUsers.ODISCOUNT_AMT, 
                objUsers.OSHIP_DETAILS_ID,
                objUsers.RewardPoints,    //Add new
                objUsers.OPOINT_REDEEM,    //Add new
                objUsers.OCURRENCY_CODE, 
                objUsers.OEXCHANGE_RATE, 
                objUsers.Checksum,
                objUsers.AuthDesc,
                DateTime.Now,
                                                                                
                objUsers.IP,
                objUsers.ISDELETED, 
                objUsers.SHP_FLAG,
                objUsers.CurrentSeesionId).Rows[0][0]).ToString();
        }
        /// <summary>
        /// GetUserOrders
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns></returns>
        public DataSet GetUserOrders(BAOUsers objUsers)
        {
            return (MsAppDataUtility.ExecuteDataset("sp_GetUserOrders",objUsers.Membership_No,objUsers.OrderIdSTR));
        }
        /// <summary>
        /// getMaxOrderId for Make Order ID
        /// </summary>
       
        /// <returns></returns>
        public Int64  getMaxOrderId()
        {
            return Convert.ToInt64(MsAppDataUtility.ExecuteScalar("sp_GetMaxOrderId"));
        }

        
    }
}
