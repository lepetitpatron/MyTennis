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
            MembersProcessor membersProcessor = new MembersProcessor();
            GamesProcessor gamesProcessor = new GamesProcessor();
            
            MemberDTO member = new MemberDTO()
            {
                FederationNr = "EFGH",
                FirstName = "Chenno",
                LastName = "Wenno",
                BirthDate = new DateTime(2007, 04, 18),
                GenderId = 1,
                Address = "Julius de Geyterstraat",
                Number = "000002",
                Addition = "XX",
                Zipcode = "2020",
                City = "Barcelona",
                PhoneNr = "0456332158",
                IsActive = true
            };

            GameDTO game = new GameDTO()
            {
                Id = 2,
                GameNumber = "000000002",
                MemberId = 3,
                LeagueId = 2,
                Date = new DateTime(2019,11,16)
            };
            MessageBox.Show(await gamesProcessor.Update(game) + "");
        }
    }
}
