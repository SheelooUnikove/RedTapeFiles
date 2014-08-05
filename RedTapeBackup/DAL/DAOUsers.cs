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
            return MsAppDataUtility.ExecuteDataset("sp_SaveUsers", objUsers.userId, objUsers.userfbId, objUsers.firstName, objUsers.lastName,objUsers.gender, objUsers.emailAddress, objUsers.password,
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
        /// GetUserDetails
        /// </summary>
        /// <returns>User All Data (DataSet)</returns>
        public DataSet GetUserDetails(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataset("sp_GetUserDetails", objUsers.userId);
        }
        /// <summary>
        /// SaveBillingAddress
        /// </summary>
        /// <returns>BilingAddressId(INT)</returns>
        public int SaveBillingAddress(BAOUsers objUsers)
        {
            return Convert.ToInt32(MsAppDataUtility.ExecuteDataTable("sp_SaveUserBillingDetails", objUsers.bilingAddressId, objUsers.userId, objUsers.street1, objUsers.street2, objUsers.countryId, objUsers.stateId,
                                                                                   objUsers.cityId, objUsers.pincode).Rows[0][0]);
        }
        /// <summary>
        /// SaveShippingAddress
        /// </summary>
        /// <returns>ShippingAddressId(INT)</returns>
        public int SaveShippingAddress(BAOUsers objUsers)
        {
            return Convert.ToInt32(MsAppDataUtility.ExecuteDataTable("sp_SaveUserShippingDetails", objUsers.shipAddressId, objUsers.userId, objUsers.street1, objUsers.street2, objUsers.countryId, objUsers.stateId,
                                                                                   objUsers.cityId, objUsers.pincode).Rows[0][0]);
        }
        /// <summary>
        /// UpdateUserPassword
        /// </summary>
        /// <returns>Massage(Satring)</returns>
        public string UpdateUserPassword(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_UpdateUserPassword", objUsers.userId, objUsers.password, objUsers.newpassword).Rows[0][0].ToString();
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
        /// <summary>
        /// GetCountryList
        /// </summary>
        /// <returns>ListData</returns>
        public DataTable GetCountryList(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_GetCountries");
        }
        /// <summary>
        /// GetStates
        /// </summary>
        /// <returns>ListData</returns>
        public DataTable GetStates(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_GetStates",objUsers.countryId);
        }
        /// <summary>
        /// GetCities
        /// </summary>
        /// <returns>ListData</returns>
        public DataTable GetCities(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_GetCities", objUsers.countryId);
        }


    }
}
