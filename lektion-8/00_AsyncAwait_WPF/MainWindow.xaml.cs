using _00_AsyncAwait_WPF.Services;
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

namespace _00_AsyncAwait_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExampleHandler exampleHandler;

        public MainWindow()
        {
            InitializeComponent();
            exampleHandler = new ExampleHandler();
        }

        private void btnBlockingCode_Click(object sender, RoutedEventArgs e)
        {
            lbResult.Content = "Blockerande koden";
            lbResult.Content = exampleHandler.BlockingCode(lbResult.Content.ToString());
        }

        private async void btnNonBlockingCode_Click(object sender, RoutedEventArgs e)
        {
            lbResult.Content = "Icke blockerande koden";
            lbResult.Content = await exampleHandler.NonBlockingCodeAsync(lbResult.Content.ToString());
        }
    }
}
