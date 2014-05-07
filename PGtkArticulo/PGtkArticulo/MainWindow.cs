using Gtk;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Collections.Generic;

using Serpis.Ad;

public partial class MainWindow: Gtk.Window
{	
	private MySqlConnection mySqlConnection;

	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		
		IDbCommand selectCommand = App.Instance.DbConnection.CreateCommand ();
		
		selectCommand.CommandText = "SELECT * FROM articulo";
		IDataReader dataReader = selectDbCommand.ExecuteReader();
		
		addColumns(dataReader);
		
		ListStore listStore = new ListStore(typeof(string));
		
		treeView.Model = listStore;
		fillListStore(listStore, dataReader);
		dataReader.Close();

	}
	
	private ListStore createListStore(int fieldCount) {

		Type[] types = new Type[fieldCount];

		for (int index = 0; index < fieldCount; index++)

			types[index] = typeof(string);

		return new ListStore(types);

	}
	
	private void addColumns (IDataReader dataReader){
		for (int index = 0; index < dataReader.FieldCount; index++)
			treeView.AppendColumn(dataReader.GetName(index), new CellRendererText(),"text", index);
	}
	
	private void fillListStore (ListStore listStore, IDataReader dataReader){
		while(dataReader.Read ()){
			
		}

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;

		mySqlConnection.Close ();
	}
}
