using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Reflection;

/// <summary>
/// Summary description for ClsGeneral
/// </summary>
public class ClsGeneral
{
	public ClsGeneral()
	{
		//
		// TODO: Add constructor logic here
		//
    }
    
    public static bool IsInt32(string anyString)
    {
        if (anyString == null)
        {
            anyString = "";
        }
        if (anyString.Length > 0)
        {
            Int32 dummyOut = new Int32();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", true);
            return Int32.TryParse(anyString, System.Globalization.NumberStyles.Any, cultureInfo.NumberFormat, out dummyOut);
        }
        else
        {
            return false;
        }
    }
    public static int getInt32(string anyString)
    {
        if (anyString.Length > 0 && anyString != null)
        {
            Int32 dummyOut = new Int32();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", true);
            Int32.TryParse(anyString, out dummyOut);
            return dummyOut;
        }
        else
        {
            return 0;
        }
    }
    public static bool IsDouble(string anyString)
    {
        if (anyString == null)
        {
            anyString = "";
        }
        if (anyString.Length > 0)
        {
            double dummyOut = new double();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", true);
            return Double.TryParse(anyString, System.Globalization.NumberStyles.Any, cultureInfo.NumberFormat, out dummyOut);
        }
        else
        {
            return false;
        }
    }
    public static double getDouble(string anyString)
    {
        if (anyString.Length > 0)
        {
            double dummyOut = new double();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", true);
            Double.TryParse(anyString, out dummyOut);
            return dummyOut;
        }
        else
        {
            return 0;
        }
    }
    public static decimal getDecimal(string anyString)
    {
        if (anyString.Length > 0)
        {
            decimal dummyOut = new decimal();
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US", true);
            Decimal.TryParse(anyString, out dummyOut);
            return dummyOut;
        }
        else
        {
            return 0;
        }
    }
    public static bool IsDate(string anyString) 
    {
        if (anyString == null)
        {
            anyString = "";
        }
        if (anyString.Length > 0)
        {
            DateTime dummyDate = DateTime.MinValue;
            try
            {
                dummyDate = DateTime.Parse(anyString);
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool getDate(string anyString, out DateTime resultDate)
    {
        bool isDate = true;
        if (anyString == null)
        {
            anyString = "";
        }
        try
        {
            resultDate = DateTime.Parse(anyString);
        }
        catch
        {
            resultDate = DateTime.MinValue;
            isDate = false;
        }
        return isDate;
    }

    static public void SaveSession()
    {
        PropertyInfo p = typeof(System.Web.HttpRuntime).GetProperty("FileChangesMonitor", BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        object o = p.GetValue(null, null);
        FieldInfo f = o.GetType().GetField("_dirMonSubdirs", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.IgnoreCase);
        object monitor = f.GetValue(o);
        MethodInfo m = monitor.GetType().GetMethod("StopMonitoring", BindingFlags.Instance | BindingFlags.NonPublic);
        m.Invoke(monitor, new object[] { }); 
    }

    static public DateTime convertdate(string dat)
    { 
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            DateTime dtDate = Convert.ToDateTime(dat);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DateTime datdate = Convert.ToDateTime(dtDate);
            return dtDate;
        }
        catch (Exception)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DateTime dtDate = Convert.ToDateTime(dat);
            return dtDate;                      
        }
    }
    static public DateTime dateconvert1(string date)
    {
        try
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            DateTime datdate = Convert.ToDateTime(date);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            DateTime dtDate = Convert.ToDateTime(datdate);
            return dtDate;
        }
        catch (Exception)
        {
            DateTime datdate = ClsGeneral.convertdate(date);
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
            DateTime dtDate = Convert.ToDateTime(datdate);
            return dtDate;
        }
    }
    static public string dateconvertForEditDisplay(string date)
    { 
        DateTime datdate = Convert.ToDateTime(date);
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        DateTime datdate1 = datdate;
        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-GB");
        DateTime dtDate = Convert.ToDateTime(datdate1);
         if (dtDate.ToShortDateString() == "01/01/1900" || dtDate.ToShortDateString() == "01/01/1900")
         { return ""; }
         else
         {  
             return dtDate.ToShortDateString();          
         }
    }

    static public string base64Decode(string sData)
    {
        System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
        System.Text.Decoder utf8Decode = encoder.GetDecoder();
        byte[] todecode_byte = Convert.FromBase64String(sData);
        int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
        char[] decoded_char = new char[charCount];
        utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
        string result = new String(decoded_char);
        return result;
    }
    static public string base64Encode(string sData)
    {
        try
        {
            byte[] encData_byte = new byte[sData.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
            string encodedData = Convert.ToBase64String(encData_byte);
            return encodedData;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in base64Encode" + ex.Message);
        }
    }
}
