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

namespace Bernadette_Alvarado_Exercise02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double discount;
        private double totaldiscount;
        private double servicesamt;
        private double flossing;
        private double filling;
        private double rootcanal;
        private double tax;
        private double totaltax;
        private double totalamt;
        private String province;


        public MainWindow()
        {
            InitializeComponent();
        }

        // handles province ComboBox
        private void provinceComboBox_SelectedIndexChanged(object sender, 
            EventArgs e)
        {
            province = provinceComboBox.Text;
        }

        // handles senior RadioButton's Checked event
        private void seniorRadioButton_Checked(object sender,
           RoutedEventArgs e)
        {
            discount = 0.10;
        } // end method seniorRadioButton_Checked

        // handles senior RadioButton's Checked event
        private void kidsRadioButton_Checked(object sender,
           RoutedEventArgs e)
        {
            discount = 0.15;
        } // end method kidsRadioButton_Checked

        // handles flossing CheckBox's Checked event
        private void flossingCheckBox_Checked(object sender,
           RoutedEventArgs e)
        {
            flossing = 20;
        } // end method flossingCheckBox_Checked

        // handles flossing CheckBox's Checked event
        private void fillingCheckBox_Checked(object sender,
           RoutedEventArgs e)
        {
            filling = 75;
        } // end method fillingCheckBox_Checked

        // handles filling CheckBox's Checked event
        private void rootCanalCheckBox_Checked(object sender,
           RoutedEventArgs e)
        {
            rootcanal = 150;
        } // end method rootCanalCheckBox_Checked

        private double calculate(double servicesamt, double totaltax, double totaldiscount)
        {
            totalamt = (servicesamt + totaltax) - totaldiscount;
            return totalamt;
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (province == "Albera")
            {
                tax = 0.07;
            }
            else if (province == "Ontario")
            {
                tax = 0.13;
            }
            else
            {
                tax = 0.06;
            }

            servicesamt = flossing + filling + rootcanal;
            totaltax = servicesamt * tax;
            totaldiscount = servicesamt * discount;

            //totalamt = (servicesamt + totaltax) - totaldiscount;

            totalamt = calculate(servicesamt, totaltax, totaldiscount);


            String output = "Patient Name: " + patientTextBox.Text + "\nTotal Charges: " + totalamt.ToString();
            outputTextBlock.Text = output;

            
            //outputTextBlock.Text = patientTextBox.Text;
        } // end method calculateButton_Click


    } // end class MainWindow
}
