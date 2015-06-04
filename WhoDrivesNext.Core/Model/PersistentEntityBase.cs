using WhoDrivesNext.Core.DataLayer;

namespace WhoDrivesNext.Core.Model {
	/// <summary>
	/// Business entity base class. Provides the ID property.
	/// </summary>
	public abstract class PersistentEntityBase : IPersistentEntity {
		public PersistentEntityBase ()
		{
		}
		
		/// <summary>
		/// Gets or sets the Database ID.
		/// </summary>
		[PrimaryKey, AutoIncrement]
        public int ID { get; set; }
	}
}

