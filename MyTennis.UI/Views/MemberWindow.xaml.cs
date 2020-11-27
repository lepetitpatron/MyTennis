using MyTennis.Core.DTO;
using MyTennis.UI.Processors;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MyTennis.UI.Views
{
    /// <summary>
    /// Interaction logic for MemberWindow.xaml
    /// </summary>
    public partial class MemberWindow : Window
    {
        readonly MembersProcessor processor;
        List<MemberDTO> members;

        public MemberWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            processor = new MembersProcessor();
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            members = await processor.GetAll();

            OverviewMembers.ItemsSource = members;
            ModifyPicker.ItemsSource = members;
            DeletePicker.ItemsSource = members;

            ModifyPicker.SelectedIndex = 0;
            DeletePicker.SelectedIndex = 0;

            SetModifyMember(members[0]);
        }

        private async void AddConfirm_Click(object sender, RoutedEventArgs e)
        {
            List<Control> controls = new List<Control>
            {
                AddFederationNr,
                AddFirstName,
                AddLastName,
                AddBirthDate,
                AddAddress,
                AddNumber,
                AddAddition,
                AddZip,
                AddCity,
                AddPhoneNumber
            };

            if (!ValidateMember(controls, AddError)) return;

            MemberDTO member = new MemberDTO
            {
                FederationNr = AddFederationNr.Text,
                FirstName = AddFirstName.Text,
                LastName = AddLastName.Text,
                BirthDate = (DateTime) ModifyBirthDate.SelectedDate,
                GenderId = (bool) (GenderMale.IsChecked) ? (byte) 1 : (byte) 2,
                Address = AddAddress.Text,
                Number = AddNumber.Text,
                Addition = AddAddition.Text,
                Zipcode = AddZip.Text,
                City = AddCity.Text,
                PhoneNr = AddPhoneNumber.Text,
                IsActive = true
            };

            // Clear all fields
            ClearFields(controls);
            GenderMale.IsChecked = true;

            await processor.Add(member);

            MessageBox.Show("De lid werd toegevoegd.", "Succes");
        }

        private async void ModifyConfirm_Click(object sender, RoutedEventArgs e)
        {
            MemberDTO selectedMember;
            List<Control> controls = new List<Control>
            {
                ModifyFederationNr,
                ModifyFirstName,
                ModifyLastName,
                ModifyBirthDate,
                ModifyAddress,
                ModifyNumber,
                ModifyAddition,
                ModifyZip,
                ModifyCity,
                ModifyPhoneNumber
            };

            if (!ValidateMember(controls, ModifyError)) return;
            selectedMember = (MemberDTO) ModifyPicker.SelectedItem;

            MemberDTO member = new MemberDTO
            {
                Id = selectedMember.Id,
                FederationNr = ModifyFederationNr.Text,
                FirstName = ModifyFirstName.Text,
                LastName = ModifyLastName.Text,
                BirthDate = (DateTime) ModifyBirthDate.SelectedDate,
                GenderId = (bool) (ModifyGenderMale.IsChecked) ? (byte) 1 : (byte) 2,
                Address = ModifyAddress.Text,
                Number = ModifyNumber.Text,
                Addition = ModifyAddition.Text,
                Zipcode = ModifyZip.Text,
                City = ModifyCity.Text,
                PhoneNr = ModifyPhoneNumber.Text,
                IsActive = true
            };

            // Reset all fields
            SetModifyMember(members[0]);
            ModifyPicker.SelectedIndex = 0;

            await processor.Update(member);

            MessageBox.Show("De lid werd aangepast.", "Succes");
        }

        private async void DeleteConfirm_Click(object sender, RoutedEventArgs e)
        {
            MemberDTO member = (MemberDTO) DeletePicker.SelectedItem;
            await processor.Delete(member.Id);

            DeletePicker.SelectedIndex = 0;

            MessageBox.Show("De lid werd verwijderd.", "Succes");
        }

        private bool ValidateMember(List<Control> controls, TextBlock error)
        {
            bool valid = true;
            TextBox input;
            DatePicker date;

            foreach (Control t in controls)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    input = (TextBox) t;

                    if (string.IsNullOrWhiteSpace(input.Text))
                        valid = false;
                }
                else if (t.GetType() == typeof(DatePicker))
                {
                    date = (DatePicker) t;

                    if (date.SelectedDate == null)
                        valid = false;
                }
            }

            if (!valid)
            {
                error.Text = "Gelieve alle velden in te vullen.";
                error.Visibility = Visibility.Visible;
            }
            else
            {
                error.Text = "";
                error.Visibility = Visibility.Collapsed;
            } 

            return valid;
        }

        private void SetModifyMember(MemberDTO member)
        {
            ModifyFederationNr.Text = member.FederationNr;
            ModifyFirstName.Text = member.FirstName;
            ModifyLastName.Text = member.LastName;
            ModifyBirthDate.SelectedDate = member.BirthDate;
            ModifyAddress.Text = member.Address;
            ModifyNumber.Text = member.Number;
            ModifyAddition.Text = member.Addition;
            ModifyZip.Text = member.Zipcode;
            ModifyCity.Text = member.City;
            ModifyPhoneNumber.Text = member.PhoneNr;

            ModifyGenderMale.IsChecked = (member.GenderId == 1) ? true : false;
            ModifyGenderFemale.IsChecked = (member.GenderId == 2) ? true : false;
        }

        private void ClearFields(List<Control> controls)
        {
            TextBox input;
            DatePicker date;

            foreach (Control t in controls)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    input = (TextBox) t;
                    input.Text = "";
                }
                else if (t.GetType() == typeof(DatePicker))
                {
                    date = (DatePicker) t;
                    date.SelectedDate = null;
                }
            }
        }

        private void ModifyPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MemberDTO member = (MemberDTO)ModifyPicker.SelectedItem;
            SetModifyMember(member);
        }

        private void LabelOverview_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Visible;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Collapsed;
            Delete.Visibility = Visibility.Collapsed;
        }

        private void LabelAdd_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Visible;
            Modify.Visibility = Visibility.Collapsed;
            Delete.Visibility = Visibility.Collapsed;
        }

        private void LabelModify_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Collapsed;
        }

        private void LabelDelete_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Collapsed;
            Delete.Visibility = Visibility.Visible;
        }

        private void Return_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}