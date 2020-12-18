using MyTennis.UI.Views;
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

        private void GameIcon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();

            Hide();
        }

        private void MemberIcon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MemberWindow memberWindow = new MemberWindow();
            memberWindow.Show();

            Hide();
        }

        private void FineIcon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FineWindow fineWindow = new FineWindow();
            fineWindow.Show();

            Hide();
        }

        private void RoleIcon_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RoleWindow roleWindow = new RoleWindow();
            roleWindow.Show();

            Hide();
        }
    }
}