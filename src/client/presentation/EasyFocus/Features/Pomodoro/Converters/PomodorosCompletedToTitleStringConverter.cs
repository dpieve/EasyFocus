using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace EasyFocus.Features.Pomodoro.Converters;

public sealed class PomodorosCompletedToTitleStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not int sessionCompleted
            || sessionCompleted < 0)
        {
            return "invalid";
        }

        if (sessionCompleted <= 1)
        {
            return $"{sessionCompleted} pomodoro";
        }

        return $"{sessionCompleted} pomodoros";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}