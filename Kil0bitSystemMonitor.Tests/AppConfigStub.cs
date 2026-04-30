namespace Kil0bitSystemMonitor.Models;

public class AppConfig
{
    public bool ShowCpuPercent { get; set; } = true;
    public bool ShowCpuClock { get; set; } = true;
    public bool ShowRamPercent { get; set; } = true;
    public bool ShowRamUsedFreeGb { get; set; } = true;
    public string CpuDisplayMode => CpuDisplayModeOverride ?? GlobalDisplayMode;
    public string CpuGraphStyle => CpuGraphStyleOverride ?? GlobalGraphStyle;
    public string GlobalDisplayMode { get; set; } = "TextGraph";
    public string GlobalGraphStyle { get; set; } = "Line";
    public string AccentColorHex { get; set; } = "#FFFFFF";
    public string LabelColorHex { get; set; } = "#00CCFF";
    public string GraphColorHex { get; set; } = "#00CCFF";
    public string? CpuDisplayModeOverride { get; set; }
    public string? CpuClockDisplayModeOverride { get; set; }
    public string? RamDisplayModeOverride { get; set; }
    public string? RamUsedFreeDisplayModeOverride { get; set; }
    public string? GpuDisplayModeOverride { get; set; }
    public string? TempDisplayModeOverride { get; set; }
    public string? NetUpDisplayModeOverride { get; set; }
    public string? NetDownDisplayModeOverride { get; set; }
    public string? DiskSpaceDisplayModeOverride { get; set; }
    public string? DiskActivityDisplayModeOverride { get; set; }
    public string? CpuGraphStyleOverride { get; set; }
    public string? CpuClockGraphStyleOverride { get; set; }
    public string? RamGraphStyleOverride { get; set; }
    public string? RamUsedFreeGraphStyleOverride { get; set; }
    public string? GpuGraphStyleOverride { get; set; }
    public string? TempGraphStyleOverride { get; set; }
    public string? NetUpGraphStyleOverride { get; set; }
    public string? NetDownGraphStyleOverride { get; set; }
    public string? DiskSpaceGraphStyleOverride { get; set; }
    public string? DiskActivityGraphStyleOverride { get; set; }
    public string? CpuAccentColorHexOverride { get; set; }
    public string? CpuLabelColorHexOverride { get; set; }
    public string? CpuGraphColorHexOverride { get; set; }
    public string? RamAccentColorHexOverride { get; set; }
    public string? RamLabelColorHexOverride { get; set; }
    public string? RamGraphColorHexOverride { get; set; }
    public string? GpuAccentColorHexOverride { get; set; }
    public string? GpuLabelColorHexOverride { get; set; }
    public string? GpuGraphColorHexOverride { get; set; }
    public string? NetworkAccentColorHexOverride { get; set; }
    public string? NetworkLabelColorHexOverride { get; set; }
    public string? NetworkGraphColorHexOverride { get; set; }
    public string? DiskAccentColorHexOverride { get; set; }
    public string? DiskLabelColorHexOverride { get; set; }
    public string? DiskGraphColorHexOverride { get; set; }
    public int CpuWarnThreshold { get; set; }
    public int CpuCriticalThreshold { get; set; }
    public int? CpuWarnThresholdOverrideValue { get; set; }
    public int? CpuCriticalThresholdOverrideValue { get; set; }
    public int RamWarnThreshold { get; set; }
    public int RamCriticalThreshold { get; set; }
    public int? RamWarnThresholdOverrideValue { get; set; }
    public int? RamCriticalThresholdOverrideValue { get; set; }
    public int GpuWarnThreshold { get; set; }
    public int GpuCriticalThreshold { get; set; }
    public int? GpuWarnThresholdOverrideValue { get; set; }
    public int? GpuCriticalThresholdOverrideValue { get; set; }
    public int NetworkWarnThreshold { get; set; }
    public int NetworkCriticalThreshold { get; set; }
    public int? NetworkWarnThresholdOverrideValue { get; set; }
    public int? NetworkCriticalThresholdOverrideValue { get; set; }
    public int DiskWarnThreshold { get; set; }
    public int DiskCriticalThreshold { get; set; }
    public int? DiskWarnThresholdOverrideValue { get; set; }
    public int? DiskCriticalThresholdOverrideValue { get; set; }
    public int PercentWarnThreshold { get; set; }
    public int PercentCriticalThreshold { get; set; }
    public int TempWarnThresholdOverride { get; set; }
    public int TempCriticalThresholdOverride { get; set; }
    public int? TempWarnThresholdOverrideValue { get; set; }
    public int? TempCriticalThresholdOverrideValue { get; set; }
    public int TempWarnThreshold { get; set; }
    public int TempCriticalThreshold { get; set; }
    public string ThresholdProfile { get; set; } = "Balanced";
}
