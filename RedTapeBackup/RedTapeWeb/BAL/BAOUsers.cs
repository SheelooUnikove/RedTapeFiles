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
        public int rewardPoints { get; set; }
        /// <summary>
        /// payemnt Properties
        /// </summary>
        public string TrackingId { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
        public string BankInfo { get; set; }
        public string Currency { get; set; }

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
        //public string orderID { get; set; }
        public string @S_OR_B { get; set; }
        /// <summary>
        /// Properties of UserProductsView
        /// </summary>
        public int viewId { get; set; }
        public int productId { get; set; }
        public int attrId { get; set; }
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
        public string OrderIdSTR { get; set; }     
        public int OrderId { get; set; }     
        public string ONET_AMT { get; set; }
        public string OTAX_AMT { get; set; }
        public string ODISCOUNT_AMT { get; set; }
        public int OSHIP_DETAILS_ID { get; set; }
        public int RewardPoints { get; set; }
        public int OPOINT_REDEEM { get; set; }
        public int OPOINT_VALUE { get; set; }
        //public string OPOINT_REDEEM_AMT { get; set; }
        public string OSHIP_AMT { get; set; }
        public string OCURRENCY_CODE { get; set; }
        public string OEXCHANGE_RATE { get; set; }
        public string Checksum { get; set; }
        //public string CheckSumPayment { get; set; }
        public string AuthDesc { get; set; }
        //public string newChecksum { get; set; }
        public DateTime DATETIME { get; set; }
        public string IP { get; set; }
        public int ISDELETED { get; set; }
        public int SHP_FLAG { get; set; }





        
        public  string userName { get; set; }
        public  string currentemail { get; set; }
        public  int WishListCount { get; set; }
        public  int CartCount { get; set; }
        public  string  currentUserType { get; set; }
        public  string CurrentSeesionId { get; set; }
    }
}
