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
        public static List<BAOProduct> ToProductListing(DataTable dt)        
        {
            List<BAOProduct> productList = new List<BAOProduct>();
            foreach (DataRow dr in dt.Rows)
            {
                BAOProduct productItem = new BAOProduct();
                productItem.ProductId = ClsGeneral.getInt32(dr["productId"].ToString());
                productItem.CategoryId = ClsGeneral.getInt32(dr["categoryId"].ToString());
                productItem.SkuID = ClsGeneral.getInt32(dr["skuID"].ToString());
                productItem.ProductTitle =dr["ProductTitle"].ToString();
                productItem.Description = dr["description"].ToString();
                productItem.ShortDescription = dr["Shortdescription"].ToString();
                productItem.MetarialTypeId = ClsGeneral.getInt32(dr["metarialTypeId"].ToString());
                productItem.MSRP =dr["mSRP"].ToString();
                productItem.SalePrice = ClsGeneral.getInt32(dr["salePrice"].ToString()); 
                productItem.ColourCode =  dr["colourCode"].ToString();
                productItem.Colour= dr["colour"].ToString();
                productItem.Weight = dr["weight"].ToString();
                productItem.GroupId = ClsGeneral.getInt32(dr["GroupId"].ToString());
                productItem.TaxAppliedPercentage = float.Parse(dr["categoryId"].ToString());
                productItem.Quantity = ClsGeneral.getInt32(dr["quantity"].ToString());
                productItem.AvailableFor = ClsGeneral.getInt32(dr["availableFor"].ToString());
                productItem.NewArrival =ClsGeneral.getInt32(dr["newArrival"].ToString());
                productItem.Rating = ClsGeneral.getInt32(dr["rating"].ToString());
                
                
                productList.Add(productItem);
            }
            return productList;

        }

    }
}
