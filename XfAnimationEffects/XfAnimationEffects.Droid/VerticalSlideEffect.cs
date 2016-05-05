using System;
using System.ComponentModel;
using Android.Animation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XfAnimationEffects.Droid;

[assembly: ResolutionGroupName(nameof(XfAnimationEffects))]
[assembly: ExportEffect(typeof(VerticalSlideEffect), nameof(VerticalSlideEffect))]
namespace XfAnimationEffects.Droid
{
    public class VerticalSlideEffect : PlatformEffect
    {
        private readonly ValueAnimator _animator;

        public VerticalSlideEffect()
        {
            _animator = ValueAnimator.OfFloat(0);
            _animator.SetInterpolator(new Android.Views.Animations.LinearInterpolator());
            _animator.SetDuration(2000);
            _animator.Update += OnAnimationUpdate;
            _animator.AnimationEnd += OnAnimationEnd;
        }

        protected override void OnAttached()
        {
            Element.PropertyChanged += OnPropertyChanged;
        }

        protected override void OnDetached()
        {
            Element.PropertyChanged -= OnPropertyChanged;
            if (_animator.IsRunning) _animator.Cancel();
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == XfAnimationEffects.VerticalSlideEffect.IsShownProperty.PropertyName)
            {
                var visualElement = Element as VisualElement;
                if (visualElement != null)
                {
                    if (XfAnimationEffects.VerticalSlideEffect.GetIsShown(visualElement))
                    {
                        AnimateIn();
                    }
                    else
                    {
                        AnimateOut();
                    }
                }
            }
        }

        private void OnAnimationUpdate(object sender, ValueAnimator.AnimatorUpdateEventArgs e)
        {
            if (!IsAttached) return;
            
            Container.TranslationY = (float) e.Animation.AnimatedValue;
        }

        private void OnAnimationEnd(object sender, EventArgs e)
        {
            var visualElement = Element as VisualElement;
            if (visualElement != null)
            {
                visualElement.TranslationY = Forms.Context.FromPixels(Container.TranslationY);
            }
        }

        private void AnimateIn()
        {
            if (_animator.IsRunning)
                _animator.Cancel();

            _animator.SetFloatValues(Container.TranslationY, -Container.Height);

            _animator.Start();
        }

        private void AnimateOut()
        {
            if (_animator.IsRunning)
                _animator.Cancel();

            _animator.SetFloatValues(Container.TranslationY, 0);

            _animator.Start();
        }
    }
}