using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using BAL;
namespace DAL
{
    public class DAOProduct
    {
       // BAOProduct objProduct = new BAOProduct();
        
               /// <summary>
        /// GetCategories
        /// </summary>
        /// <parameters> 0 for All</parameters>
        /// <returns></returns>
        public  List<BAOCategory> GetCategories(int CategoryId)
        {
            return Mapper.ToListing(MsAppDataUtility.ExecuteDataTable("sp_GetProductsCategory", CategoryId));

        }

        /// Get Product Menu
        /// </summary>
        /// <parameters> 0 for All</parameters>
        /// <returns></returns>
        public List<BAOProductMenu> GetProductMenu(int CategoryId, int SubCategoryId)
        {
            return Mapper.ToProductMenuListing(MsAppDataUtility.ExecuteDataset("sp_GetProductsleftMenu", CategoryId, SubCategoryId));
        }
        /// GetCategories
        /// </summary>
        /// <parameters> 0 for All</parameters>
        /// <returns></returns>
        public List<ProductDetails> GetProductDetails(int CategoryId, int ProductID)
        {
            return Mapper.ToProductDetails(MsAppDataUtility.ExecuteDataset("sp_GetProductDetails",ProductID));
        }
        public DataTable GetProductFullDetails(int CategoryId, int ProductID)
        {
            return MsAppDataUtility.ExecuteDataset("sp_GetProductDetails", ProductID).Tables[0];
        }
        /// <summary>
        /// GetAllProductsByCategoryId
        /// </summary>
        /// <parameters> categoryId,productId(optional=0)</parameters>
        /// <returns>1-Product Details Table,2- Product Images Table</returns>
       // public List<BAOProduct> GetAllProductsByCategoryId(int CategoryId, string colorCodes, string sizes, int LowPrice, int HighPrice, string OfferTypeId, int StartIndex, int EndIndex,string sortby)
        public List<BAOProduct> GetAllProductsByCategoryId(int CategoryId, int StartIndex, int EndIndex,int membershipId, int sortBy)
        {
            //return Mapper.ToProductListing(MsAppDataUtility.ExecuteDataTable("sp_GetProductsList", CategoryId, colorCodes, sizes, LowPrice, HighPrice, OfferTypeId, StartIndex, EndIndex,sortby));
            return Mapper.ToProductListing(MsAppDataUtility.ExecuteDataTable("sp_GetProductsListByCat", CategoryId, StartIndex, EndIndex, membershipId, sortBy));
        }  
        /// <summary>
        /// Get All pairedup products
        /// </summary>
        public DataTable GetAllPairProducts(int ProductId)        {
            return MsAppDataUtility.ExecuteDataTable("sp_GetProductPairWith", ProductId);
        }

        /// <summary>
        /// Get All pairedup products
        /// </summary>
        public DataTable GetAllAlsoLikeItems(int ProductId)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_GetProductAlsoLike", ProductId);
        }  

        /// <summary>
        /// Get All Colors products
        /// </summary>
        public DataTable GetAllColors(int ProductId)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_GetProductColorAvail", ProductId);
        }

        /// <summary>
        /// GetLooks
        /// </summary>
        public DataSet GetLooks(int lookid)
        {
            return MsAppDataUtility.ExecuteDataset("sp_GetLooks", lookid);
        }

        public DataSet GetNewArrivals(BAOUsers objBAOUsers)
        {
            return MsAppDataUtility.ExecuteDataset("sp_GetNewArrivals",objBAOUsers.Membership_No);
        }


        /// <summary>
        /// Get All Search products
        /// </summary>
        public DataTable GetSearchResults(string prefixText, int count)
        {
            return MsAppDataUtility.ExecuteDataTable("sp_GetProductSearch", prefixText, count,"");
        }

        /// <summary>
        /// Get Product Id from code
        /// </summary>
        public string GetProductIdByCode(string productCode)
        {
            DataTable dt = MsAppDataUtility.ExecuteDataTable("sp_GetProductIdByCode", productCode);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            else
            {
                return String.Empty;
            }
            
        } 
    }
}
