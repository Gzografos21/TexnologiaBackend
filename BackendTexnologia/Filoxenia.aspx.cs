using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TexnologiaProject
{
    public partial class Filoxenia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button113441_Click(object sender, EventArgs e)
        {
            //testing NO.1
            //User users = new User();
            //List<string> asd = new List<string>();
            //asd = users.getUsers();
            //this.Label1.Text = "id: " + asd[0] + "<br>";
            //this.Label2.Text = "Name:" + asd[1] + "<br>";
            //this.Label3.Text = asd[2];
            //this.Label4.Text = asd[3];
            //this.Label5.Text = asd[4];
            //this.Label6.Text = asd[5];

            //estw oti ta stoixeia pou vazei o xristis einai ta parakatw
            //ta apothikeuoume san default times gia na apodeixoume ti leitourgikotita metaxu twn klassewn UploadedRoomsToFiloxenia kai Points (kai diafores methodoi apo autes)

            //string city = "athens";
            int userID = 1;
            string city = txtCity.Text;
            string country = txtCountry.Text;
            //int persons = 1;
            int persons = Convert.ToInt32(txtPersons.Text);
            //double squareMeters = 14;
            double squareMeters = Convert.ToDouble(txtSquare.Text);
            //string startingDateString = txtStartingDate.Text;
            //DateTime startingDate = DateTime.ParseExact(startingDateString, "MM/dd/yyyy", null);

            DateTime startingDate = new DateTime(2020, 02, 02);
            DateTime endingDate = new DateTime(2020, 02, 02);

            string information = txtInfo.Text;
            string uploadedPhotos = "";//estw oti metatrepoume tis fwtografies se string
            bool photos = true;//estw oti exw anebasei o xristis fwtografia(to pairnoume apo to frontend me kapoion tropo)
                               // Session["userid"] = userID; (kapws etsi tha pairname to userID mesa apo tis diafores selides--den xrisimopoieitai--)

            UploadedRoomsToFiloxenia save = new UploadedRoomsToFiloxenia();
            bool ad = false;

            ad = save.saveRoomToUploadedRoomsToFiloxenia(userID, city, country, persons, squareMeters, startingDate, endingDate, information, photos, uploadedPhotos);
            if (ad)
            {
                try
                {
                    bool lastcheck = false;
                    UploadedRoomsToFiloxenia points = new UploadedRoomsToFiloxenia();

                    lastcheck = points.IncreasePointsUploadRoom(userID, city, country, persons, squareMeters, startingDate, endingDate, information, photos, uploadedPhotos);
                    if (lastcheck == true)
                    {
                        this.Label1.Text = "Your room has been uploaded succesfully";
                        this.Label2.Text = "You won 10000 points";

                        List<int> PointTable = new List<int>();
                        Points pointclass = new Points();

                        PointTable = pointclass.getUsersPoints(userID);
                        int userspoints = 0;
                        userspoints = PointTable[1];

                        this.Label3.Text = "Your total points are " + userspoints ;
                    }
                    else
                    {
                        this.Label1.Text = "Your room can't be uploaded";
                    }

                }
                catch (Exception ex)
                {
                    this.Label1.Text = "Something went wrong";

                }
            }
            else
            {
                this.Label1.Text = "Something went wrong";

            }




        }
    }
}
