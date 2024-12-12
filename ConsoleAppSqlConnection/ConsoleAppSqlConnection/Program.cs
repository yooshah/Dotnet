
using System;
using System.Data.SqlClient;



string connectingString = "data source=.; database=StudentDB; integerated security=SSPI";
using (SqlConnection connection = new SqlConnection(connectingString)
{
    try
        {
            connection.Open();
            Console.WriteLine("Connction has opened");
            //string query = "INSERT INTO Students(StudentID,FirstName,LastName,Age) VALUES(2,Suhail,KK,24)";
        }
        catch (Exception ex) 
        {
        Console.WriteLine("something went wrrong!");
        }
    

}
