using System.Collections.Generic;
using MultiLang;
using MultiLang.iOS;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AuthLoginPage), typeof(AuthLoginPageRenderer))]
namespace MultiLang.iOS
{
    public class AuthLoginPageRenderer : PageRenderer
    {
        private AuthLoginPage page;
        private OAuth2Authenticator auth;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            page = e.NewElement as AuthLoginPage;
            auth = page.authenticator;

            auth.Completed += (sender, eventArgs) => {
                if (eventArgs.IsAuthenticated)
                {

                    if (eventArgs.Account.Properties.Count == 3)
                    {
                        Settings.FacebookUsername = eventArgs.Account.Username;

                        Settings.FacebookState = eventArgs.Account.Properties["state"];
                        Settings.FacebookAccessToken = eventArgs.Account.Properties["access_token"];
                        Settings.FacebookExpiresIn = eventArgs.Account.Properties["expires_in"];

                        Dictionary<string, string> _properties = new Dictionary<string, string>();

                        _properties.Add("state", Settings.FacebookState);
                        _properties.Add("access_token", Settings.FacebookAccessToken);
                        _properties.Add("expires_in", Settings.FacebookExpiresIn);

                        Account _account = new Account(Settings.FacebookUsername, _properties);
                        AccountData.FacebookAccount = _account;

                        page.FacebookLoginAction.Invoke();
                    }
                    else if (eventArgs.Account.Properties.Count == 4)
                    {
                        Settings.GoogleUsername = eventArgs.Account.Username;

                        Settings.GoogleAccessToken = eventArgs.Account.Properties["access_token"];
                        Settings.GoogleExpiresIn = eventArgs.Account.Properties["expires_in"];
                        Settings.GoogleIDToken = eventArgs.Account.Properties["id_token"];
                        Settings.GoogleTokenType = eventArgs.Account.Properties["token_type"];

                        Dictionary<string, string> _properties = new Dictionary<string, string>();

                        _properties.Add("access_token", Settings.GoogleAccessToken);
                        _properties.Add("expires_in", Settings.GoogleExpiresIn);
                        _properties.Add("id_token", Settings.GoogleIDToken);
                        _properties.Add("token_type", Settings.GoogleTokenType);

                        Account _account = new Account(Settings.GoogleUsername, _properties);
                        AccountData.GoogleAccount = _account;

                        page.GoogleLoginAction.Invoke();
                    }
                    else
                        page.FailedLoginAction.Invoke();

                }
                else
                {
                    page.FailedLoginAction.Invoke();
                }

                PresentViewController(auth.GetUI(), true, null);
            };
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

    }
}