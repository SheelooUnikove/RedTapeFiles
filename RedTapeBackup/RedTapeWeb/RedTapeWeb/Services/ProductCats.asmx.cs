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
        BAOUsers objBAOUsers = new BAOUsers();


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
        public List<BAOProduct> GetProductsList(int membershipId,int CatId, int sortBy ,ProductParams p)
        //public string GetProductsList(ProductParams p)
        {
            try
            {
                DAOProduct objproduct = new DAOProduct();
               // p.Sizes
                //return objproduct.GetAllProductsByCategoryId(CategoryId, colorCodes, sizes, LowPrice, HighPrice, OfferTypeId, StartIndex, EndIndex, sortby);
                return objproduct.GetAllProductsByCategoryId(CatId, ClsGeneral.getInt32(p.StartIndex), ClsGeneral.getInt32(p.EndIndex), membershipId, sortBy);
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

        [WebMethod(Description = "Save User View Products & get Count",EnableSession=true)]        
        public int SaveUserViewProducts(int productid, int attrId, string MembershipId, int viewType, int qty)
        {
            string  CurrentSeesionId = System.Web.HttpContext.Current.Session["CurrentSessionId"].ToString();
            DAOUsers objUsers = new DAOUsers();
            int count = objUsers.SaveUserViewProducts(productid, attrId, MembershipId, viewType, qty, CurrentSeesionId);
            return count;
        }

        [WebMethod(Description = "Save User lookbook Products & get Count",EnableSession=true)]
        public int SaveLookBook(string  productids, string attrIds, string MembershipId, int viewType, int qty)
        {
            string CurrentSeesionId = System.Web.HttpContext.Current.Session["CurrentSessionId"].ToString();
            DAOUsers objUsers = new DAOUsers();
            int count = objUsers.SaveLookBook(productids, attrIds, MembershipId, viewType, qty, CurrentSeesionId);
            return count;
        }
        [WebMethod(Description = "Check Valid Redeem points Details", EnableSession = true)]
        public int CheckValidRedeemDetails(string MembershipId, int redeemPoints, int gtotal)
        {
            Session["redeemPoints"] = redeemPoints;
            Session["gtotal"] = gtotal;
            return 1;
        }
              
        [WebMethod(Description = "UPDATE QTY")]
        public int UpdateQntProduct(int viewId,int qty)
        {
            DAOUsers objUsers = new DAOUsers();
            int count = objUsers.UpdateQntProduct(viewId, qty);
            return count;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [WebMethod]
        public List<string> GetCompletionList(string prefixText, int count)//, int count)
        {
           // string[] products;
            List<string> products = new List<string>();
            int a = 0;
            try
            {
                DAOProduct objproduct = new DAOProduct();
                DataTable dtSearch= objproduct.GetSearchResults(prefixText,count);
               // products = new string[dtSearch.Rows.Count];
                foreach (DataRow dr in dtSearch.Rows)
                {
                    string item = AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(dr["ProductCode"].ToString().Trim(), dr["productId"].ToString().Trim());
                   // products[a] = dr["ProductCode"].ToString().Trim();
                   // a++;
                    products.Add(item);
                }      
            }
            catch
            {
                throw;
            }
            return products;
        }


        [WebMethod(Description = "Get Product Id By Code")]
        public string GetProductIdByCode(string productCode)
        {
            try
            {
                DAOProduct objproduct = new DAOProduct();
                string prodId = objproduct.GetProductIdByCode(productCode);
                return prodId;
            }
            catch
            {
                throw;
            }
        }


    }
  }
