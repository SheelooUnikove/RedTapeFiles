using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
namespace BAL
{
    class Mapper
    {
        public static List<BAOCategory> ToListing(DataTable dt)
        {
            List<BAOCategory> Categories = new List<BAOCategory>();

            foreach (DataRow dr in dt.Rows)
            {
                BAOCategory CatItem = new BAOCategory();

                CatItem.CategoryId = Convert.ToInt32(dr["pId"]);
                CatItem.SubCategoryId = Convert.ToInt32(dr["categoryId"]);
                CatItem.Category = dr["category"].ToString();
                CatItem.SubCategory = dr["subCategory"].ToString();
                Categories.Add(CatItem);
            }
            return Categories;

        }
        public static List<BAOProduct> ToProductsListing(DataTable dt)
        {
            List<BAOProduct> productList = new List<BAOProduct>();

            foreach (DataRow dr in dt.Rows)
            {
                BAOProduct productItem = new BAOProduct();

                productItem.ProductId = Convert.ToInt32(dr["categoryId"]);
                productItem.CategoryId =Convert.ToInt32(dr["category"]);
                productItem.SkuID = Convert.ToInt32(dr["skuId"].ToString());
                productItem.ProductTitle =dr["ProductTitle"].ToString();
                productItem.Description = dr["description"].ToString();
                productItem.ShortDescription = dr["shortDescription"].ToString();
                productItem.MetarialTypeId = Convert.ToInt32(dr["metarialTypeId"]);
                productItem.MSRP =dr["mSRP"].ToString();
                productItem.SalePrice =Convert.ToInt32(dr["salePrice"]); 
                productItem.ColourCode =  dr["colourCode"].ToString();
                productItem.Colour= dr["colour"].ToString();
                productItem.Weight = dr["weight"].ToString();
                productItem.GroupId = Convert.ToInt32(dr["GroupId"]);
                productItem.TaxAppliedPercentage = float.Parse(dr["categoryId"].ToString());
                productItem.Quantity = Convert.ToInt32(dr["quantity"]);
                productItem.AvailableFor = Convert.ToInt32(dr["availableFor"]);
                productItem.NewArrival = Convert.ToInt32(dr["newArrival"]);
                productItem.Rating = Convert.ToInt32(dr["rating"]);
                
                
                productList.Add(productItem);
            }
            return productList;

        }

    }
}
