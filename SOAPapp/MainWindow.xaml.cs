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


namespace SOAPapp
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

        private void HelloWorldButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.WebServiceSoapClient client = new ServiceReference1.WebServiceSoapClient();
            HelloWorldLabel.Content = client.HelloWorld();
            client.Close();
        }

        private void FarenheitToCelsiusButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float temp_t = float.Parse(farenheit_textbox.Text);
                ServiceReference1.WebServiceSoapClient client = new ServiceReference1.WebServiceSoapClient();
                convertedToCelsiusLabel.Content = client.Farenheit2Celsius(temp_t) + " C";
            }
            catch
            {
                MessageBox.Show("Error parsing temperature!");
                farenheit_textbox.Text = "";
            }
        }

        private void CelsiusToFarenheitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                float temp_c = float.Parse(celsius_textbox.Text);
                ServiceReference1.WebServiceSoapClient client = new ServiceReference1.WebServiceSoapClient();
                convertedToFarenheitLabel.Content = client.Celsius2Farenheit(temp_c) + " F";
                client.Close();
            }
            catch
            {
                MessageBox.Show("Error parsing temperature!");
                celsius_textbox.Text = "";
            }
        }

        private void LoadJsonButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.WebServiceSoapClient client = new ServiceReference1.WebServiceSoapClient();
            Json_textblock.Text = client.LoadJSON(json_name_textbox.Text);
            client.Close();
        }
    }
}
