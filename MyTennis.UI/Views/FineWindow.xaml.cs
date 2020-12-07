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
    /// Interaction logic for FineWindow.xaml
    /// </summary>
    public partial class FineWindow : Window
    {
        readonly FinesProcessor finesProcessor;
        readonly MembersProcessor membersProcessor;
        List<FineDTO> fines;
        List<MemberDTO> members;

        public FineWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            finesProcessor = new FinesProcessor();
            membersProcessor = new MembersProcessor();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            fines = await finesProcessor.GetAll();
            members = await membersProcessor.GetAll();

            AddPicker.ItemsSource = members;
            AddPicker.SelectedIndex = 0;

            OverviewFines.ItemsSource = fines;

            ModifyPicker.ItemsSource = fines.FindAll(fine => fine.PaymentDate == new DateTime(9999, 1, 1));
            ModifyPicker.SelectedIndex = 0;

            if (!MembersAvailable())
                AddConfirm.IsEnabled = false;

            if (fines.Count < 1)
                ModifyConfirm.IsEnabled = false;
        }

        private async void AddConfirm_Click(object sender, RoutedEventArgs e)
        {
            List<Control> controls = new List<Control>
            {
                AddFineNr,
                AddHandoutDate
            };

            if (!ValidateFine(controls, AddError)) return;

            MemberDTO member = (MemberDTO) AddPicker.SelectedItem;
            FineDTO fine = new FineDTO()
            {
                FineNumber = int.Parse(AddFineNr.Text),
                MemberId = member.Id,
                Amount = ConvertToDecimal(AddAmount.Text),
                HandoutDate = (DateTime)AddHandoutDate.SelectedDate,
                PaymentDate = GetPayoutDate(AddPaymentDate)
            };

            await finesProcessor.Add(fine);

            controls.Add(AddPaymentDate);
            controls.Add(AddAmount);
            ClearFields(controls);

            MessageBox.Show("De boete werd toegevoegd.", "Succes");
        }

        private async void ModifyConfirm_Click(object sender, RoutedEventArgs e)
        {
            List<Control> controls = new List<Control> { ModifyPaymentDate };

            if (!ValidateFine(controls, ModifyError)) return;

            FineDTO fine = (FineDTO) ModifyPicker.SelectedItem;
            fine.PaymentDate = (DateTime) ModifyPaymentDate.SelectedDate;

            await finesProcessor.Update(fine);
            ClearFields(controls);

            MessageBox.Show("De boete werd aangepast.", "Succes");
        }

        private bool ValidateFine(List<Control> controls, TextBlock error)
        {
            bool valid = true;
            TextBox input;
            DatePicker date;

            foreach (Control t in controls)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    input = (TextBox)t;

                    if (string.IsNullOrWhiteSpace(input.Text))
                        valid = false;
                }
                else if (t.GetType() == typeof(DatePicker))
                {
                    date = (DatePicker)t;

                    if (date.SelectedDate == null)
                        valid = false;
                }
            }

            if (!string.IsNullOrWhiteSpace(AddFineNr.Text))
            {
                try
                {
                    int.Parse(AddFineNr.Text);
                }
                catch (Exception)
                {
                    valid = false;
                }
            }
            
            if (ModifyPaymentDate.SelectedDate <= ModifyHandoutDate.SelectedDate)
            {
                valid = false;
            }

            if (!valid)
            {
                error.Text = "Gelieve alle velden (correct) in te vullen.";
                error.Visibility = Visibility.Visible;
            }
            else
            {
                error.Text = "";
                error.Visibility = Visibility.Collapsed;
            }

            return valid;
        }

        private double ConvertToDecimal(string num)
        {
            string temp = num.Replace("_", "0");

            return double.Parse(temp);
        }

        private DateTime GetPayoutDate(DatePicker date)
        {
            if (date.SelectedDate == null)
                return new DateTime(9999, 1, 1);

            return (DateTime) date.SelectedDate;
        }

        private void ClearFields(List<Control> controls)
        {
            TextBox input;
            DatePicker date;
            Xceed.Wpf.Toolkit.MaskedTextBox maskedInput;

            foreach (Control t in controls)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    input = (TextBox)t;
                    input.Text = "";
                }
                else if (t.GetType() == typeof(DatePicker))
                {
                    date = (DatePicker)t;
                    date.SelectedDate = null;
                }
                else if (t.GetType() == typeof(Xceed.Wpf.Toolkit.MaskedTextBox))
                {
                    maskedInput = (Xceed.Wpf.Toolkit.MaskedTextBox)t;
                    maskedInput.Text = "_______,__";
                }
            }
        }

        private bool MembersAvailable()
        {
            return members.Count > 0;
        }

        private void ModifyPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FineDTO fine = (FineDTO) ModifyPicker.SelectedItem;
            MemberDTO member = members.Find(member => member.Id == fine.MemberId);

            ModifyMember.Text = member.ToString();
            ModifyAmount.Text = fine.Amount.ToString();
            ModifyHandoutDate.SelectedDate = fine.HandoutDate;
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
