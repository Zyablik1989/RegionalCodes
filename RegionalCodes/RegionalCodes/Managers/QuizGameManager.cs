using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Schema;
using Timer = System.Threading.Timer;

namespace RegionalCodes.Managers
{
    class QuizGameManager
    {
        public static System.Timers.Timer aTimer { get; set; } = new System.Timers.Timer(1000);
        public static TimeSpan TotalTimeLeft { get; set; } = new TimeSpan();
        public static TimeSpan RoundTimeLeft { get; set; } = new TimeSpan(0, 0, 10);

        public static bool isCountingGameTime { get; set; } = false;

        public static RegionalCode.Entities.RegionalCode CurrentRegion { get; set; }

        public static List<int> CurrentCorrectAnswers { get; set; } = new List<int>();

        private static bool processing = false;

        //public delegate void SecondsPassingHandler();
        //public  event SecondsPassingHandler SecondPassed;

        //public delegate void GameOverHandler();
        //public event GameOverHandler GameIsOver;

        //public delegate Task GuessIsCorrectHandler();
        //public event GuessIsCorrectHandler GuessWasCorrect;
        public static Action SecondPassed = null;
        public static Action GameIsOver = null;
        public static Action GuessWasCorrect = null;

        public static void Restart()
        {
            TotalTimeLeft = new TimeSpan();
            RoundTimeLeft = new TimeSpan(0,0,10);

            //aTimer = new System.Timers.Timer(1000);
            //aTimer.AutoReset = true;
            //aTimer.Enabled = true;

            NextRound();
        }

        public static void NextRound()
        {
            processing = true;
            CurrentRegion =
                RegionalCodesManager.RegionalCodes.ElementAt
                    (new Random().Next(0, RegionalCodesManager.RegionalCodes.Count - 1));
            CurrentCorrectAnswers = RegionalCodesManager.RegionalCodes
                .Where(x => x.Region == CurrentRegion.Region).Select(x => x.Code).ToList();
            isCountingGameTime = true;
            processing = false;

        }

        public static void TimerSecondIsPassed(object sender, ElapsedEventArgs e)
        {
            if (isCountingGameTime && !processing)
            {
                processing = true;
                if (RoundTimeLeft > new TimeSpan())
                {
                    RoundTimeLeft = RoundTimeLeft.Add(new TimeSpan(0,0,-1));
                    SecondPassed?.Invoke();
                }
                else if (TotalTimeLeft > new TimeSpan())
                {
                    TotalTimeLeft = TotalTimeLeft.Add(new TimeSpan(0, 0, -1));
                    SecondPassed?.Invoke();
                }
                else
                {
                    SecondPassed?.Invoke();
                    GameOver();
                    
                }
                processing = false;
            }
        }

        public static void GuessAttempt(int Guess)
        {
            processing = true;
            if (isCountingGameTime && CurrentCorrectAnswers.Any(x => x == Guess))
            {
                isCountingGameTime = false;
                TotalTimeLeft = TotalTimeLeft.Add(RoundTimeLeft);
                RoundTimeLeft = new TimeSpan(0, 0, 10);
                GuessWasCorrect?.Invoke();
            }
            processing = false;
        }

        private static void GameOver()
        {
            isCountingGameTime = false;
            GameIsOver?.Invoke();
        }
    }
}
