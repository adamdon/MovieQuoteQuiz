using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    [Serializable]
    class Question
    {
        public string strMovieTitle { get; set; }
        public string strQuoteText { get; set; }
        public int intQuestionRef { get; set; }

        public Question(string strMovieTitleP, string strQuoteTextP, int intQuestionRefP)
        {
            strMovieTitle = strMovieTitleP;
            strQuoteText = strQuoteTextP;
            intQuestionRef = intQuestionRefP;
        }

    }
}
