namespace Kil0bitSystemMonitor.ViewModels.Settings.Sections;

public sealed class CpuSectionViewModel
{
    public MainViewModel Main { get; }

    public CpuSectionViewModel(MainViewModel mainViewModel)
    {
        Main = mainViewModel;
    }
}
