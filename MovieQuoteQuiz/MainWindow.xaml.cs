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

namespace MovieQuoteQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            Database.SetupDefultValues();
            InitializeComponent();
            UpdateAllFields();
        }

        private void btnNewGamebutton_Click(object sender, RoutedEventArgs e)
        {
            Controller.StartNewGame();
            UpdateAllFields();
        }

        private void btnSubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            if (radAnswer3.IsChecked == true)
            {
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show("Sorry, you are wrong");
            }
        }

        private void UpdateAllFields()
        {
            lblQuestionNumber.Content = View.strLblQuestioRoundText;
            lblCurrentQuestion.Content = View.strLblCurrentQuestion;
            lblStatusBar.Content = View.strlblStatusBar;

            radAnswer1.Content = View.strRadAnswer1;
            radAnswer2.Content = View.strRadAnswer2;
            radAnswer3.Content = View.strRadAnswer3;
        }

        private void btnUpdateStatusBar_Click(object sender, RoutedEventArgs e)
        {
            UpdateAllFields();
        }
    }
}
