using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
	public class Tickets:Reservation
	{

		private string placeOfDeparture;
		private string placeOfArrival;
		private string travelMethod;
		private string company;
		private double priceForDepartureTickets;
		private double priceForArrivalTickets;
		private int earnedPointsTickets;


        //edw kaleitai i methodo checkAvailability() apo tin uperklasi Reservation
        //endeiktikes entoles 

        protected bool checkTickets()
        {
            string avail;
            Reservation av = new Reservation();
            avail = av.checkAvailability();
        }

        // gia paradeigma sto OnClick pou tha kanei sto sugekrimeno koumpi 
        //efoson exei ginei i plirwmi(tha xreiastei allos enas elegxos opou tha elegxei an exei ginei i plirwmi)
        //kai an autos o elegxos einai true tote tha apothikeuetai 
        //otan kanei apothikeusi ousiastika apothikeuei ta attributes twn tickets kai tou reservation

        protected void BtnReserv_Click(object sender, EventArgs e) // dimiourgoume ena event apo ta asp buttons ston designer
        {
            // tha kalei edw mesa ti methodo saveReservation apo tin klasi Reservation
            //endeiktikes entoles
            string reserv;
            Reservation rs = new Reservation();
            Reserv = rs.saveReservation();//mesa stin parenthesi xreiazontai orismata, analoga ti pairnei i methodos saveReservation 
            
        }

        public static void pay()
        {

        }

        public static void upgrade()
        {
            //otan thelei na anabathmisei ton logariasmo tou tha ton pigenei stin othoni anabathmisis logariasmou
        }
	}
}