using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MultiLang
{
    public class _theme
    {
        public string FontFamily;
        public Color BackgroundColor;
        public Color TextColor;

        public _theme(string _fontFamily, Color _backgroundColor, Color _textColor)
        {
            FontFamily = _fontFamily;
            BackgroundColor = _backgroundColor;
            TextColor = _textColor;
        }
    }
    public static class Theme
    {
        //public static _theme Grayscale = new _theme();
        //public static _theme Inverted = new _theme();
        //public static _theme WizKhalifa = new _theme();
    }
}
