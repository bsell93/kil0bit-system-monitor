using Kil0bitSystemMonitor.Models;
using Kil0bitSystemMonitor.Services;
using Xunit;

namespace Kil0bitSystemMonitor.Tests;

public class ConfigMigrationTests
{
    [Fact]
    public void ApplyLegacyMetricFlags_MapsLegacyAggregatedFlagsToCurrentFlags()
    {
        const string json = """
        {
          "ShowCpu": false,
          "ShowRam": true
        }
        """;

        var config = new AppConfig
        {
            ShowCpuPercent = true,
            ShowCpuClock = true,
            ShowRamPercent = false,
            ShowRamUsedFreeGb = false
        };

        ConfigMigration.ApplyLegacyMetricFlags(json, config);

        Assert.False(config.ShowCpuPercent);
        Assert.False(config.ShowCpuClock);
        Assert.True(config.ShowRamPercent);
        Assert.True(config.ShowRamUsedFreeGb);
    }

    [Fact]
    public void ApplyLegacyMetricFlags_MigratesThresholdValuesWithoutOverrideEnableFlags()
    {
        const string json = """
        {
          "CpuWarnThreshold": 62,
          "CpuCriticalThreshold": 88,
          "RamWarnThreshold": 63,
          "RamCriticalThreshold": 89,
          "GpuWarnThreshold": 64,
          "GpuCriticalThreshold": 90,
          "NetworkWarnThreshold": 65,
          "NetworkCriticalThreshold": 91,
          "DiskWarnThreshold": 66,
          "DiskCriticalThreshold": 92,
          "TempWarnThreshold": 70,
          "TempCriticalThreshold": 86
        }
        """;

        var config = new AppConfig();

        ConfigMigration.ApplyLegacyMetricFlags(json, config);

        Assert.Equal(62, config.CpuWarnThresholdOverrideValue);
        Assert.Equal(88, config.CpuCriticalThresholdOverrideValue);
        Assert.Equal(63, config.RamWarnThresholdOverrideValue);
        Assert.Equal(89, config.RamCriticalThresholdOverrideValue);
        Assert.Equal(64, config.GpuWarnThresholdOverrideValue);
        Assert.Equal(90, config.GpuCriticalThresholdOverrideValue);
        Assert.Equal(65, config.NetworkWarnThresholdOverrideValue);
        Assert.Equal(91, config.NetworkCriticalThresholdOverrideValue);
        Assert.Equal(66, config.DiskWarnThresholdOverrideValue);
        Assert.Equal(92, config.DiskCriticalThresholdOverrideValue);
        Assert.Equal(70, config.TempWarnThresholdOverrideValue);
        Assert.Equal(86, config.TempCriticalThresholdOverrideValue);
    }

}
