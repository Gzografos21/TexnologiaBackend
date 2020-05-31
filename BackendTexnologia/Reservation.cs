using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Reservation
    {
        private DateTime dateOfDeparture;
        private DateTime dateOfArrival;
        private bool freeChangeToDates; //giorgos

        string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";

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

        public abstract List <string> returnAvailable() 
        {
 
        }

        public abstract string getListAll()  
        {

        }
        public abstract bool saveReservation()
       
    
    }

}