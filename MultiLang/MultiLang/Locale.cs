using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLang
{
    public static class Locale
    {
        public static string LocaleName = Settings.Language;
        public static void SetLocale()
        {
            Settings.Language = LocaleName;
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(LocaleName);
            LanguageResources.Culture = new CultureInfo(LocaleName);
        }
    }
}
