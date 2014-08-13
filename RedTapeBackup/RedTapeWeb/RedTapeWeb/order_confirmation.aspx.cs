using System;
using System.Collections;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CCA.Util;

namespace RedTapeWeb
{
    public partial class order_confirmation : System.Web.UI.Page
    {

        string lblAmount = "";
        string lblOrderID = ""; string lblEmail = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string WorkingKey = "71BE96B739B35D89263E0DFD2C29115D";
                if (!IsPostBack)
                {
                    //string strurlrefer = Request.UrlReferrer.ToString();
                    if (Session["billing_cust_email"] != null && Session["Amount"] != null && Session["Order_Id"] != null)
                    {
                        lblAmount = "Rs. " + String.Format("{0:#,#.00}", Session["Amount"].ToString());
                        lblOrderID = "#" + Session["Order_Id"].ToString();
                        lblEmail = Session["billing_cust_email"].ToString();
                        //Session.Remove("Amount");
                        //Session.Remove("Order_Id");
                        //Session.Remove("billing_cust_email");                }
                        CCACrypto func = new CCACrypto();
                        string encResponse = func.Decrypt(Request.Form["encResponse"], WorkingKey);
                        //Response.Write(encResponse);

                        NameValueCollection Params = new NameValueCollection();
                        string[] segments = encResponse.Split('&');
                        foreach (string seg in segments)
                        {
                            string[] parts = seg.Split('=');
                            if (parts.Length > 0)
                            {
                                string Key = parts[0].Trim();
                                string Value = parts[1].Trim();
                                Params.Add(Key, Value);
                            }
                        }

                        string strVerify = func.verifychecksum(Params["Merchant_Id"].ToString(), Params["Order_Id"].ToString(), Params["Amount"].ToString(), Params["AuthDesc"].ToString(), WorkingKey, Params["Checksum"].ToString());

                        //for (int i = 0; i < Params.Count; i++)
                        //{
                        //    Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                        //}
                        //Response.Write("VerifyChecksum = " + strVerify + "<br/>");
                        if (Params["AuthDesc"].ToString() != "")
                        {
                          
                            //Update the payment status
                          //  clsobj.UpdatePaymentStatus(Params["Order_Id"].ToString(), Params["AuthDesc"].ToString(), Params[7].ToString());
                           
                            
                            if (Params["AuthDesc"].ToString() == "N")
                            {

                             
		 
                                txnmsg.InnerHtml = "<div class='clearfix'>&nbsp;</div><div class='thanks'> Dear John Doe,<br />Sorry,</div><br/><div class='thanksmsg'>A payment of <strong>" + lblAmount + "</strong> has been cancelled for the <strong>Order" + lblOrderID + "</strong>.<br>Details of your purchase along with the invoice will be mailed to your Email <strong>" + lblEmail + "</strong>.<br> We thank you for your continued support and patronage.<br/><br/><br/>Regards,<br/><strong>REDTAPE Team.</strong></div>";

                            }
                            else
                            {
                                txnmsg.InnerHtml = "<div class='clearfix'>&nbsp;</div><div class='thanks'> Dear John Doe,<br />Thanks,</div><br/><div class='thanksmsg'>We’re pleased to inform you that your <b>Order No.</b>:" + lblOrderID + "</strong>.<br>was successfully dispatched.<br /><br />Your ORDER SUMMARY is provided below :<br /> " + lblEmail + ".<br> We thank you for your continued support and patronage.<br/><br/><br/>Regards,<br/><strong>REDTAPE Team.</strong></div>";
                            }



                        }

                    }

                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
    }
}