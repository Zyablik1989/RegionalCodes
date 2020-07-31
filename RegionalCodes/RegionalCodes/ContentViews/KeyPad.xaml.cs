using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegionalCodes.ContentViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KeyPad : ContentView
    {
        public KeyPad()
        {
            InitializeComponent();
        }
        public delegate void PressedTextHandler(string s);


        public event PressedTextHandler ButtonPressed;

        private void Button_Clicked(object sender, EventArgs e)
        {
            var s = (sender as Button)?.Text;
            if (s != null) ButtonPressed?.Invoke(s);
        }
    }
}