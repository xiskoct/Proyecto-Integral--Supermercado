using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Supermercado
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			loginButton.Clicked += loginButton_Clicked;
		}
		private async void loginButton_Clicked (object sender, EventArgs e){

			if(string.IsNullOrEmpty(emailEntry.Text)){
				await DisplayAlert("Error","Debe ingresar un email","Aceptar");
				emailEntry.Focus();
				return;
			}
			if(string.IsNullOrEmpty(passwordEntry.Text)){
				await DisplayAlert("Error","Debe ingresar un email","Aceptar");
				passwordEntry.Focus();
				return;
			}
		}
	}
}
