using MyTennis.Core.DTO;
using MyTennis.UI.Processors;
using System;
using System.Windows;

namespace MyTennis.UI.Views
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        public MemberWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { }
    }
}