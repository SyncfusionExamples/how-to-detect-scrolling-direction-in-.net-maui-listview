# how-to-detect-scrolling-direction-in-.net-maui-listview

This example demonstrates about how to find the scrolling direction in .NET MAUI ListView.

## Sample

```xaml
<syncfusion:SfListView x:Name="listView"
                                   ItemSize="60"
                                   IsStickyHeader="True"
                                   ItemsSource="{Binding ContactsInfo}">
                <syncfusion:SfListView.Behaviors>
                    <local:ListViewBehavior />
                </syncfusion:SfListView.Behaviors>

                <syncfusion:SfListView.HeaderTemplate>
                    <DataTemplate>
                        <Label Text="{Binding ScrollDirection}"
                               FontSize="Default"
                               FontAttributes="Italic"
                               HorizontalTextAlignment="Center"
                               HorizontalOptions="CenterAndExpand"
                               VerticalOptions="CenterAndExpand" />
                    </DataTemplate>
                </syncfusion:SfListView.HeaderTemplate>
                <syncfusion:SfListView.ItemTemplate>
                    <DataTemplate>
                        <Grid x:Name="grid">
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="70" />
                                <ColumnDefinition Width="*" />
                            </Grid.ColumnDefinitions>
                            <Image Source="{Binding ContactImage}"
                                   VerticalOptions="Center"
                                   HorizontalOptions="Center"
                                   HeightRequest="50"
                                   WidthRequest="50" />
                            <Grid Grid.Column="1"
                                  RowSpacing="1"
                                  Grid.Row="0"
                                  Padding="10,0,0,0"
                                  RowDefinitions="*,*"
                                  VerticalOptions="Center">
                                <Label LineBreakMode="NoWrap"
                                       TextColor="#474747"
                                       Grid.Row="0"
                                       Text="{Binding ContactName}" />
                                <Label Grid.Row="1"
                                       Grid.Column="0"
                                       TextColor="#474747"
                                       LineBreakMode="NoWrap"
                                       Text="{Binding ContactNumber}" />
                            </Grid>
                        </Grid>
                    </DataTemplate>
                </syncfusion:SfListView.ItemTemplate>
            </syncfusion:SfListView>
```

```C#

ListViewScrollView scrollview;

protected override void OnAttachedTo(SfListView bindable)
{
    base.OnAttachedTo(bindable);
    listview = bindable as SfListView;
    viewModel = new ContactsViewModel();
    listview.BindingContext = viewModel;
    scrollview = listview.GetScrollView();
    scrollview.Scrolled += Scrollview_Scrolled;
}

private void Scrollview_Scrolled(object sender, ScrolledEventArgs e)
{
    if (e.ScrollY == 0)
        return;

    if (previousOffset >= e.ScrollY)
    {
        // Up direction  
        viewModel.ScrollDirection = "Up Direction";
    }
    else
    {
        //Down direction 
        viewModel.ScrollDirection = "Down Direction";
    }

    previousOffset = e.ScrollY;
}
```

## Requirements to run the demo

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) or [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer).

## Troubleshooting

### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.
