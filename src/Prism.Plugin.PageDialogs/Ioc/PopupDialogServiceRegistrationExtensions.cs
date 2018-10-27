using Prism.Services;

namespace Prism.Ioc
{
    public static class PopupDialogServiceRegistrationExtensions
    {
        public static void RegisterPopupDialogService(this IContainerRegistry containerRegistry) =>
            containerRegistry.RegisterPopupDialogService<PopupDialogService, PopupDialogFactory>();

        public static void RegisterPopupDialogService<T>(this IContainerRegistry containerRegistry)
            where T : IPopupDialogService =>
            containerRegistry.RegisterPopupDialogService<T, PopupDialogFactory>();

        public static void RegisterPopupDialogServiceWithFactory<T>(this IContainerRegistry containerRegistry)
            where T : IPopupDialogFactory =>
            containerRegistry.RegisterPopupDialogService<PopupDialogService, T>();

        public static void RegisterPopupDialogService<TDialogService, TDialogFactory>(this IContainerRegistry containerRegistry)
            where TDialogService : IPopupDialogService
            where TDialogFactory : IPopupDialogFactory
        {
            containerRegistry.RegisterSingleton<IPopupDialogFactory, TDialogFactory>();
            containerRegistry.RegisterSingleton<IPopupDialogService, TDialogService>();
            containerRegistry.RegisterSingleton<IPopupDialogService, TDialogService>();
        }
    }
}
