using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedTapeWeb
{
    public partial class processPayment : System.Web.UI.Page
    {

        string workingKey = System.Configuration.ConfigurationManager.AppSettings["WorkingKey"];//"1227CB4825F2676C4D422CAFE291280A";//put in the 32bit alpha numeric key in the quotes provided here 	
      string ccaRequest = "";
      public string strEncRequest = "";
      public string strAccessCode = System.Configuration.ConfigurationManager.AppSettings["AccessCode"]; //"AVPC02BH27BB41CPBB";// put the access key in the quotes provided here.

        protected void Page_Load(object sender, EventArgs e)
        {

            strEncRequest = Session["Encrypted"].ToString();
            //string workingKey = "71BE96B739B35D89263E0DFD2C29115D";//put in the 32bit alpha numeric key in the quotes provided here
            //CCACrypto ccaCrypto = new CCACrypto();
            //string encResponse = ccaCrypto.Decrypt(Request.Form["encResp"], workingKey);
            //NameValueCollection Params = new NameValueCollection();
            //string[] segments = encResponse.Split('&');
            //foreach (string seg in segments)
            //{
            //    string[] parts = seg.Split('=');
            //    if (parts.Length > 0)
            //    {
            //        string Key = parts[0].Trim();
            //        string Value = parts[1].Trim();
            //        Params.Add(Key, Value);
            //    }
            //}

            //for (int i = 0; i < Params.Count; i++)
            //{
            //    Response.Write(Params.Keys[i] + " = " + Params[i] + "<br>");
            //}


           

        }
    }
}