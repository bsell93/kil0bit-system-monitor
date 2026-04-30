using System.Text.Json;
using Kil0bitSystemMonitor.Models;

namespace Kil0bitSystemMonitor.Services
{
    internal static class ConfigMigration
    {
        public static void ApplyLegacyMetricFlags(string json, AppConfig config)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return;
            }

            try
            {
                using JsonDocument document = JsonDocument.Parse(json);
                JsonElement root = document.RootElement;

                // Migrate historical aggregated flags to the current per-metric flags.
                if (TryReadBoolean(root, "ShowCpu", out bool showCpu))
                {
                    config.ShowCpuPercent = showCpu;
                }

                if (TryReadBoolean(root, "ShowRam", out bool showRam))
                {
                    config.ShowRamPercent = showRam;
                }

                string? globalDisplayMode = ReadString(root, "GlobalDisplayMode");
                if (!string.IsNullOrWhiteSpace(globalDisplayMode))
                {
                    config.GlobalDisplayMode = globalDisplayMode;
                }

                MigrateStyleOverrides(root, config);
                MigrateThresholdOverrides(root, config);
            }
            catch (JsonException)
            {
                // Ignore malformed legacy payloads and keep default values.
            }
        }

        private static void MigrateStyleOverrides(JsonElement root, AppConfig config)
        {
            bool cpuGlobal = TryReadBoolean(root, "CpuUseGlobalStyle", out bool cpuFlag) ? cpuFlag : true;
            bool ramGlobal = TryReadBoolean(root, "RamUseGlobalStyle", out bool ramFlag) ? ramFlag : true;
            bool gpuGlobal = TryReadBoolean(root, "GpuUseGlobalStyle", out bool gpuFlag) ? gpuFlag : true;
            bool networkGlobal = TryReadBoolean(root, "NetworkUseGlobalStyle", out bool networkFlag) ? networkFlag : true;
            bool diskGlobal = TryReadBoolean(root, "DiskUseGlobalStyle", out bool diskFlag) ? diskFlag : true;

            if (!cpuGlobal)
            {
                config.CpuDisplayModeOverride = ReadString(root, "CpuDisplayMode");
                config.CpuClockDisplayModeOverride = ReadString(root, "CpuClockDisplayMode");
                config.CpuGraphStyleOverride = ReadString(root, "CpuGraphStyle");
                config.CpuClockGraphStyleOverride = ReadString(root, "CpuClockGraphStyle");
                config.CpuAccentColorHexOverride = ReadString(root, "CpuAccentColorHex");
                config.CpuLabelColorHexOverride = ReadString(root, "CpuLabelColorHex");
                config.CpuGraphColorHexOverride = ReadString(root, "CpuGraphColorHex");
            }
            else
            {
                config.CpuDisplayModeOverride = null;
                config.CpuClockDisplayModeOverride = null;
                config.CpuGraphStyleOverride = null;
                config.CpuClockGraphStyleOverride = null;
                config.CpuAccentColorHexOverride = null;
                config.CpuLabelColorHexOverride = null;
                config.CpuGraphColorHexOverride = null;
            }

            if (!ramGlobal)
            {
                config.RamDisplayModeOverride = ReadString(root, "RamDisplayMode");
                config.RamUsedFreeDisplayModeOverride = ReadString(root, "RamUsedFreeDisplayMode");
                config.RamGraphStyleOverride = ReadString(root, "RamGraphStyle");
                config.RamUsedFreeGraphStyleOverride = ReadString(root, "RamUsedFreeGraphStyle");
                config.RamAccentColorHexOverride = ReadString(root, "RamAccentColorHex");
                config.RamLabelColorHexOverride = ReadString(root, "RamLabelColorHex");
                config.RamGraphColorHexOverride = ReadString(root, "RamGraphColorHex");
            }
            else
            {
                config.RamDisplayModeOverride = null;
                config.RamUsedFreeDisplayModeOverride = null;
                config.RamGraphStyleOverride = null;
                config.RamUsedFreeGraphStyleOverride = null;
                config.RamAccentColorHexOverride = null;
                config.RamLabelColorHexOverride = null;
                config.RamGraphColorHexOverride = null;
            }

            if (!gpuGlobal)
            {
                config.GpuDisplayModeOverride = ReadString(root, "GpuDisplayMode");
                config.TempDisplayModeOverride = ReadString(root, "TempDisplayMode");
                config.GpuGraphStyleOverride = ReadString(root, "GpuGraphStyle");
                config.TempGraphStyleOverride = ReadString(root, "TempGraphStyle");
                config.GpuAccentColorHexOverride = ReadString(root, "GpuAccentColorHex");
                config.GpuLabelColorHexOverride = ReadString(root, "GpuLabelColorHex");
                config.GpuGraphColorHexOverride = ReadString(root, "GpuGraphColorHex");
            }
            else
            {
                config.GpuDisplayModeOverride = null;
                config.TempDisplayModeOverride = null;
                config.GpuGraphStyleOverride = null;
                config.TempGraphStyleOverride = null;
                config.GpuAccentColorHexOverride = null;
                config.GpuLabelColorHexOverride = null;
                config.GpuGraphColorHexOverride = null;
            }

            if (!networkGlobal)
            {
                config.NetUpDisplayModeOverride = ReadString(root, "NetUpDisplayMode");
                config.NetDownDisplayModeOverride = ReadString(root, "NetDownDisplayMode");
                config.NetUpGraphStyleOverride = ReadString(root, "NetUpGraphStyle");
                config.NetDownGraphStyleOverride = ReadString(root, "NetDownGraphStyle");
                config.NetworkAccentColorHexOverride = ReadString(root, "NetworkAccentColorHex");
                config.NetworkLabelColorHexOverride = ReadString(root, "NetworkLabelColorHex");
                config.NetworkGraphColorHexOverride = ReadString(root, "NetworkGraphColorHex");
            }
            else
            {
                config.NetUpDisplayModeOverride = null;
                config.NetDownDisplayModeOverride = null;
                config.NetUpGraphStyleOverride = null;
                config.NetDownGraphStyleOverride = null;
                config.NetworkAccentColorHexOverride = null;
                config.NetworkLabelColorHexOverride = null;
                config.NetworkGraphColorHexOverride = null;
            }

            if (!diskGlobal)
            {
                config.DiskSpaceDisplayModeOverride = ReadString(root, "DiskSpaceDisplayMode");
                config.DiskActivityDisplayModeOverride = ReadString(root, "DiskActivityDisplayMode");
                config.DiskSpaceGraphStyleOverride = ReadString(root, "DiskSpaceGraphStyle");
                config.DiskActivityGraphStyleOverride = ReadString(root, "DiskActivityGraphStyle");
                config.DiskAccentColorHexOverride = ReadString(root, "DiskAccentColorHex");
                config.DiskLabelColorHexOverride = ReadString(root, "DiskLabelColorHex");
                config.DiskGraphColorHexOverride = ReadString(root, "DiskGraphColorHex");
            }
            else
            {
                config.DiskSpaceDisplayModeOverride = null;
                config.DiskActivityDisplayModeOverride = null;
                config.DiskSpaceGraphStyleOverride = null;
                config.DiskActivityGraphStyleOverride = null;
                config.DiskAccentColorHexOverride = null;
                config.DiskLabelColorHexOverride = null;
                config.DiskGraphColorHexOverride = null;
            }
        }

        private static void MigrateThresholdOverrides(JsonElement root, AppConfig config)
        {
            if (TryReadBoolean(root, "CpuThresholdOverrideEnabled", out bool cpuEnabled) && cpuEnabled)
            {
                config.CpuWarnThresholdOverrideValue = ReadInt(root, "CpuWarnThreshold");
                config.CpuCriticalThresholdOverrideValue = ReadInt(root, "CpuCriticalThreshold");
            }
            else
            {
                config.CpuWarnThresholdOverrideValue = null;
                config.CpuCriticalThresholdOverrideValue = null;
            }

            if (TryReadBoolean(root, "RamThresholdOverrideEnabled", out bool ramEnabled) && ramEnabled)
            {
                config.RamWarnThresholdOverrideValue = ReadInt(root, "RamWarnThreshold");
                config.RamCriticalThresholdOverrideValue = ReadInt(root, "RamCriticalThreshold");
            }
            else
            {
                config.RamWarnThresholdOverrideValue = null;
                config.RamCriticalThresholdOverrideValue = null;
            }

            if (TryReadBoolean(root, "GpuThresholdOverrideEnabled", out bool gpuEnabled) && gpuEnabled)
            {
                config.GpuWarnThresholdOverrideValue = ReadInt(root, "GpuWarnThreshold");
                config.GpuCriticalThresholdOverrideValue = ReadInt(root, "GpuCriticalThreshold");
            }
            else
            {
                config.GpuWarnThresholdOverrideValue = null;
                config.GpuCriticalThresholdOverrideValue = null;
            }

            if (TryReadBoolean(root, "NetworkThresholdOverrideEnabled", out bool networkEnabled) && networkEnabled)
            {
                config.NetworkWarnThresholdOverrideValue = ReadInt(root, "NetworkWarnThreshold");
                config.NetworkCriticalThresholdOverrideValue = ReadInt(root, "NetworkCriticalThreshold");
            }
            else
            {
                config.NetworkWarnThresholdOverrideValue = null;
                config.NetworkCriticalThresholdOverrideValue = null;
            }

            if (TryReadBoolean(root, "DiskThresholdOverrideEnabled", out bool diskEnabled) && diskEnabled)
            {
                config.DiskWarnThresholdOverrideValue = ReadInt(root, "DiskWarnThreshold");
                config.DiskCriticalThresholdOverrideValue = ReadInt(root, "DiskCriticalThreshold");
            }
            else
            {
                config.DiskWarnThresholdOverrideValue = null;
                config.DiskCriticalThresholdOverrideValue = null;
            }

            if (TryReadBoolean(root, "TempThresholdOverrideEnabled", out bool tempEnabled) && tempEnabled)
            {
                config.TempWarnThresholdOverride = ReadInt(root, "TempWarnThresholdOverride") ?? config.TempWarnThreshold;
                config.TempCriticalThresholdOverride = ReadInt(root, "TempCriticalThresholdOverride") ?? config.TempCriticalThreshold;
            }
            else
            {
                config.TempWarnThresholdOverrideValue = null;
                config.TempCriticalThresholdOverrideValue = null;
            }
        }

        private static bool TryReadBoolean(JsonElement root, string propertyName, out bool value)
        {
            value = default;
            if (!root.TryGetProperty(propertyName, out JsonElement element) ||
                element.ValueKind is not (JsonValueKind.True or JsonValueKind.False))
            {
                return false;
            }

            value = element.GetBoolean();
            return true;
        }

        private static string? ReadString(JsonElement root, string propertyName)
        {
            if (root.TryGetProperty(propertyName, out JsonElement element) &&
                element.ValueKind == JsonValueKind.String)
            {
                return element.GetString();
            }

            return null;
        }

        private static int? ReadInt(JsonElement root, string propertyName)
        {
            if (root.TryGetProperty(propertyName, out JsonElement element) &&
                element.TryGetInt32(out int value))
            {
                return value;
            }

            return null;
        }

    }
}
