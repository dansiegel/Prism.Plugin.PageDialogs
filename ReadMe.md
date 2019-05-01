# Prism.Plugin.PageDialogs

The Page Dialog plugin for [Prims.Forms](4) offers you the ability to quickly and easily add a Page Dialog Service that doesn't rely on the bland dialogs built into Xamarin for each platform. Instead you are able to provide a custom look and feel for each of your projects. 

[![Build Status](https://dev.azure.com/dansiegel/Prism.Plugins/_apis/build/status/Prism.Plugins.PageDialogs-CI)](https://dev.azure.com/dansiegel/Prism.Plugins/_build/latest?definitionId=30)

| Package | Version |
| ------- | ------- |
| [Prism.Plugin.PageDialogs](1) | [![2]][1] |

## Platform Initialization

This plugin itself requires no platform initialization however you will need to initialize [Rg.Plugin.Popup][3]

In your Prism Application's `RegisterTypes` you need to do the following:

```cs
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterPopupDialogService();

    // If you're using Prism.Plugin.Popups you don't need to do anything else
    // otherwise you can simply add the following:
    containerRegistry.RegisterInstance<IPopupNavigation>(PopupNavigation.Instance);
}
```

## Customized Look & Feel

The built in ActionSheetPage and AlertPage have static properties which you can set at App startup to control the look of the built in pages.

```cs
protected override void OnInitialized()
{
    AlertPage.DefaultTitleBarBackgroundColor = (Color)Resources["PrimaryColor"];
    AlertPage.DefaultTitleStyle = (Style)Resources["AlertTitleStyle"];
    AlertPage.DefaultMessageStyle = (Style)Resources["AlertMessageStyle"];
}
```

### Adding a custom Factory

In the event that simply providing custom default styles isn't enough, you can implement a custom IPopupDialogFactory. To control which style Dialog you simply need to set the Style property in either the ActionSheetRequest or AlertDialogRequest. The default `PopupDialogFactory` ignores the style key. The intent is that you are able to create an Alert or Action Sheet Dialog based on a Style key using.

```cs
public class MyFactory : IPopupDialogFactory
{
    public ActionSheetPageBase GetActionSheet(ActionSheetRequest request)
    {
        switch(request.Style)
        {
            case "Foo":
                return new FooActionSheetPage(request);
            case "Bar":
                return new BarActionSheetPage(request);
            default:
                new ActionSheetPage(request);
        }
    }

    public AlertPageBase GetAlertPage(AlertDialogRequest request)
    {
        switch(request.Style)
        {
            case "Foo":
                return new FooAlertPage(request);
            case "Bar":
                return new BarAlertPage(request);
            default:
                return AlertPage(request);
        }
    }
}
```

When using a custom Factory you can easily register both your factory and the PopupDialogService

```cs
protected override void RegisterTypes(IContainerRegistry containerRegistry)
{
    containerRegistry.RegisterPopupDialogServiceWithFactory<MyFactory>();
}
```

[1]: https://www.nuget.org/packages/Prism.Plugin.PageDialogs
[2]: https://img.shields.io/nuget/vpre/Prism.Plugin.PageDialogs.svg
[3]: https://github.com/rotorgames/Rg.Plugins.Popup
[4]: https://github.com/PrismLibrary/Prism
