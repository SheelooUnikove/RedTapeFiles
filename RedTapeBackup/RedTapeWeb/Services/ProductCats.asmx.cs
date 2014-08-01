using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using BAL;
using DAL;
using System.Web.Script.Services;
namespace RedTapeWeb.Services
{
    /// <summary>
    /// Summary description for ProductCats
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     //[System.Web.Script.Services.ScriptService]
     [ScriptService()]
    public class ProductCats : System.Web.Services.WebService
    {

        [WebMethod(Description = "Get Categories list")]
        public List<BAOCategory> GetCategoriesList(int CategoryId)
        {
            try
            {
                DAOProduct objproduct = new DAOProduct();
                return objproduct.GetCategories(CategoryId);              
            }
            catch 
            {
                throw;
            }        
        }

        //[WebMethod(Description = "Get products list")]
        //public List<DAOProduct> GetCategoriesList(int CategoryId)
        //{
        //    try
        //    {
        //        Product objproduct = new Product();
        //        //return objproduct.GetAllProductsByCategoryId();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }
  }
