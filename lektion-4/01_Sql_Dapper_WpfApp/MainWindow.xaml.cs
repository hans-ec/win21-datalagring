using _01_Sql_Dapper_WpfApp.Entities;
using _01_Sql_Dapper_WpfApp.Services;
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

namespace _01_Sql_Dapper_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IUserService _userService = new UserService();

        public MainWindow()
        {
            InitializeComponent();
            AddUsersToListView();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddUserToDatabase();
            ClearTextBoxFields();
            AddUsersToListView();
        }

        private void AddUserToDatabase()
        {
            if(tbFirstName.Text != "" && tbLastName.Text != "" && tbEmail.Text != "")
                if (!_userService.CreateUser(new User { FirstName = tbFirstName.Text, LastName = tbLastName.Text, Email = tbEmail.Text }))
                    tblockError.Text = "Det finns redan en användare med samma e-postadress";
                else
                    tblockError.Text = "";
        }

        private void ClearTextBoxFields()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
        }

        private void AddUsersToListView()
        {
            var users = _userService.GetUsers();

            if(users != null)
            {
                lvUsers.Items.Clear();

                foreach(var user in users)
                    lvUsers.Items.Add(user);
            }
        }

    }
}
