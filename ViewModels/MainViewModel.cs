using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.UI.Xaml.Media;
using Windows.UI;
using Kil0bitSystemMonitor.Models;
using Microsoft.UI;

namespace Kil0bitSystemMonitor.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string AppVersion
        {
            get
            {
                var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                return $"v{version?.Major}.{version?.Minor}.{version?.Build} (Windows 11 Native Edition)";
            }
        }

        private SystemMetrics _metrics = new();
        public SystemMetrics Metrics
        {
            get => _metrics;
            set 
            { 
                _metrics = value; 
                OnPropertyChanged(); 
                OnPropertyChanged(nameof(CpuText));
                OnPropertyChanged(nameof(RamPercentText));
                OnPropertyChanged(nameof(GpuText));
                OnPropertyChanged(nameof(GpuTempText));
            }
        }

        public string CpuText => $"{Metrics.CpuUsage:F0}%";
        public string RamPercentText => $"{Metrics.RamPercent:F0}%";
        public string GpuText => $"{Metrics.GpuUsage:F0}%";
        public string GpuTempText => Metrics.GpuTemperature >= 0 ? $"{Metrics.GpuTemperature:F0}°C" : "N/A";

        private AppConfig _config = new();
        public AppConfig Config
        {
            get => _config;
            set { _config = value; OnPropertyChanged(); OnPropertyChanged(nameof(TextColor)); }
        }

        public SolidColorBrush TextColor
        {
            get
            {
                try
                {
                    return new SolidColorBrush(HexToColor(Config.AccentColorHex));
                }
                catch
                {
                    return new SolidColorBrush(Microsoft.UI.Colors.White);
                }
            }
        }

        private Color HexToColor(string hex)
        {
            try
            {
                if (!string.IsNullOrEmpty(hex))
                {
                    hex = hex.Replace("#", "");
                    if (hex.Length == 6)
                    {
                        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
                        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
                        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
                        return Color.FromArgb(255, r, g, b);
                    }
                }
            }
            catch { }
            return Microsoft.UI.Colors.White; // Safe fallback for un-parseable colors so text is visible!
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
