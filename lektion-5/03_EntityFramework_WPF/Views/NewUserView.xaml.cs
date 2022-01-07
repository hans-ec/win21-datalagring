using _03_EntityFramework_WPF.Services;
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

namespace _03_EntityFramework_WPF.Views
{
    /// <summary>
    /// Interaction logic for NewUserView.xaml
    /// </summary>
    public partial class NewUserView : UserControl
    {
        private readonly IUserService userService = new UserService();
        private readonly IRoleService roleService = new RoleService();

        public NewUserView()
        {
            InitializeComponent();

            cbRole.SelectedValuePath = "Key";
            cbRole.DisplayMemberPath = "Value";

            ClearFields();
            PopulateRoles();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(tbFirstName.Text) && !string.IsNullOrEmpty(tbLastName.Text) && !string.IsNullOrEmpty(tbEmail.Text))
            {
                if (userService.Create(tbFirstName.Text, tbLastName.Text, tbEmail.Text, (int)cbRole.SelectedValue))
                    ClearFields();
                else
                    lbError.Content = "A user with the same email address already exists.";
            }
        }

        private void ClearFields()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbEmail.Text = "";
            lbError.Content = ""; 
        }

        private void PopulateRoles()
        {
            cbRole.Items.Clear();
            foreach(var role in roleService.GetAll())
                cbRole.Items.Add(new KeyValuePair<int, string>(role.Id, role.Name));
        }
    }
}
