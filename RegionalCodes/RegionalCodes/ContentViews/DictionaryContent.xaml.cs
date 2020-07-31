using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegionalCodes.Managers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RegionalCodes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DictionaryContent : ContentView
    {
        public DictionaryContent()
        {
            InitializeComponent();
            CodesList.ItemsSource = RegionalCodesManager.CodesForDictionary;
            //CodesList.ItemsSource = RegionalCodes
            //    .OrderBy(x=>x.Region)
            //    .ThenBy(x=>x.Code)
            //    .Select(x=>x.GetStringForDictionary());

        }
    }
}