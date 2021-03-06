using Gtk;
using MySql;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;

using PSerpisAd;

namespace Serpis.Ad
{
	public partial class MainWindow: Gtk.Window
	{	

		public MainWindow (): base (Gtk.WindowType.Toplevel)
		{
			Build ();
			TreeViewFiller.Filler (treeView, App.Instance.DbConnection, "SELECT * FROM articulo");
			
			
			/*

			App.Instance.DbConnection = new MySqlConnection("user=root;password=sistemas;database=dbrepaso;server=localhost");
			
			IDbCommand selectCommand = App.Instance.DbConnection.CreateCommand ();
			selectCommand.CommandText = "SELECT * FROM articulo";
			IDataReader dataReader = selectCommand.ExecuteReader ();
		
			addColumns (dataReader);
		
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
			for (int index = 0; index < dataReader.FieldCount; index++)
				treeView.AppendColumn (dataReader.GetName (index), new CellRendererText (), "text", index);
		}

		private void fillListStore (ListStore listStore, IDataReader dataReader)
		{
			while (dataReader.Read ()) {
				List<string> values = new List<string>();
				for (int i = 0; i< dataReader.FieldCount; i++)
					values.Add (dataReader.GetValue(i).ToString());
				
				List.AppendValues.ToString();
			}
*/
		}

		protected void OnDeleteEvent (object sender, DeleteEventArgs a)
		{
			Application.Quit ();
			a.RetVal = true;

		}
	}
}