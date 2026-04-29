using Kil0bitSystemMonitor.Helpers;
using Xunit;

namespace Kil0bitSystemMonitor.Tests;

public class MetricTextFormatterTests
{
    [Theory]
    [InlineData(0f, "N/A")]
    [InlineData(-5f, "N/A")]
    [InlineData(850f, "850 MHz")]
    [InlineData(1000f, "1.00 GHz")]
    [InlineData(4240f, "4.24 GHz")]
    public void FormatCpuClock_UsesExpectedUnits(float mhz, string expected)
    {
        var value = MetricTextFormatter.FormatCpuClock(mhz);
        Assert.Equal(expected, value);
    }

    [Theory]
    [InlineData(6.7, 9.3, "6.7/9.3 GB")]
    [InlineData(0, 0, "0.0/0.0 GB")]
    public void FormatRamUsedFree_ShowsUsedAndFreeGb(double usedGb, double freeGb, string expected)
    {
        var value = MetricTextFormatter.FormatRamUsedFree(usedGb, freeGb);
        Assert.Equal(expected, value);
    }
}
