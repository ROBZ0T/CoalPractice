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
    public partial class PageCreate : Page
    {
        public PageCreate()
        {
            InitializeComponent();
            cityCmB.SelectedValuePath = "ID_city";
            cityCmB.DisplayMemberPath = "city1";
            cityCmB.ItemsSource = CoalEntities.GetContext().CIty.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int cit;
            if (cityCmB.Text == "Abakan")
            {
                cit = 2;
            }
            else
            {
                cit = 1;
            }
            Street street = new Street
            {
                street1 = streetTB.Text,
                ID_city = cit
            };
            CoalEntities.GetContext().Street.Add(street);
            Home home = new Home
            {
                ID_street = street.ID_street,
                home1 = homeTB.Text
            };
            CoalEntities.GetContext().Home.Add(home);
            Physical_person physical = new Physical_person
            {
                ID_address = home.ID_address,
                FIO = FIOTB.Text
            };
            CoalEntities.GetContext().Physical_person.Add(physical);
            CoalEntities.GetContext().SaveChanges();
            AppFrame.FrameMain.Navigate(new PageLogin());
        }

        private void cityCmB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cityCmB.Text != null)
            {
                streetTB.IsEnabled = true;
            }
            else
            {
                streetTB.IsEnabled = false;
            }
        }
        private void streetTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (streetTB.Text != "")
            {
                homeTB.IsEnabled = true;
            }
            else
            {
                homeTB.IsEnabled = false;
            }
        }
        private void homeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (homeTB.Text != "")
            {
                FIOTB.IsEnabled = true;
            }
            else
            {
                FIOTB.IsEnabled = false;
            }
        }
        private void FIOTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FIOTB.Text != "")
            {
                nextBut.IsEnabled = true;
            }
            else
            {
                nextBut.IsEnabled = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.GoBack();
        }
    }
}
