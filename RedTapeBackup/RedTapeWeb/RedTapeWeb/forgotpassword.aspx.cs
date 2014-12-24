using BAL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedTapeWeb
{
    public partial class forgotpassword : System.Web.UI.Page
    {
        DAOUsers objDAOUsers = new DAOUsers();
        BAOUsers objBAOUsers = new BAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string password;
        protected void btn_sendemail_Click(object sender, EventArgs e)
        {
            try
            {
                objBAOUsers.emailAddress = txt_LoginUserEmailAddress.Value;
                password = iStrat.RandomString(8);
                objBAOUsers.newpassword = password;
                msg.InnerHtml = objDAOUsers.ForgotUserPassword(objBAOUsers);
                if (msg.InnerHtml != "No account found with that email address. Please try again.")
                {
                    sendMail();
                }
            }
            catch (Exception ex)
            {
                msg.InnerHtml = ex.Message;
            }
        }
        string emailBody;
        private void sendMail()
        {
            emailBody = @"<table cellspacing='0' cellpadding='0' border='0' id='backgroundTable' style='border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; margin: 0; padding: 0; width: 100% !important; line-height: 100% !important;'>
	<tbody><tr>
  		<td style='border-collapse:collapse; '>
        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; margin: 0 auto; padding: 0; width: 100% !important; line-height: 100% !important;'>
      			<tbody><tr>
        			<td style='border-collapse:collapse; '>
        				<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px;  margin: 0 auto; line-height: 100%;'>
      						<tbody><tr>
                            	<td align='left' style='border-collapse: collapse; background:#000;'>
                                	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px;  margin: 0 auto; line-height: 100%;'>
      									<tbody><tr>
                                            <td align='left' style='border-collapse: collapse; background:#000; width:194px;'>
                                                <img style='border:none; padding:25px;' src='http://www.redtape.com/mailer/redtape/pswrd_rcovry.png'></td>
                                            <td align='right' style='border-collapse: collapse; background:#000; width:194px;'>
                                                 <a target='_blank' href='http://www.redtape.com/'><img style='border:none; padding:25px;' src='http://www.redtape.com/mailer/redtape/logo.png'></a></td>
                                		</tr>
                                    </tbody></table>
                                </td>
                            </tr>
                            
                            
                            
                            <tr>
                            	<td style='border-collapse:collapse;'>
                            	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse; width: 680px; border-left:6px solid #000; border-right:6px solid #000; margin: 0 auto; line-height: 100%;'>
                            		 <tbody><tr>
                                     	<td style='border-collapse:collapse; width:547px;'>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                        		<tbody><tr>
                                                	<td style='line-height:17px; padding-left:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; background:#fff; '>
                                                    Dear User,<br>
                                       				Your request to process a new password has been processed.<br>
                                       				Please find the information below:
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                	<td style='line-height:17px; padding-left:20px; padding-top:25px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px;  font-weight:bold; background:#fff; '>
                                                    Email Address : " + txt_LoginUserEmailAddress.Value.Trim() + @"<br>
                                        			Your new password : " + password + @"
                                                    </td>
                                                </tr>
                                                
                                                
                                                <tr>
                                                	<td style='line-height:17px; padding-left:20px; padding-top:25px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-style:italic; background:#fff; '><img style='border:none; ' src='http://www.redtape.com/mailer/redtape/img2.png'> </td>
                                                </tr>
                                                <tr>
                                                	<td style='line-height:17px; padding-left:20px; padding-top:25px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:14px; font-style:italic; background:#fff; '>
                                                    Customer Care Support will be available between<br>
                                                    10 AM - 5:30 PM from Monday to Saturday only.
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                	<td style='line-height:17px; padding-left:20px; padding-top:20px; font-family:Trebuchet MS, Arial, Helvetica, sans-serif; font-size:13px; background:#fff; '>
                                                    Contact no. 011-26950499<br>
                                                    Email id : customercare@redtapeindia.com
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
                                        <td style='border-collapse:collapse; width:133px;  padding-top:30px;'>
                                        	<table cellspacing='0' cellpadding='0' border='0' style='border-collapse: collapse;'>
                                        		<tbody><tr>
                                                	<td style='border-collapse:collapse;'>
<a href='http://www.redtape.com/lookbook.aspx'>
<img align='right' style='border:none;' alt='Shop The Look' src='http://www.redtape.com/mailer/redtape/look2.png'>
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
            mail.sendMyMail("sales@redtape.com", txt_LoginUserEmailAddress.Value.Trim(), "RedTape Password Recovery", emailBody, "", "");

        }
    }
}