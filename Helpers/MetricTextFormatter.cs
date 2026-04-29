namespace Kil0bitSystemMonitor.Helpers;

public static class MetricTextFormatter
{
    public static string FormatCpuClock(float mhz)
    {
        if (mhz <= 0)
        {
            return "N/A";
        }

        if (mhz >= 1000f)
        {
            return $"{mhz / 1000f:F2} GHz";
        }

        return $"{mhz:F0} MHz";
    }

    public static string FormatRamUsedFree(double usedGb, double freeGb)
    {
        var safeUsed = usedGb < 0 ? 0 : usedGb;
        var safeFree = freeGb < 0 ? 0 : freeGb;
        return $"{safeUsed:F1}/{safeFree:F1} GB";
    }
}
