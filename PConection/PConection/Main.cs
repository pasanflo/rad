using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace PUdpConexion
{
	class MainClass
	{
		public static void main (string[] args){
			
			string connectionString =
				"Server=localhost;" +
				"Database=dbrepaso;" +
				"User Id=root;" +
				"Password=sistemas";
			
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
			
			mySqlConnection.Open();
			
			do {	
				if (mySqlConnection.State == ConnectionState.Open) {
					Console.WriteLine ("Conexión establecida.");
				} else {
					Console.WriteLine ("...");
				}
			} while (mySqlConnection.State == ConnectionState.Closed);
			
			Console.Write (mySqlConnection.State.ToString());

			mySqlConnection.Close();
			
		}
	}
}