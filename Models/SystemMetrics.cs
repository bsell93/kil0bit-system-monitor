using System.Windows.Media;
using System.Linq;

namespace Kil0bitSystemMonitor.Models
{
    public class DiskMetric
    {
        public string Name { get; set; } = "";
        public float SpacePercent { get; set; }
        public float ActivityPercent { get; set; }
        public float ReadKbps { get; set; }
        public float WriteKbps { get; set; }
    }

    public class SystemMetrics
    {
        public float CpuUsage { get; set; }
        public float CpuClockMhz { get; set; }
        public float RamPercent { get; set; }
        public double RamUsedGb { get; set; }
        public double RamFreeGb { get; set; }
        public double RamTotalGb { get; set; }
        public float GpuUsage { get; set; }
        public float GpuTemperature { get; set; }
        public float NetUpKbps { get; set; }
        public float NetDownKbps { get; set; }
        public string NetUpText { get; set; } = "0 KB/s";
        public string NetDownText { get; set; } = "0 KB/s";
        public float DiskUsage { get; set; }
        public float DiskPercent { get; set; }
        public System.Collections.Generic.List<DiskMetric> Disks { get; set; } = new();
    }

    public class AppConfig : System.ComponentModel.INotifyPropertyChanged
    {
        private bool _showOverlay = true;
        private bool _lockPosition = false;
        private bool _launchOnStartup = false;
        private bool _showCpuPercent = true;
        private bool _showCpuClock = true;
        private bool _showRamPercent = true;
        private bool _showRamUsedFreeGb = true;
        private bool _showGpu = true;
        private bool _showTemp = true;
        private bool _showDisk = true;
        private bool _showDiskSpeed = true;
        private bool _showDiskIn = true;
        private bool _showDiskOut = true;
        private bool _showNetUp = true;
        private bool _showNetDown = true;
        private string _networkAdapter = "Default";
        private string _gpuAdapter = "Default";
        private string _selectedDisks = "Default";
        private string _displayStyle = "Text";
        private string _fontFamily = "Segoe UI";
        private string _accentColorHex = "#FFFFFF";
        private string _labelColorHex = "#00CCFF";
        private double _x = 100;
        private double _y = 100;
        private bool _hideOnFullscreen = true;
        private bool _stickToTaskbar = true;
        private bool _showBackground = false;
        private string _backgroundColorHex = "#B4141414";
        private double _scaleFactor = 1.0;
        private bool _isTextBold = true;

        private string _theme = "Default";
        private int _updateInterval = 1000;
        private int _gpuIndex = 0;
        private bool _showPods = true;
        private string _podColorHex = "#0FFFFFFF"; 
        private bool _alwaysOnTop = true;
        private bool _enableInlineGraphs = true;
        private int _graphPointCount = 36;
        private int _graphOpacity = 36;
        private string _graphColorHex = "#00CCFF";
        private string _graphHistoryPreset = "Medium";
        private string _inlineGraphStyle = "Line";
        private string _cpuGraphStyle = "Line";
        private string _cpuClockGraphStyle = "Line";
        private string _ramGraphStyle = "Line";
        private string _ramUsedFreeGraphStyle = "Line";
        private string _gpuGraphStyle = "Line";
        private string _tempGraphStyle = "Line";
        private string _netUpGraphStyle = "Line";
        private string _netDownGraphStyle = "Line";
        private string _diskSpaceGraphStyle = "Line";
        private string _diskActivityGraphStyle = "Line";
        private string _cpuDisplayMode = "TextGraph";
        private string _cpuClockDisplayMode = "TextGraph";
        private string _ramDisplayMode = "TextGraph";
        private string _ramUsedFreeDisplayMode = "TextGraph";
        private string _gpuDisplayMode = "TextGraph";
        private string _tempDisplayMode = "TextGraph";
        private string _netUpDisplayMode = "TextGraph";
        private string _netDownDisplayMode = "TextGraph";
        private string _diskSpaceDisplayMode = "TextGraph";
        private string _diskActivityDisplayMode = "TextGraph";
        private bool _enableThresholdColors = true;
        private int _percentWarnThreshold = 75;
        private int _percentCriticalThreshold = 90;
        private int _tempWarnThreshold = 72;
        private int _tempCriticalThreshold = 84;
        private string _thresholdProfile = "Balanced";
        private bool _cpuThresholdOverrideEnabled = false;
        private int _cpuWarnThreshold = 75;
        private int _cpuCriticalThreshold = 90;
        private bool _tempThresholdOverrideEnabled = false;
        private int _tempWarnThresholdOverride = 72;
        private int _tempCriticalThresholdOverride = 84;
        private string _warningColorHex = "#FFF59D00";
        private string _criticalColorHex = "#FFFF4D4F";
        public bool ShowOverlay { get => _showOverlay; set { _showOverlay = value; OnPropertyChanged(); } }
        public bool LockPosition { get => _lockPosition; set { _lockPosition = value; OnPropertyChanged(); } }
        public bool LaunchOnStartup { get => _launchOnStartup; set { _launchOnStartup = value; OnPropertyChanged(); } }

