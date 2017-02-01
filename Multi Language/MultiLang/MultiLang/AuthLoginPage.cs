using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;

namespace MultiLang
{
    public class AuthLoginPage : Page
    {
        public OAuth2Authenticator authenticator;

        public AuthLoginPage(OAuth2Authenticator authenticator)
        {
            this.authenticator = authenticator;
        }
        public Action FacebookLoginAction
        {
            get
            {
                return new Action(() => goFacebook());
            }
        }
        public Action GoogleLoginAction
        {
            get
            {
                return new Action(() => goGoogle());
            }
        }

        private void goFacebook()
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new ProfilePage() { Title = "Facebook" });
        }

        private void goGoogle()
        {
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new ProfilePage() { Title = "Google" });
        }
        public Action FailedLoginAction
        {
            get
            {
                return new Action(() => goBack());
            }
        }

        private void goBack()
        {
            Navigation.PopModalAsync();
        }
    }
}
