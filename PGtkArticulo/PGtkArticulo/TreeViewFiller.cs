using Gtk;
using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

using PSerpisAd;

namespace Serpis.Ad
{
	public class TreeViewFiller
	{
		public static void Filler (TreeView treeView, IDbConnection dbConnection, string selectText)
		{
			IDbCommand selectCommand = App.Instance.DbConnection.CreateCommand ();
			selectCommand.CommandText = "SELECT * FROM articulo";
			IDataReader dataReader = selectCommand.ExecuteReader ();
		
			for (int index = 0; index < dataReader.FieldCount; index++)
			treeView.AppendColumn (dataReader.GetName (index), new CellRendererText (), "text", index);
			
			ListStore listStore = new ListStore (typeof(string));
		
			treeView.Model = listStore;
			fillListStore (listStore, dataReader);
			dataReader.Close ();

		}

		private ListStore createListStore (int fieldCount)
		{

			Type[] types = new Type[fieldCount];

			for (int index = 0; index < fieldCount; index++)

				types [index] = typeof(string);

			return new ListStore (types);

		}

		private void addColumns (IDataReader dataReader)
		{

		}

		private static void fillListStore (ListStore listStore, IDataReader dataReader)
		{
			while (dataReader.Read ()) {
				List<string> values = new List<string>();
				for (int i = 0; i< dataReader.FieldCount; i++)
					values.Add (dataReader.GetValue(i).ToString());
				
				List.AppendValues.ToString();
			}
		}
	}
}

