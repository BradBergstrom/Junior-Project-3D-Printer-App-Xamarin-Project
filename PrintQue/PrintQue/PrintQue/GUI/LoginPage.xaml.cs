﻿using PrintQue.Models;
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
		public LoginPage ()
		{
			InitializeComponent ();
            RegisterLabel_Clicked();


                
            

        }
        async public void CreateTables()
        {
            
            SQLiteAsyncConnection conn = new SQLiteAsyncConnection(App.DatabaseLocation);

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

                        Navigation.PushAsync(new RegisterPage());
                        CreateTables();
                        
                    }
                    )
            });

        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            bool isUsernameEmpty = string.IsNullOrEmpty(userNameEntry.Text);
            bool isPasswordEmpty = string.IsNullOrEmpty(userPasswordEntry.Text);
            if (isUsernameEmpty || isPasswordEmpty)
            {
                //then show error
                await DisplayAlert("Attention", "Please fill out all forms", "ok");
            }
            else
            {
                if (userNameEntry.Text.Equals("admin"))
                {
                    //admin
                    await Navigation.PushAsync(new AdminTabContainer());
                }
                else
                {

                    var user = await User.SearchByEmail(userNameEntry.Text);
                    if(user != null)
                    {
                        if (user.Password.Contains(userPasswordEntry.Text))
                        {
                            await Navigation.PushAsync(new UserTabContainer());
                        }
                    }
                    

                    
                }

                ////then try to log in user
                //if (userNameEntry.Text.Equals("admin")){
                //    //admin
                //    Navigation.PushAsync(new AdminTabContainer());
                //} else
                //{
                //    //student
                //    Navigation.PushAsync(new UserTabContainer());
                //}


            }

        }
    }
}