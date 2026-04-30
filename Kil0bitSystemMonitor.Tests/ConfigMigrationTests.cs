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
            ShowRamPercent = false
        };

        ConfigMigration.ApplyLegacyMetricFlags(json, config);

        Assert.False(config.ShowCpuPercent);
        Assert.True(config.ShowRamPercent);
    }
}
