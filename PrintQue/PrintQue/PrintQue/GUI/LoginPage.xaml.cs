﻿using PrintQue.Models;
using PrintQue.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrintQue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        LoginViewModel viewModel;
		public LoginPage ()
		{
			InitializeComponent ();
            RegisterLabel_Clicked();
            viewModel = new LoginViewModel();
            BindingContext = viewModel;                
            

        }
        async public void CreateTables()
        {
            
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(App.DatabaseLocation);
            await conn.CreateTableAsync<Message>();
            await conn.CreateTableAsync<User>();
            await conn.CreateTableAsync<Request>();
            await conn.CreateTableAsync<Printer>();
            await conn.CreateTableAsync<Status>();
            await conn.CreateTableAsync<PrintColor>();
            await conn.CloseAsync();
        }
        private void RegisterLabel_Clicked()
             {
                //not an autogenerated file
                RegisterLabel.GestureRecognizers.Add(new TapGestureRecognizer()
                {
                    Command = new Command(() =>
                    {
                        CreateTables();
                        Navigation.PushAsync(new RegisterPage());
                        
                        
                    }
                    )
            });

        }


    }
}