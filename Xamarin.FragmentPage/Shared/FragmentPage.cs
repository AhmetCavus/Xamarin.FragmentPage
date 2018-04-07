using Xamarin.Forms;

namespace Cinary.Xamarin.Fragment
{
    public class FragmentPage : View
    {
        public FragmentPage()
        {
        }

        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(ContentProperty), typeof(Page), typeof(FragmentPage));

        public Page Content
        {
            get { return (Page)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
    }
}
