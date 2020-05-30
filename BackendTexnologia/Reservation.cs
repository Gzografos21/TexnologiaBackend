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
        private bool freeChangeToDates;

        public List<string> retrieveReservations(string userID)//to userID to pairnoume kathe fora metaxu twn selidwn me session
        {
            {
                //endeiktikes entoles gia to pws tha mporouse na ginei enas elegxos sti vasi gia ta reservations
                bool check = false;
                //exoume mia upothetiki vasi pou onomazetai TexnologiaVasi
                //tha kanoume 4 select sta 4 upothetika tables: reservedTickets, reservedHostels, reservedRoomsToFiloxenia, reservedTravelPackages



                //1o select gia tin reservedTickets


                List<string> listAll = new List<string>();
                try
                {
                    //theloume gia paradeigma na paroume ta stoixeia tis kratisis EISITIRIOU enos sugekrimenou xristi
                    //tote tha mpoume sto table reservedTickets kai tha paroume ola ta dedomena me select gia to sugekrimeno userid
                    
                    string reserv;
                    string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";
                    MySqlConnection cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    //Vazw ws onoma sto select na pairnei to id tou sugekrimenou xristi gia tin sugkekrimeni kratisi
                    //epeidi ola ta stoixeia tou user apothikeuontai sti vasi kai antistoixa ginontai select gia opoiondipote elegxo 
                    //apo tin klasi User mporoume na metaferoume to userid xrisimopoiontas session
                    //kai meta na apothikeusoume to session se mia metabliti pou tha tin onomasoume userID

                    string sql = "Select  * from reservedTickets where userid='" + userID + "'";
                    MySqlCommand command = new MySqlCommand(sql, cnn);
                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        listAll.Add(dataReader[0].ToString());
                    }

                    cnn.Close();//edw kleinoume ti sindesi me ti vasi

                    return listAll;

                }
                catch
                {
                    listAll = "Error";
                    return listAll;
                }

                //2o select gia tin reservedHostels
                //omoiws gia ta upoloipa selects me ta antistoixa tous orismata
                
                
            }

        }

        public abstract bool checkAvailability() //givrgos
        {
 
        }

        public abstract bool displayResults()  //giorgos
        {

        }
        public abstract bool saveReservation()
        {
            //edw tha ginetai xana sundesi me ti vasi kai tha apothikeuontai oi kratiseis sti vasi me insert
            //sto sugekrimeno simeio ginetai arketa periploko
            //kathws exartatai apo to sxediasmo tis vasis gia to pws tha ginei to insert gia kathe sugekrimeno xristi 
            //me to sugekrimeno id tou
            //se auto to simeio arxizoun ta diafora tables tis vasis na sundeontai metaxu tous pairnontas gia paradeigma
            //to id enos xristi kai me vasei auto na antistoixizei kai na vriskei kai alles plirofories apo alla tables

        }

        //edw analoga me to an exei ginei kratisi tote tha kaleitai pali i methodos increasePoints() gia na parei extra pontous apo tin kratisi

  
          
    }

}