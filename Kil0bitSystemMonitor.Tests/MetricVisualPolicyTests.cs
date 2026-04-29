using Kil0bitSystemMonitor.Helpers;
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
}
