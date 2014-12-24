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
using BAL;
using DAL;
namespace RedTapeWeb
{

    public partial class order_confirmation : System.Web.UI.Page
    { 
        BAOUsers objBAOUsers = new BAOUsers();
        DAOOrders objDAOOrders = new DAOOrders();
        DAOUsers objDAOUsers = new DAOUsers();
        string amount = "";
        string lblOrderID = "";
        string lblEmail = "";
        string billemail = "";
        string billing_name = "";
        string delivery_name, delivery_address, delivery_city, delivery_state, delivery_country, delivery_zip = "";
        string order_id = "";
        string tracking_id = "";
        // order confirmation page load
        protected void Page_Load(object sender, EventArgs e)
        {
            
                //Hide Inner Nav
                HtmlGenericControl divInnerNav = (HtmlGenericControl)Master.FindControl("viewpath");
                divInnerNav.Visible = false;
                if (!IsPostBack)
                {
                    try
                    {

                        CCACrypto func = new CCACrypto();
                        string WorkingKey = System.Configuration.ConfigurationManager.AppSettings["WorkingKey"];

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


                        //for (int i = 0; i < Params.Count; i++)
                        //{
                        //    Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
                        //}

                        order_id = Params["order_id"];
                        Session["order_id"] = order_id;
                        tracking_id = Params["tracking_id"];
                        string strbank_ref_no = Params["strbank_ref_no"];
                        string order_status = Params["order_status"];
                        string failure_message = Params["failure_message"];
                        string payment_mode = Params["payment_mode"];
                        string card_name = Params["card_name"];
                        string status_code = Params["status_code"];
                        string status_message = Params["status_message"];
                        string currency = Params["currency"];
                        amount = Params["amount"];
                        string merchant_param1 = Params["merchant_param1"];
                        Session["MembershipNo"] = merchant_param1;

                        //Check user login or not
                        if (Session["MembershipNo"] != null)
                        {
 
                            objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                            // getting reward points 
                            idRewardPoints.InnerHtml = objDAOUsers.userRewardPoints(objBAOUsers);
                        }

                        delivery_name = Params["delivery_name"];
                        delivery_address = Params["delivery_address"];
                        delivery_city = Params["delivery_city"];
                        delivery_state = Params["delivery_state"];
                        delivery_country = Params["delivery_country"];
                        delivery_zip = Params["delivery_zip"];
                        string delivery_tel = Params["delivery_tel"];
                        billemail = Params["billing_email"];
                        billing_name = Params["billing_name"];

                        //saving the payment params 
                        objBAOUsers.OrderIdSTR = order_id;
                        objBAOUsers.Membership_No = merchant_param1;
                        objBAOUsers.TrackingId = tracking_id;
                        objBAOUsers.firstName = card_name;
                        objBAOUsers.Checksum = "";
                        objBAOUsers.OSHIP_AMT = amount;
                        objBAOUsers.Currency = currency;
                        objBAOUsers.Status = order_status;
                        objBAOUsers.PaymentType = payment_mode;
                        objBAOUsers.BankInfo = "";
                        objBAOUsers.creationDate = DateTime.Now;
                        // go to update the payment status
                        objDAOOrders.SavePaymentParams(objBAOUsers);
                        if (order_status == "Failure")
                        {
                            Response.Redirect("order_unsuccessfull.aspx");
                        }
                        else
                        {
                            objDAOOrders.UpdateOrder(order_id);
                            // Bind the card items recards
                            DataTable dt = bindPuchasedRecords();
                          
                            ViewState["orderemailData"] = dt;
                            trackingid.InnerText = tracking_id;
                            DataTable dtUserPersonalDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[0];
                            objBAOUsers.userName = dtUserPersonalDetails.Rows[0]["FirstName"].ToString();

                            txnmsg.InnerHtml = "Dear " + objBAOUsers.userName + ",<br>We’re pleased to inform you that your <b>Order No.</b>: " + Session["order_id"] + " is confirmed.<br><br>Your ORDER SUMMARY is provided below :<br> ";
                            lbladdress.InnerHtml = delivery_name + "<br>" + delivery_address + "<br>" + delivery_city + "<br>" + delivery_state + "<br>" + delivery_country + "<br>" + delivery_zip + "<br>" + delivery_tel;
                            //emailer 
                            if (Session["redeemPoints"] != null)
                            {
                                emailConfirm(billemail, billing_name, order_id, dt, Session["redeemPoints"].ToString());
                            }
                            else
                            {
                                emailConfirm(billemail, billing_name, order_id, dt, "0");
                            }
                        }

                    }

                    catch (Exception ex)
                    {
                        Elmah.ErrorLog.GetDefault(HttpContext.Current).Log(new Elmah.Error(ex));
                      //Response.Redirect("default.aspx");
                    }
                }
            
           
        }
        decimal grantTotal = 0;
        // Bind method for card items recards
        public DataTable bindPuchasedRecords()
        {
            objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
            objBAOUsers.OrderIdSTR =order_id;
             DataTable dtGetOrderList = objDAOOrders.GetUserOrders(objBAOUsers).Tables[1];
             if (dtGetOrderList.Rows.Count > 0)
            {
                rpt_AddtocartList.DataSource = dtGetOrderList;
                rpt_AddtocartList.DataBind();
                if (Session["redeemPoints"] != null)
                    grantTotal = Convert.ToDecimal(objDAOOrders.GetUserOrders(objBAOUsers).Tables[0].Rows[0]["GrandTotal"].ToString()) - Convert.ToDecimal(Session["redeemPoints"].ToString());
                else
                {
                    lbl_totalAmount.InnerHtml = "<span>&#x20B9; </span>" + objDAOOrders.GetUserOrders(objBAOUsers).Tables[0].Rows[0]["GrandTotal"].ToString();
                }
             lbl_totalAmount.InnerHtml = "<span>&#x20B9; </span>"+grantTotal.ToString();
             }
             return dtGetOrderList;

        }


