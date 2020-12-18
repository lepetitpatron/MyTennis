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
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        readonly GamesProcessor gamesProcessor;
        readonly ResultsProcessor resultsProcessor;
        readonly MembersProcessor membersProcessor;
        readonly LeaguesProcessor leaguesProcessor;
        List<GameDTO> games;
        List<GameDTO> resultGames;
        List<ResultDTO> results;
        List<MemberDTO> members;
        List<LeagueDTO> leagues;

        public GameWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();

            gamesProcessor = new GamesProcessor();
            resultsProcessor = new ResultsProcessor();
            membersProcessor = new MembersProcessor();
            leaguesProcessor = new LeaguesProcessor();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            games = await gamesProcessor.GetAll();
            members = await membersProcessor.GetAll();
            leagues = await leaguesProcessor.GetAll();
            results = await resultsProcessor.GetAll();

            AddPickerGameNr.ItemsSource = games.FindAll(game => game.Date <= DateTime.Today && !results.Exists(result => game.Id == result.GameId));
            AddPickerMember.ItemsSource = members;
            AddPickerLeague.ItemsSource = leagues;

            AddPickerGameNr.SelectedIndex = 0;
            AddPickerMember.SelectedIndex = 0;
            AddPickerLeague.SelectedIndex = 0;
            

            ModifyPickerGame.ItemsSource = games.FindAll(game => game.Date >= DateTime.Today);
            ModifyPickerMember.ItemsSource = members;
            ModifyPickerLeague.ItemsSource = leagues;

            ModifyPickerGameNr.ItemsSource = games.FindAll(game => game.Date <= DateTime.Today);

            ModifyPickerGame.SelectedIndex = 0;

            if (MembersAvailable())
            {
                AddConfirm.IsEnabled = true;
            }
            else
            {
                AddConfirm.IsEnabled = false;
            }


            if (games.FindAll(game => game.Date >= DateTime.Today).Count > 0)
            {
                DeletePicker.ItemsSource = games.FindAll(game => game.Date >= DateTime.Today);
                DeletePicker.SelectedIndex = 0;

                DeleteConfirm.IsEnabled = true;
            }
            else
            {
                DeleteConfirm.IsEnabled = false;
            }

            // Get Games with results for ModifyPickerGameNr
            foreach(ResultDTO result in results)
            {
                resultGames = new List<GameDTO>();
                resultGames.Add(games.Find(game => result.GameId == game.Id));
            }

            ModifyPickerGameNr.ItemsSource = resultGames;
            ModifyPickerGameNr.SelectedIndex = 0;
        }

        private async void AddConfirm_Click(object sender, RoutedEventArgs e)
        {
            MemberDTO member = (MemberDTO) AddPickerMember.SelectedItem; 
            LeagueDTO league = (LeagueDTO) AddPickerLeague.SelectedItem; 

            List<Control> controls = new List<Control>
            {
                AddGameNr,
                AddGameDate
            };

            if (!ValidateGame(controls, AddError)) return;

            GameDTO game = new GameDTO
            {
                GameNumber = AddGameNr.Text,
                MemberId = member.Id,
                LeagueId = league.Id,
                Date = (DateTime) AddGameDate.SelectedDate
            };

            await gamesProcessor.Add(game);
         
            ClearFields(controls);
            AddPickerMember.SelectedIndex = 0;
            AddPickerLeague.SelectedIndex = 0;

            MessageBox.Show("De wedstrijd werd toegevoegd.", "Succes");
        }

        private async void AddConfirmResult_Click(object sender, RoutedEventArgs e)
        {
            GameDTO game = (GameDTO) AddPickerGameNr.SelectedItem;
            List<Control> controls = new List<Control>
            {
                AddResultSet,
                AddResultScoreTeam,
                AddResultScoreOpponent
            };

            if (!ValidateResult(controls, AddErrorResult)) return;

            ResultDTO result = new ResultDTO
            {
                GameId = game.Id,
                SetNr = byte.Parse(AddResultSet.Text),
                ScoreTeamMember = byte.Parse(AddResultScoreTeam.Text),
                ScoreOpponent = byte.Parse(AddResultScoreOpponent.Text)
            };

            await resultsProcessor.Add(result);

            ClearFields(controls);
            AddPickerGameNr.SelectedIndex = 0;

            MessageBox.Show("De resultaat werd toegevoegd.", "Succes");
        }

        private async void ModifyConfirm_Click(object sender, RoutedEventArgs e)
        {
            GameDTO game = (GameDTO) ModifyPickerGame.SelectedItem;
            List<Control> controls = new List<Control> { ModifyGameDate };

            if (!ValidateGame(controls, ModifyError)) return;

            MemberDTO member = (MemberDTO) ModifyPickerMember.SelectedItem;
            LeagueDTO league = (LeagueDTO) ModifyPickerLeague.SelectedItem;

            game.MemberId = member.Id;
            game.LeagueId = league.Id;
            game.Date = (DateTime) ModifyGameDate.SelectedDate;

            await gamesProcessor.Update(game);
            ModifyPickerGame.SelectedIndex = 0;

            MessageBox.Show("De wedstrijd werd aangepast.", "Succes");
        }

        private async void ModifyConfirmResult_Click(object sender, RoutedEventArgs e)
        {
            GameDTO game = (GameDTO) ModifyPickerGameNr.SelectedItem;
            ResultDTO result = results.Find(result => game.Id == result.GameId);
            List<Control> controls = new List<Control>
            {
                ModifyResultSet,
                ModifyResultScoreTeam,
                ModifyResultScoreOpponent
            };

            if (!ValidateResult(controls, ModifyErrorResult)) return;

            result.SetNr = byte.Parse(ModifyResultSet.Text);
            result.ScoreTeamMember = byte.Parse(ModifyResultScoreTeam.Text);
            result.ScoreOpponent = byte.Parse(ModifyResultScoreOpponent.Text);

            await resultsProcessor.Update(result);
            ModifyPickerGameNr.SelectedIndex = 0;

            MessageBox.Show("De resultaat werd aangepast.", "Succes");
        }

        private async void DeleteConfirm_Click(object sender, RoutedEventArgs e)
        {
            GameDTO game = (GameDTO) DeletePicker.SelectedItem;
            ResultDTO result = results.Find(result => result.GameId == game.Id);

            if (result != null)
                await resultsProcessor.Delete(result.Id);
            await gamesProcessor.Delete(game.Id);
            
            MessageBox.Show("De wedstrijd werd verwijderd.", "Succes");
        }

        private bool ValidateGame(List<Control> controls, TextBlock error)
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

                    if (date.SelectedDate == null || date.SelectedDate < DateTime.Today)
                        valid = false;
                }
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

        private bool ValidateResult(List<Control> controls, TextBlock error)
        {
            bool valid = true;
            TextBox input;

            foreach (Control t in controls)
            {
                if (t.GetType() == typeof(TextBox))
                {
                    input = (TextBox)t;

                    if (string.IsNullOrWhiteSpace(input.Text))
                    {
                        valid = false;
                    }
                    else
                    {
                        try
                        {
                            byte.Parse(input.Text);
                        }
                        catch (Exception)
                        {
                            valid = false;
                        }
                    }
                }
            }

            if (!valid)
            {
                error.Text = "Gelieve sets en scores in te geven tussen 0 en 255.";
                error.Visibility = Visibility.Visible;
            }
            else
            {
                error.Text = "";
                error.Visibility = Visibility.Collapsed;
            }

            return valid;
        }

        private void ClearFields(List<Control> controls)
        {
            TextBox input;
            DatePicker date;

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
            }
        }

        private bool MembersAvailable()
        {
            return members.Count > 0;
        }

        private void SetModifyGame(GameDTO game)
        {
            ModifyPickerMember.SelectedIndex = members.FindIndex(member => member.Id == game.MemberId);
            ModifyPickerLeague.SelectedIndex = leagues.FindIndex(league => league.Id == game.LeagueId);
            ModifyGameDate.SelectedDate = game.Date;
        }

        private void SetModifyResult(GameDTO game)
        {
            ResultDTO result = results.Find(result => game.Id == result.GameId);

            ModifyResultSet.Text = "" + result.SetNr;
            ModifyResultScoreTeam.Text = "" + result.ScoreTeamMember;
            ModifyResultScoreOpponent.Text = "" + result.ScoreOpponent;
        }

        private void ModifyPickerGameNr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GameDTO game = (GameDTO) ModifyPickerGameNr.SelectedItem;
            SetModifyResult(game);
        }

        private void ModifyPickerGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GameDTO game = (GameDTO) ModifyPickerGame.SelectedItem;
            SetModifyGame(game);
        }

        private void LabelOverview_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Visible;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Collapsed;
            Delete.Visibility = Visibility.Collapsed;
        }

        private void LabelAdd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Visible;
            Modify.Visibility = Visibility.Collapsed;
            Delete.Visibility = Visibility.Collapsed;
        }

        private void LabelModify_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Visible;
            Delete.Visibility = Visibility.Collapsed;
        }

        private void LabelDelete_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Overview.Visibility = Visibility.Collapsed;
            Add.Visibility = Visibility.Collapsed;
            Modify.Visibility = Visibility.Collapsed;
            Delete.Visibility = Visibility.Visible;
        }

        private void Return_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}
