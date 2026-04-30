using Kil0bitSystemMonitor.Helpers;
using Kil0bitSystemMonitor.Models;
using Xunit;

namespace Kil0bitSystemMonitor.Tests;

public class MetricVisualPolicyTests
{
    [Theory]
    [InlineData("Line", InlineGraphStyle.Line)]
    [InlineData("Bar", InlineGraphStyle.Bar)]
    [InlineData("Pie", InlineGraphStyle.Pie)]
    [InlineData("line", InlineGraphStyle.Line)]
    [InlineData("unexpected", InlineGraphStyle.Line)]
    public void ParseInlineGraphStyle_MapsKnownValuesAndDefaultsToLine(string value, InlineGraphStyle expected)
    {
        var style = MetricVisualPolicy.ParseInlineGraphStyle(value);

        Assert.Equal(expected, style);
    }

    [Fact]
    public void ResolveDisplayModeValue_UsesEffectiveMetricValue()
    {
        var config = new AppConfig
        {
            CpuDisplayModeOverride = "TextGraph",
            GlobalDisplayMode = "Graph"
        };

        var resolved = MetricVisualPolicy.ResolveDisplayModeValue(config, useGlobalStyle: true, metricDisplayMode: config.CpuDisplayMode);

        Assert.Equal("TextGraph", resolved);
    }

    [Fact]
    public void ResolveGraphStyleValue_UsesEffectiveMetricValue()
    {
        var config = new AppConfig
        {
            CpuGraphStyleOverride = "Pie",
            GlobalGraphStyle = "Bar"
        };

        var resolved = MetricVisualPolicy.ResolveGraphStyleValue(config, useGlobalStyle: false, metricGraphStyle: config.CpuGraphStyle);

        Assert.Equal("Pie", resolved);
    }

    [Fact]
    public void ResolveDisplayModeValue_CoercesGlobalGraphOnlyToTextGraph()
    {
        var config = new AppConfig
        {
            GlobalDisplayMode = "Graph"
        };

        var resolved = MetricVisualPolicy.ResolveDisplayModeValue(config, useGlobalStyle: true, metricDisplayMode: "Text");

        Assert.Equal("TextGraph", resolved);
    }

    [Fact]
    public void ResolveAccentColorHex_UsesEffectiveMetricColor()
    {
        var config = new AppConfig
        {
            AccentColorHex = "#FF0000"
        };

        var resolved = MetricVisualPolicy.ResolveAccentColorHex(config, useGlobalStyle: false, metricAccentColorHex: "#00FF00");

        Assert.Equal("#00FF00", resolved);
    }

    [Fact]
    public void ResolvePercentThresholds_UsesRamOverridesWhenSet()
    {
        var config = new AppConfig
        {
            RamWarnThresholdOverrideValue = 61,
            RamCriticalThresholdOverrideValue = 83,
            RamWarnThreshold = 61,
            RamCriticalThreshold = 83,
            PercentWarnThreshold = 75,
            PercentCriticalThreshold = 90
        };

        var resolved = MetricVisualPolicy.ResolvePercentThresholds(config, "ram");

        Assert.Equal((61, 83), resolved);
    }
}
