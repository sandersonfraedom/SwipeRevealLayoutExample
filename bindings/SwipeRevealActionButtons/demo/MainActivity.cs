using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;
using Android.Support.V7.Widget;
using Android.Views;
using ME.Markosullivan.Swiperevealactionbuttons;

namespace demo
{
    [Activity(Label = "demo", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var unused = new RecyclerView(this);
            var asd = unused.GetType().Name;

            SetContentView(Resource.Layout.activity_main);
            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.recycler_view);
            RecyclerView.LayoutManager layoutManager = new LinearLayoutManager(this);
            recyclerView.SetLayoutManager(layoutManager);
            MainListAdapter mainListAdapter = new MainListAdapter(getMealList());
            recyclerView.SetAdapter(mainListAdapter);
        }

        public List<String> getMealList()
        {
            List<String> mealList = new List<String>();
            mealList.Add("Green Thai Curry");
            mealList.Add("Granola");
            mealList.Add("Poached Eggs");
            mealList.Add("Spaghetti");
            mealList.Add("Apple Pie");
            mealList.Add("Grilled Cheese Sandwich");
            mealList.Add("Vegetable Soup");
            mealList.Add("Chicken Noodles");
            mealList.Add("Fajitas");
            mealList.Add("Chicken Pot Pie");
            mealList.Add("Pasta and cauliflower casserole with chicken");
            mealList.Add("Vegetable stir-fry");
            mealList.Add("Sweet potato and orange soup");
            mealList.Add("Vegetable Broth");
            return mealList;
        }
    }

    public class MainListAdapter : RecyclerView.Adapter
    {

        private List<String> shoppingList;

        public MainListAdapter(List<String> shoppingList)
        {
            this.shoppingList = shoppingList;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View view = LayoutInflater.From(parent.Context)
                    .Inflate(Resource.Layout.list_item_main, parent, false);
            return new MainListItem(view);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MainListItem mainListItem = (MainListItem)holder;
            mainListItem.mealTV.Text = shoppingList[position];
            mainListItem.infoButton.Click += (object o, EventArgs a) =>
             {
                 View v = (View)o;
                Toast.MakeText(v.Context, "INFO CLICKED", ToastLength.Short).Show();
             };
            mainListItem.editButton.Click += (object o, EventArgs a) =>
            {
            View v = (View)o;
                Toast.MakeText(v.Context, "EDIT CLICKED", ToastLength.Short).Show();
        };
        }


        public override int ItemCount=>
             shoppingList.Count;

        public class MainListItem : RecyclerView.ViewHolder
        {

            public TextView mealTV;
            public ImageButton infoButton;
            public ImageButton editButton;

            public MainListItem(View itemView)
                : base(itemView)
            {
                var x = (SwipeRevealLayout)itemView;
                x.Close(false);
                
                mealTV = itemView.FindViewById<TextView>(Resource.Id.meal_tv);
                infoButton = itemView.FindViewById<ImageButton>(Resource.Id.info_button);
                editButton = itemView.FindViewById<ImageButton>(Resource.Id.edit_button);
            }
        }
    }

}