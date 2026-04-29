namespace Kil0bitSystemMonitor.Models;

public class AppConfig
{
    public bool CpuThresholdOverrideEnabled { get; set; }
    public int CpuWarnThreshold { get; set; }
    public int CpuCriticalThreshold { get; set; }
    public int PercentWarnThreshold { get; set; }
    public int PercentCriticalThreshold { get; set; }
    public bool TempThresholdOverrideEnabled { get; set; }
    public int TempWarnThresholdOverride { get; set; }
    public int TempCriticalThresholdOverride { get; set; }
    public int TempWarnThreshold { get; set; }
    public int TempCriticalThreshold { get; set; }
    public string ThresholdProfile { get; set; } = "Balanced";
}
