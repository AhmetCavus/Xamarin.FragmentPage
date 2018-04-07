# Xamarin.FragmentPage

This extension for Xamarin.forms allows the placement of any number of pages in a layout. 
The pages are wrapped in views and can have a predefined size in the layout. This approach works with iOS, Android and Windows UWP.

## Getting Started

### Usage
    
As you can see in the following example, you can set different pages in a layout in a predefined size. In the example 3 pages were placed in the layout. 
For more details, the test project can be viewed. 

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:fragment="clr-namespace:Cinary.Xamarin.Fragment;assembly=Cinary.Xamarin.Fragment.FragmentPage"
             x:Class="Xamarin.FragmentPage.Test.Views.MainPage">

    <ScrollView>
        <StackLayout HorizontalOptions="FillAndExpand" VerticalOptions="CenterAndExpand">
            <fragment:FragmentPage
                HeightRequest="251"
                HorizontalOptions="FillAndExpand">
                <fragment:FragmentPage.Content>
                    <ContentPage
                        BackgroundColor="Firebrick">
                        <Label Text="Fragment Page 1" HorizontalOptions="Center" VerticalOptions="Center" />
                    </ContentPage>
                </fragment:FragmentPage.Content>
            </fragment:FragmentPage>

            <fragment:FragmentPage
                HeightRequest="251"
                HorizontalOptions="FillAndExpand">
                <fragment:FragmentPage.Content>
                    <ContentPage
                        BackgroundColor="GreenYellow">
                        <Label Text="Fragment Page 2" HorizontalOptions="Center" VerticalOptions="Center" />
                    </ContentPage>
                </fragment:FragmentPage.Content>
            </fragment:FragmentPage>

            <fragment:FragmentPage
                HeightRequest="251"
                HorizontalOptions="FillAndExpand">
                <fragment:FragmentPage.Content>
                    <ContentPage
                        BackgroundColor="Green">
                        <Label Text="Fragment Page 3" HorizontalOptions="Center" VerticalOptions="Center" />
                    </ContentPage>
                </fragment:FragmentPage.Content>
            </fragment:FragmentPage>
        </StackLayout>
    </ScrollView>
</ContentPage>
```

### Info

Be free and make suggestions or improvements.

### License
Copyright (c) 2018 Ahmet Cavus  
Licensed under the MIT license.
