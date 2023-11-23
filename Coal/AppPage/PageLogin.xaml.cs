using Coal.ApplicationData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using static System.Net.Mime.MediaTypeNames;

namespace Coal.AppPage
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = CoalEntities.GetContext().Physical_person.FirstOrDefault(x => x.FIO == FIOtb.Text);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    var phis = CoalEntities.GetContext().Physical_person.FirstOrDefault(x => x.ID_fiz == userObj.ID_fiz);
                    MessageBox.Show("Здравствуйте,Клиент " + phis.FIO, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    AppFrame.FrameMain.Navigate(new PageUser(phis.FIO));
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() +
                    "Критическая работа приложения!", "уведомления"
                    , MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void FIOtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FIOtb.Text != "")
            {
                loginBut.IsEnabled = true;
            }
            else
            {
                loginBut.IsEnabled = false;
            }
        }
    }
}
