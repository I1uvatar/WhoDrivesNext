using System.Collections.Generic;
using System.Linq;
using WhoDrivesNext.Core.Model;

namespace WhoDrivesNext.Core.DataLayer
{
	/// <summary>
	/// AppDatabase builds on SQLite.Net and represents a specific database, in our case, the Task DB.
	/// It contains methods for retrieval and persistance as well as db creation, all based on the 
	/// underlying ORM.
	/// </summary>
	public class AppDatabase : SQLiteConnection
	{
		static object locker = new object ();

		/// <summary>
		/// Initializes a new instance of the <see cref="AppDatabase"/> AppDatabase. 
		/// if the database doesn't exist, it will create the database and all the tables.
		/// </summary>
		/// <param name='path'>
		/// Path.
		/// </param>
		public AppDatabase (string path) : base (path)
		{
			// create the tables
			CreateTable<Person> ();
            //CreateTable<Group>();
            CreateTable<GroupPersonPoint>();
		}
		
		public IEnumerable<T> GetItems<T> () where T : IPersistentEntity, new ()
		{
            lock (locker) {
                return (from i in Table<T> () select i).ToList ();
            }
		}

		public T GetItem<T> (int id) where T : IPersistentEntity, new ()
		{
            lock (locker) {
                return Table<T>().FirstOrDefault(x => x.ID == id);
                // Following throws NotSupportedException - thanks aliegeni
                //return (from i in Table<T> ()
                //        where i.ID == id
                //        select i).FirstOrDefault ();
            }
		}

		public int SaveItem<T> (T item) where T : IPersistentEntity
		{
            lock (locker) {
                if (item.ID != 0) {
                    Update (item);
                    return item.ID;
                } else {
                    return Insert (item);
                }
            }
		}
		
		public int DeleteItem<T>(int id) where T : IPersistentEntity, new ()
		{
            lock (locker) {
#if NETFX_CORE
                return Delete(new T() { ID = id });
#else
                return Delete<T> (new T () { ID = id });
#endif
            }
		}
	}
}