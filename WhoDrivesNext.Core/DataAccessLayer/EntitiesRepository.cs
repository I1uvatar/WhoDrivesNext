using System;
using System.Collections.Generic;
using System.IO;
using WhoDrivesNext.Core.DataLayer;
using WhoDrivesNext.Core.Model;

namespace WhoDrivesNext.Core.DataAccessLayer {
	public class EntitiesRepository {
        AppDatabase db = null;
		protected static string dbLocation;		
		protected static EntitiesRepository me;		
		
		static EntitiesRepository ()
		{
			me = new EntitiesRepository();
		}
		
		protected EntitiesRepository()
		{
			// set the db location
			dbLocation = DatabaseFilePath;
			
			// instantiate the database	
            db = new AppDatabase(dbLocation);
		}
		
		public static string DatabaseFilePath {
			get { 
				var sqliteFilename = "WhoDrivesNext.db3";

#if NETFX_CORE
                var path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, sqliteFilename);
#else

#if SILVERLIGHT
				// Windows Phone expects a local path, not absolute
	            var path = sqliteFilename;
#else

#if __ANDROID__
				// Just use whatever directory SpecialFolder.Personal returns
	            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); ;
#else
				// we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
				// (they don't want non-user-generated data in Documents)
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
				string libraryPath = Path.Combine (documentsPath, "../Library/"); // Library folder
#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
#endif		

#endif
				return path;	
			}
		}

	    #region Person

	    public static Person GetPerson(int id)
	    {
	        return me.db.GetItem<Person>(id);
	    }

	    public static IEnumerable<Person> GetPersons()
	    {
	        return me.db.GetItems<Person>();
	    }

	    public static int SavePerson(Person item)
	    {
	        return me.db.SaveItem<Person>(item);
	    }

	    public static int DeletePerson(int id)
	    {
	        return me.db.DeleteItem<Person>(id);
	    }

	    #endregion

        //#region Group

        //public static Group GetGroup(int id)
        //{
        //    return me.db.GetItem<Group>(id);
        //}

        //public static IEnumerable<Group> GetGroups()
        //{
        //    return me.db.GetItems<Group>();
        //}

        //public static int SaveGroup(Group item)
        //{
        //    return me.db.SaveItem<Group>(item);
        //}

        //public static int DeleteGroup(int id)
        //{
        //    return me.db.DeleteItem<Group>(id);
        //}

        //#endregion

        #region GroupPersonPoint

        public static GroupPersonPoint GetGroupPersonPoint(int id)
	    {
	        return me.db.GetItem<GroupPersonPoint>(id);
	    }

	    public static IEnumerable<GroupPersonPoint> GetGroupPersonPoints()
	    {
	        return me.db.GetItems<GroupPersonPoint>();
	    }

	    public static int SaveGroupPersonPoint(GroupPersonPoint item)
	    {
	        return me.db.SaveItem<GroupPersonPoint>(item);
	    }

	    public static int DeleteGroupPersonPoint(int id)
	    {
	        return me.db.DeleteItem<GroupPersonPoint>(id);
	    }

	    #endregion

	}
}

