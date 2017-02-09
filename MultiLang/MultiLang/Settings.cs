using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MultiLang
{
    public static class Settings
    {
        private const string facebookUsername = "facebookUsername";
        private static readonly string defaultFacebookUsername = "";

        public static string FacebookUsername
        {
            get { return AppSettings.GetValueOrDefault<string>(facebookUsername, defaultFacebookUsername); }
            set { AppSettings.AddOrUpdateValue<string>(facebookUsername, value); }
        }

        private const string facebookState = "facebookState";
        private static readonly string defaultFacebookState = "";

        public static string FacebookState
        {
            get { return AppSettings.GetValueOrDefault<string>(facebookState, defaultFacebookState); }
            set { AppSettings.AddOrUpdateValue<string>(facebookState, value); }
        }

        private const string facebookAccessToken = "facebookAccessToken";
        private static readonly string defaultFacebookAccessToken = "";

        public static string FacebookAccessToken
        {
            get { return AppSettings.GetValueOrDefault<string>(facebookAccessToken, defaultFacebookAccessToken); }
            set { AppSettings.AddOrUpdateValue<string>(facebookAccessToken, value); }
        }

        private const string facebookExpiresIn = "facebookExpiresIn";
        private static readonly string defaultFacebookExpiresIn = "";

        public static string FacebookExpiresIn
        {
            get { return AppSettings.GetValueOrDefault<string>(facebookExpiresIn, defaultFacebookExpiresIn); }
            set { AppSettings.AddOrUpdateValue<string>(facebookExpiresIn, value); }
        }

        private const string googleUsername = "googleUsername";
        private static readonly string defaultGoogleUsername = "";

        public static string GoogleUsername
        {
            get { return AppSettings.GetValueOrDefault<string>(googleUsername, defaultGoogleUsername); }
            set { AppSettings.AddOrUpdateValue<string>(googleUsername, value); }
        }

        private const string googleAccessToken = "googleAccessToken";
        private static readonly string defaultGoogleAccessToken = "";

        public static string GoogleAccessToken
        {
            get { return AppSettings.GetValueOrDefault<string>(googleAccessToken, defaultGoogleAccessToken); }
            set { AppSettings.AddOrUpdateValue<string>(googleAccessToken, value); }
        }

        private const string googleExpiresIn = "googleExpiresIn";
        private static readonly string defaultGoogleExpiresIn = "";

        public static string GoogleExpiresIn
        {
            get { return AppSettings.GetValueOrDefault<string>(googleExpiresIn, defaultGoogleExpiresIn); }
            set { AppSettings.AddOrUpdateValue<string>(googleExpiresIn, value); }
        }

        private const string googleIDToken = "googleIDToken";
        private static readonly string defaultGoogleIDToken = "";

        public static string GoogleIDToken
        {
            get { return AppSettings.GetValueOrDefault<string>(googleIDToken, defaultGoogleIDToken); }
            set { AppSettings.AddOrUpdateValue<string>(googleIDToken, value); }
        }

        private const string googleTokenType = "googleTokenType";
        private static readonly string defaultGoogleTokenType = "";

        public static string GoogleTokenType
        {
            get { return AppSettings.GetValueOrDefault<string>(googleTokenType, defaultGoogleTokenType); }
            set { AppSettings.AddOrUpdateValue<string>(googleTokenType, value); }
        }

        private const string language = "language";
        private static readonly string defaultLanguage = "en-GB";

        public static string Language
        {
            get { return AppSettings.GetValueOrDefault<string>(language, defaultLanguage); }
            set { AppSettings.AddOrUpdateValue<string>(language, value); }
        }

        private static ISettings AppSettings => CrossSettings.Current;
    }
}
