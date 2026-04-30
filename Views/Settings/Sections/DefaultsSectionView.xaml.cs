using RoutedEventArgs = System.Windows.RoutedEventArgs;
using Window = System.Windows.Window;
using SelectionChangedEventArgs = System.Windows.Controls.SelectionChangedEventArgs;
using UserControl = System.Windows.Controls.UserControl;

namespace Kil0bitSystemMonitor.Views.Settings.Sections;

public partial class DefaultsSectionView : UserControl
{
    public DefaultsSectionView()
    {
        InitializeComponent();
    }

    private void ThresholdProfile_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (Window.GetWindow(this) is SettingsWindow settingsWindow)
        {
            settingsWindow.ForwardThresholdProfileSelectionChanged(sender, e);
        }
    }

    private void ColorButton_Click(object sender, RoutedEventArgs e)
    {
        if (Window.GetWindow(this) is SettingsWindow settingsWindow)
        {
            settingsWindow.ForwardColorButtonClick(sender, e);
        }
    }
}
