using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendTexnologia
{
    public class StudentPremium:Account
    {
		private string studentID;

        public bool checkStudentID()
        {
            //auto den ginetai sti vasi, tha uparxei sustima me to opoio tha epikoinwnoume me to ekastote panepistimio 
            //ousiastika tha epikooinwnei me ti vasi dedomenwn twn allonwn panepistimiwn
            //apaitountai eidikes adeies gia ti sugekrimeni methodo kai pithanos exwterika ergaleia kai diaforetikes entoles analoga 
            //me ti vasi pou xrisimopoiei to kathe panepistimio
            //kai sigoura tha xreiastei try catch edw se periptwsi provlimatos tis vasis tou panepistimiou

        }
        public bool saveStudentID()
        {
            bool check = true;

            //prepei na ginei boolean kathws prepei na xeroume an egine ontws i apothikeusi sti vasi
            //prosthetoume ena try catch gia ton elegxo sti vasi kathws einai exwteriko sustima i vasi dedomenwn 
            //kai an gia opoiondipote logo exoume provlima me ti vasi
            //kai skasei na mporoume na epistrepsoume false
            try
            {
                //endeiktika kapoies entoles gia ti sundesi me ti vasi wste na kanoume insert xrisimopoiontas MySql kai MySql Workbench
                string connectionString = @"server=localhost;user id=root; password=****; persistsecurityinfo=True;database=leafletdb";
                MySqlConnection cnn = new MySqlConnection(connectionString);
                cnn.Open();
                //Gia paradeigma to insert tha mporouse na einai kapws etsi
                string sql = "INSERT INTO User (StudentId) VALUES ('" + StuID + "')";
                MySqlCommand command = new MySqlCommand(sql, cnn);
                command.ExecuteReader();
                cnn.Close();
                return check;
            }
            catch
            {
                check = false;
                return check ;//epsitrefoume error se periptwsi pou "skasei i vasi" kai den apothikeutei to id
            }
        }
    }
}