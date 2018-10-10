using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace MovieQuoteQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        

        public MainWindow()
        {
            Controller.SetupApplication();          
            InitializeComponent();
            PopulateFieldsWithView();
        }

        private void btnNewGamebutton_Click(object sender, RoutedEventArgs e)
        {
            if ((cmbRoundsAmount.SelectedIndex == 0) && (cmbPlayerNameTextBox.Text.ToString() != ""))
            {
                Controller.StartNewGame(cmbPlayerNameTextBox.Text.ToString(), 3);
            }
            else if ((cmbRoundsAmount.SelectedIndex == 1) && (cmbPlayerNameTextBox.Text.ToString() != ""))
            {
                Controller.StartNewGame(cmbPlayerNameTextBox.Text.ToString(), 5);
            }
            else if ((cmbRoundsAmount.SelectedIndex == 2) && (cmbPlayerNameTextBox.Text.ToString() != ""))
            {
                Controller.StartNewGame(cmbPlayerNameTextBox.Text.ToString(), 10);
            }

            PopulateFieldsWithView();
        }

        private void btnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (radAnswer1.IsChecked == true)
            {
                Controller.SubmitAnswer(1); //MessageBox.Show("Correct!");
            }
            else if (radAnswer2.IsChecked == true)
            {
                Controller.SubmitAnswer(2);
            }
            else if (radAnswer3.IsChecked == true)
            {
                Controller.SubmitAnswer(3);
            }

            PopulateFieldsWithView();
        }

        private void PopulateFieldsWithView()
        {
            lblQuestionNumber.Content = View.strLblQuestioRoundText;
            lblCurrentQuestion.Content = View.strLblCurrentQuestion;
            lblStatusBar.Content = View.strlblStatusBar;

            lblTestLable1.Content = View.strlblTestLable1;
            lblTestLable1.BeginAnimation(Window.OpacityProperty, View.AnimateLabel());

            lblCurrentRound.Content = View.strlblCurrentRound;
            lblCorrectAnswers.Content = View.strlblCorrectAnswers;
            lblGamePoints.Content = View.strlblGamePoints;

            lblPlayerName.Content = View.strlblPlayerName;
            lblPercentageCorrect.Content = View.strlblPercentageCorrect;
            lblTotalPoints.Content = View.strlblTotalPoints;

            radAnswer1.Content = View.strRadAnswer1;
            radAnswer2.Content = View.strRadAnswer2;
            radAnswer3.Content = View.strRadAnswer3;

            radAnswer1.IsChecked = View.isRadAnswer1Selected;
            radAnswer2.IsChecked = View.isRadAnswer2Selected;
            radAnswer3.IsChecked = View.isRadAnswer3Selected;

            btnSubmitAnswer.IsEnabled = View.isbtnSubmitAnswerActive;
            btnTestbutton.IsEnabled = View.isbtnNewGamebuttonActive;
            gruQuizGroupBox.IsEnabled = View.isgruQuizGroupBoxActive;
            gruScoreGroupBox.IsEnabled = View.isgruScoreGroupBoxActive;
            cmbPlayerNameTextBox.IsEnabled = View.iscmbPlayerNameTextBoxtActive;
            cmbRoundsAmount.IsEnabled = View.iscmbRoundsAmountActive;

            cmbPlayerNameTextBox.ItemsSource = null;
            cmbPlayerNameTextBox.ItemsSource = Database.plaListOfPlayers;
            cmbPlayerNameTextBox.DisplayMemberPath = "strUsername";
        }

        //private void cmbPlayerNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Controller.PlayerNameTextBox_TextChanged(cmbPlayerNameTextBox.Text.ToString());
        //    PopulateFieldsWithView();
        //}  // TextBoxBase.TextChanged="cmbPlayerNameTextBox_TextChanged"

        //private void cmbPlayerNameTextBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}  // SelectionChanged="cmbPlayerNameTextBox_SelectionChanged"
    }
}
