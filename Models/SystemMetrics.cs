using System;
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
        private string _globalDisplayMode = "TextGraph";
        private string _globalGraphStyle = "Line";
        private bool _cpuUseGlobalStyle = true;
        private bool _ramUseGlobalStyle = true;
        private bool _gpuUseGlobalStyle = true;
        private bool _networkUseGlobalStyle = true;
        private bool _diskUseGlobalStyle = true;
        private string? _cpuAccentColorHexOverride;
        private string? _cpuLabelColorHexOverride;
        private string? _cpuGraphColorHexOverride;
        private string? _ramAccentColorHexOverride;
        private string? _ramLabelColorHexOverride;
        private string? _ramGraphColorHexOverride;
        private string? _gpuAccentColorHexOverride;
        private string? _gpuLabelColorHexOverride;
        private string? _gpuGraphColorHexOverride;
        private string? _networkAccentColorHexOverride;
        private string? _networkLabelColorHexOverride;
        private string? _networkGraphColorHexOverride;
        private string? _diskAccentColorHexOverride;
        private string? _diskLabelColorHexOverride;
        private string? _diskGraphColorHexOverride;
        private string? _cpuGraphStyleOverride;
        private string? _cpuClockGraphStyleOverride;
        private string? _ramGraphStyleOverride;
        private string? _ramUsedFreeGraphStyleOverride;
        private string? _gpuGraphStyleOverride;
        private string? _tempGraphStyleOverride;
        private string? _netUpGraphStyleOverride;
        private string? _netDownGraphStyleOverride;
        private string? _diskSpaceGraphStyleOverride;
        private string? _diskActivityGraphStyleOverride;
        private string? _cpuDisplayModeOverride;
        private string? _cpuClockDisplayModeOverride;
        private string? _ramDisplayModeOverride;
        private string? _ramUsedFreeDisplayModeOverride;
        private string? _gpuDisplayModeOverride;
        private string? _tempDisplayModeOverride;
        private string? _netUpDisplayModeOverride;
        private string? _netDownDisplayModeOverride;
        private string? _diskSpaceDisplayModeOverride;
        private string? _diskActivityDisplayModeOverride;
        private bool _enableThresholdColors = true;
        private int _percentWarnThreshold = 75;
        private int _percentCriticalThreshold = 90;
        private int _tempWarnThreshold = 72;
        private int _tempCriticalThreshold = 84;
        private string _thresholdProfile = "Balanced";
        private bool _cpuThresholdOverrideEnabled = false;
        private int? _cpuWarnThresholdOverride;
        private int? _cpuCriticalThresholdOverride;
        private bool _ramThresholdOverrideEnabled = false;
        private int? _ramWarnThresholdOverride;
        private int? _ramCriticalThresholdOverride;
        private bool _gpuThresholdOverrideEnabled = false;
        private int? _gpuWarnThresholdOverride;
        private int? _gpuCriticalThresholdOverride;
        private bool _networkThresholdOverrideEnabled = false;
        private int? _networkWarnThresholdOverride;
        private int? _networkCriticalThresholdOverride;
        private bool _diskThresholdOverrideEnabled = false;
        private int? _diskWarnThresholdOverride;
        private int? _diskCriticalThresholdOverride;
        private double _cpuGroupPadLeft;
        private double _cpuGroupPadBetween;
        private double _cpuGroupPadRight;
        private double _ramGroupPadLeft;
        private double _ramGroupPadBetween;
        private double _ramGroupPadRight;
        private double _gpuGroupPadLeft;
        private double _gpuGroupPadBetween;
        private double _gpuGroupPadRight;
        private double _networkGroupPadLeft;
        private double _networkGroupPadBetween;
        private double _networkGroupPadRight;
        private double _diskGroupPadLeft;
        private double _diskGroupPadBetween;
        private double _diskGroupPadRight;
        private bool _tempThresholdOverrideEnabled = false;
        private int? _tempWarnThresholdOverride;
        private int? _tempCriticalThresholdOverride;
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

        public string AccentColorHex { get => _accentColorHex; set { _accentColorHex = value; OnPropertyChanged(); OnPropertyChanged(nameof(AccentColor)); NotifyInheritedColorChanges(); } }
        public string LabelColorHex { get => _labelColorHex; set { _labelColorHex = value; OnPropertyChanged(); OnPropertyChanged(nameof(LabelColor)); NotifyInheritedColorChanges(); } }
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
        public string GraphColorHex { get => _graphColorHex; set { _graphColorHex = value; OnPropertyChanged(); NotifyInheritedColorChanges(); } }
        public string GraphHistoryPreset { get => _graphHistoryPreset; set { _graphHistoryPreset = value; OnPropertyChanged(); } }
        public string InlineGraphStyle { get => _inlineGraphStyle; set { _inlineGraphStyle = value; OnPropertyChanged(); } }
        public string GlobalDisplayMode { get => _globalDisplayMode; set { _globalDisplayMode = value; OnPropertyChanged(); NotifyInheritedDisplayModeChanges(); } }
        public string GlobalGraphStyle { get => _globalGraphStyle; set { _globalGraphStyle = value; OnPropertyChanged(); NotifyInheritedGraphStyleChanges(); } }
        public bool CpuUseGlobalStyle { get => _cpuUseGlobalStyle; set { _cpuUseGlobalStyle = value; OnPropertyChanged(); } }
        public bool RamUseGlobalStyle { get => _ramUseGlobalStyle; set { _ramUseGlobalStyle = value; OnPropertyChanged(); } }
        public bool GpuUseGlobalStyle { get => _gpuUseGlobalStyle; set { _gpuUseGlobalStyle = value; OnPropertyChanged(); } }
        public bool NetworkUseGlobalStyle { get => _networkUseGlobalStyle; set { _networkUseGlobalStyle = value; OnPropertyChanged(); } }
        public bool DiskUseGlobalStyle { get => _diskUseGlobalStyle; set { _diskUseGlobalStyle = value; OnPropertyChanged(); } }
        public string CpuAccentColorHex { get => _cpuAccentColorHexOverride ?? AccentColorHex; set { _cpuAccentColorHexOverride = value; OnPropertyChanged(); } }
        public string RamAccentColorHex { get => _ramAccentColorHexOverride ?? AccentColorHex; set { _ramAccentColorHexOverride = value; OnPropertyChanged(); } }
        public string GpuAccentColorHex { get => _gpuAccentColorHexOverride ?? AccentColorHex; set { _gpuAccentColorHexOverride = value; OnPropertyChanged(); } }
        public string NetworkAccentColorHex { get => _networkAccentColorHexOverride ?? AccentColorHex; set { _networkAccentColorHexOverride = value; OnPropertyChanged(); } }
        public string DiskAccentColorHex { get => _diskAccentColorHexOverride ?? AccentColorHex; set { _diskAccentColorHexOverride = value; OnPropertyChanged(); } }
        public string CpuLabelColorHex { get => _cpuLabelColorHexOverride ?? LabelColorHex; set { _cpuLabelColorHexOverride = value; OnPropertyChanged(); } }
        public string RamLabelColorHex { get => _ramLabelColorHexOverride ?? LabelColorHex; set { _ramLabelColorHexOverride = value; OnPropertyChanged(); } }
        public string GpuLabelColorHex { get => _gpuLabelColorHexOverride ?? LabelColorHex; set { _gpuLabelColorHexOverride = value; OnPropertyChanged(); } }
        public string NetworkLabelColorHex { get => _networkLabelColorHexOverride ?? LabelColorHex; set { _networkLabelColorHexOverride = value; OnPropertyChanged(); } }
        public string DiskLabelColorHex { get => _diskLabelColorHexOverride ?? LabelColorHex; set { _diskLabelColorHexOverride = value; OnPropertyChanged(); } }
        public string CpuGraphColorHex { get => _cpuGraphColorHexOverride ?? GraphColorHex; set { _cpuGraphColorHexOverride = value; OnPropertyChanged(); } }
        public string RamGraphColorHex { get => _ramGraphColorHexOverride ?? GraphColorHex; set { _ramGraphColorHexOverride = value; OnPropertyChanged(); } }
        public string GpuGraphColorHex { get => _gpuGraphColorHexOverride ?? GraphColorHex; set { _gpuGraphColorHexOverride = value; OnPropertyChanged(); } }
        public string NetworkGraphColorHex { get => _networkGraphColorHexOverride ?? GraphColorHex; set { _networkGraphColorHexOverride = value; OnPropertyChanged(); } }
        public string DiskGraphColorHex { get => _diskGraphColorHexOverride ?? GraphColorHex; set { _diskGraphColorHexOverride = value; OnPropertyChanged(); } }
        public string CpuGraphStyle { get => _cpuGraphStyleOverride ?? GlobalGraphStyle; set { _cpuGraphStyleOverride = value; OnPropertyChanged(); } }
        public string CpuClockGraphStyle { get => _cpuClockGraphStyleOverride ?? GlobalGraphStyle; set { _cpuClockGraphStyleOverride = value; OnPropertyChanged(); } }
        public string RamGraphStyle { get => _ramGraphStyleOverride ?? GlobalGraphStyle; set { _ramGraphStyleOverride = value; OnPropertyChanged(); } }
        public string RamUsedFreeGraphStyle { get => _ramUsedFreeGraphStyleOverride ?? GlobalGraphStyle; set { _ramUsedFreeGraphStyleOverride = value; OnPropertyChanged(); } }
        public string GpuGraphStyle { get => _gpuGraphStyleOverride ?? GlobalGraphStyle; set { _gpuGraphStyleOverride = value; OnPropertyChanged(); } }
        public string TempGraphStyle { get => _tempGraphStyleOverride ?? GlobalGraphStyle; set { _tempGraphStyleOverride = value; OnPropertyChanged(); } }
        public string NetUpGraphStyle { get => _netUpGraphStyleOverride ?? GlobalGraphStyle; set { _netUpGraphStyleOverride = value; OnPropertyChanged(); } }
        public string NetDownGraphStyle { get => _netDownGraphStyleOverride ?? GlobalGraphStyle; set { _netDownGraphStyleOverride = value; OnPropertyChanged(); } }
        public string DiskSpaceGraphStyle { get => _diskSpaceGraphStyleOverride ?? GlobalGraphStyle; set { _diskSpaceGraphStyleOverride = value; OnPropertyChanged(); } }
        public string DiskActivityGraphStyle { get => _diskActivityGraphStyleOverride ?? GlobalGraphStyle; set { _diskActivityGraphStyleOverride = value; OnPropertyChanged(); } }
        public string CpuDisplayMode { get => _cpuDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _cpuDisplayModeOverride = value; OnPropertyChanged(); } }
        public string CpuClockDisplayMode { get => _cpuClockDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _cpuClockDisplayModeOverride = value; OnPropertyChanged(); } }
        public string RamDisplayMode { get => _ramDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _ramDisplayModeOverride = value; OnPropertyChanged(); } }
        public string RamUsedFreeDisplayMode { get => _ramUsedFreeDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _ramUsedFreeDisplayModeOverride = value; OnPropertyChanged(); } }
        public string GpuDisplayMode { get => _gpuDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _gpuDisplayModeOverride = value; OnPropertyChanged(); } }
        public string TempDisplayMode { get => _tempDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _tempDisplayModeOverride = value; OnPropertyChanged(); } }
        public string NetUpDisplayMode { get => _netUpDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _netUpDisplayModeOverride = value; OnPropertyChanged(); } }
        public string NetDownDisplayMode { get => _netDownDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _netDownDisplayModeOverride = value; OnPropertyChanged(); } }
        public string DiskSpaceDisplayMode { get => _diskSpaceDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _diskSpaceDisplayModeOverride = value; OnPropertyChanged(); } }
        public string DiskActivityDisplayMode { get => _diskActivityDisplayModeOverride ?? ResolveGlobalDisplayMode(); set { _diskActivityDisplayModeOverride = value; OnPropertyChanged(); } }
        public bool EnableThresholdColors { get => _enableThresholdColors; set { _enableThresholdColors = value; OnPropertyChanged(); } }
        public int PercentWarnThreshold { get => _percentWarnThreshold; set { _percentWarnThreshold = Math.Clamp(value, 1, 99); OnPropertyChanged(); NotifyInheritedPercentThresholdChanges(); } }
        public int PercentCriticalThreshold { get => _percentCriticalThreshold; set { _percentCriticalThreshold = Math.Clamp(value, 1, 99); OnPropertyChanged(); NotifyInheritedPercentThresholdChanges(); } }
        public int TempWarnThreshold { get => _tempWarnThreshold; set { _tempWarnThreshold = Math.Clamp(value, 20, 120); OnPropertyChanged(); if (!_tempWarnThresholdOverride.HasValue) OnPropertyChanged(nameof(TempWarnThresholdOverride)); } }
        public int TempCriticalThreshold { get => _tempCriticalThreshold; set { _tempCriticalThreshold = Math.Clamp(value, 20, 120); OnPropertyChanged(); if (!_tempCriticalThresholdOverride.HasValue) OnPropertyChanged(nameof(TempCriticalThresholdOverride)); } }
        public string ThresholdProfile { get => _thresholdProfile; set { _thresholdProfile = value; OnPropertyChanged(); } }
        public bool CpuThresholdOverrideEnabled { get => _cpuThresholdOverrideEnabled; set { _cpuThresholdOverrideEnabled = value; OnPropertyChanged(); } }
        public int CpuWarnThreshold { get => _cpuWarnThresholdOverride ?? PercentWarnThreshold; set { _cpuWarnThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public int CpuCriticalThreshold { get => _cpuCriticalThresholdOverride ?? PercentCriticalThreshold; set { _cpuCriticalThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public bool RamThresholdOverrideEnabled { get => _ramThresholdOverrideEnabled; set { _ramThresholdOverrideEnabled = value; OnPropertyChanged(); } }
        public int RamWarnThreshold { get => _ramWarnThresholdOverride ?? PercentWarnThreshold; set { _ramWarnThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public int RamCriticalThreshold { get => _ramCriticalThresholdOverride ?? PercentCriticalThreshold; set { _ramCriticalThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public bool GpuThresholdOverrideEnabled { get => _gpuThresholdOverrideEnabled; set { _gpuThresholdOverrideEnabled = value; OnPropertyChanged(); } }
        public int GpuWarnThreshold { get => _gpuWarnThresholdOverride ?? PercentWarnThreshold; set { _gpuWarnThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public int GpuCriticalThreshold { get => _gpuCriticalThresholdOverride ?? PercentCriticalThreshold; set { _gpuCriticalThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public bool NetworkThresholdOverrideEnabled { get => _networkThresholdOverrideEnabled; set { _networkThresholdOverrideEnabled = value; OnPropertyChanged(); } }
        public int NetworkWarnThreshold { get => _networkWarnThresholdOverride ?? PercentWarnThreshold; set { _networkWarnThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public int NetworkCriticalThreshold { get => _networkCriticalThresholdOverride ?? PercentCriticalThreshold; set { _networkCriticalThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public bool DiskThresholdOverrideEnabled { get => _diskThresholdOverrideEnabled; set { _diskThresholdOverrideEnabled = value; OnPropertyChanged(); } }
        public int DiskWarnThreshold { get => _diskWarnThresholdOverride ?? PercentWarnThreshold; set { _diskWarnThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }
        public int DiskCriticalThreshold { get => _diskCriticalThresholdOverride ?? PercentCriticalThreshold; set { _diskCriticalThresholdOverride = Math.Clamp(value, 1, 99); OnPropertyChanged(); } }

        public double CpuGroupPadLeft { get => _cpuGroupPadLeft; set { _cpuGroupPadLeft = ClampPad(value); OnPropertyChanged(); } }
        public double CpuGroupPadBetween { get => _cpuGroupPadBetween; set { _cpuGroupPadBetween = ClampPad(value); OnPropertyChanged(); } }
        public double CpuGroupPadRight { get => _cpuGroupPadRight; set { _cpuGroupPadRight = ClampPad(value); OnPropertyChanged(); } }
        public double RamGroupPadLeft { get => _ramGroupPadLeft; set { _ramGroupPadLeft = ClampPad(value); OnPropertyChanged(); } }
        public double RamGroupPadBetween { get => _ramGroupPadBetween; set { _ramGroupPadBetween = ClampPad(value); OnPropertyChanged(); } }
        public double RamGroupPadRight { get => _ramGroupPadRight; set { _ramGroupPadRight = ClampPad(value); OnPropertyChanged(); } }
        public double GpuGroupPadLeft { get => _gpuGroupPadLeft; set { _gpuGroupPadLeft = ClampPad(value); OnPropertyChanged(); } }
        public double GpuGroupPadBetween { get => _gpuGroupPadBetween; set { _gpuGroupPadBetween = ClampPad(value); OnPropertyChanged(); } }
        public double GpuGroupPadRight { get => _gpuGroupPadRight; set { _gpuGroupPadRight = ClampPad(value); OnPropertyChanged(); } }
        public double NetworkGroupPadLeft { get => _networkGroupPadLeft; set { _networkGroupPadLeft = ClampPad(value); OnPropertyChanged(); } }
        public double NetworkGroupPadBetween { get => _networkGroupPadBetween; set { _networkGroupPadBetween = ClampPad(value); OnPropertyChanged(); } }
        public double NetworkGroupPadRight { get => _networkGroupPadRight; set { _networkGroupPadRight = ClampPad(value); OnPropertyChanged(); } }
        public double DiskGroupPadLeft { get => _diskGroupPadLeft; set { _diskGroupPadLeft = ClampPad(value); OnPropertyChanged(); } }
        public double DiskGroupPadBetween { get => _diskGroupPadBetween; set { _diskGroupPadBetween = ClampPad(value); OnPropertyChanged(); } }
        public double DiskGroupPadRight { get => _diskGroupPadRight; set { _diskGroupPadRight = ClampPad(value); OnPropertyChanged(); } }

        private static double ClampPad(double value) =>
            double.IsFinite(value) ? Math.Clamp(value, 0d, 400d) : 0d;

        public bool TempThresholdOverrideEnabled { get => _tempThresholdOverrideEnabled; set { _tempThresholdOverrideEnabled = value; OnPropertyChanged(); } }
        public int TempWarnThresholdOverride { get => _tempWarnThresholdOverride ?? TempWarnThreshold; set { _tempWarnThresholdOverride = Math.Clamp(value, 20, 120); OnPropertyChanged(); } }
        public int TempCriticalThresholdOverride { get => _tempCriticalThresholdOverride ?? TempCriticalThreshold; set { _tempCriticalThresholdOverride = Math.Clamp(value, 20, 120); OnPropertyChanged(); } }
        public string WarningColorHex { get => _warningColorHex; set { _warningColorHex = value; OnPropertyChanged(); } }
        public string CriticalColorHex { get => _criticalColorHex; set { _criticalColorHex = value; OnPropertyChanged(); } }

        public string? CpuDisplayModeOverride { get => _cpuDisplayModeOverride; set { _cpuDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(CpuDisplayMode)); } }
        public string? CpuClockDisplayModeOverride { get => _cpuClockDisplayModeOverride; set { _cpuClockDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(CpuClockDisplayMode)); } }
        public string? RamDisplayModeOverride { get => _ramDisplayModeOverride; set { _ramDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(RamDisplayMode)); } }
        public string? RamUsedFreeDisplayModeOverride { get => _ramUsedFreeDisplayModeOverride; set { _ramUsedFreeDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(RamUsedFreeDisplayMode)); } }
        public string? GpuDisplayModeOverride { get => _gpuDisplayModeOverride; set { _gpuDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(GpuDisplayMode)); } }
        public string? TempDisplayModeOverride { get => _tempDisplayModeOverride; set { _tempDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(TempDisplayMode)); } }
        public string? NetUpDisplayModeOverride { get => _netUpDisplayModeOverride; set { _netUpDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(NetUpDisplayMode)); } }
        public string? NetDownDisplayModeOverride { get => _netDownDisplayModeOverride; set { _netDownDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(NetDownDisplayMode)); } }
        public string? DiskSpaceDisplayModeOverride { get => _diskSpaceDisplayModeOverride; set { _diskSpaceDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(DiskSpaceDisplayMode)); } }
        public string? DiskActivityDisplayModeOverride { get => _diskActivityDisplayModeOverride; set { _diskActivityDisplayModeOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(DiskActivityDisplayMode)); } }

        public string? CpuGraphStyleOverride { get => _cpuGraphStyleOverride; set { _cpuGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(CpuGraphStyle)); } }
        public string? CpuClockGraphStyleOverride { get => _cpuClockGraphStyleOverride; set { _cpuClockGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(CpuClockGraphStyle)); } }
        public string? RamGraphStyleOverride { get => _ramGraphStyleOverride; set { _ramGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(RamGraphStyle)); } }
        public string? RamUsedFreeGraphStyleOverride { get => _ramUsedFreeGraphStyleOverride; set { _ramUsedFreeGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(RamUsedFreeGraphStyle)); } }
        public string? GpuGraphStyleOverride { get => _gpuGraphStyleOverride; set { _gpuGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(GpuGraphStyle)); } }
        public string? TempGraphStyleOverride { get => _tempGraphStyleOverride; set { _tempGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(TempGraphStyle)); } }
        public string? NetUpGraphStyleOverride { get => _netUpGraphStyleOverride; set { _netUpGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(NetUpGraphStyle)); } }
        public string? NetDownGraphStyleOverride { get => _netDownGraphStyleOverride; set { _netDownGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(NetDownGraphStyle)); } }
        public string? DiskSpaceGraphStyleOverride { get => _diskSpaceGraphStyleOverride; set { _diskSpaceGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(DiskSpaceGraphStyle)); } }
        public string? DiskActivityGraphStyleOverride { get => _diskActivityGraphStyleOverride; set { _diskActivityGraphStyleOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(DiskActivityGraphStyle)); } }

        public string? CpuAccentColorHexOverride { get => _cpuAccentColorHexOverride; set { _cpuAccentColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(CpuAccentColorHex)); } }
        public string? CpuLabelColorHexOverride { get => _cpuLabelColorHexOverride; set { _cpuLabelColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(CpuLabelColorHex)); } }
        public string? CpuGraphColorHexOverride { get => _cpuGraphColorHexOverride; set { _cpuGraphColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(CpuGraphColorHex)); } }
        public string? RamAccentColorHexOverride { get => _ramAccentColorHexOverride; set { _ramAccentColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(RamAccentColorHex)); } }
        public string? RamLabelColorHexOverride { get => _ramLabelColorHexOverride; set { _ramLabelColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(RamLabelColorHex)); } }
        public string? RamGraphColorHexOverride { get => _ramGraphColorHexOverride; set { _ramGraphColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(RamGraphColorHex)); } }
        public string? GpuAccentColorHexOverride { get => _gpuAccentColorHexOverride; set { _gpuAccentColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(GpuAccentColorHex)); } }
        public string? GpuLabelColorHexOverride { get => _gpuLabelColorHexOverride; set { _gpuLabelColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(GpuLabelColorHex)); } }
        public string? GpuGraphColorHexOverride { get => _gpuGraphColorHexOverride; set { _gpuGraphColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(GpuGraphColorHex)); } }
        public string? NetworkAccentColorHexOverride { get => _networkAccentColorHexOverride; set { _networkAccentColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(NetworkAccentColorHex)); } }
        public string? NetworkLabelColorHexOverride { get => _networkLabelColorHexOverride; set { _networkLabelColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(NetworkLabelColorHex)); } }
        public string? NetworkGraphColorHexOverride { get => _networkGraphColorHexOverride; set { _networkGraphColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(NetworkGraphColorHex)); } }
        public string? DiskAccentColorHexOverride { get => _diskAccentColorHexOverride; set { _diskAccentColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(DiskAccentColorHex)); } }
        public string? DiskLabelColorHexOverride { get => _diskLabelColorHexOverride; set { _diskLabelColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(DiskLabelColorHex)); } }
        public string? DiskGraphColorHexOverride { get => _diskGraphColorHexOverride; set { _diskGraphColorHexOverride = value; OnPropertyChanged(); OnPropertyChanged(nameof(DiskGraphColorHex)); } }

        public int? CpuWarnThresholdOverrideValue { get => _cpuWarnThresholdOverride; set { _cpuWarnThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(CpuWarnThreshold)); } }
        public int? CpuCriticalThresholdOverrideValue { get => _cpuCriticalThresholdOverride; set { _cpuCriticalThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(CpuCriticalThreshold)); } }
        public int? RamWarnThresholdOverrideValue { get => _ramWarnThresholdOverride; set { _ramWarnThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(RamWarnThreshold)); } }
        public int? RamCriticalThresholdOverrideValue { get => _ramCriticalThresholdOverride; set { _ramCriticalThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(RamCriticalThreshold)); } }
        public int? GpuWarnThresholdOverrideValue { get => _gpuWarnThresholdOverride; set { _gpuWarnThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(GpuWarnThreshold)); } }
        public int? GpuCriticalThresholdOverrideValue { get => _gpuCriticalThresholdOverride; set { _gpuCriticalThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(GpuCriticalThreshold)); } }
        public int? NetworkWarnThresholdOverrideValue { get => _networkWarnThresholdOverride; set { _networkWarnThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(NetworkWarnThreshold)); } }
        public int? NetworkCriticalThresholdOverrideValue { get => _networkCriticalThresholdOverride; set { _networkCriticalThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(NetworkCriticalThreshold)); } }
        public int? DiskWarnThresholdOverrideValue { get => _diskWarnThresholdOverride; set { _diskWarnThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(DiskWarnThreshold)); } }
        public int? DiskCriticalThresholdOverrideValue { get => _diskCriticalThresholdOverride; set { _diskCriticalThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 1, 99) : null; OnPropertyChanged(); OnPropertyChanged(nameof(DiskCriticalThreshold)); } }
        public int? TempWarnThresholdOverrideValue { get => _tempWarnThresholdOverride; set { _tempWarnThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 20, 120) : null; OnPropertyChanged(); OnPropertyChanged(nameof(TempWarnThresholdOverride)); } }
        public int? TempCriticalThresholdOverrideValue { get => _tempCriticalThresholdOverride; set { _tempCriticalThresholdOverride = value.HasValue ? Math.Clamp(value.Value, 20, 120) : null; OnPropertyChanged(); OnPropertyChanged(nameof(TempCriticalThresholdOverride)); } }

        private string ResolveGlobalDisplayMode()
        {
            return string.Equals(GlobalDisplayMode, "Graph", StringComparison.OrdinalIgnoreCase)
                ? "TextGraph"
                : GlobalDisplayMode;
        }

        private void NotifyInheritedDisplayModeChanges()
        {
            if (_cpuDisplayModeOverride is null) OnPropertyChanged(nameof(CpuDisplayMode));
            if (_cpuClockDisplayModeOverride is null) OnPropertyChanged(nameof(CpuClockDisplayMode));
            if (_ramDisplayModeOverride is null) OnPropertyChanged(nameof(RamDisplayMode));
            if (_ramUsedFreeDisplayModeOverride is null) OnPropertyChanged(nameof(RamUsedFreeDisplayMode));
            if (_gpuDisplayModeOverride is null) OnPropertyChanged(nameof(GpuDisplayMode));
            if (_tempDisplayModeOverride is null) OnPropertyChanged(nameof(TempDisplayMode));
            if (_netUpDisplayModeOverride is null) OnPropertyChanged(nameof(NetUpDisplayMode));
            if (_netDownDisplayModeOverride is null) OnPropertyChanged(nameof(NetDownDisplayMode));
            if (_diskSpaceDisplayModeOverride is null) OnPropertyChanged(nameof(DiskSpaceDisplayMode));
            if (_diskActivityDisplayModeOverride is null) OnPropertyChanged(nameof(DiskActivityDisplayMode));
        }

        private void NotifyInheritedGraphStyleChanges()
        {
            if (_cpuGraphStyleOverride is null) OnPropertyChanged(nameof(CpuGraphStyle));
            if (_cpuClockGraphStyleOverride is null) OnPropertyChanged(nameof(CpuClockGraphStyle));
            if (_ramGraphStyleOverride is null) OnPropertyChanged(nameof(RamGraphStyle));
            if (_ramUsedFreeGraphStyleOverride is null) OnPropertyChanged(nameof(RamUsedFreeGraphStyle));
            if (_gpuGraphStyleOverride is null) OnPropertyChanged(nameof(GpuGraphStyle));
            if (_tempGraphStyleOverride is null) OnPropertyChanged(nameof(TempGraphStyle));
            if (_netUpGraphStyleOverride is null) OnPropertyChanged(nameof(NetUpGraphStyle));
            if (_netDownGraphStyleOverride is null) OnPropertyChanged(nameof(NetDownGraphStyle));
            if (_diskSpaceGraphStyleOverride is null) OnPropertyChanged(nameof(DiskSpaceGraphStyle));
            if (_diskActivityGraphStyleOverride is null) OnPropertyChanged(nameof(DiskActivityGraphStyle));
        }

        private void NotifyInheritedColorChanges()
        {
            if (_cpuAccentColorHexOverride is null) OnPropertyChanged(nameof(CpuAccentColorHex));
            if (_ramAccentColorHexOverride is null) OnPropertyChanged(nameof(RamAccentColorHex));
            if (_gpuAccentColorHexOverride is null) OnPropertyChanged(nameof(GpuAccentColorHex));
            if (_networkAccentColorHexOverride is null) OnPropertyChanged(nameof(NetworkAccentColorHex));
            if (_diskAccentColorHexOverride is null) OnPropertyChanged(nameof(DiskAccentColorHex));
            if (_cpuLabelColorHexOverride is null) OnPropertyChanged(nameof(CpuLabelColorHex));
            if (_ramLabelColorHexOverride is null) OnPropertyChanged(nameof(RamLabelColorHex));
            if (_gpuLabelColorHexOverride is null) OnPropertyChanged(nameof(GpuLabelColorHex));
            if (_networkLabelColorHexOverride is null) OnPropertyChanged(nameof(NetworkLabelColorHex));
            if (_diskLabelColorHexOverride is null) OnPropertyChanged(nameof(DiskLabelColorHex));
            if (_cpuGraphColorHexOverride is null) OnPropertyChanged(nameof(CpuGraphColorHex));
            if (_ramGraphColorHexOverride is null) OnPropertyChanged(nameof(RamGraphColorHex));
            if (_gpuGraphColorHexOverride is null) OnPropertyChanged(nameof(GpuGraphColorHex));
            if (_networkGraphColorHexOverride is null) OnPropertyChanged(nameof(NetworkGraphColorHex));
            if (_diskGraphColorHexOverride is null) OnPropertyChanged(nameof(DiskGraphColorHex));
        }

        private void NotifyInheritedPercentThresholdChanges()
        {
            if (!_cpuWarnThresholdOverride.HasValue) OnPropertyChanged(nameof(CpuWarnThreshold));
            if (!_cpuCriticalThresholdOverride.HasValue) OnPropertyChanged(nameof(CpuCriticalThreshold));
            if (!_ramWarnThresholdOverride.HasValue) OnPropertyChanged(nameof(RamWarnThreshold));
            if (!_ramCriticalThresholdOverride.HasValue) OnPropertyChanged(nameof(RamCriticalThreshold));
            if (!_gpuWarnThresholdOverride.HasValue) OnPropertyChanged(nameof(GpuWarnThreshold));
            if (!_gpuCriticalThresholdOverride.HasValue) OnPropertyChanged(nameof(GpuCriticalThreshold));
            if (!_networkWarnThresholdOverride.HasValue) OnPropertyChanged(nameof(NetworkWarnThreshold));
            if (!_networkCriticalThresholdOverride.HasValue) OnPropertyChanged(nameof(NetworkCriticalThreshold));
            if (!_diskWarnThresholdOverride.HasValue) OnPropertyChanged(nameof(DiskWarnThreshold));
            if (!_diskCriticalThresholdOverride.HasValue) OnPropertyChanged(nameof(DiskCriticalThreshold));
        }

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
