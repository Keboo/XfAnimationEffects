using Xamarin.Forms;

namespace XfAnimationEffects
{
    public class VerticalSlideEffect : RoutingEffect
    {
        public const string ID = nameof(XfAnimationEffects) + "." + nameof(VerticalSlideEffect);

        public static readonly BindableProperty IsShownProperty = BindableProperty.CreateAttached(ID + ".IsShown",
            typeof(bool), typeof(VerticalSlideEffect), default(bool));

        public static bool GetIsShown(BindableObject obj)
        {
            return (bool)obj.GetValue(IsShownProperty);
        }

        public static void SetIsShown(BindableObject obj, bool value)
        {
            obj.SetValue(IsShownProperty, value);
        }

        public VerticalSlideEffect()
            : base(ID)
        {

        }
    }
}