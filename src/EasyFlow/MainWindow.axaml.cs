using Avalonia.Controls;
using Avalonia.Interactivity;
using SukiUI.Controls;
using SukiUI.Models;

namespace EasyFlow;

public partial class MainWindow : SukiWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MenuItem_OnClick(object? sender, RoutedEventArgs e)
    {
        if (DataContext is not MainViewModel vm)
        {
            return;
        }

        if (e.Source is not MenuItem menuItem)
        {     
            return;
        }

        if (menuItem.DataContext is not SukiColorTheme colorTheme)
        {
            return;
        }

        vm.ChangeTheme(colorTheme);
    }
}