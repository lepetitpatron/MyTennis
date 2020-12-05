using MyTennis.Core.DTO;
using MyTennis.UI.Processors;
using System;
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
        readonly RolesProcessor rolesProcessor;
        readonly MembersProcessor membersProcessor;
        readonly MemberRolesProcessor memberRolesProcessor;
        List<RoleDTO> roles;
        List<MemberDTO> members;

        public RoleWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            rolesProcessor = new RolesProcessor();
            membersProcessor = new MembersProcessor();
            memberRolesProcessor = new MemberRolesProcessor();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            roles = await rolesProcessor.GetAll();
            members = await membersProcessor.GetAll();

            OverviewList.ItemsSource = roles;
            OverviewList.SelectedIndex = 0;
            
            ModifyPicker.ItemsSource = roles;
            ModifyPicker.SelectedIndex = 0;

            ConfigurePickerAssignMember.ItemsSource = members;
            ConfigurePickerAssignRole.ItemsSource = roles;
            ConfigurePickerRetractMember.ItemsSource = members;
            ConfigurePickerRetractRole.ItemsSource = roles;

            ConfigurePickerAssignMember.SelectedIndex = 0;
            ConfigurePickerAssignRole.SelectedIndex = 0;
            ConfigurePickerRetractMember.SelectedIndex = 0;
            ConfigurePickerRetractRole.SelectedIndex = 0;
        }

        private async void AddConfirm_Click(object sender, RoutedEventArgs e)
        {
            string input = AddInput.Text;
            if (!ValidateRole(AddInput, AddError)) return;

            RoleDTO role = new RoleDTO() { Name = input };

            await rolesProcessor.Add(role);
            roles = await rolesProcessor.GetAll();

            MessageBox.Show("De rol werd toegevoegd.", "Succes");
        }

        private async void ModifyConfirm_Click(object sender, RoutedEventArgs e)
        {
            string input = ModifyInput.Text;
            if (!ValidateRole(ModifyInput, ModifyError)) return;

            RoleDTO role = (RoleDTO) ModifyPicker.SelectedItem;
            role.Name = input;

            await rolesProcessor.Update(role);
            roles = await rolesProcessor.GetAll();

            MessageBox.Show("De rol werd aangepast.", "Succes");
        }

        private async void AssignConfirm_Click(object sender, RoutedEventArgs e)
        {
            MemberDTO member = (MemberDTO) ConfigurePickerAssignMember.SelectedItem;
            RoleDTO role = (RoleDTO) ConfigurePickerAssignRole.SelectedItem;
            MemberRoleDTO memberRole = new MemberRoleDTO()
            {
                MemberId = member.Id,
                RoleId = role.Id,
                StartDate = DateTime.Today,
                EndDate = new DateTime(9999, 1, 1)
            };

            await memberRolesProcessor.Add(memberRole);

            ConfigurePickerAssignMember.SelectedIndex = 0;
            ConfigurePickerAssignRole.SelectedIndex = 0;

            MessageBox.Show("De rol werd toegewezen.", "Succes");
        }

        private async void RetractConfirm_Click(object sender, RoutedEventArgs e)
        {
            MemberDTO member = (MemberDTO) ConfigurePickerRetractMember.SelectedItem;
            RoleDTO role = (RoleDTO) ConfigurePickerRetractRole.SelectedItem;

            await memberRolesProcessor.Delete(member.Id, role.Id);

            ConfigurePickerRetractMember.SelectedIndex = 0;
            ConfigurePickerRetractRole.SelectedIndex = 0;

            MessageBox.Show("De rol werd afgenomen.", "Succes");
        }

        private async void OverviewList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RoleDTO role = (RoleDTO) OverviewList.SelectedItem;
            List<MemberRoleDTO> memberRoles = await memberRolesProcessor.GetAllMembers(role.Id);
            List<string> currentMembers = new List<string>();
            List<string> ancientMembers = new List<string>();

            foreach (MemberRoleDTO mr in memberRoles)
            {
                if (mr.EndDate == new DateTime(9999,1,1))
                {
                    MemberDTO member = members.Find(member => member.Id == mr.MemberId);
                    currentMembers.Add($"{member.FirstName} {member.LastName} \t (vanaf {mr.StartDate.ToShortDateString()})");
                }
                else
                {
                    MemberDTO member = members.Find(member => member.Id == mr.MemberId);
                    ancientMembers.Add($"{member.FirstName} {member.LastName} \t ({mr.StartDate.ToShortDateString()} - {mr.EndDate.ToShortDateString()})");
                }
            }

            OverviewMembers.ItemsSource = currentMembers;
            OverviewHistory.ItemsSource = ancientMembers;
        }

        private async void ConfigurePickerAssignMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MemberDTO member = (MemberDTO) ConfigurePickerAssignMember.SelectedItem;
            List<MemberRoleDTO> memberRoles = await memberRolesProcessor.GetAllRoles(member.Id);
            List<RoleDTO> availableRoles = new List<RoleDTO>();

            foreach(RoleDTO role in roles)
            {
                if (!memberRoles.Exists(mr => mr.RoleId == role.Id && mr.EndDate == new DateTime(9999,1,1)))
                    availableRoles.Add(role);
            };

            ConfigurePickerAssignRole.ItemsSource = availableRoles;
            ConfigurePickerAssignRole.SelectedIndex = 0;

            AssignConfirm.IsEnabled = (availableRoles.Count == 0) ? false : true;
        }

        private async void ConfigurePickerRetractMember_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MemberDTO member = (MemberDTO) ConfigurePickerRetractMember.SelectedItem;
            List<MemberRoleDTO> memberRoles = await memberRolesProcessor.GetAllRoles(member.Id);
            List<RoleDTO> availableRoles = new List<RoleDTO>();

            foreach (RoleDTO role in roles)
            {
                if (memberRoles.Exists(mr => mr.RoleId == role.Id && mr.EndDate == new DateTime(9999, 1, 1)))
                    availableRoles.Add(role);
            };

            ConfigurePickerRetractRole.ItemsSource = availableRoles;
            ConfigurePickerRetractRole.SelectedIndex = 0;

            RetractConfirm.IsEnabled = (availableRoles.Count == 0) ? false : true;
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
            Configure.Visibility = Visibility.Collapsed;
        }

        private void LabelAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Visible;
            Modify.Visibility = Visibility.Collapsed;
            Configure.Visibility = Visibility.Collapsed;
        }

        private void LabelModify_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Visible;
            Configure.Visibility = Visibility.Collapsed;
        }

        private void LabelConfigure_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Collapsed;
            Configure.Visibility = Visibility.Visible;
        }

        private void Return_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}