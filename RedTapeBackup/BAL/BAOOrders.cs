using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL
{
    class BAOOrders
    {
        /// <summary>
        /// Properties of Oders
        /// </summary>
        public int oderId { get; set; }
        public int userId { get; set; }
        public float totalAmount { get; set; }
        public int billingAddressId { get; set; }
        public int shippingAddressId { get; set; }
        public DateTime shipDate { get; set; }
        public int paymentType { get; set; }
        public bool paid { get; set; }
        public string transactStatus { get; set; }
        public string transactDescription { get; set; }
        public DateTime orderDate { get; set; }

        /// <summary>
        /// Properties of OrderDetail
        /// </summary>
        public int orderDetailId { get; set; }
        // public int oderId { get; set; }
        public int productId { get; set; }
        public int price { get; set; }
        public int quantity { get; set; }
        public float discount { get; set; }
        public float totalPrice { get; set; }
        public string size { get; set; }
        public int color { get; set; }
        public float weight { get; set; }

        /// <summary>
        /// Common Properties
        /// </summary>
        public int createdBy { get; set; }
        public DateTime creationDate { get; set; }
        public int modifiedBy { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}
