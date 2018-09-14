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
            PopulateFieldsWithView();
        }

        private void btnNewGamebutton_Click(object sender, RoutedEventArgs e)
        {
            Controller.StartNewGame();
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

            radAnswer1.Content = View.strRadAnswer1;
            radAnswer2.Content = View.strRadAnswer2;
            radAnswer3.Content = View.strRadAnswer3;
        }

        private void btnUpdateStatusBar_Click(object sender, RoutedEventArgs e)
        {
            PopulateFieldsWithView();
        }
    }
}
