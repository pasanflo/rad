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
			
			string command = "SELECT * FROM articulo";
			
			string change = "UPDATE articulo SET nombre={1} where id=1";
			
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString); //Crear conexión a bd
			
			mySqlConnection.Open(); //Abrimos la conexión
			
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand(); //Creamos comando SQL
			mySqlCommand.CommandText = change; //Cambiamos el texto del comando SQL por command.
			
			MySqlCommand mySqlCommandChange = mySqlConnection.CreateCommand(); //Creamos comando SQL
			mySqlCommand.CommandText = command; //Cambiamos el texto del comando SQL por command.
			
			MySqlDataReader mySqlDataReader; //Creamos un DataReader
			mySqlDataReader = mySqlCommand.ExecuteReader(); // Nos devuelve un mySqlDataReader, lector de datos
			
			MySqlDataReader mySqlDataReader2; //Creamos otro DataReader
			mySqlDataReader2 = mySqlCommand.ExecuteNonQuery(); // ExecuteNonQuery ejecuta el Update
			
			while(mySqlDataReader.Read()){ //Leemos todas las filas
				Console.WriteLine (mySqlDataReader.GetString (0) + ", " + mySqlDataReader.GetString (1));
			}
			
			while()
			

			
/*			do {	
			if (mySqlConnection.State == ConnectionState.Open) {
			Console.WriteLine ("Conexión establecida.");
			} else {
			Console.WriteLine ("...");
			}
			} while (mySqlConnection.State == ConnectionState.Closed);
*/			
			mySqlConnection.Close();

		}
	}
}
