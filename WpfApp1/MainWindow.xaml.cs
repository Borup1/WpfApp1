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
       
        public MainWindow()
        {            
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        // Opens the Theam Window
        private void Theme(object sender, RoutedEventArgs e)
        { theme sw = new theme(); sw.Show(); }

        //EXit The Application 
        private void Exit(object sender, RoutedEventArgs e)
        { App.Current.Shutdown(); }

        // Let+s Us move the window around 
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
            string selectedTheme = UiSettings.GetSelectedTheme();

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

}
