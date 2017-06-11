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
				await DisplayAlert("Error","Email no puede estar vacio","Aceptar");
				emailEntry.Focus();
				return;
			}
			if(string.IsNullOrEmpty(passwordEntry.Text)){
				await DisplayAlert("Error","Debes introducir una contraseña","Aceptar");
				passwordEntry.Focus();
				return;
			}
		}
	}
}
