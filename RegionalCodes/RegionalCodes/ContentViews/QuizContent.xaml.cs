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
                    QuizManager.RoundTimeLeft.ToString(@"hh\:mm\:ss");
                lbTotalTimeLeft.Text =
                    QuizManager.TotalTimeLeft.ToString(@"hh\:mm\:ss");
            }));

        }

        private async Task GuessWasCorrect()
        {

            await Task.Run(() => { Thread.Sleep(2000); });
            QuizManager.NextRound();
            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRegionName.Text = QuizManager.CurrentRegion.Region;
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
                QuizManager.GuessAttempt(Code);
            }
        }

        private void RestartButtonPressed(object sender, EventArgs e)
        {



            QuizManager = new QuizGameManager();

            QuizManager.GuessWasCorrect += GuessWasCorrect;
            QuizManager.GameIsOver += GameOver;
            QuizManager.SecondPassed += GameSecondPassed;

            QuizManager.Start();

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.Text = 
                QuizManager.RoundTimeLeft.ToString(@"hh\:mm\:ss");
            lbTotalTimeLeft.Text =
                QuizManager.TotalTimeLeft.ToString(@"hh\:mm\:ss");
            lbRegionName.Text = QuizManager.CurrentRegion.Region;
            CodeToGuess = string.Empty;
            lbGuessInput.Text = CodeToGuess;
            }));




        }

        
    }
}