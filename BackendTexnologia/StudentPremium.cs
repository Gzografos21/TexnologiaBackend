using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=leafletdb";
    public class StudentPremium : Account
    {
        private string studentCode;
        private string university;
        //

        public bool checkStudentCode(int userID, string studentCode, string university)
        {
            //tha uparxei sustima me to opoio tha epikoinwnoume me to ekastote panepistimio 
            //ousiastika tha epikooinwnei me ti vasi dedomenwn twn allonwn panepistimiwn
            //apaitountai eidikes adeies gia ti sugekrimeni methodo kai pithanos exwterika ergaleia kai diaforetikes entoles analoga 
            //me ti vasi pou xrisimopoiei to kathe panepistimio
            //tha pairnei san orisma to code pou dinei o xristis (to am tou diladi) kai to panepistimiou pou spoudazei
            //edw mporei na uparxei ena automato sustima elegxou me ola ta panepistimia
            //tha pairnoume apantisi gia to an autos o xristis einai ontws foititis tha tin apothikeuoume se mia metavliti
            bool checkstudent;
            return checkstudent;


        }
        public bool saveStudentCode(string userID, string studentCode, string university)
        {
            //kaloume tin checkStudentCode
            bool checkstudent = false;
            StudentPremium sp = new StudentPremium();
            checkstudent = sp.checkStudentCode(userID, studentCode, university);


            bool checksaved = true;
            if (checkstudent == true)
            {
                try
                {
                    string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=TexnologiaVasi";
                    MySqlConnection cnn = new MySqlConnection(connectionString);
                    cnn.Open();
                    string sql = "INSERT INTO Accounts (StudentCode) VALUES ('" + studentCode + "')";
                    MySqlCommand command = new MySqlCommand(sql, cnn);
                    command.ExecuteReader();
                    cnn.Close();
                    checksaved = true;
                    return checksaved;
                }
                catch
                {
                    return checksaved;//epsitrefoume error se periptwsi pou "skasei i vasi" kai den apothikeutei to id
                }
            }
        }
    }
}