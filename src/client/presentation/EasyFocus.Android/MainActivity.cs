﻿using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;
using Avalonia.ReactiveUI;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Serilog;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;

namespace EasyFocus.Android;

[Activity(
    Label = "EasyFocus.Android",
    Theme = "@style/MyTheme.NoActionBar",
    Icon = "@drawable/icon",
    MainLauncher = true,
    ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
        _ = Host.CreateDefaultBuilder()
              .ConfigureServices((_, services) =>
              {
                  services.UseMicrosoftDependencyResolver();

                  Log.Logger = new LoggerConfiguration()
#if DEBUG
                        .MinimumLevel.Verbose()
#else
                        .MinimumLevel.Information()
#endif
                        .Enrich.FromLogContext()
                        .WriteTo.Debug()
                        .CreateLogger();

                  var resolver = Locator.CurrentMutable;
                  resolver.InitializeSplat();
                  resolver.InitializeReactiveUI();

                  services
                      .AddBrowser()
                      .AddPresentation();
              })
              .Build();

        return base.CustomizeAppBuilder(builder)
            .WithInterFont()
            .UseReactiveUI();
    }
}