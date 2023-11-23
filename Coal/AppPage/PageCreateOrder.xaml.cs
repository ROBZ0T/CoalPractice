using Coal.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.AccessControl;
using System.Security.Cryptography;
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
    /// <summary>
    /// Логика взаимодействия для PageCreateOrder.xaml
    /// </summary>
    public partial class PageCreateOrder : Page
    {
        string fio;
        int summa = 0;
        int lot = 0;
        public PageCreateOrder(string FIOO,int lots)
        {
            InitializeComponent();
            fio = FIOO;
            lot = lots;
            int lotes = Convert.ToInt32(brushL2.Content) - lots;
            brushL2.Content = lotes;
            CityComBCoal.SelectedValuePath = "ID_city_coal";
            CityComBCoal.DisplayMemberPath = "City_coal1";
            CityComBCoal.ItemsSource = CoalEntities.GetContext().City_coal.ToList();
        }
        private void CityComBCoal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int s = Convert.ToInt32(CityComBCoal.SelectedValue);
            typeCoalComB.IsEnabled = true;
            typeCoalComB.SelectedValuePath = "ID_type_coal";
            typeCoalComB.DisplayMemberPath = "Name_type";
            var a = CoalEntities.GetContext().City_coal.FirstOrDefault(x => x.ID_city_coal == s);
            typeCoalComB.ItemsSource = CoalEntities.GetContext().Type_coal.Where(x => x.ID_city_coal == a.ID_city_coal).ToList();
        }
        private void typeCoalComB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int s = Convert.ToInt32(typeCoalComB.SelectedValue);
            var a = CoalEntities.GetContext().Type_coal.FirstOrDefault(x => x.ID_type_coal == s);
            int n = Convert.ToInt32(CityComBCoal.SelectedValue);
            var us = CoalEntities.GetContext().Physical_person.FirstOrDefault(x => x.FIO == fio);
            var homes = CoalEntities.GetContext().Home.FirstOrDefault(x => x.ID_address == us.ID_address);
            var streets = CoalEntities.GetContext().Street.FirstOrDefault(x =>x.ID_street == homes.ID_street);
            var Citys = CoalEntities.GetContext().CIty.FirstOrDefault(x =>x.ID_city == streets.ID_city );
            if (n == 1)
            {
                if (Citys.ID_city == n)
                {
                    if (a != null)
                    {
                        priceCoalL.Content = $" {a.Price}";
                        quantityCoalL.Content = $" {a.Total_quantity_coal}";
                    }
                    else
                    {
                        priceCoalL.Content = $" ";
                        quantityCoalL.Content = $" ";
                    }
                }
                else
                {
                    if (a != null)
                    {
                        priceCoalL.Content = $" {a.Price+500}";
                        quantityCoalL.Content = $" {a.Total_quantity_coal}";
                    }
                    else
                    {
                        priceCoalL.Content = $" ";
                        quantityCoalL.Content = $" ";
                    }
                }
            }

            if (n == 2)
            {
                if (Citys.ID_city ==1)
                {
                    if (a != null)
                    {
                        priceCoalL.Content = $" {a.Price+1000}";
                        quantityCoalL.Content = $" {a.Total_quantity_coal}";
                    }
                    else
                    {
                        priceCoalL.Content = $" ";
                        quantityCoalL.Content = $" ";
                    }
                }
                else
                {
                    if (Citys.ID_city == 2)
                    {
                        if (a != null)
                        {
                            priceCoalL.Content = $" {a.Price + 500}";
                            quantityCoalL.Content = $" {a.Total_quantity_coal}";
                        }
                        else
                        {
                            priceCoalL.Content = $" ";
                            quantityCoalL.Content = $" ";
                        }
                    }
                }
            }

            if (typeCoalComB != null)
            {
                min.IsEnabled = true;
                max.IsEnabled = true;
            }
            else
            {
                min.IsEnabled = false;
                max.IsEnabled = false;
            }
        }
        int ii;
        int orderII=0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CityComBCoal.Text != null && CityComBCoal.Text !="" && typeCoalComB.Text != null && typeCoalComB.Text != "" && qountTexB.Text != "0")
                {
                    var dat = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    var us = CoalEntities.GetContext().Physical_person.FirstOrDefault(x => x.FIO == fio);
                    int beginnings = Convert.ToInt32(brushL.Content);
                    int finish = Convert.ToInt32(brushL2.Content);
                    if (beginnings != finish)
                    {

                        if (CoalEntities.GetContext().Order.FirstOrDefault(x => x.ID_fiz == us.ID_fiz && x.Date_order == dat) == null)
                        {
                            if (orderII == 0)
                            {
                                var user = CoalEntities.GetContext().Physical_person.FirstOrDefault(x => x.FIO == fio);
                                Order order = new Order()
                                {
                                    ID_fiz = user.ID_fiz,
                                    Date_order = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                                };
                                CoalEntities.GetContext().Order.Add(order);
                                CoalEntities.GetContext().SaveChanges();
                                orderII = 1;
                            }
                        }
                        if (brushL.Content != brushL2.Content)
                        {
                            ii = Convert.ToInt32(brushL.Content);
                        }
                        string typecoal = typeCoalComB.Text;
                        int qountcoal = Convert.ToInt32(qountTexB.Text);
                        var orderscoal = CoalEntities.GetContext().Order.FirstOrDefault(x => x.ID_fiz == us.ID_fiz && x.Date_order == dat);
                        switch (ii)
                        {
                            case 0:
                                num1L.Content = orderscoal.ID_order;
                                num1L.Visibility = Visibility.Visible;
                                type1L.Content = typecoal;
                                type1L.Visibility = Visibility.Visible;
                                qount1L.Content = qountcoal;
                                qount1L.Visibility = Visibility.Visible;
                                sum1L.Content = qountcoal * Convert.ToInt32(priceCoalL.Content);
                                sum1L.Visibility = Visibility.Visible;
                                qountTexB.Text = "0";
                                typeCoalComB.Text = null;
                                summa += Convert.ToInt32(sum1L.Content);
                                sumL.Content = Convert.ToString(summa);
                                OrderCreateBut.IsEnabled = true;
                                break;
                            case 1:
                                num2L.Content = orderscoal.ID_order;
                                num2L.Visibility = Visibility.Visible;
                                type2L.Content = typecoal;
                                type2L.Visibility = Visibility.Visible;
                                qount2L.Content = qountcoal;
                                qount2L.Visibility = Visibility.Visible;
                                sum2L.Content = qountcoal * Convert.ToInt32(priceCoalL.Content);
                                sum2L.Visibility = Visibility.Visible;
                                qountTexB.Text = "0";
                                typeCoalComB.Text = null;
                                summa += Convert.ToInt32(sum2L.Content);
                                sumL.Content = Convert.ToString(summa);
                                break;
                            case 2:
                                num3L.Content = orderscoal.ID_order;
                                num3L.Visibility = Visibility.Visible;
                                type3L.Content = typecoal;
                                type3L.Visibility = Visibility.Visible;
                                qount3L.Content = qountcoal;
                                qount3L.Visibility = Visibility.Visible;
                                sum3L.Content = qountcoal * Convert.ToInt32(priceCoalL.Content);
                                sum3L.Visibility = Visibility.Visible;
                                qountTexB.Text = "0";
                                typeCoalComB.Text = null;
                                summa += Convert.ToInt32(sum3L.Content);
                                sumL.Content = Convert.ToString(summa);
                                break;
                            case 3:
                                num4L.Content = orderscoal.ID_order;
                                num4L.Visibility = Visibility.Visible;
                                type4L.Content = typecoal;
                                type4L.Visibility = Visibility.Visible;
                                qount4L.Content = qountcoal;
                                qount4L.Visibility = Visibility.Visible;
                                sum4L.Content = qountcoal * Convert.ToInt32(priceCoalL.Content);
                                sum4L.Visibility = Visibility.Visible;
                                qountTexB.Text = "0";
                                typeCoalComB.Text = null;
                                summa += Convert.ToInt32(sum4L.Content);
                                sumL.Content = Convert.ToString(summa);
                                break;
                            case 4:
                                num5L.Content = orderscoal.ID_order;
                                num5L.Visibility = Visibility.Visible;
                                type5L.Content = typecoal;
                                type5L.Visibility = Visibility.Visible;
                                qount5L.Content = qountcoal;
                                qount5L.Visibility = Visibility.Visible;
                                sum5L.Content = qountcoal * Convert.ToInt32(priceCoalL.Content);
                                sum5L.Visibility = Visibility.Visible;
                                qountTexB.Text = "0";
                                typeCoalComB.Text = null;
                                summa += Convert.ToInt32(sum5L.Content);
                                sumL.Content = Convert.ToString(summa);
                                break;
                            default:
                                MessageBox.Show("Не можете добавить в корзина (нет свободных машин)!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                                break;
                        }
                        int h = Convert.ToInt32(brushL.Content);
                        int h2 = Convert.ToInt32(brushL2.Content);
                        if (h < h2)
                        {
                            brushL.Content = Convert.ToString(ii + 1);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не можете добавить в корзина (нет свободных машин)!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("указаны не все значения!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                throw;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(qountTexB.Text);
            if (a>0)
            {
                qountTexB.Text = Convert.ToString(Convert.ToInt32(qountTexB.Text) - 1);
                qountTexB.IsEnabled = false;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(qountTexB.Text);
            if (a < 20)
            {
                qountTexB.Text = Convert.ToString(Convert.ToInt32(qountTexB.Text) + 1);
                qountTexB.IsEnabled = false;
            }
        }

        private void saveorders (string typecoal, Type_coal coalTYPE, int qoun, Order orderscoal)
        {
            if (qoun <= coalTYPE.Total_quantity_coal)
            {
                Ordered_coal ordered_Coal = new Ordered_coal()
                {
                    ID_order = orderscoal.ID_order,
                    ID_type_coal = coalTYPE.ID_type_coal,
                    quantity = qoun
                };
                coalTYPE.Total_quantity_coal -= qoun;
                CoalEntities.GetContext().Type_coal.AddOrUpdate(coalTYPE);
                CoalEntities.GetContext().Ordered_coal.Add(ordered_Coal);
                CoalEntities.GetContext().SaveChanges();
            }
            else
            {
                MessageBox.Show("Ошибка не хватает угля перезайдите в приложение!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void OrderCreateBut_Click(object sender, RoutedEventArgs e)
        {
            var dat = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            var us = CoalEntities.GetContext().Physical_person.FirstOrDefault(x => x.FIO == fio);
            var orderscoal = CoalEntities.GetContext().Order.FirstOrDefault(x => x.ID_fiz == us.ID_fiz && x.Date_order == dat);
            if (Convert.ToString(num1L.Content) != " ")
            {
                string typecoal = Convert.ToString(type1L.Content);
                var coalTYPE = CoalEntities.GetContext().Type_coal.FirstOrDefault(x => x.Name_type == typecoal);
                int qoun = Convert.ToInt32(qount1L.Content);
                saveorders(typecoal, coalTYPE, qoun, orderscoal);
            }

            if (Convert.ToString(num2L.Content) != " ")
            {
                string typecoal = Convert.ToString(type2L.Content);
                var coalTYPE = CoalEntities.GetContext().Type_coal.FirstOrDefault(x => x.Name_type == typecoal);
                int qoun = Convert.ToInt32(qount2L.Content);
                saveorders(typecoal, coalTYPE, qoun, orderscoal);
            }

            if (Convert.ToString(num3L.Content) != " ")
            {
                string typecoal = Convert.ToString(type3L.Content);
                var coalTYPE = CoalEntities.GetContext().Type_coal.FirstOrDefault(x => x.Name_type == typecoal);
                int qoun = Convert.ToInt32(qount3L.Content);
                saveorders(typecoal, coalTYPE, qoun, orderscoal);
            }

            if (Convert.ToString(num4L.Content) != " ")
            {
                string typecoal = Convert.ToString(type4L.Content);
                var coalTYPE = CoalEntities.GetContext().Type_coal.FirstOrDefault(x => x.Name_type == typecoal);
                int qoun = Convert.ToInt32(qount4L.Content);
                saveorders(typecoal, coalTYPE, qoun, orderscoal);
            }

            if (Convert.ToString(num5L.Content) != " ")
            {
                string typecoal = Convert.ToString(type5L.Content);
                var coalTYPE = CoalEntities.GetContext().Type_coal.FirstOrDefault(x => x.Name_type == typecoal);
                int qoun = Convert.ToInt32(qount5L.Content);
                saveorders(typecoal, coalTYPE, qoun, orderscoal);
            }
            CoalEntities.GetContext().Order.AddOrUpdate(orderscoal);
            CoalEntities.GetContext().SaveChanges();
            int coaltypes = Convert.ToInt32(sumL.Content);
            if (orderscoal.sum_order == null)
            {
                orderscoal.sum_order = 0;
            }   
            orderscoal.sum_order += coaltypes;
            CoalEntities.GetContext().Order.AddOrUpdate(orderscoal);
            CoalEntities.GetContext().SaveChanges();
            AppFrame.FrameMain.GoBack();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            AppFrame.FrameMain.GoBack();
        }
    }
}
