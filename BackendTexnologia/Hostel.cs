﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class Hostel
    {
        private string city;
        private string country;
        private int persons;
        private double pricePerDay;
        private int earnedPointsHostel;
        private int days;
    }

    //edw kaleitai i methodo checkAvailability() apo tin uperklasi Reservation
    //endeiktikes entoles 
    string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";//to bgazw apexw gia na mporw na to xrisimopoiw kathe fora pou xreiazetai na anoixw ti vasi

    //i exwteriki vasi dedomenvn tvn hostels tha exei sthles hostelID(primary key), userID(foreign key), City, Country, DepartureDate, ArrivalDate, Persons, PricePerDay

    public List<string> returnAvailable(string city, string country, int persons, double pricePerDay, DateTime dateOfDeparture, DateTime dateOfArrival)
    {

        List<string> listAll = new List<string>();//orizoume mia keni lista opou mesa tha apothikeusoume ta dedomena twn diathesimwn hostels

        try
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);// dimiourgoume to connection me ti vasi xrisimopoiwntas to connection string pou einai exw apo ti methodo
            cnn.Open();//anoigei ti vasi me to cnn opou to cnn einai to mysqlconnection me orisma connectionString to opoio connection string 
                       //deixnei pou tha paei gia na sundethei me ti sugekrimeni vasi pou exw ftiaxei gia to sustima
            string sql = "Select City, Country, DepartureDate, ArrivalDate, Persons, PricePerDay from Hostels where City='" + city + "' AND Country= '" + country + "' AND DepartureDate=" + dateOfDeparture + "'AND ArrivalDate='" + dateOfArrival + "' AND Persons= '" + persons + "'AND PricePerDay='" + pricePerDay + "'";//einai ena aplo string pou tha xrisimopoithei ws query
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
            }

            cnn.Close();//edw kleinoume ti sindesi me ti vasi
        }
        catch
        {
            listAll.Add("Error");
            //return listid;
        }


        return listAll;
    }
    //se auto to simeio ginetai to display twn hostels
    public string getListAll()
    {
        List<string> returnedlist = new List<string>();
        returnedlist = Hostel.returnAvailable(" ", " ", " ", " ", " ", " ");
        string allresultsasstring = "";

        for (var i = 0; i < returnedlist.Count(); i++)
        {
            allresultsasstring += i + " στοιχείο:" + returnedlist[i] + ",";
        }

    }

    //gia na ginei save reservation 
    // exoume duo synthikes
    //1. o xristis exei epilexei hostels gia kratisi
    //2. exei ginei i plirwmi 
    public bool saveReservation(int userID, string city, string country, int persons, double pricePerDay, DateTime dateOfDeparture, DateTime dateOfArrival)
    {

        //edw ftiaxnoume mia vasi pou tha legetai ReservedHostels opou tha pairnei to userID tou xristi apo to table Users kai me vasi auto tha exei stiles
        //userID(foreign key), City, Country, DepartureDate, ArrivalDate, Persons, PricePerDay

        //ara gia na ginei i kratisi tha prepei na epilexei o xristis ena apo ta diathesima hostels pou tou kaname "Display", to pws tha ginei afora kommati tou Frontend
        //estw loipon oti apothikeuetai se mia metavliti selectedHostel to id tis sugekrimenis kratisis tou xristi
        //gia na proxwrisoume se apothikeusi tha prepei episis na xeroume an exei plirwsei o xristis
        //estw oti exei ginei plirwmi. Auto tha mporouse na simainei oti i trapeza tha mas steilei pisw mia metavliti me ena true ii false
        //an einai true exei ginei i plirwmi, an einai false den exei ginei
        //epomenws aspoume oti exoume mia metavliti paymentcheck
        //kai me vasi auti ti metabliti mporoume na sunexisoume
        bool checksavedReserv = false;

        // edw tha kaleitai i pay i opoia epikoinwnei me to exwteriko sustima tis trapezas gia na paroume pisw ena true ii false an exei ginei i oxi i sunalagi(elegxos apo to exwteriko sustima tis trapezas)
        //pairnoume epomenws tin paymentcheck
        //ara edw kaloume tin pay() gia na paroume tin timi tou paymentcheck
        bool paymentcheck = false;
        Hostel hs = new Hostel();

        TimeSpan result = dateOfArrival.Subtract(dateOfDeparture);
        //metatrepoume to apotelesma se int kai to apothikeuoume se mia metavliti days
        int days = (int)result.TotalDays;

        //i timi gia kathe imera epi to sunolo twn merwn 
        double FinalPrice = pricePerDay * days;

        paymentcheck = hs.pay(userID, FinalPrice);

        if (paymentcheck = true)
        {
            try
            {
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();
                string sql = "INSERT INTO ReservedHostels (userID, City, Country, DepartureDate, ArrivalDate, Persons, PricePerDay) VALUES('" + userID + "','" + city + "', '" + country + "', '" + dateOfDeparture + "','" + dateOfArrival + "','" + persons + "','" + pricePerDay + "')";
                MySqlCommand command = new MySqlCommand(sql, cnn);
                command.ExecuteCommand();
                cnn.Close();
                checksavedReserv = true;
                increasePointsHostel(userID, 1500);
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

    public void increasePointsHostel(int userID)
    {
        //exoume allo ena upothetiko table gia tous pontous tou xristi, opou mesa tha exei to userid tou xristi kai tous sunolikous tou pontous
        //tha kalesoume tin saveReservation kai me vasi to checksavedReserv an einai true i false tha proxwrisoume
        //kathws o xristis pairnei pontous an exei oloklirwthei i kratisi (na uparxei diathesimotita kai na exei ginei plirwmi opou ola auta elegxontai stin saveReservation)
        string checkSaved = "";
        Hostel hl = new Hostel();
        checkSaved = hl.saveReservation();

        if (checkSaved == true)
        {

            //an isxuei i sunthiki gia kathe oloklirwmeni kratisi hostel pairnei 1500 pontous
            int earnedPointsHostel = 1500;

            List<int> PointTable = new List<int>();

            PointTable = Points.getUsersPoints(userID);
            int pointid = 0;
            int userspoints = 0;
            //for (int i; i < Pointtable.Count(); i++)
            //{
            pointid = Pointtable[0];
            userspoints = Pointtable[1];
            //}
            int newpointstobesaved = 0;
            newpointstobesaved = earnedPointsHostel + userspoints;

            Points.saveNewPoints(pointid, newpointstobesaved);
        }
    }
    public bool saveReservationChange(int userID, string city, string country, int persons, double pricePerDay, DateTime dateOfDeparture, DateTime dateOfArrival, double extraPrice)
    {
        //Gia na ginei i allagi kratisis tha prepei na xanaginei oli i diadikasia elegxou diathesimotitas gia tis nees imerominies 
        //kai na kalountai opoies methodoi xreiazontai xana
        //efoson uparxei diathesimotita
        //an o xristis kanei allagi se imerominies hostel tote tha kanei update tis kainouries imerominies sto table reservedHostels
        //kaleitai i upgrade gia na mathoume an einai upgraded o xristis ii basic

        //an einai upgraded (upgraded = true)
        //dikaioutai dwrean allagi kratisis se imerominies

        //an einai basic (upgraded = false) tha tou emfanizei duo epiloges
        //eite na plirwsei kapoia extra xrimata
        //eite na kanei anabathmisi tou logariasmou tou

        //ara vazoume tin epilogi tou xristi se mia metabliti
        bool checksavedchanges = false;
        string choice;
        if (choice == "Extra Pay")
        {
            bool paymentcheck = false;
            Hostel ho = new Hostel();

            paymentcheck = ho.pay(userID, extraPrice);
            if (paymentcheck == true)
            {
                //se auto to simeio kanei update sti vasi tis nees imeromnies tis kratisis
                checksavedchanges = true;

                return checksavedchanges;
            }
            else
            {
                return checksavedchanges;
            }
        }
        else if (choice == "upgrade")
        {
            bool checkupgraded = false;
            Hostel ho = new Hostel();

            checkupgraded = ho.upgrade(userID);

            if (checkupgraded == true)
            {
                checksavedchanges = true;
                return checksavedchanges;
                //se auto to simeio kanei update sti vasi tis nees imeromnies tis kratisis
            }
            else
            {
                return checksavedchanges;
            }
        }

    }

    public bool upgrade()//otan o xristis epilexei oti thelei na anavathmisi ton logariasmo tou tha tou emfanizei ti selida anavathmisis logariasmou
    {
        bool checkupgraded = false;
        //pigenei stin account elegxei an exei kanei upgrade iii oxi
        //kai an exei kanei 
        //tote dikaioutai dwrean allagi imerominiwn
        //ara den xreiazetai na ginei pay
        //ara epistrefei mia metavliti 
        return checkupgraded;


    }

    public bool pay(int userID, double FinalPrice)//otan o xristis epilexei na plirwsei tha ton stelnei sto exwteriko sustima tis trapezas
    {
        bool paymentcheck = false;
        //arxikopoioume tin paymentcheck
        //se auto to simeio tha epikoinwnei to europemoov me to sustima tis trapezas 
        //kai an exei ginei i plirwmi stin trapeza tha apothikeuetai se mia metavliti paymentcheck=true; iii paymentcheck=false; an den exei ginei


        return paymentcheck;
    }

}