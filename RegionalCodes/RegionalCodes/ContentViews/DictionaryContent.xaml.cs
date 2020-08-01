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

    public class regionString
    {
        public string regstring { get; set; } = string.Empty;
    }

    public partial class DictionaryContent : ContentView
    {
        public DictionaryContent()
        {
            InitializeComponent();

            List<regionString> regions = new List<regionString>();
            foreach (var region in RegionalCodesManager.CodesForDictionary)
            {
                regions.Add(new regionString { regstring = region});
            }

            TextCell textCell1 = new TextCell { TextColor = Color.Black, DetailColor = Color.Green };
            textCell1.SetBinding(TextCell.TextProperty, "regstring");

            var a = new DataTemplate(() =>
            {

                TextCell textCell = new TextCell {TextColor = Color.Black, DetailColor = Color.Green};
                textCell.SetBinding(TextCell.TextProperty, "regstring");
                //Binding companyBinding = new Binding { Path = "Company", StringFormat = "Флагман от компании {0}" };
                //textCell.SetBinding(TextCell.DetailProperty, companyBinding);
                return textCell;
                //Label titleLabel = new Label {FontSize = 18};
                //titleLabel.SetBinding(Label.TextProperty, "regstring");
                //return new ViewCell
                //{
                //   View = titleLabel
                //    //View = new StackLayout
                //    //{
                //    //    //Padding = new Thickness(0, 5),
                //    //    Orientation = StackOrientation.Vertical,
                //    //    Children = { titleLabel }
                //    //}
                //};
            });
            var v = new ListView
                {
                    HasUnevenRows = true,
                    // Определяем источник данных
                    ItemsSource = regions,
                    ItemTemplate = new DataTemplate(() =>
                    {

                        TextCell textCell = new TextCell { TextColor = Color.Black, DetailColor = Color.Green };
                        textCell.SetBinding(TextCell.TextProperty, "regstring");
                        //Binding companyBinding = new Binding { Path = "Company", StringFormat = "Флагман от компании {0}" };
                        //textCell.SetBinding(TextCell.DetailProperty, companyBinding);
                        return textCell;
                        //Label titleLabel = new Label {FontSize = 18};
                        //titleLabel.SetBinding(Label.TextProperty, "regstring");
                        //return new ViewCell
                        //{
                        //   View = titleLabel
                        //    //View = new StackLayout
                        //    //{
                        //    //    //Padding = new Thickness(0, 5),
                        //    //    Orientation = StackOrientation.Vertical,
                        //    //    Children = { titleLabel }
                        //    //}
                        //};
                    })
                };
            v.ItemTemplate = a;
            CodesList = v;
                //CodesList.ItemsSource = labels;
                //CodesList.ItemsSource = RegionalCodesManager.CodesForDictionary;

            //CodesList.ItemsSource =
            //    RegionalCodesManager.CodesForDictionary
            //        .Select(x => new Label { Text = x }));

            //CodesList.ItemsSource = RegionalCodes
            //    .OrderBy(x=>x.Region)
            //    .ThenBy(x=>x.Code)
            //    .Select(x=>x.GetStringForDictionary());

        }
    }
}