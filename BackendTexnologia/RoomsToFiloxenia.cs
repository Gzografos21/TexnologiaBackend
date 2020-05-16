using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class RoomsToFiloxenia : Reservation
    {
        private string city;
        private string country;
        private string ownerName;
        private int persons;
        private int days;
        private int earnedPointsReservationFiloxenia;

        public bool checkAvailability()
        {
            //epistrefei true i false analoga me ton an uparxei diathesimotita

        }

        //edw kaloume ti methodo tis reservation me onoma saveReservation()
        //endeiktikes entoles

        //an ginetai me click analoga to id tou click sto koumpi pou uparxei stin asp einai san na kaleitai i BtnReserv_Click kata to patima tou koumpiou

        protected void BtnReserv_Click(object sender, EventArgs e) // dimiourgoume ena event apo ta asp buttons ston designer
        {
            // tha kalei edw mesa ti methodo saveReservation apo tin klasi Reservation
            //endeiktikes entoles
            string reserv;
            Reservation rs = new Reservation();
            Reserv = rs.saveReservation();//mesa stin parenthesi xreiazontai orismata, analoga ti pairnei i methodos saveReservation 

        }

        //antistoixa gia to increase points
        protected void BtnIncr_Click(object sender, EventArgs e) // dimiourgoume ena event apo ta asp buttons ston designer
        {
            // tha kalei edw mesa ti methodo increasePoints apo tin klasi Points
            //endeiktikes entoles
            string increase;
            Points inc = new Points();
            Increase = inc.increasePoints();//mesa stin parenthesi xreiazontai orismata, analoga ti pairnei i methodos increase

        }

    }
}