using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAL;
using System.Data;
namespace DAL
{
    public class DAOUsers
    {
        /// <summary>
        /// SaveUsers
        /// </summary>
        /// <returns>User All Data (DataSet)</returns>
        public DataSet SaveUsers(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataset("sp_SaveUsers", objUsers.userId, objUsers.userfbId, objUsers.firstName, objUsers.lastName, objUsers.emailAddress, objUsers.password,
                                                                           objUsers.dob, objUsers.mobileNo, objUsers.telePhoneNo, objUsers.fax, objUsers.userType, objUsers.IsSubscribe);
        }
        /// <summary>
        /// UserLogin
        /// </summary>
        /// <returns>User All Data (DataSet)</returns>
        public DataSet UserLogin(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataset("sp_GetValidLoginUserDetails", objUsers.emailAddress, objUsers.password, objUsers.userfbId);
        }
        /// <summary>
        /// SaveBillingAddress
        /// </summary>
        /// <returns>BilingAddressId(INT)</returns>
        public int SaveBillingAddress(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteNonQuery("sp_SaveUserBillingDetails", objUsers.bilingAddressId, objUsers.userId, objUsers.street1, objUsers.street2, objUsers.countryId, objUsers.stateId,
                                                                                   objUsers.cityId, objUsers.pincode);
        }
        /// <summary>
        /// SaveShippingAddress
        /// </summary>
        /// <returns>ShippingAddressId(INT)</returns>
        public int SaveShippingAddress(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteNonQuery("sp_SaveUserShippingDetails", objUsers.shipAddressId, objUsers.userId, objUsers.street1, objUsers.street2, objUsers.countryId, objUsers.stateId,
                                                                                   objUsers.cityId, objUsers.pincode);
        }
        /// <summary>
        /// UpdateUserPassword
        /// </summary>
        /// <returns>Massage(Satring)</returns>
        public string UpdateUserPassword(BAOUsers objUsers)
        {
            return Convert.ToString(MsAppDataUtility.ExecuteNonQuery("sp_UpdateUserPassword", objUsers.emailAddress, objUsers.password, objUsers.newpassword));
        }
        /// <summary>
        /// CheckUseEmailAddress
        /// </summary>
        /// <returns>UserId(Table)</returns>
        public DataTable CheckUseEmailAddress(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_CheckUserEmailAddress", objUsers.emailAddress);
        }
        /// <summary>
        /// ResetUserPassword
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns>Massage(Satring)</returns>
        public string ResetUserPassword(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_ResetUserPassword", objUsers.userId, objUsers.newpassword).Rows[0][0].ToString();
        }
        /// <summary>
        /// SaveSubscribeUserDetail
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns>Massage(Satring)</returns>
        public string SaveSubscribeUserDetail(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_SaveSubscribeUserDetail", objUsers.emailAddress).Rows[0][0].ToString();
        }
        /// <summary>
        /// GetUserStatusList  1-recentview,2-addtocart,3-wishlist
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns>ListData</returns>
        public DataTable GetUserStatusList(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_GetUserStatusList", objUsers.userId, objUsers.viewType);
        }
        /// <summary>
        /// SaveUserViewProducts  0-delete,1-recentview,2-addtocart,3-wishlist
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns>ListData</returns>
        public DataTable SaveUserViewProducts(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_SaveUserViewProducts", objUsers.productId, objUsers.userId, objUsers.viewType);
        }
    }
}
