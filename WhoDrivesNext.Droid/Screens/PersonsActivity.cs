using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WhoDrivesNext.Core.Model;
using WhoDrivesNext.Droid.Adapters;

namespace WhoDrivesNext.Droid.Screens
{
    [Activity(Label = "PersonsActivity")]
    public class PersonsActivity : Activity
    {
        protected ListView personListView = null;
        protected IList<Person> persons;
        protected PersonListAdapter personListAdapter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.PersonsScreen);

            personListView = FindViewById<ListView>(Resource.Id.personsListView);

        }

        protected override void OnResume()
        {
            base.OnResume();
            persons = GenerateDummyPersons();

            personListAdapter = new PersonListAdapter(this,persons);

            personListView.Adapter = personListAdapter;


        }

        private IList<Person> GenerateDummyPersons()
        {
            return new List<Person>()
            {
                new Person() {FirstName = "Homer", PersonId = Guid.NewGuid(), LastName = "Simpson"},
                new Person() {FirstName = "Marge", PersonId = Guid.NewGuid(), LastName = "Simpson"},
                new Person() {FirstName = "Bart", PersonId = Guid.NewGuid(), LastName = "Simpson" },
                new Person() {FirstName = "Lisa", PersonId = Guid.NewGuid(), LastName = "Simpson" },
                new Person() {FirstName = "Magie", PersonId = Guid.NewGuid(), LastName = "Simpson" }
            };
        }
    }
}