        public bool ShowCpuPercent { get => _showCpuPercent; set { _showCpuPercent = value; OnPropertyChanged(); OnPropertyChanged(nameof(ShowCpu)); } }
        public bool ShowCpuClock { get => _showCpuClock; set { _showCpuClock = value; OnPropertyChanged(); } }
        public bool ShowRamPercent { get => _showRamPercent; set { _showRamPercent = value; OnPropertyChanged(); OnPropertyChanged(nameof(ShowRam)); } }
        public bool ShowRamUsedFreeGb { get => _showRamUsedFreeGb; set { _showRamUsedFreeGb = value; OnPropertyChanged(); } }
        public bool ShowCpu { get => _showCpuPercent; set { _showCpuPercent = value; OnPropertyChanged(); OnPropertyChanged(nameof(ShowCpuPercent)); } }
        public bool ShowRam { get => _showRamPercent; set { _showRamPercent = value; OnPropertyChanged(); OnPropertyChanged(nameof(ShowRamPercent)); } }
        public bool ShowGpu { get => _showGpu; set { _showGpu = value; OnPropertyChanged(); } }
        public bool ShowTemp { get => _showTemp; set { _showTemp = value; OnPropertyChanged(); } }
        public bool ShowDisk { get => _showDisk; set { _showDisk = value; OnPropertyChanged(); } }
        public bool ShowDiskSpeed { get => _showDiskSpeed; set { _showDiskSpeed = value; OnPropertyChanged(); } }
        public bool ShowDiskIn { get => _showDiskIn; set { _showDiskIn = value; OnPropertyChanged(); } }
        public bool ShowDiskOut { get => _showDiskOut; set { _showDiskOut = value; OnPropertyChanged(); } }
        public bool ShowNetUp { get => _showNetUp; set { _showNetUp = value; OnPropertyChanged(); } }
        public bool ShowNetDown { get => _showNetDown; set { _showNetDown = value; OnPropertyChanged(); } }

        public string NetworkAdapter { get => _networkAdapter; set { _networkAdapter = value; OnPropertyChanged(); } }
        public string GpuAdapter { get => _gpuAdapter; set { _gpuAdapter = value; OnPropertyChanged(); } }
        public string SelectedDisks { get => _selectedDisks; set { _selectedDisks = value; OnPropertyChanged(); } }
        public string DisplayStyle { get => _displayStyle; set { _displayStyle = value; OnPropertyChanged(); } }
        public string FontFamily { get => _fontFamily; set { _fontFamily = value; OnPropertyChanged(); } }

        public string AccentColorHex { get => _accentColorHex; set { _accentColorHex = value; OnPropertyChanged(); OnPropertyChanged(nameof(AccentColor)); } }
        public string LabelColorHex { get => _labelColorHex; set { _labelColorHex = value; OnPropertyChanged(); OnPropertyChanged(nameof(LabelColor)); } }
        public string BackgroundColorHex { get => _backgroundColorHex; set { _backgroundColorHex = value; OnPropertyChanged(); OnPropertyChanged(nameof(BackgroundColor)); } }

        public double ScaleFactor { get => _scaleFactor; set { _scaleFactor = value; OnPropertyChanged(); } }
        public bool IsTextBold { get => _isTextBold; set { _isTextBold = value; OnPropertyChanged(); } }

