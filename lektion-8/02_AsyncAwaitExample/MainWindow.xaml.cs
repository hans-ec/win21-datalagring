using _02_AsyncAwaitExample.Services;
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

namespace _02_AsyncAwaitExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileHandler _fileHandler;

        public MainWindow()
        {
            InitializeComponent();
            _fileHandler = new FileHandler();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lbStatus.Content = "";
            lbStatus.Content = _fileHandler.Example();
        }
    }
}
