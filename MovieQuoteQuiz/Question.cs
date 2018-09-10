using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Question
    {
        string strMovieTitle { get; set; }
        string strQuoteText { get; set; }
        int intQuestionRef { get; set; }

        public Question(string strMovieTitleP, string strQuoteTextP, int intQuestionRefP)
        {
            strMovieTitle = strMovieTitleP;
            strQuoteText = strQuoteTextP;
            intQuestionRef = intQuestionRefP;
        }

    }
}
