using Kil0bitSystemMonitor.ViewModels.Settings.Sections;

namespace Kil0bitSystemMonitor.ViewModels.Settings;

public sealed class SettingsWindowViewModel
{
    public MainViewModel Main { get; }
    public GeneralSectionViewModel General { get; }
    public DefaultsSectionViewModel Defaults { get; }
    public CpuSectionViewModel Cpu { get; }

    public SettingsWindowViewModel(MainViewModel mainViewModel)
    {
        Main = mainViewModel;
        General = new GeneralSectionViewModel(mainViewModel);
        Defaults = new DefaultsSectionViewModel(mainViewModel);
        Cpu = new CpuSectionViewModel(mainViewModel);
    }
}
