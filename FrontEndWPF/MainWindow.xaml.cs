using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows;

namespace FrontEndWPF
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

        /// <summary>
        /// This is the button Click for answering question 2. Just make sure the directory 'C:\temp' exists!
        /// </summary>
        /// <param name="sender">the sender.</param>
        /// <param name="e">the events.</param>
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // Checking if the name is entered and doesn't contain digits
            if (string.IsNullOrWhiteSpace(ContentName.Text) || ContentName.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Please enter a valid Name value. No digits allowed.", "Alert", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            // Checking if the address is entered.
            if (string.IsNullOrWhiteSpace(ContentAddress.Text))
            {
                MessageBox.Show("Please enter a valid address value", "Alert", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            // Checking if the phone number is entered and only contains digits
            if (string.IsNullOrWhiteSpace(ContentPhoneNumber.Text) || ContentName.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter a valid phone number value. It must only be digits", "Alert", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                return;
            }

            // We're now saving the value into a text file.
            // Checking if the file exists, if it doesn't we'll create it.
            if (!File.Exists(Properties.Settings.Default.csvFile))
            {
                // Create a file to write to.
                using (var streamWriter = File.CreateText(Properties.Settings.Default.csvFile))
                {
                    streamWriter.WriteLine($"Name:\t{ContentName.Text}\tAddress:\t{ContentAddress.Text}\tPhone Number:\t{ContentPhoneNumber.Text}");
                }
            }
            else // we're adding to the already created file.
            {
                // appending as true
                using (var streamWriter = new StreamWriter(Properties.Settings.Default.csvFile, true))
                {
                    streamWriter.WriteLine($"Name:\t{ContentName.Text}\tAddress:\t{ContentAddress.Text}\tPhone Number:\t{ContentPhoneNumber.Text}");
                }
            }
        }
    }
}
