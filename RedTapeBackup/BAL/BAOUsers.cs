using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL
{
  public  class BAOUsers
    {
        /// <summary>
        /// Properties of UserDetails
        /// </summary>
        public int userId { get; set; }
        public string userfbId { get; set; }// Facebook userid
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailAddress { get; set; }
        public string password { get; set; }
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
        public int countryId { get; set; }
        public int stateId { get; set; }
        public int cityId { get; set; }
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


        /// <summary>
        /// Properties of SubscribeUsers
        /// </summary>
        public int newsletterId { get; set; }
        public DateTime subscribeDate { get; set; }
        public DateTime subscribeEndDate { get; set; }

    }
}
