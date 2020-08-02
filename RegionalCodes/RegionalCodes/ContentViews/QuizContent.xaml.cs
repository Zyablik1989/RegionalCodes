using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RegionalCodes.ContentViews;
using RegionalCodes.Managers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegionalCodes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuizContent : ContentView
    {
        private string CodeToGuess = string.Empty;

        private QuizGameManager QuizManager { get; set; } = new QuizGameManager();

        public QuizContent(KeyPad keyPad)
        {
            InitializeComponent();
            keyPad.VerticalOptions = LayoutOptions.FillAndExpand;
            keyPad.ButtonPressed += GetPressedButtonText;
            ContainerForKeyPad.Children.Add(keyPad);
            QuizGameManager.GuessWasCorrect += GuessWasCorrect;
            QuizGameManager.GameIsOver += GameOver;
            QuizGameManager.SecondPassed += GameSecondPassed;
            QuizGameManager.aTimer.Elapsed += QuizGameManager.TimerSecondIsPassed;
            QuizGameManager.aTimer.AutoReset = true;
            QuizGameManager.aTimer.Enabled = true;
            QuizGameManager.TotalTimeLeft = new TimeSpan();
            QuizGameManager.RoundTimeLeft = new TimeSpan(0, 0, 10);
        }

        private void GameOver()
        {
            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRegionName.Text = "ВЫ НЕ УСПЕЛИ";
            }));
        }

        private void GameSecondPassed()
        {


            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.Text =
                    QuizGameManager.RoundTimeLeft.ToString(@"hh\:mm\:ss");
                lbTotalTimeLeft.Text =
                    QuizGameManager.TotalTimeLeft.ToString(@"hh\:mm\:ss");
            }));

        }

        private async void GuessWasCorrect()
        {

            await Task.Run(() => { Thread.Sleep(2000); });
            QuizGameManager.NextRound();
            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRegionName.Text = QuizGameManager.CurrentRegion.Region;
                CodeToGuess = string.Empty;
                lbGuessInput.Text = CodeToGuess;
            }));

        }

        private void GetPressedButtonText(string s)
        {
            if (s.ToLower() == "c")
            {
                CodeToGuess = string.Empty;
                lbGuessInput.Text = CodeToGuess;
                return;
            }

            if (CodeToGuess.Length >= 3 || lbGuessInput.Text.Length >= 3)
            {
                CodeToGuess = string.Empty;
                lbGuessInput.Text = string.Empty;
            }

             CodeToGuess += s;
            lbGuessInput.Text = CodeToGuess;

            int Code = 0;
            if (int.TryParse(CodeToGuess, out Code))
            {
                QuizGameManager.GuessAttempt(Code);
            }
        }

        private void RestartButtonPressed(object sender, EventArgs e)
        {
        


            //QuizManager = new QuizGameManager();

            //Delegate[] clientList = QuizManager.GuessWasCorrect.GetInvocationList();
            //if (QuizManager.GuessWasCorrect != null)
            //    foreach (var d in QuizManager.GuessWasCorrect.GetInvocationList())
            //        QuizManager.GuessWasCorrect -= (d as this.GuessWasCorrect);

            QuizGameManager.Restart();

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.Text =
                    QuizGameManager.RoundTimeLeft.ToString(@"hh\:mm\:ss");
            lbTotalTimeLeft.Text =
                QuizGameManager.TotalTimeLeft.ToString(@"hh\:mm\:ss");
            lbRegionName.Text = QuizGameManager.CurrentRegion.Region;
            CodeToGuess = string.Empty;
            lbGuessInput.Text = CodeToGuess;
            }));




        }

        
    }
}