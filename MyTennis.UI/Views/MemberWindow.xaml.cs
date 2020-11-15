using MyTennis.Core.DTO;
using MyTennis.UI.Processors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            MemberDTO member = new MemberDTO()
            {
                FederationNr = "1111",
                FirstName = "Hamza",
                LastName = "Menouny",
                BirthDate = DateTime.Now,
                GenderId = 1,
                Address = "fzqfq",
                Number = "000000",
                Addition = "X",
                Zipcode = "X",
                City = "Antwerp",
                PhoneNr = "20000",
                IsActive = true,
               // MemberRoles = new List<MemberRoleDTO>()
            };

            MembersProcessor processor = new MembersProcessor();

            bool hmm = await processor.Add(member);

            if (hmm)
                MessageBox.Show("OMG");
            else
                MessageBox.Show("Sike");
        }
    }
}
