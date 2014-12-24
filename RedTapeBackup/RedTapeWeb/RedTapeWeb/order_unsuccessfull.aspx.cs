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
using DAL;
using BAL;

namespace RedTapeWeb
{
    public partial class order_unsuccessfull : System.Web.UI.Page
    {
        BAOUsers objBAOUsers = new BAOUsers();
        DAOOrders objDAOOrders = new DAOOrders();   
         // Order unsuccessfull page load
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hide Inner Nav
            HtmlGenericControl divInnerNav = (HtmlGenericControl)Master.FindControl("viewpath");
            divInnerNav.Visible = false;

            try
            {
                CCACrypto func = new CCACrypto();
                string WorkingKey =System.Configuration.ConfigurationManager.AppSettings["WorkingKey"];
                                      
                CCACrypto ccaCrypto = new CCACrypto();
                string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], WorkingKey);
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
                string order_id = Params["order_id"];
                string tracking_id = Params["tracking_id"];
                string strbank_ref_no = Params["strbank_ref_no"]; 
                string order_status = Params["order_status"];
                string failure_message = Params["failure_message"]; 
                string payment_mode = Params["payment_mode"]; 
                string card_name = Params["card_name"]; 
                string status_code = Params["status_code"]; 
                string status_message = Params["status_message"]; 
                string currency = Params["currency"]; 
                string amount = Params["amount"];
                string merchant_param1 = Params["merchant_param1"];
                string billemail = Params["billing_email"];
                Session["MembershipNo"] = merchant_param1;
              
                //saving the payment params 
                objBAOUsers.OrderIdSTR=order_id;
                objBAOUsers.Membership_No=merchant_param1;
                objBAOUsers.TrackingId=tracking_id;
                objBAOUsers.firstName=card_name;
                objBAOUsers.Checksum= "";
                objBAOUsers.OSHIP_AMT=amount;
                objBAOUsers.Currency = currency;
                objBAOUsers.Status=order_status;
                objBAOUsers.PaymentType=payment_mode;
                objBAOUsers.BankInfo="";
                objBAOUsers.creationDate = DateTime.Now;

                objDAOOrders.SavePaymentParams(objBAOUsers);
            }
            catch (Exception ex)
            {
                //ex.Message.ToString();
                Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
            }
        }     
    }
}