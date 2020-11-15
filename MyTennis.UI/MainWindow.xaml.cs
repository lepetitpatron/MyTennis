using MyTennis.Core.DTO;
using MyTennis.UI.Processors;
using MyTennis.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyTennis.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private void GameIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            GameIcon.Foreground = new SolidColorBrush(Colors.Gold);
            GameLabel.Foreground = new SolidColorBrush(Colors.Gold);
        }

        private void MemberIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            MemberIcon.Foreground = new SolidColorBrush(Colors.Gold);
            MemberLabel.Foreground = new SolidColorBrush(Colors.Gold);
        }

        private void FineIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            FineIcon.Foreground = new SolidColorBrush(Colors.Gold);
            FineLabel.Foreground = new SolidColorBrush(Colors.Gold);
        }

        private void RoleIcon_MouseEnter(object sender, MouseEventArgs e)
        {
            RoleIcon.Foreground = new SolidColorBrush(Colors.Gold);
            RoleLabel.Foreground = new SolidColorBrush(Colors.Gold);
        }

        private void GameLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            GameIcon.Foreground = new SolidColorBrush(Colors.Gold);
            GameLabel.Foreground = new SolidColorBrush(Colors.Gold);
        }

        private void MemberLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            MemberIcon.Foreground = new SolidColorBrush(Colors.Gold);
            MemberLabel.Foreground = new SolidColorBrush(Colors.Gold);
        }

        private void FineLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            FineIcon.Foreground = new SolidColorBrush(Colors.Gold);
            FineLabel.Foreground = new SolidColorBrush(Colors.Gold);
        }

        private void RoleLabel_MouseEnter(object sender, MouseEventArgs e)
        {
            RoleIcon.Foreground = new SolidColorBrush(Colors.Gold);
            RoleLabel.Foreground = new SolidColorBrush(Colors.Gold);
        }

        private void Rectangle_MouseEnter(object sender, MouseEventArgs e)
        {
            MakeElementsWhite();
        }

        private void MakeElementsWhite()
        {
            GameIcon.Foreground = new SolidColorBrush(Colors.White);
            GameLabel.Foreground = new SolidColorBrush(Colors.White);
            MemberIcon.Foreground = new SolidColorBrush(Colors.White);
            MemberLabel.Foreground = new SolidColorBrush(Colors.White);
            FineIcon.Foreground = new SolidColorBrush(Colors.White);
            FineLabel.Foreground = new SolidColorBrush(Colors.White);
            RoleIcon.Foreground = new SolidColorBrush(Colors.White);
            RoleLabel.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Rectangle_MouseEnter_1(object sender, MouseEventArgs e)
        {
            GameIcon.Foreground = new SolidColorBrush(Colors.White);
            GameLabel.Foreground = new SolidColorBrush(Colors.White);
            MemberIcon.Foreground = new SolidColorBrush(Colors.White);
            MemberLabel.Foreground = new SolidColorBrush(Colors.White);
            FineIcon.Foreground = new SolidColorBrush(Colors.White);
            FineLabel.Foreground = new SolidColorBrush(Colors.White);
            RoleIcon.Foreground = new SolidColorBrush(Colors.White);
            RoleLabel.Foreground = new SolidColorBrush(Colors.White);
        }

        private void RoleIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Window window = new RoleWindow();
            this.Hide();
            window.ShowDialog();
        }
    }
}
