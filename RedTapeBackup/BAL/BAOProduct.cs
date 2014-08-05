using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
namespace BAL
{

    public class BAOProductMenu
    {
        public List<BAOCategory> Categorylst { get; set; }
        public List<BAOColourCodes> ColourCodeslst { get; set; }
        public List<BAOAttributes> Attributeslst { get; set; }
        public List<BAOMinMaxSliderVals> MinMaxVals { get; set; }
        public List<BAOOffers> Offerslst { get; set; }
    }

    public class BAOProduct
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int SkuID { get; set; }
        public string ProductTitle { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }      
        public string MSRP { get; set; }
        public int SalePrice { get; set; }
        public string ColourCode { get; set; }
        public string Colour { get; set; }
        public string Weight { get; set; }
        public int GroupId { get; set; }
        public float TaxAppliedPercentage { get; set; }
        public int Quantity { get; set; }
        public int IsAvailableFor { get; set; }// 1=AVailable,2=sale,3=outofstock
        public int NewArrival { get; set; }
        public int Rating { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    


    }

    public class BAOCategory
    {
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public String Category { get; set; }
        public String SubCategory { get; set; }
        public String Description { get; set; }
    }

    public class BAOColourCodes
    {        
        public String ColourCode { get; set; }       

    }

    public class BAOAttributes
    {
       // public int AttributeId { get; set; }
        public String AttributeValue { get; set; }

    }
    public class BAOMinMaxSliderVals
    {
        public int MinVal{ get; set; }
        public int MaxVal { get; set; } 

    }
     public class BAOOffers
    {
        public int offerId{ get; set; }
        public string offerTitle { get; set; }
        public int percentage { get; set; }

    }
}
