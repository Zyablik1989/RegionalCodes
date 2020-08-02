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
            //Delegate[] clientList = QuizManager.GuessWasCorrect.GetInvocationList();
            //if (QuizManager.GuessWasCorrect != null)
            //    foreach (var d in QuizManager.GuessWasCorrect.GetInvocationList())
            //        QuizManager.GuessWasCorrect -= (d as this.GuessWasCorrect);
            InitializeComponent();
            keyPad.VerticalOptions = LayoutOptions.FillAndExpand;
            keyPad.ButtonPressed += GetPressedButtonText;
            ContainerForKeyPad.Children.Add(keyPad);
            QuizGameManager.GuessWasCorrect += GuessWasCorrect;
            QuizGameManager.GameIsOver += GameOver;
            QuizGameManager.SecondPassed += GameSecondPassed;
            QuizGameManager.isCountingGameTime = false;

            if (!QuizGameManager.SubscribedTimer)
            {
                QuizGameManager.aTimer.Elapsed += QuizGameManager.TimerSecondIsPassed;
                QuizGameManager.SubscribedTimer = true;
            }

            QuizGameManager.aTimer.AutoReset = true;
            QuizGameManager.aTimer.Enabled = true;
            QuizGameManager.TotalTimeLeft = new TimeSpan();
            QuizGameManager.RoundTimeLeft = new TimeSpan(0, 0, 10);
        }

        private void GameOver()
        {
            Color Reder = Color.FromHex("#95FFAACC");

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRegionName.Text = "ВЫ НЕ УСПЕЛИ";
                sRegion.BackgroundColor = Reder;
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
            Color Basic = Color.FromHex("#70AAAACC");
            Color Greener = Color.FromHex("#70AAFFCC");
            Color Black = Color.Black;


            //Надпись
            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRegionName.Text = "ВЕРНО!";
                sRegion.BackgroundColor = Greener;
            }));
            await Task.Run(() => { Thread.Sleep(500); });


            //Номер
            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                sGuess.BackgroundColor = Greener;
            }));
            await Task.Run(() => { Thread.Sleep(250); });

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                sGuess.BackgroundColor = Basic;
            }));
            await Task.Run(() => { Thread.Sleep(250); });

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                sGuess.BackgroundColor = Greener;
            }));
            await Task.Run(() => { Thread.Sleep(250); });

            //Время

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.TextColor = Greener;
                lbTotalTimeLeft.TextColor = Greener;
            }));
            await Task.Run(() => { Thread.Sleep(150); });

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.TextColor = Black;
                lbRoundTimeLeft.TextColor = Black;
            }));
            await Task.Run(() => { Thread.Sleep(150); });

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.TextColor = Greener;
                lbTotalTimeLeft.TextColor = Greener;
            }));
            await Task.Run(() => { Thread.Sleep(150); });

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.TextColor = Black;
                lbRoundTimeLeft.TextColor = Black;
            }));
            await Task.Run(() => { Thread.Sleep(150); });

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.TextColor = Greener;
                lbTotalTimeLeft.TextColor = Greener;
            }));
            await Task.Run(() => { Thread.Sleep(150); });

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.TextColor = Black;
                lbRoundTimeLeft.TextColor = Black;
            }));
            await Task.Run(() => { Thread.Sleep(150); });

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.TextColor = Greener;
                lbTotalTimeLeft.TextColor = Greener;
            }));
            await Task.Run(() => { Thread.Sleep(150); });


            QuizGameManager.NextRound();
            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRegionName.Text = QuizGameManager.CurrentRegion.Region;
                CodeToGuess = string.Empty;
                lbGuessInput.Text = CodeToGuess;
            }));

            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.TextColor = Black;
                lbTotalTimeLeft.TextColor = Black;
                sRegion.BackgroundColor = Basic;
                sGuess.BackgroundColor = Basic;
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
            Color Basic = Color.FromHex("#70AAAACC");
            Dispatcher?.BeginInvokeOnMainThread((delegate
            {
                lbRoundTimeLeft.TextColor = Color.Black;
                lbTotalTimeLeft.TextColor = Color.Black;
                sRegion.BackgroundColor = Basic;
                sGuess.BackgroundColor = Basic;
            }));

            //QuizManager = new QuizGameManager();



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