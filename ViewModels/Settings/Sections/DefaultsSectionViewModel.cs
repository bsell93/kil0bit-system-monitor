namespace Kil0bitSystemMonitor.ViewModels.Settings.Sections;

public sealed class DefaultsSectionViewModel
{
    public MainViewModel Main { get; }

    public DefaultsSectionViewModel(MainViewModel mainViewModel)
    {
        Main = mainViewModel;
    }
}
