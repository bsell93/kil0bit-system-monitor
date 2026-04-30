using System;
using Kil0bitSystemMonitor.Models;

namespace Kil0bitSystemMonitor.Helpers;

public enum MetricDisplayMode
{
    Text,
    Graph,
    TextGraph
}

public enum InlineGraphStyle
{
    Line,
    Bar,
    Pie
}

public enum ThresholdSeverity
{
    Normal,
    Warning,
    Critical
}

public static class MetricVisualPolicy
{
    public static int ResolveHistoryPoints(string preset, int fallback)
    {
        return preset switch
        {
            "Short" => 24,
            "Medium" => 48,
            "Long" => 96,
            _ => Math.Clamp(fallback, 16, 96)
        };
    }

    public static MetricDisplayMode ParseDisplayMode(string mode)
    {
        return mode switch
        {
            "Text" => MetricDisplayMode.Text,
            "Graph" => MetricDisplayMode.Graph,
            _ => MetricDisplayMode.TextGraph
        };
    }

    public static InlineGraphStyle ParseInlineGraphStyle(string? style)
    {
        if (string.Equals(style, "Bar", StringComparison.OrdinalIgnoreCase))
        {
            return InlineGraphStyle.Bar;
        }

        if (string.Equals(style, "Pie", StringComparison.OrdinalIgnoreCase))
        {
            return InlineGraphStyle.Pie;
        }

        return InlineGraphStyle.Line;
    }

    public static string ResolveDisplayModeValue(AppConfig config, bool useGlobalStyle, string metricDisplayMode)
    {
        _ = config;
        _ = useGlobalStyle;
        return metricDisplayMode;
    }

    public static string ResolveGraphStyleValue(AppConfig config, bool useGlobalStyle, string metricGraphStyle)
    {
        _ = config;
        _ = useGlobalStyle;
        return metricGraphStyle;
    }

    public static string ResolveAccentColorHex(AppConfig config, bool useGlobalStyle, string metricAccentColorHex)
    {
        _ = config;
        _ = useGlobalStyle;
        return metricAccentColorHex;
    }

    public static string ResolveLabelColorHex(AppConfig config, bool useGlobalStyle, string metricLabelColorHex)
    {
        _ = config;
        _ = useGlobalStyle;
        return metricLabelColorHex;
    }

    public static string ResolveGraphColorHex(AppConfig config, bool useGlobalStyle, string metricGraphColorHex)
    {
        _ = config;
        _ = useGlobalStyle;
        return metricGraphColorHex;
    }

    public static (int Warn, int Critical) ResolvePercentThresholds(AppConfig config, string metricKey)
    {
        if (metricKey == "cpu" && config.CpuWarnThresholdOverrideValue.HasValue && config.CpuCriticalThresholdOverrideValue.HasValue)
        {
            return NormalizePair(config.CpuWarnThreshold, config.CpuCriticalThreshold);
        }
        if (metricKey == "ram" && config.RamWarnThresholdOverrideValue.HasValue && config.RamCriticalThresholdOverrideValue.HasValue)
        {
            return NormalizePair(config.RamWarnThreshold, config.RamCriticalThreshold);
        }
        if (metricKey == "gpu" && config.GpuWarnThresholdOverrideValue.HasValue && config.GpuCriticalThresholdOverrideValue.HasValue)
        {
            return NormalizePair(config.GpuWarnThreshold, config.GpuCriticalThreshold);
        }
        if (metricKey.StartsWith("net.", StringComparison.Ordinal) && config.NetworkWarnThresholdOverrideValue.HasValue && config.NetworkCriticalThresholdOverrideValue.HasValue)
        {
            return NormalizePair(config.NetworkWarnThreshold, config.NetworkCriticalThreshold);
        }
        if (metricKey.StartsWith("disk.", StringComparison.Ordinal) && config.DiskWarnThresholdOverrideValue.HasValue && config.DiskCriticalThresholdOverrideValue.HasValue)
        {
            return NormalizePair(config.DiskWarnThreshold, config.DiskCriticalThreshold);
        }

        return NormalizePair(config.PercentWarnThreshold, config.PercentCriticalThreshold);
    }

    public static (int Warn, int Critical) ResolveTempThresholds(AppConfig config)
    {
        if (config.TempWarnThresholdOverrideValue.HasValue && config.TempCriticalThresholdOverrideValue.HasValue)
        {
            return NormalizePair(config.TempWarnThresholdOverride, config.TempCriticalThresholdOverride);
        }

        return NormalizePair(config.TempWarnThreshold, config.TempCriticalThreshold);
    }

    public static ThresholdSeverity Evaluate(float value, int warn, int critical)
    {
        if (value >= critical) return ThresholdSeverity.Critical;
        if (value >= warn) return ThresholdSeverity.Warning;
        return ThresholdSeverity.Normal;
    }

    public static void ApplyThresholdProfile(AppConfig config, string profile)
    {
        config.ThresholdProfile = profile;
        switch (profile)
        {
            case "Conservative":
                config.PercentWarnThreshold = 65;
                config.PercentCriticalThreshold = 82;
                config.TempWarnThreshold = 68;
                config.TempCriticalThreshold = 80;
                break;
            case "Aggressive":
                config.PercentWarnThreshold = 85;
                config.PercentCriticalThreshold = 95;
                config.TempWarnThreshold = 78;
                config.TempCriticalThreshold = 90;
                break;
            default:
                config.PercentWarnThreshold = 75;
                config.PercentCriticalThreshold = 90;
                config.TempWarnThreshold = 72;
                config.TempCriticalThreshold = 84;
                break;
        }
    }

    private static (int Warn, int Critical) NormalizePair(int warn, int critical)
    {
        int w = Math.Clamp(warn, 1, 120);
        int c = Math.Clamp(critical, 1, 120);
        if (w >= c) w = Math.Max(1, c - 1);
        return (w, c);
    }
}
