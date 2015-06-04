using System.Collections.Generic;
using WhoDrivesNext.Core.DataAccessLayer;
using WhoDrivesNext.Core.Model;

namespace WhoDrivesNext.Core.Managers
{
	public static class EntityManager
	{
		static EntityManager ()
		{
		}

	    #region Person

	    public static Person GetPerson(int id)
	    {
	        return EntitiesRepository.GetPerson(id);
	    }

	    public static IList<Person> GetPersons()
	    {
	        return new List<Person>(EntitiesRepository.GetPersons());
	    }

	    public static int SavePerson(Person item)
	    {
	        return EntitiesRepository.SavePerson(item);
	    }

	    public static int DeletePerson(int id)
	    {
	        return EntitiesRepository.DeletePerson(id);
	    }

	    #endregion

        //#region Group

        //public static Group GetGroup(int id)
        //{
        //    return EntitiesRepository.GetGroup(id);
        //}

        //public static IList<Group> GetGroups()
        //{
        //    return new List<Group>(EntitiesRepository.GetGroups());
        //}

        //public static int SaveGroup(Group item)
        //{
        //    return EntitiesRepository.SaveGroup(item);
        //}

        //public static int DeleteGroup(int id)
        //{
        //    return EntitiesRepository.DeleteGroup(id);
        //}

        //#endregion

        #region GroupPersonPoint

        public static GroupPersonPoint GetGroupPersonPoint(int id)
        {
            return EntitiesRepository.GetGroupPersonPoint(id);
        }

        public static IList<GroupPersonPoint> GetGroupPersonPoints()
        {
            return new List<GroupPersonPoint>(EntitiesRepository.GetGroupPersonPoints());
        }

        public static int SaveGroupPersonPoint(GroupPersonPoint item)
        {
            return EntitiesRepository.SaveGroupPersonPoint(item);
        }

        public static int DeleteGroupPersonPoint(int id)
        {
            return EntitiesRepository.DeleteGroupPersonPoint(id);
        }

        #endregion

     }
}