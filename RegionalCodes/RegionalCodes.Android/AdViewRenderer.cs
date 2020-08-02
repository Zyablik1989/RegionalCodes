using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Ads;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using RegionalCodes.Controls;
using RegionalCodes.Droid;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AdControlView), typeof(AdViewRenderer))]
namespace RegionalCodes.Droid
{
    
    public class AdViewRenderer : ViewRenderer<AdControlView,AdView>
    {
        public AdViewRenderer(Context context) : base(context)
        {

        }

        private string adUnitId = "ca-app-pub-4183080386790760/3615497217";
        
        private AdSize adSize = AdSize.SmartBanner;
        AdView adView;

        private AdView CreateAdView()
        {
            if (adView != null)
            {
                return adView;
            }

            adView = new AdView(Context)
            {
                AdSize = adSize,
                AdUnitId = adUnitId
            };

            var adParams = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            adView.LayoutParameters = adParams;
            adView.LoadAd(new AdRequest.Builder().Build());

            return adView;

        }

        protected override void OnElementChanged(ElementChangedEventArgs<AdControlView> e)
        {
            base.OnElementChanged(e);
            if (Control == null && e.NewElement != null)
            {
                SetNativeControl(CreateAdView());
            }
        }
    }
}