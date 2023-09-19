using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for theme.xaml
    /// </summary>
    public partial class theme : Window
    {

        Configuration AppConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public theme()
        {

            string[] Theme = new string[] { "Dark", "Light", "Green", "Blue", "Yellow" };
            string[] Languages = new string[] { "English", "Dansk" };

            InitializeComponent();

            LanguageCombobox.ItemsSource = Languages;
            ThemesCombobox.ItemsSource = Theme;

            if (AppConfig.Sections["UiSettings"] is null)
            {
                AppConfig.Sections.Add("UiSettings", new UiSettings());

            }

            var UiSettingSection = AppConfig.GetSection("UiSettings");

            this.DataContext = UiSettingSection;
        }


        private void Save(object sender, RoutedEventArgs e)
        { AppConfig.Save(); }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        //        private void Dark(object sender, RoutedEventArgs e)
        //        {
        //            UiSettings.ChangeTheme( new Uri("Themes/Dark.xaml",UriKind.Relative));
        //        }

        //        private void Light(object sender, RoutedEventArgs e)
        //        {
        //          UiSettings.ChangeTheme(new Uri("Themes/Light.xaml", UriKind.Relative));                   
        //        }


        private void ThemesCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemesCombobox.SelectedItem != null)
            {
                string? selectedTheme = ThemesCombobox.SelectedItem.ToString();
                switch (selectedTheme)
                {
                    case "Dark":
                        UiSettings.ChangeTheme(new Uri("Themes/Dark.xaml", UriKind.Relative));
                        AppConfig.Save();
                        break;
                    case "Light":
                        UiSettings.ChangeTheme(new Uri("Themes/Light.xaml", UriKind.Relative));
                        AppConfig.Save();
                        break;
                    case "Green":
                        UiSettings.ChangeTheme(new Uri("Themes/Green.xaml", UriKind.Relative));
                        AppConfig.Save();
                        break;
                    case "Blue":
                        UiSettings.ChangeTheme(new Uri("Themes/Blue.xaml", UriKind.Relative));
                        AppConfig.Save();
                        break;
                    case "Yellow":
                        UiSettings.ChangeTheme(new Uri("Themes/Yellow.xaml", UriKind.Relative));
                        AppConfig.Save();
                        break;
                }
            }
        }

    }
}