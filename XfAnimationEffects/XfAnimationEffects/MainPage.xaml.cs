using System;

using Xamarin.Forms;

namespace XfAnimationEffects
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ShowOverlayClicked(object sender, EventArgs e)
        {
            VerticalSlideEffect.SetIsShown(Overlay, !VerticalSlideEffect.GetIsShown(Overlay));
        }
    }
}
