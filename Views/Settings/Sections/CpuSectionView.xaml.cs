using RoutedEventArgs = System.Windows.RoutedEventArgs;
using Window = System.Windows.Window;
using UserControl = System.Windows.Controls.UserControl;

namespace Kil0bitSystemMonitor.Views.Settings.Sections;

public partial class CpuSectionView : UserControl
{
    public CpuSectionView()
    {
        InitializeComponent();
    }

    private void ColorButton_Click(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is SettingsWindow settingsWindow)
        {
            settingsWindow.ForwardColorButtonClick(sender, e);
        }
    }
}
