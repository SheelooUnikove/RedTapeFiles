using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BAL;
using System.Data;
using System.Security.Cryptography;
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
            if (objUsers.Membership_No == "0")
            {
                string salt = iStrat.RandomString(20);
                objUsers.salt = salt;
                objUsers.password = encPwd(objUsers.password, salt);
            }
            return MsAppDataUtility.ExecuteDataset("sp_SaveUsers", objUsers.Membership_No, objUsers.userfbId, objUsers.firstName, objUsers.lastName,objUsers.gender, objUsers.emailAddress, objUsers.password,objUsers.salt,
                                                                           objUsers.dob, objUsers.mobileNo, objUsers.telePhoneNo, objUsers.fax, objUsers.userType, objUsers.IsSubscribe);
        }

        private string encPwd(string password, string salt)
        {
            return iStrat.EncodePassword(password, salt);
        }
        public bool chkPwd(string password, string salt, string SQLPwd)
        {
            if (SQLPwd == encPwd(password, salt))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// UserLogin
        /// </summary>
        /// <returns>User All Data (DataSet)</returns>
        public DataSet UserLogin(BAOUsers objUsers)
        {           
            return MsAppDataUtility.ExecuteDataset("sp_GetValidLoginUserDetails", objUsers.emailAddress);
        }
        public DataSet FBLogin(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataset("sp_FBLogin", objUsers.userfbId,objUsers.firstName,objUsers.lastName,objUsers.emailAddress,objUsers.gender);
        }
        /// <summary>
        /// GetUserDetails
        /// </summary>
        /// <returns>User All Data (DataSet)</returns>
        public DataSet GetUserDetails(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataset("sp_GetUserDetails", objUsers.Membership_No);
        }
        /// <summary>
        /// SaveBillingAddress
        /// </summary>
        /// <returns>BilingAddressId(INT)</returns>
        public int SaveBillingAddress(BAOUsers objUsers)
        {
            return Convert.ToInt32(MsAppDataUtility.ExecuteDataTable("sp_SaveUserBillingDetails", objUsers.bilingAddressId, objUsers.Membership_No, objUsers.firstName, objUsers.lastName, objUsers.mobileNo, objUsers.emailAddress, objUsers.street1, objUsers.street2, objUsers.country, objUsers.state,
                                                                                   objUsers.city, objUsers.pincode).Rows[0][0]);
        }
        /// <summary>
        /// SaveShippingAddress
        /// </summary>
        /// <returns>ShippingAddressId(INT)</returns>
        public int SaveShippingAddress(BAOUsers objUsers)
        {
            return Convert.ToInt32(MsAppDataUtility.ExecuteDataTable("sp_SaveUserShippingDetails", objUsers.shipAddressId, objUsers.Membership_No, objUsers.firstName,objUsers.lastName,objUsers.mobileNo,objUsers.emailAddress,objUsers.street1, objUsers.street2, objUsers.country, objUsers.state,
                                                                                   objUsers.city, objUsers.pincode).Rows[0][0]);
        }
        /// <summary>
        /// UpdateUserPassword
        /// </summary>
        /// <returns>Massage(Satring)</returns>
        public string UpdateUserPassword(BAOUsers objUsers)
        {
            string salt = iStrat.RandomString(20);
            objUsers.salt = salt;
            objUsers.newpassword = encPwd(objUsers.newpassword, salt);
            return MsAppDataUtility.ExecuteDataTable("sp_UpdateUserPassword", objUsers.Membership_No, objUsers.newpassword, objUsers.salt).Rows[0][0].ToString();
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
            return MsAppDataUtility.ExecuteDataTable("sp_ResetUserPassword", objUsers.Membership_No, objUsers.newpassword).Rows[0][0].ToString();
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
            return MsAppDataUtility.ExecuteDataTable("sp_GetUserStatusList", objUsers.Membership_No, objUsers.viewType,objUsers.SessionId);
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
            return MsAppDataUtility.ExecuteDataTable("sp_GetStates",objUsers.country);
        }
        /// <summary>
        /// GetCities
        /// </summary>
        /// <returns>ListData</returns>
        public DataTable GetCities(BAOUsers objUsers)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_GetCities", objUsers.country);
        }
        /// <summary>
        /// SaveUserViewProducts
        /// </summary>
        /// <param name="objUsers"></param>
        /// <returns></returns>
        public int SaveUserViewProducts(int productid, string  MembershipId, int viewType, int qty)
        {
            return Convert.ToInt32(MsAppDataUtility.ExecuteDataTable("sp_SaveUserViewProducts", productid, MembershipId, viewType, qty).Rows[0][0]);
        }       

    }
}
