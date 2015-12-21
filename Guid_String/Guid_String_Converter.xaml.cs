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

namespace Guid_String
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

        private void btConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rbGtS.IsChecked == true)
                {
                    if (txtInput.Text.Length < 32)
                    {
                        MessageBox.Show("Input string must be a 32 characters.");
                        return;
                    }

                    Guid convertedGuid = new Guid(txtInput.Text);
                    string str64 = Convert.ToBase64String(convertedGuid.ToByteArray());
                    txtOutput.Text = str64;
                    txtOutput.Focus();
                }
                else
                {
                    Guid convertedGuid = new Guid(Convert.FromBase64String(txtInput.Text));
                    txtOutput.Text = convertedGuid.ToString();
                    txtOutput.Focus();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error: \n" + err.Message);
            }
        }

        private void txtInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            char ch = e.Text[0];
            TextBox txt = (TextBox)sender;

            if (Char.IsNumber(ch) || (ch >= 'a' && ch <= 'f'))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtInput_GotFocus(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "";
            txtOutput.Text = "";
        }
    }
}
