namespace Kil0bitSystemMonitor.ViewModels.Settings.Sections;

public sealed class GeneralSectionViewModel
{
    public MainViewModel Main { get; }

    public GeneralSectionViewModel(MainViewModel mainViewModel)
    {
        Main = mainViewModel;
    }
}
