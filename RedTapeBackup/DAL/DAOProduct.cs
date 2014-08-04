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

        /// GetCategories
        /// </summary>
        /// <parameters> 0 for All</parameters>
        /// <returns></returns>
        public  List<BAOProductMenu> GetProductMenu(int CategoryId)
        {
            return Mapper.ToProductMenuListing(MsAppDataUtility.ExecuteDataset("sp_GetProductsleftMenu", CategoryId));

        }

        /// <summary>
        /// GetAllProductsByCategoryId
        /// </summary>
        /// <parameters> categoryId,productId(optional=0)</parameters>
        /// <returns>1-Product Details Table,2- Product Images Table</returns>
        public List<BAOProduct> GetAllProductsByCategoryId(int CategoryId, string colorCodes, string sizes, int LowPrice, int HighPrice, string OfferTypeId, int StartIndex, int EndIndex,string sortby)
        {
            return Mapper.ToProductListing(MsAppDataUtility.ExecuteDataTable("sp_GetProductsList", CategoryId, colorCodes, sizes, LowPrice, HighPrice, OfferTypeId, StartIndex, EndIndex,sortby));
        }  


    }
}