        // email method  for order confirmations
        private void emailConfirm(string mailto, string billing_name, string OID, DataTable dt, string redeemPoints)
        {
            string rewardpoints = idRewardPoints.InnerHtml;
            string emailBody = @"<table cellspacing='0' cellpadding='0' border='0' id='backgroundTable' style='border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; margin: 0; padding: 0; width: 100% !important; line-height: 100% !important;'>
	<tbody><tr>
  		<td style='border-collapse:collapse; '>
        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; margin: 0 auto; padding: 0; width: 680px !important; line-height: 100% !important;'>
      			<tbody><tr>
        			<td style='border-collapse:collapse; '>
        				<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px;  margin: 0 auto; line-height: 100%;'>
      						<tbody><tr>
                            	<td align='left' style='border-collapse: collapse; background:#000;'>
                                	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px;  margin: 0 auto; line-height: 100%;'>
      									<tbody><tr>
                                            <td align='left' style='border-collapse: collapse; background:#000; width:194px;'>                                                
												<img style='border:none; padding:25px;' src='http://www.redtape.com/mailer/redtape/ordr_confirm.png'></td>
                                            <td align='right' style='border-collapse: collapse; background:#000; width:194px;'>
                                               <a target='_blank' href='http://www.redtape.com/'><img style='border:none; padding:25px;' src='http://www.redtape.com/mailer/redtape/logo.png'></a></td>   
											</td>
                                		</tr>
                                    </tbody></table>
                                </td>
                            </tr>
                            <tr>
                            	<td>
                                	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px; border-left:6px solid #000; border-right:6px solid #000; margin: 0 auto; line-height: 100%;'>
                                    <tbody><tr>
                                    	<td style='line-height:17px; padding-left:20px; padding-top:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:15px; background:#fff; '>
                                		Dear  " + billing_name + @",<br>
                                       We are pleased to inform you that your Order No. :<span style='color:#ff0018; text-decoration:none;'> " + Session["order_id"].ToString() + @" </span>is confirmed.<div class='odrcf_page_hdng redm'>Total number of reward points available: <span id='idRewardPoints'>"+rewardpoints+@"</span></div></td>
                                    </tr>
                                    
                                    <tr>
                                    	<td style='line-height:17px; padding-left:20px; padding-top:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:15px; background:#fff; '>
                                		Your order will be delivered within 10 working days, based on your location. Your order<br> will be dispatched soon, please expect an email from us confirming the same.  </td>
                                    </tr>
                                    
                                    <tr>
                                    	<td valign='top' style='border-collapse: collapse; padding:20px 20px 0 20px;'>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                            <tbody><tr>
                                        		<td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; background:#292929; color:#fff; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:117px; font-size:13px;'>
                                        			Category
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; background:#292929; color:#fff; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:114px; font-size:13px;'>
                                        			Product
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; background:#292929; color:#fff; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:111px; font-size:13px;'>
                                        			Product Code
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; background:#292929; color:#fff; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:56px; font-size:13px;'>
                                        			Size
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; background:#292929; color:#fff; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:75px; font-size:13px;'>
                                        			Quantity
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; background:#292929; color:#fff; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:80px; font-size:13px;'>
                                        			Unit Price<br>(in INR)
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; background:#292929; color:#fff; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:73px; font-size:13px;'>
                                        			Price<br>(in INR)
                                                </td>    	
                                            </tr>";


            for (int count = 0; count <= dt.Rows.Count - 1; count++)
            {
                emailBody += @"
                                            
                                            <tr>
                                            	<td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; color:#000; border:2px solid #d6d5d5; text-align:left; padding-left:15px; width:117px; font-size:13px;'>
                                        			" + dt.Rows[count]["categoryName"].ToString().Trim() + @"
                                                </td>
                                                <td valign='middle' align='center' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; color:#000; border:2px solid #d6d5d5;  padding:15px 0;width:114px;'>
                                        			<a target='_blank' href='http://www.redtape.com/productdetails.aspx?productid=" + dt.Rows[count]["productId"].ToString().Trim() + "'><img src='http://www.redtape.com/" + dt.Rows[count]["imgUrl"].ToString().Trim().Replace(" ", "%20") + @"' style='border:none;'></a>
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; color:#000; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:111px; font-size:13px;'>
                                        			" + dt.Rows[count]["productCode"].ToString().Trim() + @"
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; color:#000; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:56px; font-size:13px;'>
                                        			" + dt.Rows[count]["sizeAttribute"].ToString().Trim() + @"
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; color:#000; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:75px; font-size:13px;'>
                                        			" + dt.Rows[count]["qty"].ToString().Trim() + @"
                                                </td>
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; color:#000; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:80px; font-size:13px;'>
                                        			" + dt.Rows[count]["Price"].ToString().Trim() + @"
                                                </td> 
                                                <td valign='middle' style='border-collapse: collapse; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; color:#000; border:2px solid #d6d5d5; text-align:center; padding:15px 0; width:73px; font-size:13px;'>
                                        			" + dt.Rows[count]["subTotal"].ToString().Trim() + @"
                                                </td>  
                                            </tr>";
            }
            
            emailBody += @"
                                            </tbody></table>
                                        </td>
                                    </tr><tr>
                                    	<td valign='top' style='border-collapse: collapse; padding:0 20px'>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                            <tbody><tr>
                                            	<td valign='middle' align='top' style='border-collapse: collapse; color:#000; border-left:2px solid #d6d5d5;  border-right:2px solid #d6d5d5; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; border-bottom:2px solid #d6d5d5; text-align:left; width:552px; padding:5px 12px; font-weight:bold; font-size:13px;'>
                                        			Total Amount (in INR)
                                                </td>
                                                <td valign='middle' align='top' style='border-collapse: collapse; color:#000; border-left:2px solid #d6d5d5;  border-right:2px solid #d6d5d5; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; border-bottom:2px solid #d6d5d5; text-align:center; width:72px; padding:5px 0; font-weight:bold; font-size:13px;'>
                                        			" + lbl_totalAmount.InnerHtml + @"
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                            	<td valign='middle' align='top' style='border-collapse: collapse; color:#000; border-left:2px solid #d6d5d5;  border-right:2px solid #d6d5d5; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; border-bottom:2px solid #d6d5d5; text-align:left; width:552px; padding:5px 12px; font-weight:bold; font-size:13px;'>
                                        			Amount Redeemed (in INR)
                                                </td>
                                                <td valign='middle' align='top' style='border-collapse: collapse; color:#000; border-left:2px solid #d6d5d5;  border-right:2px solid #d6d5d5; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; border-bottom:2px solid #d6d5d5; text-align:center; width:72px; padding:5px 0; font-weight:bold; font-size:13px;'>
                                        			" + redeemPoints + @"
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                            	<td valign='middle' align='top' style='border-collapse: collapse; color:#000; border-left:2px solid #d6d5d5;  border-right:2px solid #d6d5d5; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; border-bottom:2px solid #d6d5d5; text-align:left; width:552px; padding:5px 12px; font-weight:bold; font-size:13px;'>
                                        			Net Amount of the Invoice (in INR)
                                                </td>
                                                <td valign='middle' align='top' style='border-collapse: collapse; color:#000; border-left:2px solid #d6d5d5;  border-right:2px solid #d6d5d5; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; border-bottom:2px solid #d6d5d5; text-align:center; width:72px; padding:5px 0; font-weight:bold; font-size:13px;'>
                                        			" + grantTotal + @"
                                                </td>
                                            </tr>
                                            </tbody></table>
                                        </td>
                                    </tr>
                             		
                                    
                                    
                                    <tr>
                                    	<td valign='top' style='padding-left:20px; padding-top:25px; '>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                        		<tbody><tr>
                                                	<td style='line-height:17px; padding-bottom:30px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:15px; background:#fff; '>
                                                   Your shipping address registered with us is 

                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                	<td style='line-height:17px; padding-bottom:30px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:15px; font-weight:bold; background:#fff; '>
                                                   " + lbladdress.InnerHtml + @"                       
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                	<td style='line-height:17px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; background:#fff; '>
                                                    To contact us regarding this order or any other queries, write to us at <br>CustomerCare@redtapeindia.com or <br>
call us at 011-26950499 &amp; we will respond to you at the earliest.
                                                    </td>
                                        		</tr>
                                            </tbody></table>
                                        </td>
                                     </tr>
                                    </tbody></table>
                                </td>
                            </tr>
                            
                            
                            <tr>
                            	<td valign='top' style='border-collapse:collapse;'>
                            	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px; border-left:6px solid #000; border-right:6px solid #000; margin: 0 auto; line-height: 100%;'>
                            		
                                     <tbody><tr>
                                     	<td valign='top' style='border-collapse:collapse; width:512px;'>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                        		
                                                <tbody><tr>
                                                	<td style='line-height:17px; padding-left:20px; padding-top:50px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-style:italic; background:#fff; '><img style='border:none;' src='http://www.redtape.com/mailer/redtape/img2.png'> </td>
                                                </tr>
                                                <tr>
                                                	<td style='line-height:17px; padding-left:20px; padding-top:25px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-weight:bold; font-style:italic; background:#fff; '>
                                                    Customer Care Support will be available between<br>
                                                    10 AM - 5:30 PM from Monday to Saturday only.
                                                    </td>
                                                </tr>
                                                <tr>
                                                	<td style='line-height:17px; padding-left:20px; padding-top:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:13px; background:#fff; '>
                                                    Regards,<br>
                                                    Team Redtape
                                                    </td>
                                                </tr>
                                            </tbody></table>
                                        </td>
                                        <td valign='top' style='border-collapse:collapse; width:164px;'>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                        		<tbody><tr>
                                                	<td align='top' style='border-collapse:collapse;'>
<a href='http://www.redtape.com/lookbook.aspx'>
<img align='right' style='border:none;' alt='Shop The Look' src='http://www.redtape.com/mailer/redtape/look3.png'>
</a>
</td>
                                                </tr>
                                            </tbody></table>
                                        </td>
                                     </tr>
                               </tbody></table>
                    		</td>  
                		</tr>
                        <tr>
                        	<td align='left' style='border-collapse: collapse; background:#000;'>
                                	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px;  margin: 0 auto;'>
      									<tbody><tr>
                                            <td align='left' style='line-height:17px; padding-left:26px; padding-top:20px; padding-bottom:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:12px; color:#fff; '>
                                                    <b>MIRZA INTERNATIONAL LIMITED</b><br>
                                                    Corporate &amp; Marketing Office :<br>
                                                    A-7, Mohan Cooperative Industrial Estate,<br>
                                                    Mathura Road, New Delhi - 110076
                                            </td>
                                            <td align='right' style='border-collapse: collapse; background:#000; padding-right:26px;'>
                                            	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>	
                                                 <tbody><tr>
                                                   <td align='right' style='border-collapse: collapse; padding-right:10px;'><a target='_blank' href='https://www.facebook.com/pages/REDTAPE/143362402810'><img style='border:none;' src='http://www.redtape.com/mailer/redtape/facebook.png'></a></td>
                                                     <td align='right' style='border-collapse: collapse; padding-left:10px; border-left:1px solid #fff;'><a target='_blank' href='https://twitter.com/RedTapeindia'><img style='border:none;' src='http://www.redtape.com/mailer/redtape/twitter.png'></a></td>
                                                 </tr>
                                               </tbody></table>
                                            </td>
                                                 
                                		</tr>
                                    </tbody></table>
                                </td>
                        </tr>
            	 </tbody></table>
       		</td>
		</tr>
	</tbody></table>
   </td>
  </tr>
</tbody></table>";

            mailExchange mail = new mailExchange();
            mail.sendMyMail("sales@redtape.com", mailto, "RedTape Order Confirmation :Order No : " + OID, emailBody, "sales@redtape.com", "");

        }
        // 
        protected void lnk_btnEmail_Click(object sender, EventArgs e)
        {
            if (Session["MembershipNo"] != null)
            {

                objBAOUsers.Membership_No = Session["MembershipNo"].ToString();
                DataTable dtUserPersonalDetails = objDAOUsers.GetUserDetails(objBAOUsers).Tables[0];

                objBAOUsers.currentemail = dtUserPersonalDetails.Rows[0]["emailAddress"].ToString();
                objBAOUsers.emailAddress = objBAOUsers.currentemail;
                if (Session["redeemPoints"] != null)
                {
                    emailConfirm(objBAOUsers.currentemail, billing_name, order_id, (DataTable)ViewState["orderemailData"], Session["redeemPoints"].ToString());
                }
                else
                {
                    emailConfirm(objBAOUsers.currentemail, billing_name, order_id, (DataTable)ViewState["orderemailData"], "0");
                }
                LBLEMAILMSG.InnerText = "Email Sent Successfully.";
            }
        }



    }
}