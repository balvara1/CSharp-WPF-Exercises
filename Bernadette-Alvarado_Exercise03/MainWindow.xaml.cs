using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Bernadette_Alvarado_Exercise03
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private readonly ViewModel viewModel;

        List<Bill> Beverage = new List<Bill>();
        List<Bill> Appetizer = new List<Bill>();
        List<Bill> MainCourse = new List<Bill>();
        List<Bill> Dessert = new List<Bill>();

        private double subTotal = 0.0, tax = 0.0, total = 0.0;

        public MainWindow()
        {
            InitializeComponent();

            Beverage.Add(new Bill { Name = "Soda", Category = "Beverage", Price = 1.95 });
            Beverage.Add(new Bill { Name = "Tea", Category = "Beverage", Price = 1.50 });
            Beverage.Add(new Bill { Name = "Coffee", Category = "Beverage", Price = 1.25 });
            Beverage.Add(new Bill { Name = "Mineral Water", Category = "Beverage", Price = 2.95 });
            Beverage.Add(new Bill { Name = "Juice", Category = "Beverage", Price = 2.50 });
            Beverage.Add(new Bill { Name = "Milk", Category = "Beverage", Price = 1.50 });
            Appetizer.Add(new Bill { Name = "Buffalo Wings", Category = "Appetizer", Price = 5.95 });
            Appetizer.Add(new Bill { Name = "Buffalo Fingers", Category = "Appetizer", Price = 6.95 });
            Appetizer.Add(new Bill { Name = "Potato Skins", Category = "Appetizer", Price = 8.95 });
            Appetizer.Add(new Bill { Name = "Nachos", Category = "Appetizer", Price = 8.95 });
            Appetizer.Add(new Bill { Name = "Mushroom Caps", Category = "Appetizer", Price = 10.95 });
            Appetizer.Add(new Bill { Name = "Shrimp Cocktail", Category = "Appetizer", Price = 12.95 });
            Appetizer.Add(new Bill { Name = "Chips and Salsa", Category = "Appetizer", Price = 6.95 });
            MainCourse.Add(new Bill { Name = "Seafood Alfredo", Category = "Main Course", Price = 15.95 });
            MainCourse.Add(new Bill { Name = "Chicken Alfredo", Category = "Main Course", Price = 13.95 });
            MainCourse.Add(new Bill { Name = "Chicken Picatta", Category = "Main Course", Price = 15.95 });
            MainCourse.Add(new Bill { Name = "Turkey Club", Category = "Main Course", Price = 11.95 });
            MainCourse.Add(new Bill { Name = "Lobster Pie", Category = "Main Course", Price = 19.95 });
            MainCourse.Add(new Bill { Name = "Prime Rib", Category = "Main Course", Price = 20.95 });
            MainCourse.Add(new Bill { Name = "Shrimp Scampi", Category = "Main Course", Price = 18.95 });
            MainCourse.Add(new Bill { Name = "Turkey Dinner", Category = "Main Course", Price = 13.95 });
            MainCourse.Add(new Bill { Name = "Struffed Chicken", Category = "Main Course", Price = 14.95 });
            Dessert.Add(new Bill { Name = "Apple Pie", Category = "Dessert", Price = 5.95 });
            Dessert.Add(new Bill { Name = "Sundae", Category = "Dessert", Price = 3.95 });
            Dessert.Add(new Bill { Name = "Carrot Cake", Category = "Dessert", Price = 5.95 });
            Dessert.Add(new Bill { Name = "Mud Pie", Category = "Dessert", Price = 4.95 });
            Dessert.Add(new Bill { Name = "Apple Crisp", Category = "Dessert", Price = 5.95 });


            beverageComboBox.DisplayMemberPath = "Name";
            beverageComboBox.SelectedValuePath = "Price";
            beverageComboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = Beverage });
            appetizerComboBox.DisplayMemberPath = "Name";
            appetizerComboBox.SelectedValuePath = "Price";
            appetizerComboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = Appetizer });
            maincourseComboBox.DisplayMemberPath = "Name";
            maincourseComboBox.SelectedValuePath = "Price";
            maincourseComboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = MainCourse });
            dessertComboBox.DisplayMemberPath = "Name";
            dessertComboBox.SelectedValuePath = "Price";
            dessertComboBox.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = Dessert });

        }

        private void logoLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.centennialcollege.ca/");
        }

        private void clearButton_Clicked(object sender, RoutedEventArgs e)
        {
            subtotalTextBox.Text = "$0.00";
            taxTextBox.Text = "$0.00";
            totalTextBox.Text = "$0.00";

            // clear datagrid
            orderDataGrid.Items.Clear();
            orderDataGrid.Items.Refresh();

        }

            private void beverageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string inputComboBox = (sender as ComboBox).SelectedValue.ToString();
            Calculate(inputComboBox);

            // add item to datagrid
            Bill selectedBillDetails = (Bill)beverageComboBox.SelectedItem;
            orderDataGrid.Items.Add(selectedBillDetails);
            selectedBillDetails.Quantity = 0;

            // add quantity
            foreach (var item in orderDataGrid.Items)
            {
                if (item == selectedBillDetails)
                {
                    selectedBillDetails.Quantity++;
                }
            }

        }

        private void appetizerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            Calculate(text);

            // add item to datagrid
            Bill selectedBillDetails = (Bill)appetizerComboBox.SelectedItem;
            orderDataGrid.Items.Add(selectedBillDetails);
            selectedBillDetails.Quantity = 0;

            // add quantity
            foreach (var item in orderDataGrid.Items)
            {
                if (item == selectedBillDetails)
                {
                    selectedBillDetails.Quantity++;
                }
            }
        }


        private void maincourseComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            Calculate(text);

            // add item to datagrid
            Bill selectedBillDetails = (Bill)maincourseComboBox.SelectedItem;
            orderDataGrid.Items.Add(selectedBillDetails);
            selectedBillDetails.Quantity = 0;

            // add quantity
            foreach (var item in orderDataGrid.Items)
            {
                if (item == selectedBillDetails)
                {
                    selectedBillDetails.Quantity++;
                }
            }
        }

        private void dessertComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = (sender as ComboBox).SelectedValue.ToString();
            Calculate(text);

            // add item to datagrid
            Bill selectedBillDetails = (Bill)dessertComboBox.SelectedItem;
            orderDataGrid.Items.Add(selectedBillDetails);
            selectedBillDetails.Quantity = 0;

            // add quantity
            foreach (var item in orderDataGrid.Items)
            {
                if (item == selectedBillDetails)
                {
                    selectedBillDetails.Quantity++;
                }
            }

        }

        private void Calculate(string itemValue)
        {
            if (itemValue == null)
            {
                return;
            }
            subTotal += Convert.ToDouble(itemValue);
            
            // set to 2 decimal places
            subtotalTextBox.Text = String.Format("${0:0.00}", subTotal);

            tax += Convert.ToDouble(itemValue) * .15;
            
            // set to 2 decimal places
            taxTextBox.Text = String.Format("${0:0.00}", tax);

            total = subTotal + tax;
            
            // set to 2 decimal places
            totalTextBox.Text = String.Format("${0:0.00}", total);

        }


    }
}
