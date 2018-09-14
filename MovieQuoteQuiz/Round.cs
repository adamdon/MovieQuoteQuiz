using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    class Round
    {
        public Question queCurrentQuestion { get; set; }

        public Question queCurrentWrongAnswer1 { get; set; }
        public Question queCurrentWrongAnswer2 { get; set; }

        public int intRoundNumber { get; set; }

        public int intSelectedRadio { get; set; }

        public int intCorrectRadio { get; set; }
        public int intIncorrectRadio1 { get; set; }
        public int intIncorrectRadio2 { get; set; }


        public Round(Question queCurrentQuestionP, Question queCurrentWrongAnswer1P, Question queCurrentWrongAnswer2P, int intCorrectRadioP, int intIncorrectRadio1P, int intIncorrectRadio2P, int intRoundNumberP)
        {
            queCurrentQuestion = queCurrentQuestionP;
            queCurrentWrongAnswer1 = queCurrentWrongAnswer1P;
            queCurrentWrongAnswer2 = queCurrentWrongAnswer2P;
            
            intCorrectRadio = intCorrectRadioP;
            intIncorrectRadio1 = intIncorrectRadio1P;
            intIncorrectRadio2 = intIncorrectRadio2P;

            intRoundNumber = intRoundNumberP;
        }

    }
}
