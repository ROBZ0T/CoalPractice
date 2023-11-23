using Coal.ApplicationData;
using System;
using System.Collections;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace Coal.AppPage
{
    /// <summary>
    /// Логика взаимодействия для Pagehistory.xaml
    /// </summary>
    public partial class Pagehistory : Page
    {
        public Pagehistory(string fio)
        {
            InitializeComponent();
            var us = CoalEntities.GetContext().Physical_person.FirstOrDefault(x => x.FIO == fio);
            var homes = CoalEntities.GetContext().Home.FirstOrDefault(x => x.ID_address == us.ID_address);
            var streets = CoalEntities.GetContext().Street.FirstOrDefault(x => x.ID_street == homes.ID_street);
            var Citys = CoalEntities.GetContext().CIty.FirstOrDefault(x => x.ID_city == streets.ID_city);
            cityme.Content = Citys.city1;
            streetme.Content = streets.street1;
            homeme.Content = homes.home1;
            var order = CoalEntities.GetContext().Order.FirstOrDefault(x => x.ID_fiz == us.ID_fiz);
            if (order != null)
            {
                var orders = CoalEntities.GetContext().Ordered_coal.FirstOrDefault(x => x.ID_order == order.ID_order);
                if (orders != null)
                {
                    CreateDynamicStackPanel(us);
                }
            }
            else
            {
                MessageBox.Show("Вы не заказывали", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void CreateDynamicStackPanel(Physical_person us)
        {
            var order = CoalEntities.GetContext().Order.Where(x => x.ID_fiz == us.ID_fiz).ToList();
            foreach (var item in order)
            {
                StackPanel mainStackPanel = new StackPanel();

                StackPanel stack1 = new StackPanel()
                {
                    Width = 380,
                    Orientation = Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top
                };
                var orders = CoalEntities.GetContext().Ordered_coal.Where(x => x.ID_order == item.ID_order).ToList();
                StackPanel stack2 = new StackPanel();
                stack2.Children.Add(new Label() { Name = "numorder", Content = $"номер заказа: {item.ID_order}" });
                stack2.Children.Add(new Label() { Name = "dateorder", Content = $"дата заказа: {item.Date_order.ToShortDateString()}" });
                stack2.Children.Add(new Label() { Name = "sumorder", Content = $"стоимость заказа: {item.sum_order}" });

                StackPanel stack3 = new StackPanel();

                StackPanel stack4 = new StackPanel()
                {
                    Width = 260,
                    Height = 160
                };
                StackPanel stack6 = new StackPanel()
                {
                    Orientation = Orientation.Horizontal
                };
                StackPanel stack7 = new StackPanel();
                stack7.Children.Add(new Label() { Content = "сорт угля" });
                StackPanel stack8 = new StackPanel();
                stack8.Children.Add(new Label() { Content = "кол-во" });
                StackPanel stack9 = new StackPanel();
                stack9.Children.Add(new Label() { Content = "цена за 1 тонну" });
                stack6.Children.Add(stack7);
                stack6.Children.Add(stack8);
                stack6.Children.Add(stack9);

                stack4.Children.Add(stack6);
                if (item != null)
                {
                    foreach (var items in orders)
                    {
                        var coaltypes = CoalEntities.GetContext().Type_coal.FirstOrDefault(x => x.ID_type_coal == items.ID_type_coal);
                        stack7.Children.Add(new Label() {Content = $"{coaltypes.Name_type}" });
                        stack8.Children.Add(new Label() {Content = $"{items.quantity}" });
                        stack9.Children.Add(new Label() {Content = $"{coaltypes.Price}" });
                    }
                }
                else
                {

                }
                stack3.Children.Add(stack4);

                stack1.Children.Add(stack2);
                stack1.Children.Add(stack3);

                mainStackPanel.Children.Add(stack1);

                hoh.Children.Add(mainStackPanel);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.GoBack();
        }
    }
}
