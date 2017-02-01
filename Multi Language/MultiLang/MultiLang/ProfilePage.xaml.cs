using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;

namespace MultiLang
{
    public partial class ProfilePage : ContentPage
    {
        private string _account;
        public ProfilePage()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.iOS)
            {
                GoBackButton.BackgroundColor = Color.White;
                GoBackButton.WidthRequest = 100;
                SignOutButton.BackgroundColor = Color.White;
                SignOutButton.WidthRequest = 100;
                MainScrollView.Margin = new Thickness(0, 20, 0, 0);
            }
        }
        protected override void OnAppearing()
        {
            PopulateValues();
            base.OnAppearing();
        }
        private void PopulateValues()
        {
            SignOutButton.Text = LanguageResources.SignOut;
            GoBackButton.Text = LanguageResources.GoBack;
            LocaleImage.Source = LanguageResources.LanguageImageSource;
            ProfilePageLabel.Text = LanguageResources.ProfilePage;
            if (this.Title == "Facebook")
            {
                MainScrollView.BackgroundColor = Xamarin.Forms.Color.FromHex("#8b9dc3");
                ProfilePageLabel.TextColor = Xamarin.Forms.Color.Red;
                ProfilePageLabel.FontSize = 15;
                UsernameLabel.TextColor = Xamarin.Forms.Color.Red;
                UsernameLabel.FontFamily = "Droid Sans Serif";
                UsernameLabel.FontSize = 40;
                if (AccountData.FacebookAccount != null)
                {
                    getFacebookData();
                }

            }
            else if (this.Title == "Google")
            {
                MainScrollView.BackgroundColor = Xamarin.Forms.Color.FromHex("#d34836");
                ProfilePageLabel.TextColor = Xamarin.Forms.Color.Lime;
                ProfilePageLabel.FontSize = 20;
                UsernameLabel.TextColor = Xamarin.Forms.Color.Lime;
                UsernameLabel.FontFamily = "Droid Mono";
                UsernameLabel.FontSize = 30;
                if (AccountData.GoogleAccount != null)
                {
                    getGoogleData();
                }
            }
            else
                UsernameLabel.Text = "BaDumTssss";
        }

        private void OnLocaleTapped(object sender, EventArgs e)
        {
            LocaleImage.IsEnabled = false;
            switch (Locale.LocaleName)
            {
                case "en-GB":
                    Locale.LocaleName = "bs-Latn-BA";
                    break;
                case "bs-Latn-BA":
                    Locale.LocaleName = "en-GB";
                    break;
                default:
                    break;
            }
            Locale.SetLocale();
            PopulateValues();
            LocaleImage.IsEnabled = true;
        }

        protected override bool OnBackButtonPressed()
        {
            return true;
            //return base.OnBackButtonPressed();
        }

        private async void getFacebookData()
        {
            try
            {
                var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me"), null,
                    AccountData.FacebookAccount);
                var response = await request.GetResponseAsync();
                var obj = JObject.Parse(response.GetResponseText());
                var id = obj["id"].ToString().Replace("\"", "");
                UsernameLabel.Text = obj["name"].ToString().Replace("\"", "");
                request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/" + id + "/picture?type=large"),
                    null, AccountData.FacebookAccount);
                response = await request.GetResponseAsync();
                ProfilePic.Source = response.ToString().Remove(0, 3);
                ;
            }
            catch (Exception e)
            {
                await DisplayAlert("Logged Out", "Sorry, you were logged out of Facebook!", "OK");
                SignOut();
            }
        }

        private async void getGoogleData()
        {
            try
            {
                var request = new OAuth2Request("GET", new Uri("https://www.googleapis.com/oauth2/v1/userinfo?alt=json"), null, AccountData.GoogleAccount);
                var response = await request.GetResponseAsync();
                var obj = JObject.Parse(response.GetResponseText());
                UsernameLabel.Text = obj["name"].ToString().Replace("\"", "");
                ProfilePic.Source = obj["picture"].ToString().Replace("\"", "");
            }
            catch (Exception e)
            {
                await DisplayAlert("Signed Out", "Sorry, you were signed out of Google!", "OK");
                SignOut();
            }
        }

        private void OnSignOutClicked(object sender, EventArgs e)
        {
            SignOut();
        }

        private void SignOut()
        {
            if (this.Title == "Facebook")
            {
                Settings.FacebookUsername = "";
                Settings.FacebookState = "";
                Settings.FacebookAccessToken = "";
                Settings.FacebookExpiresIn = "";
            }
            else if (this.Title == "Google")
            {
                Settings.GoogleUsername = "";
                Settings.GoogleAccessToken = "";
                Settings.GoogleExpiresIn = "";
                Settings.GoogleIDToken = "";
                Settings.GoogleTokenType = "";
            }
            Navigation.PopModalAsync();
        }

        private void OnGoBackClicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
