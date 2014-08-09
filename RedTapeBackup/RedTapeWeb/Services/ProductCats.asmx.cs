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



    public class ProductParams
    {        
        public Dictionary<string, List<string>> ProdAttributes { get; set; }
        public string StartIndex { get; set; }
        public string EndIndex { get; set; }
    }
    
 

    /// <summary>
    /// Summary description for ProductCats
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]      
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

       
    //   public List<BAOProduct> GetProductsList(string data)
        [WebMethod(Description = "Get products list")]
       //public List<BAOProduct> GetProductsList(int CategoryId, string colorCodes, string sizes, int LowPrice, int HighPrice, string OfferTypeId, int StartIndex, int EndIndex, string sortby)
        public List<BAOProduct> GetProductsList(int CatId, ProductParams p)
        //public string GetProductsList(ProductParams p)
        {
            try
            {
                DAOProduct objproduct = new DAOProduct();
               // p.Sizes
                //return objproduct.GetAllProductsByCategoryId(CategoryId, colorCodes, sizes, LowPrice, HighPrice, OfferTypeId, StartIndex, EndIndex, sortby);
                return objproduct.GetAllProductsByCategoryId(CatId, ClsGeneral.getInt32(p.StartIndex), ClsGeneral.getInt32(p.EndIndex));
               // return p.CategoryId + "Bharat";
            }
            catch
            {
                throw;
            }
        } 
        [WebMethod(Description = "Get Categories list")]
        public List<BAOProductMenu> GetProductsMenu(int CategoryId, int SubCategoryId)
        {
            try
            {
                DAOProduct objproduct = new DAOProduct();
                return objproduct.GetProductMenu(CategoryId, SubCategoryId);              
            }
            catch 
            {
                throw;
            }        
        }

        [WebMethod(Description = "Get Product Details")]
        public List<ProductDetails> GetProductDetails(int CategoryId, int ProductId)
        {
            try
            { 
                DAOProduct objproduct = new DAOProduct();
                return objproduct.GetProductDetails(CategoryId, ProductId);
            }
            catch
            {
                throw;
            }
        }


        [WebMethod(Description = "Save User View Products & get Count")]
        public int SaveUserViewProducts(int productid, string MembershipId, int viewType, int qty)
        {
            DAOUsers objUsers = new DAOUsers();
            int count = objUsers.SaveUserViewProducts(productid, MembershipId, viewType, qty);
            return count;
        }
    }
  }
