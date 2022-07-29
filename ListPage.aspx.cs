using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;


namespace StaffGrid
{
    public partial class StaffGrid : System.Web.UI.Page
    {
        //Initializing some variables

        public List<Staff> list = new List < Staff >{new Staff()};
        public int currentPageIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Upon page load, generate an array of 1000 Staff members

            string[] nameArr = { "Edgar Barber", "Marquis Reilly", "Isabell Frank", "Issac Hammond", "Aydan Mcclain", "Daphne Burke", "Mia Duarte", "Phoebe Mcclain", "Dayana Massey", "Maxwell Zhang", "Keith Pineda", "Dustin Camacho", "Alyvia Lam", "Justice Mata", "Alissa Bautista", "Laura Wade", "Howard Flynn", "Marques Wilcox", "Taryn Wang", "Caden Potts" };
            string[] roleArr = { "IT Coordinator", "Technical writer", "Data Analyst", "Web Developer", "Systems Analyst", "IT Analyst", "SQA Engineer", "System Administrator", "Business intelligence analyst", "Software Architect", ".NET Developer", "UX Designer", "Product Manager", "Database Administrator", "Data Scientist", "Computer Programmer", "Application analyst", "Web Developer", "Java Developer", "Application developer" };
            string[] addressArr = { "753, Schinner Lake", "15504, O'Kon Plaza", "10281, Moore Island", "58552, Fermin Harbors", "786, Schmitt Crescent", "4028, Swaniawski Pass", "12616, Allison Inlet", "19745, Emily Street", "5733, Winifred Motorway", "678, McClure Course" };
            List<Staff> staffList = new Staff().StaffGenerator(nameArr, roleArr, addressArr, 1000);
            
            if(!IsPostBack)
            {
                //if its first time, initialize session
                list = staffList;
                Session["staffList"] = list;

                currentPageIndex = 0;
                Session["index"] = currentPageIndex;
                Session["pageSize"] = 15;
                UpdateTable();


            }
            else
            {
                //else use session variables
                 list = (List<Staff>)Session["staffList"];
                Session["index"] = staffGrid.PageIndex;
                 currentPageIndex = Convert.ToInt32(Session["index"]);

               
            }

            
           

        }

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Change the pageindex & update session & table
            staffGrid.PageIndex = e.NewPageIndex;
            Session["index"] = e.NewPageIndex;
            Session["pageSize"] = staffGrid.PageSize;


            UpdateTable();
           
        }

        protected void UpdateTable()
        {
            //Uses session list to bind table
            staffGrid.DataSource = Session["staffList"];
            staffGrid.DataBind();
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Removes the clicked list item & updates the table 

            int size = Convert.ToInt32(Session["pageSize"]);
            list.RemoveAt(currentPageIndex * size + e.RowIndex);
            UpdateTable();
            
           
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            //get the event row index
            staffGrid.EditIndex = e.NewEditIndex;
            //Bind data to the GridView control.
            UpdateTable();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //resets the index
            staffGrid.EditIndex = -1 ;
            UpdateTable();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //Gets the row on which event occured & updates the values 
            int size = Convert.ToInt32(Session["pageSize"]);
            int index = currentPageIndex * size + e.RowIndex;

            Staff selected = list[index];

            selected.Name = e.NewValues["Name"].ToString();
            selected.Role = e.NewValues["Role"].ToString();

            Session["staffList"] = list;


            ////Reset the edit index.
            staffGrid.EditIndex = -1;

            ////Bind data to the GridView control.
            UpdateTable();
        }
        protected void onselectedindexchanging(Object sender, GridViewSelectEventArgs e)
        {
            //Get the object that is selected, from the list, stores in session & redirects
            int size = Convert.ToInt32(Session["pageSize"]);
            int index = currentPageIndex * 15 + e.NewSelectedIndex;

            Staff selected = list[index];
            Session["viewField"] = selected;

            Response.Redirect("Details.aspx");

        }

        protected void Search(object sender, EventArgs e)
        {
            //Searches for all the objects where the name matches query & displays them on new page 

            string query = search.Text;
            List<Staff> searchResults = new List<Staff> { new Staff() };

            foreach (Staff obj in list)
            {
                if(obj.Name == query)
                {
                    searchResults.Add(obj);
                }
            }

            Session["search"] = searchResults;
            Response.Redirect("SearchResults.aspx");
        }
    }   
        
}