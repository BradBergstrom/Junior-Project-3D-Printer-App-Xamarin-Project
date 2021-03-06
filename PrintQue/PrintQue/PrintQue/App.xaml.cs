﻿using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PrintQue.Models;
using PrintQue.Helper;
using PrintQue.ViewModel;
using Newtonsoft.Json;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrintQue
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static UserViewModel    LoggedInUser   = null;
        public static MobileServiceClient MobileService =new MobileServiceClient("http://3dprintqueue.azurewebsites.net");
        //public static IMobileServiceSyncTable<Request> requestsTable;
        //public static IMobileServiceSyncTable<Printer> printersTable;
        //public static IMobileServiceSyncTable<Status> statusesTable;
        //public static IMobileServiceSyncTable<PrintColor> printColorsTable;
        //
        //public static IMobileServiceSyncTable<Message> messagesTable;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new MainPage();
        }

        //private async void Getdata()
        //{
        //    var test = await MobileService.GetTable<Request>().ToListAsync();
        //    if (test != null)
        //    {
        //        await AzureAppServiceHelper.SyncAsync();
        //        var test2 = await requestsTable.ToListAsync();
        //        if (test2 == null) ;

        //    }
        //}

        public App(string databaseLocation)
        {
            InitializeComponent();
            


            DatabaseLocation = databaseLocation;
            //var store = new MobileServiceSQLiteStore(databaseLocation);
            //store.DefineTable<Request>();
            //store.DefineTable<PrintColor>();
            //store.DefineTable<Printer>();
            //store.DefineTable<Status>();
            //store.DefineTable<Message>();
            //MobileService.SyncContext.InitializeAsync(store);
            //requestsTable = MobileService.GetSyncTable<Request>();
            //printersTable = MobileService.GetSyncTable<Printer>();
            //statusesTable = MobileService.GetSyncTable<Status>();
            //printColorsTable = MobileService.GetSyncTable<PrintColor>();
            //messagesTable = MobileService.GetSyncTable<Message>();
            //Getdata();
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new MainPage();


        }

        protected override async void OnStart()
        {
            string androidAppSecret = "5d3acf09-ac5b-4fa8-9cc2-a4024926fd08";
            AppCenter.Start($"android={androidAppSecret}", typeof(Push));
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