        public string Theme { get => _theme; set { _theme = value; OnPropertyChanged(); } }
        public int UpdateInterval { get => _updateInterval; set { _updateInterval = value; OnPropertyChanged(); } }
        public int GpuIndex { get => _gpuIndex; set { _gpuIndex = value; OnPropertyChanged(); } }
        public bool ShowPods { get => _showPods; set { _showPods = value; OnPropertyChanged(); } }
        public string PodColorHex { get => _podColorHex; set { _podColorHex = value; OnPropertyChanged(); OnPropertyChanged(nameof(PodColor)); } }
        public bool AlwaysOnTop { get => _alwaysOnTop; set { _alwaysOnTop = value; OnPropertyChanged(); } }
        public bool EnableInlineGraphs { get => _enableInlineGraphs; set { _enableInlineGraphs = value; OnPropertyChanged(); } }
        public int GraphPointCount { get => _graphPointCount; set { _graphPointCount = Math.Clamp(value, 16, 80); OnPropertyChanged(); } }
        public int GraphOpacity { get => _graphOpacity; set { _graphOpacity = Math.Clamp(value, 8, 96); OnPropertyChanged(); } }
        public string GraphColorHex { get => _graphColorHex; set { _graphColorHex = value; OnPropertyChanged(); } }
        public string GraphHistoryPreset { get => _graphHistoryPreset; set { _graphHistoryPreset = value; OnPropertyChanged(); } }
        public string InlineGraphStyle { get => _inlineGraphStyle; set { _inlineGraphStyle = value; OnPropertyChanged(); } }
        public string CpuGraphStyle { get => _cpuGraphStyle; set { _cpuGraphStyle = value; OnPropertyChanged(); } }
        public string CpuClockGraphStyle { get => _cpuClockGraphStyle; set { _cpuClockGraphStyle = value; OnPropertyChanged(); } }
        public string RamGraphStyle { get => _ramGraphStyle; set { _ramGraphStyle = value; OnPropertyChanged(); } }
        public string RamUsedFreeGraphStyle { get => _ramUsedFreeGraphStyle; set { _ramUsedFreeGraphStyle = value; OnPropertyChanged(); } }
        public string GpuGraphStyle { get => _gpuGraphStyle; set { _gpuGraphStyle = value; OnPropertyChanged(); } }
        public string TempGraphStyle { get => _tempGraphStyle; set { _tempGraphStyle = value; OnPropertyChanged(); } }
        public string NetUpGraphStyle { get => _netUpGraphStyle; set { _netUpGraphStyle = value; OnPropertyChanged(); } }
        public string NetDownGraphStyle { get => _netDownGraphStyle; set { _netDownGraphStyle = value; OnPropertyChanged(); } }
        public string DiskSpaceGraphStyle { get => _diskSpaceGraphStyle; set { _diskSpaceGraphStyle = value; OnPropertyChanged(); } }
        public string DiskActivityGraphStyle { get => _diskActivityGraphStyle; set { _diskActivityGraphStyle = value; OnPropertyChanged(); } }
        public string CpuDisplayMode { get => _cpuDisplayMode; set { _cpuDisplayMode = value; OnPropertyChanged(); } }
        public string CpuClockDisplayMode { get => _cpuClockDisplayMode; set { _cpuClockDisplayMode = value; OnPropertyChanged(); } }
        public string RamDisplayMode { get => _ramDisplayMode; set { _ramDisplayMode = value; OnPropertyChanged(); } }
        public string RamUsedFreeDisplayMode { get => _ramUsedFreeDisplayMode; set { _ramUsedFreeDisplayMode = value; OnPropertyChanged(); } }
        public string GpuDisplayMode { get => _gpuDisplayMode; set { _gpuDisplayMode = value; OnPropertyChanged(); } }
        public string TempDisplayMode { get => _tempDisplayMode; set { _tempDisplayMode = value; OnPropertyChanged(); } }
        public string NetUpDisplayMode { get => _netUpDisplayMode; set { _netUpDisplayMode = value; OnPropertyChanged(); } }
        public string NetDownDisplayMode { get => _netDownDisplayMode; set { _netDownDisplayMode = value; OnPropertyChanged(); } }
        public string DiskSpaceDisplayMode { get => _diskSpaceDisplayMode; set { _diskSpaceDisplayMode = value; OnPropertyChanged(); } }
        public string DiskActivityDisplayMode { get => _diskActivityDisplayMode; set { _diskActivityDisplayMode = value; OnPropertyChanged(); } }
        public bool EnableThresholdColors { get => _enableThresholdColors; set { _enableThresholdColors = value; OnPropertyChanged(); } }
        public int PercentWarnThreshold { get => _percentWarnThreshold; set { _percentWarnThreshold = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public int PercentCriticalThreshold { get => _percentCriticalThreshold; set { _percentCriticalThreshold = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public int TempWarnThreshold { get => _tempWarnThreshold; set { _tempWarnThreshold = Math.Clamp(value, 20, 120); OnPropertyChanged(); } }
        public int TempCriticalThreshold { get => _tempCriticalThreshold; set { _tempCriticalThreshold = Math.Clamp(value, 20, 120); OnPropertyChanged(); } }
        public string ThresholdProfile { get => _thresholdProfile; set { _thresholdProfile = value; OnPropertyChanged(); } }
        public bool CpuThresholdOverrideEnabled { get => _cpuThresholdOverrideEnabled; set { _cpuThresholdOverrideEnabled = value; OnPropertyChanged(); } }
        public int CpuWarnThreshold { get => _cpuWarnThreshold; set { _cpuWarnThreshold = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public int CpuCriticalThreshold { get => _cpuCriticalThreshold; set { _cpuCriticalThreshold = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public bool TempThresholdOverrideEnabled { get => _tempThresholdOverrideEnabled; set { _tempThresholdOverrideEnabled = value; OnPropertyChanged(); } }
        public int TempWarnThresholdOverride { get => _tempWarnThresholdOverride; set { _tempWarnThresholdOverride = Math.Clamp(value, 20, 120); OnPropertyChanged(); } }
        public int TempCriticalThresholdOverride { get => _tempCriticalThresholdOverride; set { _tempCriticalThresholdOverride = Math.Clamp(value, 20, 120); OnPropertyChanged(); } }
        public string WarningColorHex { get => _warningColorHex; set { _warningColorHex = value; OnPropertyChanged(); } }
        public string CriticalColorHex { get => _criticalColorHex; set { _criticalColorHex = value; OnPropertyChanged(); } }

        public double X { get => _x; set { _x = value; OnPropertyChanged(); } }
        public double Y { get => _y; set { _y = value; OnPropertyChanged(); } }
        public bool HideOnFullscreen { get => _hideOnFullscreen; set { _hideOnFullscreen = value; OnPropertyChanged(); } }
        public bool StickToTaskbar { get => _stickToTaskbar; set { _stickToTaskbar = value; OnPropertyChanged(); } }
        public bool ShowBackground { get => _showBackground; set { _showBackground = value; OnPropertyChanged(); } }

        [System.Text.Json.Serialization.JsonIgnore]
        public System.Windows.Media.Color AccentColor { get => HexToColor(AccentColorHex); set => AccentColorHex = ColorToHex(value); }

        [System.Text.Json.Serialization.JsonIgnore]
        public System.Windows.Media.Color LabelColor { get => HexToColor(LabelColorHex); set => LabelColorHex = ColorToHex(value); }

        [System.Text.Json.Serialization.JsonIgnore]
        public System.Windows.Media.Color BackgroundColor { get => HexToColor(BackgroundColorHex); set => BackgroundColorHex = ColorToHex(value); }

        [System.Text.Json.Serialization.JsonIgnore]
        public System.Windows.Media.Color PodColor { get => HexToColor(PodColorHex); set => PodColorHex = ColorToHex(value); }

        private System.Windows.Media.Color HexToColor(string hex)
        {
            try
            {
                hex = hex.TrimStart('#');
                if (hex.Length == 8) // ARGB
                {
                    return System.Windows.Media.Color.FromArgb(
                        byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber));
                }
                if (hex.Length == 6) // RGB
                {
                    return System.Windows.Media.Color.FromRgb(
                        byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber),
                        byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber));
                }
            }
            catch { }
            return Colors.White;
        }

        private string ColorToHex(System.Windows.Media.Color c) => $"#{c.A:X2}{c.R:X2}{c.G:X2}{c.B:X2}";

        public event System.ComponentModel.PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(name));
        }
    }
}
