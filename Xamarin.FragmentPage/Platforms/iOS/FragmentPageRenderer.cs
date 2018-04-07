using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Cinary.Xamarin.Fragment;
using Cinary.Xamarin.Fragment.Platforms.iOS;

[assembly: ExportRenderer(typeof(FragmentPage), typeof(FlexiPageRenderer))]
namespace Cinary.Xamarin.Fragment.Platforms.iOS
{
    public class FlexiPageRenderer : ViewRenderer<FragmentPage, ViewControllerContainer>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<FragmentPage> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.ViewController = null;
            }

            if (e.NewElement != null)
            {
                var viewControllerContainer = new ViewControllerContainer(Bounds);
                SetNativeControl(viewControllerContainer);
            }


        }

        Page _initializedPage;

        void ChangePage(Page page)
        {
            if (page != null)
            {
                page.Parent = Element.Parent;
                var pageRenderer = Platform.CreateRenderer(page);
                UIViewController viewController = null;
                if (pageRenderer != null && pageRenderer.ViewController != null)
                {
                    viewController = pageRenderer.ViewController;
                }
                else
                {
                    viewController = Platform.CreateRenderer(page).ViewController;
                }
                var parentPage = Element.Parent;
                var renderer = Platform.CreateRenderer(parentPage as VisualElement);
                //var renderer = Platform.CreateRenderer(parentPage);
                Control.ParentViewController = renderer.ViewController;
                Control.ViewController = viewController;
                _initializedPage = page;
            }
            else
            {
                if (Control != null)
                {
                    Control.ViewController = null;
                }
            }
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            var page = Element?.Content;
            if (page != null)
            {
                page.Layout(new Rectangle(0, 0, Bounds.Width, Bounds.Height));
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Content" || e.PropertyName == "Renderer")
            {
                Device.BeginInvokeOnMainThread(() => ChangePage(Element?.Content));
            }
        }

    }
}

