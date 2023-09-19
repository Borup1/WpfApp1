using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    internal class UiSettings : ConfigurationSection
    {
        [ConfigurationProperty("language", DefaultValue = "English")]
        public string Language
        { 
          get { return (String)this["language"]; }
          set { this["language"] = value; }              
        }

        [ConfigurationProperty("Theme", DefaultValue = "Light")]
        public string Theme
        {
            get { return (String)this["Theme"]; }
            set { this["Theme"] = value; }
        }

        [ConfigurationProperty("Currency", DefaultValue = "£")]
        public string Currency
        {
            get { return (String)this["Currency"]; }
            set { this["Currency"] = value; }
        }

        [ConfigurationProperty("FontSize", DefaultValue = 8)]
        public int FontSize
        {
            get { return (int)this["FontSize"]; }
            set { this["FontSize"] = value; }
        }

        public static void ChangeTheme(Uri Themeuri)
        {

            ResourceDictionary Theme = new ResourceDictionary() { Source = Themeuri };

            App.Current.Resources.Clear();
            App.Current.Resources.MergedDictionaries.Add(Theme);

        }

    }
}
