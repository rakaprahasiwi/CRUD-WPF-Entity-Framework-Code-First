using BusinessLogic.Service;
using BusinessLogic.Service.Application;
using DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ISupplierService iSupplierService = new SupplierService(); //send
        IItemService iItemService = new ItemService();

        SupplierVM supplierVM = new SupplierVM(); //Get Data
        ItemVM itemVM = new ItemVM();

        public MainWindow()
        {
            InitializeComponent();
            Show();
        }

        private void button_saveOrEdit_Click(object sender, RoutedEventArgs e)
        {
            supplierVM.Name = textBox_name.Text;
            if (string.IsNullOrWhiteSpace(textBox_id.Text))
            {
                var result = iSupplierService.Insert(supplierVM);
                if (result) //default true
                {
                    MessageBox.Show("Insert Successfully");
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
            }
            else
            {
                var result = iSupplierService.Update(Convert.ToInt32(textBox_id.Text), supplierVM);
                if (result) //default true
                {
                    MessageBox.Show("Update Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
            }
            Show();
        }

        private void button_saveOrEditItem_Click(object sender, RoutedEventArgs e)
        {
            itemVM.Name = textBox_name_item.Text;
            itemVM.Stock = Convert.ToInt32(textBox_Stock_item.Text);
            itemVM.Price = Convert.ToDouble(textBox_price_item.Text);
            itemVM.Supplier_Id = Convert.ToInt32(comboBox_item.SelectedValue.ToString());

            if (string.IsNullOrWhiteSpace(textBox_id_item.Text))
            {
                    
                var result = iItemService.Insert(itemVM);
                if (result) //default true
                {
                    MessageBox.Show("Insert Successfully");
                }
                else
                {
                    MessageBox.Show("Insert Failed");
                }
            }
            else
            {
                var result = iItemService.Update(Convert.ToInt32(textBox_id_item.Text), itemVM);
                if (result) //default true
                {
                    MessageBox.Show("Update Successfully");
                }
                else
                {
                    MessageBox.Show("Update Failed");
                }
            }
            
            Show();
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_id.Text))
            {
                 MessageBox.Show("Data Not Found");
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var result = iSupplierService.Delete(Convert.ToInt32(textBox_id.Text));
                    if (result) //default true
                    {
                        MessageBox.Show("Delete Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed");
                    }
                }
            }
            Show();
        }

        private void button_deleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_id_item.Text))
            {
                MessageBox.Show("Data Not Found");
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    var result = iItemService.Delete(Convert.ToInt32(textBox_id_item.Text));
                    if (result) //default true
                    {
                        MessageBox.Show("Delete Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Delete Failed");
                    }
                }
            }
            Show();
        }

        private void Show()
        {
            dataGrid_supplier.ItemsSource = iSupplierService.Get();
            dataGrid_item.ItemsSource = iItemService.Get();
            comboBox_item.ItemsSource = iSupplierService.Get();
        }
        
        private void button_search_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_search.Text))
            {
                MessageBox.Show("Input Dulu Dong");
            }
            else
            {
                dataGrid_supplier.ItemsSource = iSupplierService.GetSearch(textBox_search.Text);
            }
        }

        private void button_search_item_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_search_item.Text))
            {
                MessageBox.Show("Input Dulu Dong");
            }
            else
            {
                dataGrid_item.ItemsSource = iItemService.GetSearch(textBox_search_item.Text);
            }
        }

        private void dataGrid_supplier_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                var data = dataGrid_supplier.SelectedItem;
                string id = (dataGrid_supplier.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                string name = (dataGrid_supplier.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
                textBox_id.Text = id;
                textBox_name.Text = name;
            }
            catch
            {
                textBox_id.Text = "";
                textBox_name.Text = "";
            }
        }

        private void dataGrid_item_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                var data = dataGrid_item.SelectedItem;
                string id = (dataGrid_item.SelectedCells[0].Column.GetCellContent(data) as TextBlock).Text;
                string name = (dataGrid_item.SelectedCells[1].Column.GetCellContent(data) as TextBlock).Text;
                string stock = (dataGrid_item.SelectedCells[2].Column.GetCellContent(data) as TextBlock).Text;
                string price = (dataGrid_item.SelectedCells[3].Column.GetCellContent(data) as TextBlock).Text;
                string cmb_supplier = (dataGrid_item.SelectedCells[4].Column.GetCellContent(data) as TextBlock).Text;
                textBox_id_item.Text = id;
                textBox_name_item.Text = name;
                textBox_Stock_item.Text = stock;
                textBox_price_item.Text = price;
                comboBox_item.Text = cmb_supplier;
            }
            catch
            {
                textBox_id_item.Text = "";
                textBox_name_item.Text = "";
                textBox_Stock_item.Text = "";
                textBox_price_item.Text = "";
                comboBox_item.Text = "";
            }
        }
        
        private void textBox_price_item_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[,][0-9]+$|^[0-9]*[,]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }

        private void textBox_stock_item_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[,][0-9]+$|^[0-9]*[,]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
        }
    }
}
