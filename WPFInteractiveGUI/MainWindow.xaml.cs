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

namespace WPFInteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();

            controller = new Controller();

            CheckIfRepoEmpty();
        }

        public void CheckIfRepoEmpty()
        {
            if (controller.PersonCount == 0 && controller.PersonIndex == -1)
            {
                txtbxFirstName.Text = "";
                txtbxLastName.Text = "";
                txtbxAge.Text = "";
                txtbxTelephoneNo.Text = "";

                txtbxFirstName.IsEnabled = false;
                txtbxLastName.IsEnabled = false;
                txtbxAge.IsEnabled = false;
                txtbxTelephoneNo.IsEnabled = false;

                btnDeletePerson.IsEnabled = false;
                btnDown.IsEnabled = false;
                btnUp.IsEnabled = false;
                btnNewPerson.IsEnabled = true;
            }
        }

        private void btnNewPerson_Click(object sender, RoutedEventArgs e)
        {
            controller.AddPerson();

            txtbxFirstName.IsEnabled = true;
            txtbxLastName.IsEnabled = true;
            txtbxAge.IsEnabled = true;
            txtbxTelephoneNo.IsEnabled = true;

            btnDeletePerson.IsEnabled = true;
            btnDown.IsEnabled = true;
            btnUp.IsEnabled = true;
        }

        private void txtbxFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.FirstName = txtbxFirstName.Text;
        }

        private void txtbxAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.Age = int.Parse(txtbxAge.Text);
        }

        private void txtbxLastName_TextChanged(object sender, TextChangedEventArgs e)
        {            
            controller.CurrentPerson.LastName = txtbxLastName.Text;
        }

        private void txtbxTelephoneNo_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentPerson.TelephoneNo = txtbxTelephoneNo.Text;
        }

        private void btnDeletePerson_Click(object sender, RoutedEventArgs e)
        {
            controller.DeletePerson();
            CheckIfRepoEmpty();
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();
            txtbxFirstName.Text = controller.CurrentPerson.FirstName;
            txtbxLastName.Text = controller.CurrentPerson.LastName;
            txtbxAge.Text = controller.CurrentPerson.Age.ToString();
            txtbxTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();
            txtbxFirstName.Text = controller.CurrentPerson.FirstName;
            txtbxLastName.Text = controller.CurrentPerson.LastName;
            txtbxAge.Text = controller.CurrentPerson.Age.ToString();
            txtbxTelephoneNo.Text = controller.CurrentPerson.TelephoneNo;
        }

    }
}
