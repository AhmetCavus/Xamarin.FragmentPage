using Prism.Navigation;

namespace Xamarin.FragmentPage.Test.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "FragmentPage";
        }
    }
}
