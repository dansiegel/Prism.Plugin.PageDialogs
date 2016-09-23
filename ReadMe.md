# Prism.Plugin.PageDialogs

The Page Dialog plugin for Prims.Forms offers you the ability to quickly and easily add a Page Dialog Service that doesn't rely on the bland dialogs built into Xamarin for each platform. Instead you are able to provide a custom look and feel for each of your projects. 

| Package | Version |
| ------- | ------- |
| [Prism.Plugin.PageDialogs](1) | [![2]][1] |

## Platform Initialion

This plugin itself requires no platform initialization however you will need to initialize [Rg.Plugin.Popup][3]

## Customized Look & Feel

To make this all work and still provide your custom look and feel you can simply inherit from our custom page dialog service and register it.

```cs
public class MyPageDialogService : CustomPageDialogService
{
     protected override ActionSheetPageBase GetActionSheet( string title, string message, string cancelButton, string destroyButton, string[] otherButtons )
    {
        // return your custom ActionSheetPage as long as it inherits from ActionSheetPageBase
    }

    protected override AlertPageBase GetAlertPage( string title, string message, string acceptButton, string cancelButton )
    {
        // return your custom AlertPage as long as it inherits from AlertPageBase
    }
}
```

In your PrismApplication class

```cs
protected override void RegisterTypes()
{
    Container.Register<IPageDialogService,CustomPageDialogService>();
}
```

[1]: https://www.nuget.org/packages/Prism.Plugin.PageDialogs
[2]: https://img.shields.io/nuget/vpre/Prism.Plugin.PageDialogs
[3]: https://github.com/rotorgames/Rg.Plugins.Popup