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
                CatItem.Description = dr["description"].ToString();
                Categories.Add(CatItem);
            }
            return Categories;

        }

        public static List<ProductDetails> ToProductDetails(DataSet ds)
        {
            List<BAOProduct> Productlst = new List<BAOProduct>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BAOProduct productItem = new BAOProduct();
                productItem.ProductId = ClsGeneral.getInt32(dr["productId"].ToString());
                productItem.CategoryId = ClsGeneral.getInt32(dr["categoryId"].ToString());
                productItem.Category = dr["Category"].ToString();
                productItem.SkuID = ClsGeneral.getInt32(dr["skuID"].ToString());
                productItem.ProductTitle = dr["ProductTitle"].ToString();
                productItem.Description = dr["description"].ToString();
                productItem.ShortDescription = dr["Shortdescription"].ToString();
                productItem.ProductCode =   dr["ProductCode"].ToString();
                productItem.MSRP = dr["mSRP"].ToString();
                productItem.SalePrice = ClsGeneral.getInt32(dr["salePrice"].ToString());
                productItem.ColourCode = dr["colourCode"].ToString();
                productItem.Colour = dr["colour"].ToString();
                productItem.Weight = dr["weight"].ToString();
                productItem.GroupId = ClsGeneral.getInt32(dr["GroupId"].ToString());
                productItem.TaxAppliedPercentage = float.Parse(dr["categoryId"].ToString());
                productItem.Quantity = ClsGeneral.getInt32(dr["quantity"].ToString());
                productItem.IsAvailableFor = ClsGeneral.getInt32(dr["availableFor"].ToString());
                productItem.NewArrival = ClsGeneral.getInt32(dr["newArrival"].ToString());
                productItem.Rating = ClsGeneral.getInt32(dr["rating"].ToString());


                Productlst.Add(productItem);
            }
            
            //start from here
            List<BAOAttributes> AttributesSizelst = new List<BAOAttributes>();
            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                BAOAttributes BAOAttributesItem = new BAOAttributes();
                BAOAttributesItem.AttributeValue = dr["attributeValue"].ToString();
                AttributesSizelst.Add(BAOAttributesItem);
            }


            List<BAOImageURL> BAOImglst = new List<BAOImageURL>();
            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                BAOImageURL BAOImagesItem = new BAOImageURL();
                BAOImagesItem.imageId = ClsGeneral.getInt32(dr["imgId"].ToString());
                BAOImagesItem.imageURL = dr["ImgUrl"].ToString();
                BAOImglst.Add(BAOImagesItem);

            }


            List<ProductDetails> ProductDetailslst = new List<ProductDetails>();
            ProductDetails ProductDetailItem = new ProductDetails();
            ProductDetailItem.ProductDeatilslst = Productlst;
            ProductDetailItem.Sizelst =AttributesSizelst;
            ProductDetailItem.ProductImageURLlst = BAOImglst;
            ProductDetailslst.Add(ProductDetailItem);
            return ProductDetailslst;

        }

        public static List<BAOProductMenu> ToProductMenuListing(DataSet ds)
        {
            List<BAOCategory> Categorieslst = new List<BAOCategory>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                BAOCategory CatItem = new BAOCategory();

                CatItem.CategoryId = Convert.ToInt32(dr["pId"]);
                CatItem.SubCategoryId = Convert.ToInt32(dr["categoryId"]);
                CatItem.Category = dr["category"].ToString();
                CatItem.SubCategory = dr["subCategory"].ToString();
                CatItem.Description = dr["description"].ToString();

                Categorieslst.Add(CatItem);
            }

            //List<BAOColourCodes> ColourCodeslst = new List<BAOColourCodes>();

            //foreach (DataRow dr in ds.Tables[1].Rows)
            //{
            //    BAOColourCodes ColourItem = new BAOColourCodes();
            //    ColourItem.ColourCode = dr["colourCode"].ToString();
            //    ColourCodeslst.Add(ColourItem);
            //}


            List<BAOAttributesType> AttributesTypelst = new List<BAOAttributesType>();

            foreach (DataRow dr in ds.Tables[1].Rows)
            {
                BAOAttributesType AttrTypeItem = new BAOAttributesType();
                AttrTypeItem.AttributeId = ClsGeneral.getInt32(dr["attributeId"].ToString());
                AttrTypeItem.AttributeTitle = dr["attributeTitle"].ToString();
                AttributesTypelst.Add(AttrTypeItem);

            }

            List<BAOAttributes> Attributeslst = new List<BAOAttributes>();

            foreach (DataRow dr in ds.Tables[2].Rows)
            {
                BAOAttributes AttrItem = new BAOAttributes();
                AttrItem.AttributeId = ClsGeneral.getInt32(dr["attributeId"].ToString());
                AttrItem.AttributeValue = dr["attributeValue"].ToString();
                AttrItem.AttributeTitle = dr["attributeTitle"].ToString();
                Attributeslst.Add(AttrItem);

            }

            List<BAOMinMaxSliderVals> MinMaxlst = new List<BAOMinMaxSliderVals>();

            foreach (DataRow dr in ds.Tables[3].Rows)
            {
                BAOMinMaxSliderVals BAOSliderItem = new BAOMinMaxSliderVals();
                BAOSliderItem.MinVal = Convert.ToInt32(dr["minvalue"]);
                BAOSliderItem.MaxVal = Convert.ToInt32(dr["maxvalue"]);

                MinMaxlst.Add(BAOSliderItem);

            }

            List<BAOOffers> Offerslst = new List<BAOOffers>();

            foreach (DataRow dr in ds.Tables[4].Rows)
            {
                BAOOffers offerItem = new BAOOffers();
                offerItem.offerId = Convert.ToInt32(dr["offerId"]);
                offerItem.offerTitle = dr["offerTitle"].ToString();
                offerItem.percentage = Convert.ToInt32(dr["percentage"]);
                Offerslst.Add(offerItem);

            }

            List<BAOProductMenu> productMenulst = new List<BAOProductMenu>();
            BAOProductMenu PrdMenuItem = new BAOProductMenu();
            PrdMenuItem.Categorylst = Categorieslst;
            PrdMenuItem.AttributesTypelst = AttributesTypelst;
            PrdMenuItem.Attributeslst = Attributeslst;            
            PrdMenuItem.MinMaxVals = MinMaxlst;
            PrdMenuItem.Offerslst = Offerslst;
            productMenulst.Add(PrdMenuItem);
            return productMenulst;

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
               // productItem.MetarialTypeId = ClsGeneral.getInt32(dr["metarialTypeId"].ToString());
                productItem.MSRP =dr["mSRP"].ToString();
                productItem.SalePrice = ClsGeneral.getInt32(dr["salePrice"].ToString()); 
                productItem.ColourCode =  dr["colourCode"].ToString();
                productItem.Colour= dr["colour"].ToString();
                productItem.Weight = dr["weight"].ToString();
                productItem.GroupId = ClsGeneral.getInt32(dr["GroupId"].ToString());
                productItem.TaxAppliedPercentage = float.Parse(dr["categoryId"].ToString());
                productItem.Quantity = ClsGeneral.getInt32(dr["quantity"].ToString());
                productItem.IsAvailableFor = ClsGeneral.getInt32(dr["availableFor"].ToString());
                productItem.NewArrival =ClsGeneral.getInt32(dr["newArrival"].ToString());
                productItem.Rating = ClsGeneral.getInt32(dr["rating"].ToString());
                
                
                productList.Add(productItem);
            }
            return productList;

        }

    }
}
