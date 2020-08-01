using RegionalCodes.ContentViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RegionalCodes
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();

            MenuCarousel.PositionChanged += (object sender, PositionChangedEventArgs e) =>
                {
                    ContainerForViews.Children.Clear();
                    switch (MenuCarousel.Position)
                    {
                        case 0:     //Коды
                            ContainerForViews.Children.Add(new CodesContent(new KeyPad()));
                            break;
                        case 1:     //Справочник
                            ContainerForViews.Children.Add(new DictionaryContent());
                            break;
                        case 2:     //Викторина
                            ContainerForViews.Children.Add(new QuizContent(new KeyPad()));
                            break;

                        default:
                            break;
                    }
                    
                }
            ;
            ContainerForViews.Children.Add(new CodesContent(new KeyPad()));
        }
    }
}
