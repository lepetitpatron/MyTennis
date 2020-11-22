using MyTennis.Core.DTO;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyTennis.UI.Views
{
    /// <summary>
    /// Interaction logic for RoleWindow.xaml
    /// </summary>
    public partial class RoleWindow : Window
    {
        readonly RolesProcessor processor;
        List<RoleDTO> roles;

        public RoleWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            processor = new RolesProcessor();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            roles = await processor.GetAll();

            OverviewList.ItemsSource = roles;
            
            ModifyPicker.ItemsSource = roles;
            ModifyPicker.SelectedIndex = 1;
        }

        private async void AddConfirm_Click(object sender, RoutedEventArgs e)
        {
            string input = AddInput.Text;
            if (!ValidateRole(AddInput, AddError)) return;

            RoleDTO role = new RoleDTO() { Name = input };

            await processor.Add(role);
            roles = await processor.GetAll();

            MessageBox.Show("De rol werd toegevoegd.", "Succes");
        }

        private async void ModifyConfirm_Click(object sender, RoutedEventArgs e)
        {
            string input = ModifyInput.Text;
            if (!ValidateRole(ModifyInput, ModifyError)) return;

            RoleDTO role = (RoleDTO) ModifyPicker.SelectedItem;
            role.Name = input;

            await processor.Update(role);
            roles = await processor.GetAll();

            MessageBox.Show("De rol werd aangepast.", "Succes");
        }

        private bool ValidateRole(TextBox input, TextBlock error)
        {
            bool valid = true;

            if (string.IsNullOrWhiteSpace(input.Text))
            {
                error.Text =  "Gelieve een rol in te geven.";
                error.Visibility = Visibility.Visible;

                valid = false;
            }
            else if (input.Text.Length > 20)
            {
                error.Text = "Een rol mag niet meer dan 20 karakters bevatten.";
                error.Visibility = Visibility.Visible;

                valid = false;
            }
            else
            {
                input.Text = "";
                error.Text = "";
                error.Visibility = Visibility.Collapsed;
            }

            return valid;
        }

        private void LabelOverview_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Visible;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Collapsed;
        }

        private void LabelAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Visible;
            Modify.Visibility = Visibility.Collapsed;
        }

        private void LabelModify_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Visible;
        }

        private void Return_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}