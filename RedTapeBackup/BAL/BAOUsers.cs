using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL
{
    public class BAOUsers
    {
        /// <summary>
        /// Properties of UserDetails
        /// </summary>
        public int userId { get; set; }
        public string Membership_No { get; set; }
        public string userfbId { get; set; }// Facebook userid
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string emailAddress { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
        public string newpassword { get; set; }
        public DateTime dob { get; set; }
        public string mobileNo { get; set; }
        public string telePhoneNo { get; set; }
        public string fax { get; set; }
        // public bool active { get; set; }
        public string userType { get; set; }
        public bool IsSubscribe { get; set; } // 0-no,1-yes
        /// <summary>
        /// Common Properties
        /// </summary>
        public int createdBy { get; set; }
        public DateTime creationDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }

        /// <summary>
        /// Properties of UserBillingDetails
        /// </summary>
        public int bilingAddressId { get; set; }
        public string street1 { get; set; }
        public string street2 { get; set; }
        public string country { get; set; }
        public string  state { get; set; }
        public string city { get; set; }
        public string pincode { get; set; }
       
        /// <summary>
        /// Properties of UserShippingDetails
        /// </summary>
        public int shipAddressId { get; set; }

        /// <summary>
        /// Properties of UserProductsView
        /// </summary>
        public int viewId { get; set; }
        public int productId { get; set; }
        public int viewType { get; set; } // 0- Delete,1- RecentView,2- Add To Cart,3- WishList
        public int qty { get; set; }

        /// <summary>
        /// Properties of SubscribeUsers
        /// </summary>
        public int newsletterId { get; set; }
        public DateTime subscribeDate { get; set; }
        public DateTime subscribeEndDate { get; set; }


        /// <summary>
        ///  Properties of ShoppingCart
        /// </summary>

        public string parm { get; set; }
        public int SelectProductID { get; set; }
        public string  SessionId { get; set; }
        public int SHP_PROD_ID { get; set; }
        public int SHP_PROD_CAT_ID { get; set; }
        public int SHP_PROD_SUB_CAT_ID { get; set; }
        //public string PROD_TABALE_NAME { get; set; }
        public string SHP_PROD_CODE { get; set; }
        public string SHP_PROD_NAME { get; set; }
        public float SHP_PROD_DISC_PRICE { get; set; }
        public string SHP_PROD_ACTULE_PRICE { get; set; }
        public string SHP_PROD_TAX { get; set; }
        public int SHP_PROD_PERCENT { get; set; }
        public int SHP_PROD_QTY { get; set; }
        public string SHP_PROD_SIZE { get; set; }
        public string SHP_PROD_IMG { get; set; }
        public string SHP_PROD_DESC { get; set; }
        public string PROD_DETAIL_URL { get; set; }
        public string SHP_FLAG { get; set; }
        public string UserIP { get; set; }

        
        public static string userName { get; set; }
        public static string currentemail { get; set; }
        public static int WishListCount { get; set; }
        public static int CartCount { get; set; }
        public static string  currentUserType { get; set; }
    }
}
