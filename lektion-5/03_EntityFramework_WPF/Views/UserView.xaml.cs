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
    /// Interaction logic for UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        private readonly IUserService userService = new UserService();

        public UserView()
        {
            InitializeComponent();
            
            lvUsers.Items.Clear();
            foreach(var user in userService.GetAll())
            {
                lvUsers.Items.Add(user);
            }
        }
    }
}
