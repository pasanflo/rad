using System;
using Gtk;
using System.Data;
using System.Collections.Generic;

using Serpis.Ad;

namespace Ad.Serpis{

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();

		mySqlConnection = new MySqlConnection("Server=localhost;Database=dbprueba;User Id=root;Password=sistemas");
		mySqlConnection.Open ();

		string selectSql = 
				"SELECT articulo.id, articulo.nombre FROM articulo";
		TreeViewHelper treeViewHelper = new TreeViewHelper(treeView, mySqlConnection, selectSql);

		ListStore listStore = treeViewHelper.ListStore;

		editAction.Sensitive = false;
		deleteAction.Sensitive = false;

		editAction.Activated += delegate {
			if (treeView.Selection.CountSelectedRows() == 0)
				return;
			TreeIter treeIter;
			treeView.Selection.GetSelected(out treeIter);
			object id = listStore.GetValue (treeIter, 0);
			object nombre = listStore.GetValue (treeIter, 1);

		};

		deleteAction.Activated += delegate {
			if (treeView.Selection.CountSelectedRows() == 0)
				return;
			TreeIter treeIter;
			treeView.Selection.GetSelected(out treeIter);
			object id = listStore.GetValue (treeIter, 0);

			MySqlCommand deleteMySqlCommand = mySqlConnection.CreateCommand();
			deleteMySqlCommand.CommandText = "delete from articulo where id=" + id;
			deleteMySqlCommand.ExecuteNonQuery();
		};

		treeView.Selection.Changed += delegate {
			bool hasSelectedRows = treeView.Selection.CountSelectedRows() > 0;
			editAction.Sensitive = hasSelectedRows;
			deleteAction.Sensitive = hasSelectedRows;
		};
				
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;

		mySqlConnection.Close ();
	}
	}
	

}
