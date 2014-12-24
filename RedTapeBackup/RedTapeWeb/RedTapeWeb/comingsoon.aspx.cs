using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedTapeWeb
{
    public partial class comingsoon : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

         /*   string Order_Id = DateTime.Now.Date.ToString("ddyy") + DateTime.Now.Hour.ToString() + DateTime.Now.Second.ToString();
            Response.Write(Order_Id);
            Response.Write("<br />");
            Response.Write(DateTime.Now.Hour.ToString());
            Response.Write("<br />");
            Response.Write(DateTime.Now.Second.ToString()); */

            BAOUsers objBAOUsers = new BAOUsers();
            DAOOrders objDAOOrders = new DAOOrders();
            DAOUsers objDAOUsers = new DAOUsers();

            objBAOUsers.Membership_No = "897299353"; //Session["MembershipNo"].ToString();
            objBAOUsers.OrderIdSTR = "12141735";
            Session["order_id"] = objBAOUsers.OrderIdSTR;
            DataTable dtGetOrderList = objDAOOrders.GetUserOrders(objBAOUsers).Tables[1];
            emailConfirm("arjun.pershad@please-see.com","Bharat Kumar",objBAOUsers.OrderIdSTR,dtGetOrderList);
           

           // Shirts();

           
        }

        private void emailConfirm(string mailto, string billing_name, string OID, DataTable dt)
        {
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
                                       We are pleased to inform you that your Order No. :<span style='color:#ff0018; text-decoration:none;'> " + Session["order_id"].ToString() + @" </span>is confirmed.</td>
                                    </tr>
                                    
                                    <tr>
                                    	<td style='line-height:17px; padding-left:20px; padding-top:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:15px; background:#fff; '>
                                		Your order will be delivered within 10 working days, based on your location. Your order<br> will be dispatched soon, please expect an email from us confirming the same.  </td>
                                    </tr>
                                    
                                    <tr>
                                    	<td valign='top' style='border-collapse: collapse; padding:20px 20px 0 20px;'>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                            <tbody>
                                              <tr>
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
                                        			M/40
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
                                        			0
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                            	<td valign='middle' align='top' style='border-collapse: collapse; color:#000; border-left:2px solid #d6d5d5;  border-right:2px solid #d6d5d5; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; border-bottom:2px solid #d6d5d5; text-align:left; width:552px; padding:5px 12px; font-weight:bold; font-size:13px;'>
                                        			Net Amount of the Invoice (in INR)
                                                </td>
                                                <td valign='middle' align='top' style='border-collapse: collapse; color:#000; border-left:2px solid #d6d5d5;  border-right:2px solid #d6d5d5; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; border-bottom:2px solid #d6d5d5; text-align:center; width:72px; padding:5px 0; font-weight:bold; font-size:13px;'>
                                        			" + lbl_totalAmount.InnerHtml + @"
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
                                                   " + lbl_Address.InnerText + @"                       
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
                                                	<td align='top' style='border-collapse:collapse;'><img align='right' style='border:none;' alt='Shop The Look' src='http://www.redtape.com/mailer/redtape/look3.png'></td>
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

        private void emailConfirm333(string mailto, string billing_name, string OID, DataTable dt)
        {
            string emailBody = @"<table width='700' border='0' align='center' cellpadding='0' cellspacing='0'>  
        <tr>
        <td height='400' align='left' valign='top' bgcolor='#D7182A'><table width='668' border='0' align='center' cellpadding='0' cellspacing='0'>
        <TR>
          <TD align='left' valign='top' bgColor=#ffffff><a href='http://www.redtape.com/' target='_blank'><img src='http://redtape.com/mailer/images/top-header.jpg' width='668' height='96' border='none' /></a></TD>
        </TR>
        <tr>
        <td align='left' valign='top' bgcolor='#FFFFFF' style='padding-left:10px; font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'>Dear " + billing_name + @",<br />
          We’re pleased to inform you that your Order No. :<span style='color:#ff0018; text-decoration:none;'> " + OID + @" </span>is confirmed.<br />
          <br />Your order will be delivered within 10 working days, based on your location. Your order will be dispatched soon, please expect an email from us confirming the same. <br/><br/>
          <span style='font-weight:bold; color:#ff0018; text-decoration:none;'>Your ORDER SUMMARY is provided below :</span> 
          <br /><br />
          <table width='650' border='0' cellspacing='0' cellpadding='0'>
            <tr>
              <td bgcolor='#c9c7c7'><table width='100%' border='0' cellspacing='1' cellpadding='5'>
                <tr>
                  <td width='19%' height='45' align='left' bgcolor='#292929' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; color:#FFFFFF;'>Product</td>
          
            
            <td width='12%' align='center' bgcolor='#292929' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; color:#FFFFFF;'>Quantity Ordered</td>
            <td width='15%' align='center' bgcolor='#292929' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; color:#FFFFFF;'>Unit Price <br />
              (in INR) </td>
            
            <td width='12%' align='center' bgcolor='#292929' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; font-weight:bold; color:#FFFFFF;'>Price<br /> 
              (in INR)</td>
          </tr>";


            for (int count = 0; count <= dt.Rows.Count - 1; count++)
            {
                emailBody += @"<tr>
                  <td bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'>" + dt.Rows[count]["productName"].ToString().Trim() + @"</td>
            
            <td align='center' bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'>" + dt.Rows[count]["qty"].ToString().Trim() + @"</td>
            
            <td align='center' bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'>" + dt.Rows[count]["Price"].ToString().Trim() + @"</td>
            
            <td align='center' bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'>" + dt.Rows[count]["subTotal"].ToString().Trim() + @"</td>
          </tr>";
            }
            emailBody += @"<tr>
                  <td colspan='6' bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'><b>Total Amount (in INR) </b></td>
            <td align='center' bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'><b>" + "2640" + @"</b></td>
          </tr>
                <tr>
                  <td colspan='6' bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'><b>Amount Redeemed (in INR) </b></td>
            <td align='center' bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'><b>0</b></td>
          </tr>
                <tr>
                  <td colspan='6' bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'><b>Net Amount of the Invoice (in INR) </b></td>
            <td align='center' bgcolor='#FFFFFF' style='font-family:Arial, Helvetica, sans-serif; font-size:12px; line-height:17px;'><b>" + "2640" + @"</b></td>
          </tr>";
            emailBody += @"</table></td>
        </tr>
            </table>
            <br /><a href='http://www.redtape.com/shopthelook.aspx' target='_blank'><IMG align=right src='http://redtape.com/mailer/images/pic-img.jpg' border='none'></a>
        <b>Your shipping address registered with us is </b><br />
        <br />" + "F344/2 Second Floor, Lado Sarai" + @"                       
        <br /><br />
        To contact us regarding this order or any other queries, write to us at <a href='mailto:CustomerCare@redtapeindia.com' style='color:#ff0018; text-decoration:none;'>CustomerCare@redtapeindia.com</a> or <br />
        call us at <span style='color:#ff0018; text-decoration:none;'>011-26950499</span> &amp; we will respond to you at the earliest.
        <br /><br />
        <b>Customer Care Support will be available  between <br />
        10:00 AM - 5:30 PM from Monday to Saturday only.</b><br />
        <br />
        <A class=ecxredtext 
            href='http://www.redtape.com/' target=_blank><IMG 
            style='BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none' 
            align=right 
            src='http://redtape.com/mailer/images/bottom-logo.jpg' border='none'></A>
        Regards,<br />
        Team Redtape  
        <br /><br />
        Log on to, <a href='http://www.redtape.com/' target='_blank' style='color:#ff0018; text-decoration:none;'>www.redtape.com</a><br />

        
</td>
        </tr>
        </table></td>
        </tr>
        <tr>
            <td align='left' valign='top' bgcolor='#d7182a'><img src='http://redtape.com/mailer/images/bottom-img.jpg' width='700' height='38' /></td>
        </tr>
        <tr>
            <td height='83' align='left' valign='top' bgcolor='#d7182a'><TABLE border=0 cellSpacing=0 cellPadding=0 width=650 align=center>
            <TBODY>
        <TR>
          <TD colSpan=2>&nbsp;</TD></TR>
        <TR>
          <TD 
          style='FONT-FAMILY: Arial, Helvetica, sans-serif; COLOR: #ffffff; FONT-SIZE: 12px; FONT-WEIGHT: bold' 
          class=ecxtextwhite width=393 align=left><b>MIRZA INTERNATIONAL 
            LIMITED</b><BR>Corporate &amp; Marketing Office :<BR>A-7, Mohan 
            Cooperative Industrial Estate,<BR>Mathura Road, New Delhi - 
            110076</TD>
          <TD vAlign=top width=257 align=right><A 
            href='http://www.facebook.com/#%21/pages/REDTAPE/143362402810' 
            target=_blank><IMG 
            style='BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-TOP-STYLE: none; BORDER-LEFT-STYLE: none' 
            src='http://redtape.com/mailer/images/facebook.jpg' width=20 
            height=19></A></TD></TR>
        <TR>
        <TD colSpan=2>&nbsp;</TD></TR></TBODY></TABLE></td>
        </tr>
    <tr>
<td><div style='font:normal 11px Arial, Helvetica, sans-serif; color:Gray; padding:5px 5px 5px 15px;'>
          	    *****Product image are considered illustrative and indicative only. Actual product 
                  may differ to some extent. We have made every effort to display the colours of 
                  the products that appear on the Site as accurately as possible. However, as the 
                  actual colours you see will depend on your monitor, we cannot guarantee that 
                  your monitor&#39;s display of any colours will be accurate.
          	</div></td>
</tr>
        </table>";


            mailExchange mail = new mailExchange();
            mail.sendMyMail("sales@redtape.com", mailto, "Redtape : order No : " + OID, emailBody, "sales@redtape.com", "");

        }





        protected void Shirts()
        {
            /*
           
            String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
      + "Data Source=C:\\Users\\bharat\\Documents\\Book.xlsx;"
      + "Extended Properties='Excel 8.0;HDR=Yes'";

            System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
            System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
            cmdExcel.Connection = connExcel;

            connExcel.Open();
            System.Data.DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            connExcel.Close();

            System.Data.DataSet ds = new System.Data.DataSet();
            string SheetName = dtExcelSchema.Rows[6]["TABLE_NAME"].ToString();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            System.Data.OleDb.OleDbDataAdapter da;
            da = new System.Data.OleDb.OleDbDataAdapter();
            da.SelectCommand = cmdExcel;
            da.Fill(ds);

            List<String> insertStringStatements = new List<string>();
            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                string productCode = dr["Item Name"].ToString();

                string MRP = dr["MRP"].ToString();
                string colour = dr["Colour"].ToString();
                int isAvailable = 0;
                if (dr["Available"].ToString().Trim() == "YES")
                {
                    isAvailable = 1;
                }
                string insertString = "";
                insertString = String.Format("INSERT INTO tblProducts(categoryId, ProductCode, MSRP, offerId, colour, IsAvailable, IsNewArrival, isVisible, isDeleted) VALUES ({0},'{1}',{2},{3},'{4}',{5},1,1,0)", 29, productCode, MRP, 1111, colour, isAvailable);
                insertStringStatements.Add(insertString);


                string strSQL = string.Format("Select * From tblProducts where categoryId=29 and ProductCode like '%{0}%'", productCode);
                //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                    // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                    using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string prodId = reader["productId"].ToString();
                            string updateString = "";
                            updateString = String.Format("UPDATE tblProducts SET isAvailable={0}, MSRP={1}, colour='{2}' ,offerId={4}, isNewArrival={5}, isVisible={6}, isDeleted=0 WHERE productId={3};", isAvailable, MRP, colour, prodId, 1111, 1, 1);
                            insertStringStatements.Add(updateString);
                            //insertStringStatements.Add(prodId);
                        }
                    }
                }

            }
            foreach (string s in insertStringStatements)
            {
                Response.Write(s);
                Response.Write("<br/>");
            }
            
          
             
            */
            

            /*
            
            String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
            + "Data Source=C:\\Users\\bharat\\Documents\\Book.xlsx;"
            + "Extended Properties='Excel 8.0;HDR=Yes'";

            System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
            System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
            cmdExcel.Connection = connExcel;

            connExcel.Open();
            System.Data.DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            connExcel.Close();

            System.Data.DataSet ds = new System.Data.DataSet();
            string SheetName = dtExcelSchema.Rows[6]["TABLE_NAME"].ToString();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            System.Data.OleDb.OleDbDataAdapter da;
            da = new System.Data.OleDb.OleDbDataAdapter();
            da.SelectCommand = cmdExcel;
            da.Fill(ds);

            List<String> insertStringStatements = new List<string>();
            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                string codeName = dr["Item Name"].ToString();

                string strSQL = string.Format("Select * From tblProducts where categoryId=29 and ProductCode like '%{0}%' and isVisible=1 and isDeleted=0", codeName);
                //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                    // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                    using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string prodId = reader["productId"].ToString();
                            string attrValue = "";
                            int attrId = 0;
                            int isAvailableFor = 1;
                            string insertString = "";

                            for (int i = 0; i < dr.ItemArray.Count(); i++)
                            {

                                switch (i)
                                {
                                    case 5:
                                        attrId = 1;
                                        string[] sizes = dr.ItemArray[i].ToString().Split(',');
                                        foreach (string sz in sizes)
                                        {
                                            insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, sz.Trim(), isAvailableFor);
                                            insertStringStatements.Add(insertString);
                                        }
                                        break;
                                    case 2:
                                        attrId = 2;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    case 4:
                                        attrId = 3;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    case 13:
                                        attrId = 5;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    case 14:
                                        attrId = 8;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    case 15:
                                        attrId = 9;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    case 16:
                                        attrId = 10;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    case 17:
                                        attrId = 12;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);

                                        break;
                                    case 18:
                                        attrId = 13;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                }

                            }



                        }
                    }

                }


            }
            foreach (string s in insertStringStatements)
            {
                Response.Write(s);
                Response.Write("<br/>");
            }
            
             */
             
            
            
            string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("~/images/products/SWEATERS"), "*", System.IO.SearchOption.AllDirectories);

            List<String> insertStringStatements = new List<string>(filesindirectory.Count());

            string tempProdId = "";
            int tempImageTypeId = 0;
            int seq = 1;

            foreach (string item in filesindirectory)
            {
                System.IO.DirectoryInfo myDirectory = new System.IO.DirectoryInfo(item);
                string sizeName = myDirectory.Parent.Name;
                string codeName = myDirectory.Parent.Parent.Name;
                //images.Add(String.Format("images/products/JACKETS/{1}/{2}/{0}", System.IO.Path.GetFileName(item), codeName, sizeName));
                string imagePath = String.Format("images/products/SWEATERS/{1}/{2}/{0}", System.IO.Path.GetFileName(item), codeName, sizeName);

                int imageTypeId = 0;

                switch (sizeName.ToLower())
                {
                    case "87x98":
                        imageTypeId = 1;
                        break;
                    case "123x139":
                        imageTypeId = 2;
                        break;
                    case "226x259":
                        imageTypeId = 3;
                        break;
                    case "276x242":
                        imageTypeId = 4;
                        break;
                    case "320x165":
                        imageTypeId = 5;
                        break;
                    case "308x353":
                        imageTypeId = 7;
                        break;
                    case "600x902":
                        imageTypeId = 6;
                        break;

                }



               // codeName = codeName.Substring(3, codeName.Length - 3);
                //codeName = codeName.Replace(" ", string.Empty);



                string strSQL = string.Format("Select * From tblProducts where categoryId=29 and isVisible=1 and ProductCode like '%{0}%'", codeName);
                //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                    // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                    using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string prodId = reader["productId"].ToString();
                            if (prodId == tempProdId && imageTypeId == tempImageTypeId)
                            {
                                seq++;
                            }
                            else
                            {
                                seq = 1;
                                tempProdId = "";
                                tempImageTypeId = 0;
                            }
                            string insertString = String.Format("INSERT INTO tblProductImages(productId, imgUrl, ImageTypeId, seqOrder) VALUES ({0},'{1}',{2},{3});", prodId, imagePath, imageTypeId, seq);

                            insertStringStatements.Add(insertString);
                            tempProdId = prodId;
                            tempImageTypeId = imageTypeId;


                        }
                    }

                }
                //cnn.Open();


            }

            foreach (string s in insertStringStatements)
            {
                Response.Write(s);
                Response.Write("<br/>");
            }
             
             
             
             
             
             
        }






        protected void PairUP()
        {
            
          /*  String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
+ "Data Source=C:\\Users\\bharat\\Documents\\SHOES.xlsx;"
+ "Extended Properties='Excel 8.0;HDR=Yes'";

            System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
            System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
            cmdExcel.Connection = connExcel;

            connExcel.Open();
            System.Data.DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            connExcel.Close();

            System.Data.DataSet ds = new System.Data.DataSet();
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            System.Data.OleDb.OleDbDataAdapter da;
            da = new System.Data.OleDb.OleDbDataAdapter();
            da.SelectCommand = cmdExcel;
            da.Fill(ds);

            List<String> insertStringStatements = new List<string>();
            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                string productCode = dr["LINE NO"].ToString().Replace(" ", string.Empty);
                //productCode = productCode.Substring(0, 7);

                string strSQL = string.Format("Select * From tblProducts where categoryId=10 and isVisible=1 and isDeleted=0 and ProductCode like '%{0}%'", productCode);
                //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                    // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                    using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string prodId = reader["productId"].ToString();
                            string prodPairedId = "";
                            
                            string productCode2 = dr["P1"].ToString().Replace(" ",string.Empty);
                            string strSQL2 = string.Format("Select * From tblProducts where isDeleted=0 and ProductCode like '%{0}%'", productCode2);
                            //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                            string ConnectionString2 = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                            using (System.Data.SqlClient.SqlConnection cnn2 = new System.Data.SqlClient.SqlConnection(ConnectionString2))
                            {
                                cnn2.Open();
                                System.Data.SqlClient.SqlCommand myCommand2 = new System.Data.SqlClient.SqlCommand(strSQL2, cnn2);
                                // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                                using (System.Data.SqlClient.SqlDataReader reader2 = myCommand2.ExecuteReader())
                                {
                                    while (reader2.Read())
                                    {
                                        prodPairedId = reader2["productId"].ToString();


                                
                                    }
                                }
                            }

                            

                            string insertString = "";
                            insertString = String.Format("INSERT INTO tblProductsGroup(productId, groupTypeId, groupwith) VALUES ({0},{1},{2});", prodId, 2, prodPairedId);
                            insertString += "      " + productCode2;
                            insertStringStatements.Add(insertString);
                        }
                    }
                }



            }
            foreach (string s in insertStringStatements)
            {
                Response.Write(s);
                Response.Write("<br/>");
            }
        */
             

        }


        protected void Accessories()
        {
            /*    String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
 + "Data Source=C:\\Users\\bharat\\Documents\\Book.xlsx;"
 + "Extended Properties='Excel 8.0;HDR=Yes'";

          System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
          System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
          cmdExcel.Connection = connExcel;

          connExcel.Open();
          System.Data.DataTable dtExcelSchema;
          dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
          connExcel.Close();

          System.Data.DataSet ds = new System.Data.DataSet();
          string SheetName = dtExcelSchema.Rows[5]["TABLE_NAME"].ToString();
          cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
          System.Data.OleDb.OleDbDataAdapter da;
          da = new System.Data.OleDb.OleDbDataAdapter();
          da.SelectCommand = cmdExcel;
          da.Fill(ds);

          List<String> insertStringStatements = new List<string>();
          foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
          {
              string productCode = dr["Name"].ToString();
              //productCode = productCode.Substring(0, 7);
                
              string MRP = dr["MRP"].ToString();
              string colour = dr["Colour"].ToString();
              int isAvailable = 0;
              if (dr["Available"].ToString() == "YES")
              {
                  isAvailable = 1;
              }
             string insertString = "";
              insertString = String.Format("INSERT INTO tblProducts(categoryId, ProductCode, MSRP, offerId, colour, IsAvailable, IsNewArrival, isVisible, isDeleted) VALUES ({0},'{1}',{2},{3},'{4}',{5},0,1,0)", 36, productCode, MRP, 1111, colour, isAvailable);
              insertStringStatements.Add(insertString);
                

              /*
              string strSQL = string.Format("Select * From tblProducts where categoryId=15 and isDeleted=0 and ProductCode like '%{0}%'", productCode);
              //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
              string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
              using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
              {
                  cnn.Open();
                  System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                  // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                  using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                  {
                      while (reader.Read())
                      {
                          string prodId = reader["productId"].ToString();
                          string MRP = dr["MRP"].ToString();
                          string colour = dr["Colour"].ToString();
                          int isAvailable = 0;
                          int isNewArrival = 0;
                          int isVisible = 1;
                          int offerId = 1111;

                          

                          if (dr["Available"].ToString().Trim().ToUpper() == "YES")
                          {
                              isAvailable = 1;
                          }
                          

                          string insertString = "";
                          insertString = String.Format("UPDATE tblProducts SET isAvailable={0}, MSRP={1}, colour='{2}' ,offerId={4}, isNewArrival={5}, isVisible={6}, isDeleted=0 WHERE productId={3};", isAvailable, MRP, colour, prodId, offerId, isNewArrival, isVisible);
                          insertStringStatements.Add(insertString);
                      }
                  }
              }
                 
                 
                



          }
          foreach (string s in insertStringStatements)
          {
              Response.Write(s);
              Response.Write("<br/>");
          }
  */


            /*     String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
                + "Data Source=C:\\Users\\bharat\\Documents\\Book.xlsx;"
                + "Extended Properties='Excel 8.0;HDR=Yes'";

                 System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
                 System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
                 cmdExcel.Connection = connExcel;

                 connExcel.Open();
                 System.Data.DataTable dtExcelSchema;
                 dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
                 connExcel.Close();

                 System.Data.DataSet ds = new System.Data.DataSet();
                 string SheetName = dtExcelSchema.Rows[5]["TABLE_NAME"].ToString();
                 cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
                 System.Data.OleDb.OleDbDataAdapter da;
                 da = new System.Data.OleDb.OleDbDataAdapter();
                 da.SelectCommand = cmdExcel;
                 da.Fill(ds);

                 List<String> insertStringStatements = new List<string>();
                 foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
                 {
                     string codeName = dr["Name"].ToString();

                     string strSQL = string.Format("Select * From tblProducts where categoryId=36 and isDeleted=0 and isVisible=1 and ProductCode like '%{0}%'", codeName);
                     //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                     string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                     using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                     {
                         cnn.Open();
                         System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                         // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                         using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                         {
                             while (reader.Read())
                             {
                                 string prodId = reader["productId"].ToString();
                                 string attrValue = "";
                                 int attrId = 0;
                                 int isAvailableFor = 1;
                                 string insertString = "";

                                 for (int i = 0; i < dr.ItemArray.Count(); i++)
                                 {

                                     switch (i)
                                     {
                                         case 5:
                                             attrId = 1;
                                             string[] sizes = dr.ItemArray[i].ToString().Split(',');
                                             foreach (string sz in sizes)
                                             {
                                                 insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, sz, isAvailableFor);
                                                 insertStringStatements.Add(insertString);
                                             }
                                             break;
                                         case 2:
                                             attrId = 2;
                                             attrValue = dr.ItemArray[i].ToString();
                                             insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                             insertStringStatements.Add(insertString);
                                             break;
                                 

                                     }

                                 }



                             }
                         }

                     }


                 }
                 foreach (string s in insertStringStatements)
                 {
                     Response.Write(s);
                     Response.Write("<br/>");
                 }


                 */
        }


        protected void Shoes()
        {
            /*
             String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
+ "Data Source=C:\\Users\\bharat\\Documents\\SHOESS.xlsx;"
+ "Extended Properties='Excel 8.0;HDR=Yes'";

           System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
           System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
           cmdExcel.Connection = connExcel;

           connExcel.Open();
           System.Data.DataTable dtExcelSchema;
           dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
           connExcel.Close();

           System.Data.DataSet ds = new System.Data.DataSet();
           string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
           cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
           System.Data.OleDb.OleDbDataAdapter da;
           da = new System.Data.OleDb.OleDbDataAdapter();
           da.SelectCommand = cmdExcel;
           da.Fill(ds);

           List<String> insertStringStatements = new List<string>();
           foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
           {
               string productCode = dr["LINE NO"].ToString();
               //productCode = productCode.Substring(0, 7);
               string MRP = dr["MRP"].ToString();
               string colour = dr["Colour"].ToString();
               int isAvailable = 0;
               int isNewArrival = 0;
               int isVisible = 1;
               int offerId = 1111;

               if (dr["DISCOUNT"].ToString().Trim().ToUpper() == "50")
               {
                   offerId = 1113;
               }
               if (dr["DISCOUNT"].ToString().Trim().ToUpper() == "40")
               {
                   offerId = 1116;
               }

               if (dr["Available"].ToString().Trim().ToUpper() == "YES")
               {
                   isAvailable = 1;
               }
               if (dr["SOLD"].ToString().Trim().ToUpper() == "YES")
               {
                   isVisible = 0;
               }
               if (dr["Fresh Arrival"].ToString().Trim().ToUpper() == "YES")
               {
                   isNewArrival = 1;
               }
               string insertString = "";
               insertString = String.Format("INSERT INTO tblProducts(categoryId, ProductCode, MSRP, offerId, colour, IsAvailable, IsNewArrival, isVisible, isDeleted) VALUES ({0},'{1}',{2},{3},'{4}',{5},0,1,0)", 4, productCode, MRP, 1111, colour, isAvailable);
               insertStringStatements.Add(insertString);

               string strSQL = string.Format("Select * From tblProducts where categoryId=4 and isDeleted=0 and ProductCode like '%{0}%'", productCode);
               //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
               string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
               using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
               {
                   cnn.Open();
                   System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                   // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                   using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                   {
                       while (reader.Read())
                       {
                           string prodId = reader["productId"].ToString();
                           //string MRP = dr["MRP"].ToString();
                           //string colour = dr["Colour"].ToString();
                        /*   int isAvailable = 0;
                           int isNewArrival = 0;
                           int isVisible = 1;
                           int offerId = 1111;

                           if (dr["DISCOUNT"].ToString().Trim().ToUpper() == "50")
                           {
                               offerId = 1113;
                           }
                           if (dr["DISCOUNT"].ToString().Trim().ToUpper() == "40")
                           {
                               offerId = 1116;
                           }

                           if (dr["Available"].ToString().Trim().ToUpper() == "Yes")
                           {
                               isAvailable = 1;
                           }
                           if (dr["SOLD"].ToString().Trim().ToUpper() == "Yes")
                           {
                               isVisible = 0;
                           }
                           if (dr["Fresh Arrival"].ToString().Trim().ToUpper() == "Yes")
                           {
                               isNewArrival = 1;
                           }

                           string insertString = "";
                           insertString = String.Format("UPDATE tblProducts SET isAvailable={0}, MSRP={1}, colour='{2}' ,offerId={4}, isNewArrival={5}, isVisible={6}, isDeleted=0 WHERE productId={3};", isAvailable, MRP, colour, prodId,offerId,isNewArrival,isVisible);
                           insertStringStatements.Add(insertString);
                       }
                   }
               }



           }
           foreach (string s in insertStringStatements)
           {
               Response.Write(s);
               Response.Write("<br/>");
           }
          */

            
            String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
           + "Data Source=C:\\Users\\bharat\\Documents\\SHOESS.xlsx;"
           + "Extended Properties='Excel 8.0;HDR=Yes'";

            System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
            System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
            cmdExcel.Connection = connExcel;

            connExcel.Open();
            System.Data.DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            connExcel.Close();

            System.Data.DataSet ds = new System.Data.DataSet();
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            System.Data.OleDb.OleDbDataAdapter da;
            da = new System.Data.OleDb.OleDbDataAdapter();
            da.SelectCommand = cmdExcel;
            da.Fill(ds);

            List<String> insertStringStatements = new List<string>();
            foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
            {
                string codeName = dr["LINE NO"].ToString();

                string strSQL = string.Format("Select * From tblProducts where categoryId=4 and isDeleted=0 and isVisible=1 and ProductCode like '%{0}%'", codeName);
                //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                    // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                    using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string prodId = reader["productId"].ToString();
                            string attrValue = "";
                            int attrId = 0;
                            int isAvailableFor = 1;
                            string insertString = "";

                            for (int i = 0; i < dr.ItemArray.Count(); i++)
                            {

                                switch (i)
                                {
                                    case 7:
                                        attrId = 1;
                                        string[] sizes = dr.ItemArray[i].ToString().Split(',');
                                        foreach (string sz in sizes)
                                        {
                                            insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, sz, isAvailableFor);
                                            insertStringStatements.Add(insertString);
                                        }
                                        break;
                                    case 2:
                                        attrId = 2;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    case 14:
                                        attrId = 3;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    case 15:
                                        attrId = 14;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    
                                    case 16:
                                        attrId = 15;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);
                                        break;
                                    case 17:
                                        attrId = 16;
                                        attrValue = dr.ItemArray[i].ToString();
                                        insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                        insertStringStatements.Add(insertString);

                                        break;
                                    
                                }

                            }



                        }
                    }

                }


            }
            foreach (string s in insertStringStatements)
            {
                Response.Write(s);
                Response.Write("<br/>");
            }
             
            

            /*
            string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("~/images/products/FASHIONFORMALS"), "*", System.IO.SearchOption.AllDirectories);

            List<String> insertStringStatements = new List<string>(filesindirectory.Count());

            string tempProdId = "";
            int tempImageTypeId = 0;
            int seq = 1;

            foreach (string item in filesindirectory)
            {
                System.IO.DirectoryInfo myDirectory = new System.IO.DirectoryInfo(item);
                string sizeName = myDirectory.Parent.Name;
                string codeName = myDirectory.Parent.Parent.Name;
                //images.Add(String.Format("images/products/JACKETS/{1}/{2}/{0}", System.IO.Path.GetFileName(item), codeName, sizeName));
                string imagePath = String.Format("images/products/FASHIONFORMALS/{1}/{2}/{0}", System.IO.Path.GetFileName(item), codeName, sizeName);

                int imageTypeId = 0;

                switch (sizeName.ToLower())
                {
                    case "87x98":
                        imageTypeId = 1;
                        break;
                    case "123x139":
                        imageTypeId = 2;
                        break;
                    case "226x259":
                        imageTypeId = 3;
                        break;
                    case "276x242":
                        imageTypeId = 4;
                        break;
                    case "320x165":
                        imageTypeId = 5;
                        break;
                    case "308x353":
                        imageTypeId = 7;
                        break;
                    case "600x902":
                        imageTypeId = 6;
                        break;

                }



               // codeName = codeName.Substring(3, codeName.Length - 3);
               // codeName = codeName.Replace(" ", string.Empty);



                string strSQL = string.Format("Select * From tblProducts where categoryId=4 and isVisible=1 and ProductCode like '%{0}%'", codeName);
                //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                {
                    cnn.Open();
                    System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                    // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                    using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            string prodId = reader["productId"].ToString();
                            if (prodId == tempProdId && imageTypeId == tempImageTypeId)
                            {
                                seq++;
                            }
                            else
                            {
                                seq = 1;
                                tempProdId = "";
                                tempImageTypeId = 0;
                            }
                            string insertString = String.Format("INSERT INTO tblProductImages(productId, imgUrl, ImageTypeId, seqOrder) VALUES ({0},'{1}',{2},{3});", prodId, imagePath, imageTypeId, seq);

                            insertStringStatements.Add(insertString);
                            tempProdId = prodId;
                            tempImageTypeId = imageTypeId;


                        }
                    }

                }
                //cnn.Open();


            }

            foreach (string s in insertStringStatements)
            {
                Response.Write(s);
                Response.Write("<br/>");
            }
             */
             
        }




        protected void Trousers()
        {
            /*
            String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
         + "Data Source=C:\\Users\\bharat\\Documents\\Book.xlsx;"
         + "Extended Properties='Excel 8.0;HDR=Yes'";

         System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
         System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
         cmdExcel.Connection = connExcel;

         connExcel.Open();
         System.Data.DataTable dtExcelSchema;
         dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
         connExcel.Close();

         System.Data.DataSet ds = new System.Data.DataSet();
         string SheetName = dtExcelSchema.Rows[3]["TABLE_NAME"].ToString();
         cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
         System.Data.OleDb.OleDbDataAdapter da;
         da = new System.Data.OleDb.OleDbDataAdapter();
         da.SelectCommand = cmdExcel;
         da.Fill(ds);

         List<String> insertStringStatements = new List<string>();
         foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
         {
             string productCode = dr["Item Name"].ToString();
             productCode = productCode.Substring(0, 7);

              string strSQL = string.Format("Select * From tblProducts where categoryId=10 and ProductCode like '%{0}%'", productCode);
             //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
             string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
             using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
             {
                 cnn.Open();
                 System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                 // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                 using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                 {
                     while (reader.Read())
                     {
                         string prodId = reader["productId"].ToString();
                         string MRP = dr["MRP"].ToString();
                         string colour = dr["Colour"].ToString();
                         int isAvailable = 0;
                         if (dr["Available"].ToString() == "YES")
                         {
                             isAvailable = 1;
                         }
                         string insertString = "";
                         insertString = String.Format("UPDATE tblProducts SET isAvailable={0}, MSRP={1}, colour='{2}' ,offerId=1111, isNewArrival=1, isVisible=1, isDeleted=0 WHERE productId={3};",isAvailable,MRP,colour,prodId);
                         insertStringStatements.Add(insertString);
                     }
                 }
             }


             
                
         }
         foreach (string s in insertStringStatements)
         {
             Response.Write(s);
             Response.Write("<br/>");
         }

         */






            /*
          String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
          + "Data Source=C:\\Users\\bharat\\Documents\\Book.xlsx;"
          + "Extended Properties='Excel 8.0;HDR=Yes'";

          System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
          System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
          cmdExcel.Connection = connExcel;

          connExcel.Open();
          System.Data.DataTable dtExcelSchema;
          dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
          connExcel.Close();

          System.Data.DataSet ds = new System.Data.DataSet();
          string SheetName = dtExcelSchema.Rows[3]["TABLE_NAME"].ToString();
          cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
          System.Data.OleDb.OleDbDataAdapter da;
          da = new System.Data.OleDb.OleDbDataAdapter();
          da.SelectCommand = cmdExcel;
          da.Fill(ds);

          List<String> insertStringStatements = new List<string>();
          foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
          {
              string codeName = dr["Item Name"].ToString();
              codeName = codeName.Substring(0, 7);

              string strSQL = string.Format("Select * From tblProducts where categoryId=10 and isVisible=1 and ProductCode like '%{0}%'", codeName);
              //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
              string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
              using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
              {
                  cnn.Open();
                  System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                  // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                  using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                  {
                      while (reader.Read())
                      {
                          string prodId = reader["productId"].ToString();
                          string attrValue = "";
                          int attrId=0;
                          int isAvailableFor = 1;
                          string insertString = "";

                          for (int i = 0; i < dr.ItemArray.Count();i++ )
                          {                               
                                
                              switch (i)
                              {
                                  case 4:
                                      attrId = 1;
                                      string[] sizes = dr.ItemArray[i].ToString().Split(',');
                                      foreach (string sz in sizes)
                                      {
                                          insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, sz, isAvailableFor);
                                          insertStringStatements.Add(insertString);
                                      }
                                      break;
                                  case 2:
                                      attrId = 2;
                                      attrValue = dr.ItemArray[i].ToString() ;
                                      insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                      insertStringStatements.Add(insertString);
                                      break;
                                  case 11:
                                      attrId = 3;
                                      attrValue = dr.ItemArray[i].ToString();
                                      insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                      insertStringStatements.Add(insertString);
                                      break;
                                  case 12:
                                      attrId = 5;
                                      attrValue = dr.ItemArray[i].ToString(); 
                                      insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                      insertStringStatements.Add(insertString);
                                      break;
                                
                                  case 13:
                                      attrId = 9;
                                      attrValue = dr.ItemArray[i].ToString(); 
                                      insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                      insertStringStatements.Add(insertString);
                                      break;
                                  case 14:
                                      attrId = 10;
                                      attrValue = dr.ItemArray[i].ToString(); 
                                      insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                      insertStringStatements.Add(insertString);
                                      break;
                                  case 15:
                                      attrId = 12;
                                      attrValue = dr.ItemArray[i].ToString(); 
                                      insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                      insertStringStatements.Add(insertString);

                                      break;
                                  case 16:
                                      attrId = 13;
                                      attrValue = dr.ItemArray[i].ToString(); 
                                      insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                      insertStringStatements.Add(insertString);
                                      break;
                              }
                                
                          }
                            
                           

                      }
                  }

              }

                
          }
          foreach (string s in insertStringStatements)
          {
              Response.Write(s);
              Response.Write("<br/>");
          }
             */



            /*
             string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("~/images/products/JEANS"), "*", System.IO.SearchOption.AllDirectories);

              List<String> insertStringStatements = new List<string>(filesindirectory.Count());

              string tempProdId = "";
              int tempImageTypeId = 0;
              int seq = 1;

              foreach (string item in filesindirectory)
              {
                  System.IO.DirectoryInfo myDirectory = new System.IO.DirectoryInfo(item);
                  string sizeName = myDirectory.Parent.Name;
                  string codeName = myDirectory.Parent.Parent.Name;
                  //images.Add(String.Format("images/products/JACKETS/{1}/{2}/{0}", System.IO.Path.GetFileName(item), codeName, sizeName));
                  string imagePath = String.Format("images/products/JEANS/{1}/{2}/{0}", System.IO.Path.GetFileName(item), codeName, sizeName);

                  int imageTypeId = 0;

                  switch (sizeName.ToLower())
                  {
                      case "87x98":
                          imageTypeId = 1;
                          break;
                      case "123x139":
                          imageTypeId = 2;
                          break;
                      case "226x259":
                          imageTypeId = 3;
                          break;
                      case "276x242":
                          imageTypeId = 4;
                          break;
                      case "320x165":
                          imageTypeId = 5;
                          break;
                      case "308x353":
                          imageTypeId = 7;
                          break;
                      case "600x902":
                          imageTypeId = 6;
                          break;

                  }
                  


                 codeName = codeName.Substring(0,8);
                  codeName = codeName.Replace(" ", string.Empty).Trim();

                 

                  string strSQL = string.Format("Select * From tblProducts where categoryId=10 and isVisible=1 and ProductCode like '%{0}%'", codeName);
                  //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                      string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                      using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                      {
                          cnn.Open();
                          System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                          // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                          using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                          {
                              
                              while (reader.Read())
                              {
                                  string prodId = reader["productId"].ToString();
                                  if (prodId == tempProdId && imageTypeId==tempImageTypeId)
                                  {
                                      seq++;
                                  }
                                  else
                                  {
                                      seq = 1;
                                      tempProdId = "";
                                      tempImageTypeId = 0;
                                  }
                                  string insertString = String.Format("INSERT INTO tblProductImages(productId, imgUrl, ImageTypeId, seqOrder) VALUES ({0},'{1}',{2},{3});", prodId, imagePath, imageTypeId, seq);

                                  insertStringStatements.Add(insertString);
                                  tempProdId = prodId;
                                  tempImageTypeId = imageTypeId;
                                  

                              }
                          }

                      }
                      //cnn.Open();
                   

              }

              foreach (string s in insertStringStatements)
              {
                  Response.Write(s);
                  Response.Write("<br/>");
              }
             */

            

        }


        protected void Apparel()
        {

            /*
           String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
        + "Data Source=C:\\Users\\bharat\\Documents\\Book.xlsx;"
        + "Extended Properties='Excel 8.0;HDR=Yes'";

        System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
        System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
        cmdExcel.Connection = connExcel;

        connExcel.Open();
        System.Data.DataTable dtExcelSchema;
        dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
        connExcel.Close();

        System.Data.DataSet ds = new System.Data.DataSet();
        string SheetName = dtExcelSchema.Rows[3]["TABLE_NAME"].ToString();
        cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
        System.Data.OleDb.OleDbDataAdapter da;
        da = new System.Data.OleDb.OleDbDataAdapter();
        da.SelectCommand = cmdExcel;
        da.Fill(ds);

        List<String> insertStringStatements = new List<string>();
        foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
        {
            string productCode = dr["Item Name"].ToString();
            string MRP = dr["MRP"].ToString();
            string colour = dr["Colour"].ToString();
            int isAvailable = 0;
            if (dr["Available"].ToString() == "YES")
            {
                isAvailable = 1;
            }
            string insertString = "";
            insertString = String.Format("INSERT INTO tblProducts(categoryId, ProductCode, MSRP, offerId, colour, IsAvailable, IsNewArrival, isVisible, isDeleted) VALUES ({0},'{1}',{2},{3},'{4}',{5},0,1,0)",29,productCode, MRP,1111,colour,isAvailable);
            insertStringStatements.Add(insertString);
                
        }
        foreach (string s in insertStringStatements)
        {
            Response.Write(s);
            Response.Write("<br/>");
        }

        */















            /*

           String strExcelConn = "Provider=Microsoft.ACE.OLEDB.12.0;"
           + "Data Source=C:\\Users\\bharat\\Documents\\Book.xlsx;"
           + "Extended Properties='Excel 8.0;HDR=Yes'";

           System.Data.OleDb.OleDbConnection connExcel = new System.Data.OleDb.OleDbConnection(strExcelConn);
           System.Data.OleDb.OleDbCommand cmdExcel = new System.Data.OleDb.OleDbCommand();
           cmdExcel.Connection = connExcel;

           connExcel.Open();
           System.Data.DataTable dtExcelSchema;
           dtExcelSchema = connExcel.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
           connExcel.Close();

           System.Data.DataSet ds = new System.Data.DataSet();
           string SheetName = dtExcelSchema.Rows[3]["TABLE_NAME"].ToString();
           cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
           System.Data.OleDb.OleDbDataAdapter da;
           da = new System.Data.OleDb.OleDbDataAdapter();
           da.SelectCommand = cmdExcel;
           da.Fill(ds);

           List<String> insertStringStatements = new List<string>();
           foreach (System.Data.DataRow dr in ds.Tables[0].Rows)
           {
               string codeName = dr["Item Name"].ToString();

               string strSQL = string.Format("Select * From tblProducts where categoryId=29 and ProductCode like '%{0}%'", codeName);
               //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
               string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
               using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
               {
                   cnn.Open();
                   System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                   // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                   using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                   {
                       while (reader.Read())
                       {
                           string prodId = reader["productId"].ToString();
                           string attrValue = "";
                           int attrId=0;
                           int isAvailableFor = 1;
                           string insertString = "";

                           for (int i = 0; i < dr.ItemArray.Count();i++ )
                           {                               
                                
                               switch (i)
                               {
                                   case 5:
                                       attrId = 1;
                                       string[] sizes = dr.ItemArray[i].ToString().Split(',');
                                       foreach (string sz in sizes)
                                       {
                                           insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, sz, isAvailableFor);
                                           insertStringStatements.Add(insertString);
                                       }
                                       break;
                                   case 2:
                                       attrId = 2;
                                       attrValue = dr.ItemArray[i].ToString() ;
                                       insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                       insertStringStatements.Add(insertString);
                                       break;
                                   case 4:
                                       attrId = 3;
                                       attrValue = dr.ItemArray[i].ToString();
                                       insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                       insertStringStatements.Add(insertString);
                                       break;
                                   case 13:
                                       attrId = 5;
                                       attrValue = dr.ItemArray[i].ToString(); 
                                       insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                       insertStringStatements.Add(insertString);
                                       break;
                                   case 14:
                                       attrId = 8;
                                       attrValue = dr.ItemArray[i].ToString(); 
                                       insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                       insertStringStatements.Add(insertString);
                                       break;
                                   case 15:
                                       attrId = 9;
                                       attrValue = dr.ItemArray[i].ToString(); 
                                       insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                       insertStringStatements.Add(insertString);
                                       break;
                                   case 16:
                                       attrId = 10;
                                       attrValue = dr.ItemArray[i].ToString(); 
                                       insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                       insertStringStatements.Add(insertString);
                                       break;
                                   case 17:
                                       attrId = 12;
                                       attrValue = dr.ItemArray[i].ToString(); 
                                       insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                       insertStringStatements.Add(insertString);

                                       break;
                                   case 18:
                                       attrId = 13;
                                       attrValue = dr.ItemArray[i].ToString(); 
                                       insertString = String.Format("INSERT INTO tblAttributeValues(productId, attributeId, attributeValue, isAvailableFor) VALUES ({0},{1},'{2}',{3});", prodId, attrId, attrValue, isAvailableFor);
                                       insertStringStatements.Add(insertString);
                                       break;
                               }
                                
                           }
                            
                           

                       }
                   }

               }

                
           }
           foreach (string s in insertStringStatements)
           {
               Response.Write(s);
               Response.Write("<br/>");
           }

           */
            /*

             string[] filesindirectory = System.IO.Directory.GetFiles(Server.MapPath("~/images/products/SWEATERS"), "*", System.IO.SearchOption.AllDirectories);

              List<String> insertStringStatements = new List<string>(filesindirectory.Count());

              string tempProdId = "";
              int tempImageTypeId = 0;
              int seq = 1;

              foreach (string item in filesindirectory)
              {
                  System.IO.DirectoryInfo myDirectory = new System.IO.DirectoryInfo(item);
                  string sizeName = myDirectory.Parent.Name;
                  string codeName = myDirectory.Parent.Parent.Name;
                  //images.Add(String.Format("images/products/JACKETS/{1}/{2}/{0}", System.IO.Path.GetFileName(item), codeName, sizeName));
                  string imagePath = String.Format("images/products/SWEATERS/{1}/{2}/{0}", System.IO.Path.GetFileName(item), codeName, sizeName);

                  int imageTypeId = 0;

                  switch (sizeName.ToLower())
                  {
                      case "87x98":
                          imageTypeId = 1;
                          break;
                      case "123x139":
                          imageTypeId = 2;
                          break;
                      case "226x259":
                          imageTypeId = 3;
                          break;
                      case "276x242":
                          imageTypeId = 4;
                          break;
                      case "320x165":
                          imageTypeId = 5;
                          break;
                      case "308x353":
                          imageTypeId = 7;
                          break;
                      case "600x902":
                          imageTypeId = 6;
                          break;

                  }
                  


                 codeName = codeName.Substring(3,codeName.Length-3);
                  codeName = codeName.Replace(" ", string.Empty);

                 

                  string strSQL = string.Format("Select * From tblProducts where categoryId=29 and isVisible=1 and ProductCode like '%{0}%'", codeName);
                  //    string strSQL = string.Format("Select * From [tblProducts] where ProductCode like '%{0}%'", codeName);
                      string ConnectionString = Convert.ToString(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["ConnectionString"]);
                      using (System.Data.SqlClient.SqlConnection cnn = new System.Data.SqlClient.SqlConnection(ConnectionString))
                      {
                          cnn.Open();
                          System.Data.SqlClient.SqlCommand myCommand = new System.Data.SqlClient.SqlCommand(strSQL, cnn);
                          // System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader();
                          using (System.Data.SqlClient.SqlDataReader reader = myCommand.ExecuteReader())
                          {
                              
                              while (reader.Read())
                              {
                                  string prodId = reader["productId"].ToString();
                                  if (prodId == tempProdId && imageTypeId==tempImageTypeId)
                                  {
                                      seq++;
                                  }
                                  else
                                  {
                                      seq = 1;
                                      tempProdId = "";
                                      tempImageTypeId = 0;
                                  }
                                  string insertString = String.Format("INSERT INTO tblProductImages(productId, imgUrl, ImageTypeId, seqOrder) VALUES ({0},'{1}',{2},{3});", prodId, imagePath, imageTypeId, seq);

                                  insertStringStatements.Add(insertString);
                                  tempProdId = prodId;
                                  tempImageTypeId = imageTypeId;
                                  

                              }
                          }

                      }
                      //cnn.Open();
                   

              }

              foreach (string s in insertStringStatements)
              {
                  Response.Write(s);
                  Response.Write("<br/>");
              }

            */
             

        }
    }
}