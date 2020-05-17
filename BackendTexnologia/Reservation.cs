using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Reservation
    {
        private string dateOfDeparture;
        private string dateOfArrival;
        private double totalAmountOfMoney;
        private bool freeChangeToDates;

        public string retrieveReservations()
        {
            {

                //otan thelei na kanei allagi kratisis to sustima epikoinwnei me tin vasi dedomenwn twn kratisew kai anakta oles tis kratiseis pou exei kanei o xristis
                //endeiktikes entoles gia to pws tha mporouse na ginei enas elegxos sti vasi gia ta reservations
                bool check = false;
                try
                {
                    string reserv;
                    string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=leafletdb";
                    MySqlConnection cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    //Vazw ws onoma sto select na pairnei to id tou sugekrimenou xristi gia tin sugkekrimeni kratisi
                    //epeidi ola ta stoixeia tou user apothikeuontai sti vasi kai antistoixa ginontai select gia opoiondipote elegxo 
                    //apo tin klasi User mporoume na metaferoume to userid xrisimopoiontas session
                    //kai meta na apothikeusoume to session se mia metabliti pou tha tin onomasoume userID

                    string userid;
                    //tha prepei na uparxei ena table xexwristo gia tis kratiseis aspoume oti legetai reservations opou kai auti tha kleironomei to userid tou xristi etsi wste na 
                    //mporei na pairnei ta stoixeia tis kratisis tou sugekrimenou xristi
                    //to userid tha pernietai se auti ti selida me session
                    string sql = "Select reservation from reservations where userid='" + userid+ "'";
                    MySqlCommand command = new MySqlCommand(sql, cnn);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        if (dataReader[0].ToString() == InsertUserName)
                        {
                            check = true;
                        }
                    }
                }
                catch
                {
                    check = true;
                }
                return check;
            }

        }

        public bool checkAvailability()
        {
            //elegxoume sti vasi me select an uparxei diathesimotita opws kai stin retrieveReservations()

        }

        public bool saveReservation()
        {
            //edw tha ginetai xana sundesi me ti vasi kai tha apothikeuontai oi kratiseis sti vasi me insert
            //sto sugekrimeno simeio ginetai arketa periploko
            //kathws exartatai apo to sxediasmo tis vasis gia to pws tha ginei to insert gia kathe sugekrimeno xristi 
            //me to sugekrimeno id tou
            //se auto to simeio arxizoun ta diafora tables tis vasis na sundeontai metaxu tous pairnontas gia paradeigma
            //to id enos xristi kai me vasei auto na antistoixizei kai na vriskei kai alles plirofories apo alla tables

        }

        public bool saveReservationChange()
        {
            //einai bool giati theloume na mathoume apo tin epistrofi tis metablitis an ontws egine save sti vasi i kratisi
            //kai tha exoume try catch gia pithana errors sti vasi dedomenwn
        }

        //edw analoga me to an exei ginei kratisi tote tha kaleitai pali i methodos increasePoints() gia na parei extra pontous apo tin kratisi

        public static void Points() // dimiourgoume ena event apo ta asp buttons ston designer
        {
            // tha kalei edw mesa ti methodo increasePoints apo tin klasi Points
            //endeiktikes entoles
            string increase;
            Points inc = new Points();
            Increase = inc.increasePoints();//mesa stin parenthesi xreiazontai orismata, analoga ti pairnei i methodos increase
        }
    }

}