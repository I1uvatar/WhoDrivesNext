using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WhoDrivesNext.Core.Model;

namespace WhoDrivesNext.Droid.Adapters
{
    public class PersonListAdapter : BaseAdapter<Person>
    {
        protected Activity context = null;
        protected IList<Person> persons = new List<Person>();

        public PersonListAdapter(Activity context, IList<Person> persons) : base()
        {
            this.context = context;
            this.persons = persons;
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            // Get our object for position
            var item = persons[position];
            View view;

            //Try to reuse convertView if it's not  null, otherwise inflate it from our item layout
            // gives us some performance gains by not always inflating a new view
            if (convertView == null)
            {
                view = context.LayoutInflater.Inflate(Resource.Layout.PersonListItem, null);
            }
            else
            {
                view = convertView;
            }

            var firstNameLabel = view.FindViewById<TextView>(Resource.Id.lblFirstName);
            firstNameLabel.Text = item.FirstName;
            var lastNameLabel = view.FindViewById<TextView>(Resource.Id.lblLastName);
            lastNameLabel.Text = item.LastName;
            
            //Finally return the view
            return view;
        }

        public override int Count
        {
            get { return persons.Count; }
        }

        public override Person this[int position]
        {
            get { return  persons[position]; }
        }
    }
}