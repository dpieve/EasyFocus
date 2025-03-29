﻿using EasyFlow.Domain.Services;
using System.Runtime.InteropServices.JavaScript;
using System.Runtime.Versioning;
using System.Threading.Tasks;

namespace EasyFlow.Features.Pomodoro;

public partial class BrowserTitleApi
{
    [JSImport("setBrowserTitle", "BrowserTitleApi")]
    public static partial void SetBrowserTitle(string title);
}

[SupportedOSPlatform("browser")]
public sealed class BrowserTitleService
{
    private bool _isInitialized = false;

    public async Task Update(int secondsLeft, bool started)
    {
        if (!_isInitialized)
        {
            await JSHost.ImportAsync("BrowserTitleApi", "/TitleJs.js");
            _isInitialized = true;
        }

        if (!started || secondsLeft == 0)
        {
            BrowserTitleApi.SetBrowserTitle("EasyFlow");
            return;
        }

        string title = $"{secondsLeft / 60}:{secondsLeft % 60:D2} | EasyFlow";
        BrowserTitleApi.SetBrowserTitle(title);
    }
}