using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Auth;
using Xamarin.Forms;

namespace MultiLang
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Locale.SetLocale();
            if (Device.OS == TargetPlatform.iOS)
            {
                GoogleSignin.WidthRequest = 300;
                FacebookLogin.WidthRequest = 300;
            }
        }

        protected override void OnAppearing()
        {
            CheckAccounts();
            PopulateValues();
            base.OnAppearing();
        }

        private void CheckAccounts()
        {
            AccountData.FacebookAccount = null;
            if (Settings.FacebookState != "" && Settings.FacebookAccessToken != "" && Settings.FacebookExpiresIn != "")
            {
                Dictionary<string, string> _properties = new Dictionary<string, string>();

                _properties.Add("state", Settings.FacebookState);
                _properties.Add("access_token", Settings.FacebookAccessToken);
                _properties.Add("expires_in", Settings.FacebookExpiresIn);

                AccountData.FacebookAccount = new Account(Settings.FacebookUsername, _properties);
            }

            AccountData.GoogleAccount = null;
            if (Settings.GoogleAccessToken != "" && Settings.GoogleExpiresIn != "" && Settings.GoogleIDToken != "" && Settings.GoogleTokenType != "")
            {
                Dictionary<string, string> _properties = new Dictionary<string, string>();

                _properties.Add("access_token", Settings.GoogleAccessToken);
                _properties.Add("expires_in", Settings.GoogleExpiresIn);
                _properties.Add("id_token", Settings.GoogleIDToken);
                _properties.Add("token_type", Settings.GoogleTokenType);

                AccountData.GoogleAccount = new Account(Settings.GoogleUsername, _properties);
            }
        }

        private void PopulateValues()
        {
            if (AccountData.FacebookAccount == null)
            {
                FacebookLogin.Text = LanguageResources.LoginFacebook;
            }
            else
            {
                FacebookLogin.Text = LanguageResources.OpenFacebook;
            }
            if (AccountData.GoogleAccount == null)
            {
                GoogleSignin.Text = LanguageResources.SignInGoogle;
            }
            else
            {
                GoogleSignin.Text = LanguageResources.OpenGoogle;
            }
            LocaleImage.Source = LanguageResources.LanguageImageSource;
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

        private async void OnFacebookClicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
                await DisplayAlert("No Connection", "It appears you are not connected to the Internet", "OK");
            else
            {
                FacebookLogin.IsEnabled = false;
                GoogleSignin.IsEnabled = false;
                LocaleImage.IsEnabled = false;
                if (AccountData.FacebookAccount == null)
                {
                    OAuth2Authenticator auth = new OAuth2Authenticator(
                        clientId: "593849957485255",
                        scope: "",
                        authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                        redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));

                    await Navigation.PushModalAsync(new AuthLoginPage(auth) {Title = "Facebook"});
                }
                else
                {
                    await Navigation.PushModalAsync(new ProfilePage() {Title = "Facebook"});
                }
                FacebookLogin.IsEnabled = true;
                GoogleSignin.IsEnabled = true;
                LocaleImage.IsEnabled = true;
            }
        }

        private async void OnGoogleClicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
                await DisplayAlert("No Connection", "It appears you are not connected to the Internet", "OK");
            else
            {
                FacebookLogin.IsEnabled = false;
                GoogleSignin.IsEnabled = false;
                LocaleImage.IsEnabled = false;
                if (AccountData.GoogleAccount == null)
                {
                    OAuth2Authenticator auth = new OAuth2Authenticator(
                        clientId: "409631933629-8rnvan6aefmh5q462i1kf9scsldstig2.apps.googleusercontent.com",
                        clientSecret: "RACVAcihQhY8jsP_VCWKckw3",
                        scope: "https://www.googleapis.com/auth/userinfo.profile",
                        authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/auth"),
                        redirectUrl: new Uri("https://upload.wikimedia.org/wikipedia/en/f/ff/SuccessKid.jpg"),
                        accessTokenUrl: new Uri("https://accounts.google.com/o/oauth2/token"));

                    await Navigation.PushModalAsync(new AuthLoginPage(auth) {Title = "Google"});
                }
                else
                {
                    await Navigation.PushModalAsync(new ProfilePage() {Title = "Google"});
                }
                FacebookLogin.IsEnabled = true;
                GoogleSignin.IsEnabled = true;
                LocaleImage.IsEnabled = true;
            }
        }
    }
}
