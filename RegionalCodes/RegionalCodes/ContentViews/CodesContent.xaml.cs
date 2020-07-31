using RegionalCodes.ContentViews;
using RegionalCodes.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegionalCodes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodesContent : ContentView
    {
        public CodesContent()
        {
            InitializeComponent();
            //var keys = new KeyPad() {};
            //keys.ButtonPressed += GetPressedButtonText;
            //ContainerForKeyPad.Children.Add(keys);
            

        }

        private string CodeToRecognize = string.Empty;

        public CodesContent(KeyPad keyPad)
        {
            InitializeComponent();
            keyPad.VerticalOptions = LayoutOptions.FillAndExpand;
            keyPad.ButtonPressed += GetPressedButtonText;
            ContainerForKeyPad.Children.Add(keyPad);
        }

        private void GetPressedButtonText(string s)
        {
            if (s.ToLower() == "c")
            {
                CodeToRecognize = string.Empty;
                lbCodeEntered.Text = "Введите код региона";
                RegionRecognized.Text = string.Empty;
                return;
            }

            if (CodeToRecognize.Length >= 3)
                CodeToRecognize = string.Empty;


            CodeToRecognize += s;

            lbCodeEntered.Text = CodeToRecognize;

            RecognizeCode();
        }

        private void RecognizeCode()
        {
            int Code = 0;
            if (int.TryParse(CodeToRecognize, out Code))
                RegionRecognized.Text = RegionalCodesManager.RegionalCodes.FirstOrDefault(x => x.Code == Code)?.Region
                    .Trim();


        }
    }
}