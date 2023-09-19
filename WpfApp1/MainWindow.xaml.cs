using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Configuration AppConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public MainWindow()
        {
            string[] Theme = new string[] { "Dark", "Light", "Green", "Blue", "Yellow" };
            string[] Languages = new string[] { "English", "Dansk" };

            InitializeComponent();

            if (AppConfig.Sections["UiSettings"] is null)
            {
                AppConfig.Sections.Add("UiSettings", new UiSettings());

            }

            var UiSettingSection = AppConfig.GetSection("UiSettings");

            this.DataContext = UiSettingSection;

        }


        private void Theme(object sender, RoutedEventArgs e)
        { theme sw = new theme(); sw.Show(); }

        private void Exit(object sender, RoutedEventArgs e)
        { App.Current.Shutdown(); }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Apply the selected theme from the configuration settings
            string selectedTheme = UiSettings.GetSelectedTheme(); // Replace with the actual method to retrieve the selected theme

            // Assuming UiSettings.GetSelectedTheme() returns the selected theme as a string
            switch (selectedTheme)
            {
                case "Dark":
                    UiSettings.ChangeTheme(new Uri("Themes/Dark.xaml", UriKind.Relative));
                    break;
                case "Light":
                    UiSettings.ChangeTheme(new Uri("Themes/Light.xaml", UriKind.Relative));
                    break;
                case "Green":
                    UiSettings.ChangeTheme(new Uri("Themes/Green.xaml", UriKind.Relative));
                    break;
                case "Blue":
                    UiSettings.ChangeTheme(new Uri("Themes/Blue.xaml", UriKind.Relative));
                    break;
                case "Yellow":
                    UiSettings.ChangeTheme(new Uri("Themes/Yellow.xaml", UriKind.Relative));
                    break;
                default:
                    // Handle the case where no theme is selected or it's an invalid value
                    break;
            }
        }
        
}
