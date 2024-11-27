using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using IkemenToolbox.Helpers;
using IkemenToolbox.Views;

namespace IkemenToolbox
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.Exit += Desktop_Exit;
                Cache.Initialize();

                // Line below is needed to remove Avalonia data validation.
                // Without this line you will get duplicate validations from both Avalonia and CT
                BindingPlugins.DataValidators.RemoveAt(0);
                desktop.MainWindow = new HomeWindow();
            }

            base.OnFrameworkInitializationCompleted();
        }

        private void Desktop_Exit(object sender, ControlledApplicationLifetimeExitEventArgs e)
        {
            Cache.Save();
        }
    }
}