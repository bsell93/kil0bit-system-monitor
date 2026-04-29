using Kil0bitSystemMonitor.Helpers;
using Xunit;

namespace Kil0bitSystemMonitor.Tests;

public class MetricGraphHistoryTests
{
    [Fact]
    public void Add_EnforcesCapacityAndRetainsLatestValues()
    {
        var history = new MetricGraphHistory(3);
        history.Add(10f);
        history.Add(20f);
        history.Add(30f);
        history.Add(40f);

        var values = history.GetValues();
        Assert.Equal(new[] { 20f, 30f, 40f }, values);
    }

    [Fact]
    public void NormalizePercent_ClampsToZeroAndOneHundredRange()
    {
        Assert.Equal(0f, MetricGraphNormalizer.NormalizePercent(-5f));
        Assert.Equal(50f, MetricGraphNormalizer.NormalizePercent(50f));
        Assert.Equal(100f, MetricGraphNormalizer.NormalizePercent(120f));
    }

    [Fact]
    public void NormalizeSeries_UsesFallbackWhenSeriesIsFlat()
    {
        float[] values = { 10f, 10f, 10f };
        var normalized = MetricGraphNormalizer.NormalizeSeries(values, dynamicRangeFloor: 100f);

        Assert.Equal(new[] { 0f, 0f, 0f }, normalized);
    }
}
