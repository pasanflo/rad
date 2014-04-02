using System;
using System.Data;
using MySql;
using MySql.Data.MySqlClient;


namespace PArticulo
{
	class MainClass
	{
		public static void Main (string[] args){

			string connectionString =
			"Server=localhost;" +
			"Database=dbrepaso;" +
			"User Id=root;" +
			"Password=sistemas";
			
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
			
			mySqlConnection.Open();
			
			string command = "SELECT nombre FROM articulo";
			
			MySqlCommand mySqlCommand = new MySqlCommand(command);
			
			MySqlDataReader mySqlDataReader;
			mySqlDataReader = mySqlCommand.ExecuteReader();
			
			while(mySqlDataReader.Read()){
				Console.WriteLine (mySqlDataReader.GetString (0) + ", " + mySqlDataReader.GetString (1));
			}
			

			
			do {	
			if (mySqlConnection.State == ConnectionState.Open) {
			Console.WriteLine ("Conexión establecida.");
			} else {
			Console.WriteLine ("...");
			}
			} while (mySqlConnection.State == ConnectionState.Closed);
			
			mySqlConnection.Close();

		}
	}
}
