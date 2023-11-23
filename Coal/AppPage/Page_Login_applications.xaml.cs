using Coal.ApplicationData;
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

namespace Coal.AppPage
{
    public partial class Page_Login_applications : Page
    {
        public Page_Login_applications()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageLogin());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new PageCreate());
        }
    }
}
