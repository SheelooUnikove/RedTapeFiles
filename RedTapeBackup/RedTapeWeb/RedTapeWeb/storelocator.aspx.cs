using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RedTapeWeb
{
    public partial class storelocator : System.Web.UI.Page
    {
        
        DAOUsers objDAOUsers = new DAOUsers();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindStoreLocations();
            }
        }

        private void BindStoreStates(List<string> states)
        {
            drp_States.DataSource = states;
            drp_States.DataBind();
        }

        private void BindStoreCities(List<string> cities)
        {
            drp_Cities.DataSource = cities;
            drp_Cities.DataBind();
        }

        public void BindStoreLocations()
        {
            DataTable dtStores = objDAOUsers.GetStoreLocations();
            rpt_Stores.DataSource = dtStores;
            rpt_Stores.DataBind();

            List<string> states = dtStores.AsEnumerable().Select(r => r.Field<string>("state")).Distinct().ToList();
            List<string> cities = dtStores.AsEnumerable().Select(r => r.Field<string>("city")).Distinct().ToList();


            states.Insert(0, "Select All");
            cities.Insert(0, "Select All");


            BindStoreStates(states);
            BindStoreCities(cities);
            citiesContainer.Visible = false;

            hfZoom.Value = "5";
            hfCenterLat.Value = "23.237007";
            hfCenterLong.Value = "77.408515";
        }

        protected void drp_Cities_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtStores = objDAOUsers.GetStoreLocations();
            string state = drp_States.SelectedValue;
            string city = drp_Cities.SelectedValue;
            DataView dv = new DataView(dtStores);
            if (state != "Select All")
            {
                dv.RowFilter = "state='" + state + "'";
            }
            if (city != "Select All")
            {
                dv.RowFilter = "city='" + city + "'";
            }
            
            rpt_Stores.DataSource = dv;
            rpt_Stores.DataBind();
        }

        protected void drp_States_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            DataTable dtStores = objDAOUsers.GetStoreLocations();
            string state = drp_States.SelectedValue;
            string city = drp_Cities.SelectedValue;

            if (state == "Select All")
            {
                rpt_Stores.DataSource = dtStores;
                rpt_Stores.DataBind();
                citiesContainer.Visible = false;

            }
            else
            {
                DataView dv = new DataView(dtStores);
                if (state != "Select All")
                {
                    dv.RowFilter = "state='" + state + "'";
                }
                if (city != "Select All")
                {
                    dv.RowFilter = "city='" + city + "'";
                }
                hfZoom.Value = "6";
                DataTable dtFilteredStores = dv.ToTable();
                hfCenterLat.Value = dtFilteredStores.Rows[0]["latitude"].ToString();
                hfCenterLong.Value = dtFilteredStores.Rows[0]["longitude"].ToString();
                rpt_Stores.DataSource = dtFilteredStores;
                rpt_Stores.DataBind();
                citiesContainer.Visible = true;

                List<string> cities = dtFilteredStores.AsEnumerable().Select(r => r.Field<string>("city")).Distinct().ToList();
                cities.Insert(0, "Select All");
                BindStoreCities(cities);
            }

           /* int zoom = 6;
            decimal centerLat = Convert.ToDecimal(hfCenterLat.Value);
            decimal centerLong = Convert.ToDecimal(hfCenterLong.Value);
            string script =   "google.maps.event.addDomListener(window, 'load', initialize("+centerLat+","+centerLong+","+zoom+"))";
             this.Page.ClientScript.RegisterStartupScript(this.GetType(), "a", script);*/
        }
    }
}