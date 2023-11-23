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
    public partial class PageUser : Page
    {
        string FIOO;
        public PageUser(string fio)
        {
            InitializeComponent();
            FIOO = fio;
            FIOL.Content = $"Здравствуйте клиент , {fio}";
            DateL.Content = $"{DateTime.Now.ToShortDateString()}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int qount = 0;
            var user = CoalEntities.GetContext().Physical_person.FirstOrDefault(x => x.FIO == FIOO);
            if (CoalEntities.GetContext().Order.FirstOrDefault(x => x.ID_fiz == user.ID_fiz) != null)
            {
                user = CoalEntities.GetContext().Physical_person.FirstOrDefault(x => x.FIO == FIOO);
                var order = CoalEntities.GetContext().Order.FirstOrDefault(x => x.ID_fiz == user.ID_fiz);
                var orders = CoalEntities.GetContext().Ordered_coal.Where(x => x.ID_order == order.ID_order).ToList();
                qount = orders.Count();
            }
            if (qount != 5)
            {
                AppFrame.FrameMain.Navigate(new PageCreateOrder(FIOO, qount));
            }
            else
            {
                MessageBox.Show("Не можете сделать заказ , на следующий день сможете сделать заказ (нет свободных машин)!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.Navigate(new Pagehistory(FIOO));
        }
    }
}
