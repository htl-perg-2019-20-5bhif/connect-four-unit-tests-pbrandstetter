using ConnectFour.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ConnectFour.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mwvm = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mwvm;
        }
        private void Column_MouseDown(object sender, RoutedEventArgs e)
        {
            mwvm.SetStone(byte.Parse(((Button)sender).Tag.ToString()));
        }
    }
}
