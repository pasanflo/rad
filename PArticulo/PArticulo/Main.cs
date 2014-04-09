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
	
			MySqlConnection mySqlConnection = new MySqlConnection(connectionString); //Crear conexión a bd
			
			mySqlConnection.Open(); //Abrimos la conexión
			
			MySqlCommand mySqlCommand = mySqlConnection.CreateCommand(); //Creamos comando SQL
			mySqlCommand.CommandText = command; //Cambiamos el texto del comando SQL por command.
			
			MySqlCommand mySqlCommandChange = mySqlConnection.CreateCommand(); //Creamos comando SQL
			mySqlCommandChange.CommandText = "UPDATE articulo SET nombre=@nombre WHERE id=1"; //Cambiamos el texto del comando SQL por command.
			MysqlParameter mySqlParameter = mySqlCommandChange.CreateParameter();
			mySqlParameter.Parameter = "nombre";
			mySqlParameter.Value = DateTime.Now.ToString();
			mySqlCommandChange.Parameters.Add(mySqlParameter);
			
			
			//MySqlDataReader mySqlDataReader; //Creamos un DataReader
			//mySqlDataReader = mySqlCommand.ExecuteReader(); // Nos devuelve un mySqlDataReader, lector de datos
			
			MySqlDataReader mySqlDataReaderChange; //Creamos otro DataReader
			mySqlDataReaderChange = mySqlCommandChange.ExecuteNonQuery();
			// ExecuteNonQuery ejecuta el Update
			mySqlDataReaderChange.Close();
			
			//while(mySqlDataReader.Read()){ //Leemos todas las filas
			//	Console.WriteLine (mySqlDataReader.GetString (0) + ", " + mySqlDataReader.GetString (1));
			//}
			
			while(mySqlDataReaderChange.Read()){ //Leemos todas las filas
				Console.WriteLine (mySqlDataReaderChange.GetString (0) + ", " + mySqlDataReaderChange.GetString (1));
			}
			

			
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
