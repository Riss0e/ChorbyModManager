using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChorbyModManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        public void ClearFocus(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is DependencyObject obj && !(obj is TextBox))
            {
                Keyboard.ClearFocus();
            }
        }
    }
}
