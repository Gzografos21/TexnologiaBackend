using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
	public class Hostel: Reservation
	{
		private string city;
		private string country;
		private int persons;
		private double pricePerDay;
		private int days;
		private int earnedPointsHostel;
	}

    //edw tha kaleitai i checkAvailability() tis uperklasis Resevation

    //edw tha kaleitai i saveReservation() tis uperklasis Reservation

    //edw tha kaleitai i increasePoints() tis klasis Points

    public static void pay()
    {

    }

    public static void upgrade()
    {
        //otan thelei na anabathmisei ton logariasmo tou tha ton pigenei stin othoni anabathmisis logariasmou
    }

}