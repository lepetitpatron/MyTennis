using MyTennis.Core.DTO;
using MyTennis.UI.Processors;
using MyTennis.UI.Views;
using System;
using System.Collections.Generic;
using System.Windows;

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
        }

        private void RoleIcon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            OpenRolesWindow();
        }

        private void OpenRolesWindow()
        {
            RoleWindow roleWindow = new RoleWindow();
            roleWindow.Show();

            Hide();
        }
    }
}