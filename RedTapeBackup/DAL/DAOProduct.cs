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

        /// <summary>
        /// GetAllProductsByCategoryId
        /// </summary>
        /// <parameters> categoryId,productId(optional=0)</parameters>
        /// <returns>1-Product Details Table,2- Product Images Table</returns>

        /// 
        //public  DataSet GetAllProductsByCategoryId()
        //{
        //    return MsAppDataUtility.ExecuteDataset("sp_GetAllProductsByCategoryId", , objProduct..prductId);
        //}  


    }
}
