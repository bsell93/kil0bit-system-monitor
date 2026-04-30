namespace Kil0bitSystemMonitor.Models;

public class AppConfig
{
    public bool ShowCpuPercent { get; set; } = true;
    public bool ShowRamPercent { get; set; } = true;
    public string CpuDisplayMode { get; set; } = "TextGraph";
    public string CpuGraphStyle { get; set; } = "Line";
    public string GlobalDisplayMode { get; set; } = "TextGraph";
    public string GlobalGraphStyle { get; set; } = "Line";
    public string AccentColorHex { get; set; } = "#FFFFFF";
    public string LabelColorHex { get; set; } = "#00CCFF";
    public string GraphColorHex { get; set; } = "#00CCFF";
    public string? CpuDisplayModeOverride { get; set; }
    public string? CpuGraphStyleOverride { get; set; }
    public string? CpuAccentColorHexOverride { get; set; }
    public string? CpuLabelColorHexOverride { get; set; }
    public string? CpuGraphColorHexOverride { get; set; }
    public bool CpuThresholdOverrideEnabled { get; set; }
    public int CpuWarnThreshold { get; set; }
    public int CpuCriticalThreshold { get; set; }
    public int? CpuWarnThresholdOverrideValue { get; set; }
    public int? CpuCriticalThresholdOverrideValue { get; set; }
    public bool RamThresholdOverrideEnabled { get; set; }
    public int RamWarnThreshold { get; set; }
    public int RamCriticalThreshold { get; set; }
    public int? RamWarnThresholdOverrideValue { get; set; }
    public int? RamCriticalThresholdOverrideValue { get; set; }
    public bool GpuThresholdOverrideEnabled { get; set; }
    public int GpuWarnThreshold { get; set; }
    public int GpuCriticalThreshold { get; set; }
    public int? GpuWarnThresholdOverrideValue { get; set; }
    public int? GpuCriticalThresholdOverrideValue { get; set; }
    public bool NetworkThresholdOverrideEnabled { get; set; }
    public int NetworkWarnThreshold { get; set; }
    public int NetworkCriticalThreshold { get; set; }
    public int? NetworkWarnThresholdOverrideValue { get; set; }
    public int? NetworkCriticalThresholdOverrideValue { get; set; }
    public bool DiskThresholdOverrideEnabled { get; set; }
    public int DiskWarnThreshold { get; set; }
    public int DiskCriticalThreshold { get; set; }
    public int? DiskWarnThresholdOverrideValue { get; set; }
    public int? DiskCriticalThresholdOverrideValue { get; set; }
    public int PercentWarnThreshold { get; set; }
    public int PercentCriticalThreshold { get; set; }
    public bool TempThresholdOverrideEnabled { get; set; }
    public int TempWarnThresholdOverride { get; set; }
    public int TempCriticalThresholdOverride { get; set; }
    public int? TempWarnThresholdOverrideValue { get; set; }
    public int? TempCriticalThresholdOverrideValue { get; set; }
    public int TempWarnThreshold { get; set; }
    public int TempCriticalThreshold { get; set; }
    public string ThresholdProfile { get; set; } = "Balanced";
}
