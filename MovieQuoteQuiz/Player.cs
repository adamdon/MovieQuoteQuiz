using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieQuoteQuiz
{
    [Serializable]
    class Player
    {
        public string strUsername { get; set; }

        public Player(string strUsernameP)
        {
            strUsername = strUsernameP;
        }

    }
}
