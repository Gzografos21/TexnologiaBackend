using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BackendTexnologia
{
    public class Tickets : Reservation
    {

        private string placeOfDeparture;
        private string placeOfArrival;
        private string travelMethod;
        private string company;
        private double priceOfDepartureTickets;
        private double priceOfArrivalTickets;
        private int earnedPointsTickets;


        string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";//to bgazw apexw gia na mporw na to xrisimopoiw kathe fora pou xreiazetai na anoixw ti vasi


        //i exwteriki vasi dedomenvn tvn eisitirivn tha exei sthles ticketID(primary key), userID(foreign key), Departure, Arrival, DepartureDate, ArrivalDate, DeparturePrice, ArrivalPrice, Company, TravelMethod
        public List<string> returnAvailable(string placeOfDeparture, string placeOfArrival, string travelMethod, DateTime dateOfDeparture, DateTime dateOfArrival)
        {
            List<string> listAll = new List<string>();//orizoume mia keni lista opou mesa tha apothikeusoume ta dedomena twn diathesimwn eisitiriwn

           
            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
                cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                           //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
                string sql = "Select Departure, Arrival, DepartureDate, ArrivalDate, DeparturePrice, ArrivalPrice, Company, TravelMethod from Tickets where Departure='" + placeOfDeparture + "' AND Arrival= '" + placeOfArrival + "' AND DepartureDate=" + dateOfDeparture + "' AND ArrivalDate='" + dateOfArrival + "' AND priceOdDepartureTickets='" + priceOfDeparture + "' AND priceOfArrivalTickets='" + priceOfArrival + "' AND Company= '" + company + "' AND TravelMethod='" + travelMethod + "'";//einai ena aplo string pou tha xrisimopoithei ws query
                MySqlCommand command = new MySqlCommand(sql, cnn);//arxikopoioume to command pou xrisimopoiei ti vilviothiki MySqlCommand i opoia exei 2 orismata
                MySqlDataReader dataReader = command.ExecuteReader();//ektelei tin entoli command kai to apotelesma to apothikeuei se enan reader tis mysql

                while (dataReader.Read())
                {
                    listAll.Add(dataReader[0].ToString());
                    listAll.Add(dataReader[1].ToString());
                    listAll.Add(dataReader[2].ToString());
                    listAll.Add(dataReader[3].ToString());
                    listAll.Add(dataReader[4].ToString());
                    listAll.Add(dataReader[5].ToString());
                    listAll.Add(dataReader[6].ToString());
                    listAll.Add(dataReader[7].ToString());
                }

                cnn.Close();//edw kleinoume ti sindesi me ti vasi
            }
            catch
            {
                listAll.Add("Error");

            }
            return listAll;
        }
    }
    //se auto to simeio ginetai to display twn eisitiriwn
    //auto den tha ginetai akrivws sto backend alla sti sundesi me to front end
    //kapws etsi diladi tha to xrisimopoiousame gia na emfanisoume ta eisitiria
    public string getListAll()
    {
        List<string> returnedlist = new List<string>();
        returnedlist = Tickets.returnAvailable("", "", "", "", "", "","","");
        string allresultsasstring = "";

        for (var i = 0; i < returnedlist.Count(); i++)
        {
            allresultsasstring += i + " στοιχείο:" + returnedlist[i] + ",";
        }
        //deuteros tropos

        //foreach (var item in returnedlist)
        //{
        //    allreseiultsasstring += "Το στοιχείο:" + item + ",";
        //}
    }

    //gia na ginei save reservation 
    // exoume duo synthikes
    //1. o xristis exei epilexei eisitiria gia kratisi
    //2. exei ginei i plirwmi 
    public bool saveReservation(int userID, string placeOfDeparture, string placeOfArrival, DateTime dateOfDeparture, DateTime dateOfArrival, string Company, double priceOfDepartureTickets, double priceOfArrivalTickets, string TravelMethod)
    {

        //edw ftiaxnoume mia vasi pou tha legetai ReservedTickets opou tha pairnei to userid tou xristi apo to table Users kai me vasi auto tha exei stiles
        //userid, departure, arrival, departureDate, arrivalDate, Company, departurePrice, arrivalPrice, travelMethod

        //endeiktiki entoli tis sql gia tin enwsi duo table
        //Select tblUsers.userID tblReservedTickets.Departure from ReservedTickets join tblUsers on tblReservedTickets.UserID = tblUsers.UserID; 

        //ara gia na ginei i kratisi tha prepei na epilexei o xristis mia apo tis diathesimes epiloges eisitiriwn pou tou kaname "Display", to pws tha ginei afora kommati tou Frontend
        //estw loipon oti apothikeuetai se mia metavliti selectedTick to id tis sugekrimenis kratisis tou xristi
        //gia na proxwrisoume se apothikeusi tha prepei episis na xeroume an exei plirwsei o xristis
        //estw oti exei ginei plirwmi. Auto tha mporouse na simainei oti i trapeza tha mas steilei pisw mia metavliti me ena true ii false
        //an einai true exei ginei i plirwmi, an einai false den exei ginei
        //epomenws aspoume oti exoume mia metavliti paymentcheck
        //kai me vasi auti ti metabliti mporoume na sunexisoume
        bool checksavedReserv = false;
        bool paymentcheck = false;
        //edw tha kaleitai to exwteriko sustima tis trapezas gia na paroume pisw ena true ii false an exei ginei i oxi i sunalagi(elegxos apo to exwteriko sustima tis trapezas) 
        //kai to apothikeuoume sti metavliti paymentcheck
        if (paymentcheck = true)
        {
            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sql = "INSERT INTO ReservedTickets (userID, Departure, Arrival, DepartureDate, ArrivalDate, DeparturePrice, ArrivalPrice, Company, TravelMethod) VALUES('" + userID + "','" + placeOfDeparture + "', '" + placeOfArrival + "', '" + dateOfDeparture + "','" + dateOfArrival + "','" + Company + "','" + priceOfDepartureTickets + "','" + priceOfArrivalTickets + "','" + priceOfDepartureTickets + "'.'" + TravelMethod + "')";
                MySqlCommand command = new MySqlCommand(sql, cnn);
                command.ExecuteCommand();
                cnn.Close();
                checksavedReserv = true;
                increasePointsTickets(userID, 1500);
                return checksavedReserv;
                //an den upirxe provlima sti vasi epistrefei true
                //alliws pigenei sto catch kai epistrefei tin arxikopoiimeni timi false

            }
            catch
            {
                return checksavedReserv;
            }

        }
        else
        {
            return checksavedReserv;
        }
    }

    public void increasePointsTickets(int userID)
    {
        //exoume allo ena upothetiko table gia tous pontous tou xristi, opou mesa tha exei to userid tou xristi kai tous sunolikous tou pontous
        //tha kalesoume tin saveReservation kai me vasi to checksavedReserv an einai true i false tha proxwrisoume
        //kathws o xristis pairnei pontous an exei oloklirwthei i kratisi (na uparxei diathesimotita kai na exei ginei plirwmi opou ola auta elegxontai stin saveReservation)
        string checkSaved = "";
        Tickets sr = new Tickets();
        checkSaved = sr.saveReservation();

        if (checkSaved == true)
        {

            //an isxuei i sunthiki gia kathe oloklirwmeni kratisi eisitiriwn pairnei 1500 pontous 
            int earnedPointsTickets = 1500;
           
            List<int> PointTable = new List<int>();

            PointTable = Points.getUsersPoints(userID);
            int pointid = 0;
            int userspoints = 0;
            //for (int i; i < Pointtable.Count(); i++)
            //{
            pointid = Pointtable[0];//id=5
            userspoints = Pointtable[1];//collectedpoints = 8000
                                        //}
            int newpointstobesaved = 0;
            newpointstobesaved = earnedPointsTickets + userspoints;

            Points.SaveNewPoints(pointid, newpointstobesaved);
        }
    }
    public bool saveReservationChange()
    {
        //Gia na ginei i allagi kratisis tha prepei na xanaginei oli i diadikasia elegxou diathesimotitas gia tis nees imerominies 
        //kai na kalountai opoies methodoi xreiazontai xana
        //efoson uparxei diathesimotita
        //an o xristis kanei allagi se imerominies eisitiriwn tote tha kanei update tis kainouries imerominies sto table reservedTickets
    }

    //otan o xristis epilexei oti thelei na kanei allagi kratisis
    //se imerominies tote tha tou emfanizei duo epiloges
    //eite na plirwsei kapoia extra xrimata
    //eite na kanei anabathmisi tou logariasmou tou
    //(otan exei anabathmisi ton logariasmo tou dikaioutai dwrean allagi kratisis se imerominies)

    public void upgrade()//otan o xristis epilexei oti thelei na anavathmisi ton logariasmo tou tha tou emfanizei ti selida anavathmisis logariasmou
    {

    }

    public void pay()//otan o xristis epilexei na plirwsei tha ton stelnei sto exwteriko sustima tis trapezas
    {

    }


}
