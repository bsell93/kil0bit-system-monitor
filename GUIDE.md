# kil0bit System Monitor — User Guide (v2.0.0)

A complete guide to using, customizing, and mastering your hardware telemetry overlay.

---

## 🛠️ Getting Started

### 1. Installation
The app is available in two professional formats:
- **`Kil0bitSystemMonitor-vX.Y.Z-Setup.msi` (Recommended)**: A professional installer that handles your Start Menu, Desktop shortcuts, and provides a clean uninstall.
- **`Kil0bitSystemMonitor-vX.Y.Z.exe` (Portable)**: A standalone, zero-installation version for users who prefer a single, portable file.

Download the latest version from [GitHub Releases](https://github.com/kil0bit-kb/kil0bit-system-monitor/releases) and launch.

---

## 🖥️ The Overlay

The overlay is a slim, elegant pill that sits directly on your **Windows 11 taskbar**. It displays real-time telemetry from your hardware:

### 📈 Included Metrics
- **CPU**: Total processor load percentage.
- **RAM**: Real-time memory pressure.
- **NET**: Combined Upload and Download speeds.
- **GPU**: Raw load from your graphics processor.
- **DISK**: Real-time disk active time and storage capacity usage.

### 🖱️ Overlay Controls
- **Drag & Move**: Left-click and drag the overlay to reposition it.
- **Snap to Taskbar**: When enabled, the overlay snaps to the taskbar area. Disable this to **free-float** the overlay anywhere on your screen.
- **Toggle Lock**: Right-click the overlay and select **Lock Position** to prevent any accidental movement.
- **Settings**: Right-click to quickly jump into the dashboard.

---

## 🏠 Home Dashboard

The Home dashboard is your high-level control center. It features four primary quick-links:
1. **General**: Configure startup behavior and app lifecycle.
2. **Monitoring**: Select which hardware sensors to track.
3. **Appearance**: Customize font, colors, and styling.
4. **About**: View version history and developer links.

---

## ⚙️ Core Configuration

Open the **Settings Window** to customize your experience:

### 🚀 General Settings
- **Hardware Overlay**: Toggle the entire overlay on or off.
- **Snap to Taskbar**: Enable to snap to the taskbar; disable to **unlock** it so you can position the overlay anywhere on your desktop.
- **Launch on Startup**: Enable this to start monitoring automatically when you log in to Windows.
- **Lock Position**: Lock the overlay in its current location.

### 📊 Monitoring & Sensors
- **Sensor Selection**: Choose which metrics you want to see (CPU, RAM, NET, GPU, DISK).
- **Network Adapter**: If you have multiple network cards (Wi-Fi, Ethernet, VPN), pick the one you want to track.
- **Disk Drive**: Select a specific physical drive (C:, D:, etc.) to monitor its activity and used space.

### 🎨 Appearance & Design
- **Accent Color**: Pick a color that matches your Windows theme.
- **Font Selection**: Choose from high-legibility fonts (Segoe UI, Outfit, Inter).
- **Design Mode**: Toggle between **Standard**, **Compact**, and **Icon** modes for different levels of detail.

---

## ❓ Troubleshooting

**Q: The overlay is missing!**  
A: Go to **General** settings and ensure "Show Hardware Overlay" is toggled **ON**.

**Q: Why doesn't the app start with Windows?**  
A: Ensure "Launch on Windows Startup" is enabled. Note that this requires the app to remain in the same folder where you first enabled the setting.

**Q: Windows says "Unknown Publisher" or "SmartScreen" prevents it from running.**  
A: This happens because the app is a local, independent release. Click **"More Info"** and then **"Run Anyway"**. The app is 100% safe and builds are verified via [GitHub Actions](https://github.com/kil0bit-kb/kil0bit-system-monitor/actions).

**Q: My network speed shows 0 KB/s.**  
A: In **Monitoring** settings, select the correct active Network Adapter from the dropdown menu.

---

## 🌐 Community & Support

Built with ❤️ by **KB - kil0bit**.
For feedback, bug reports, or feature requests, visit the [GitHub Repository](https://github.com/kil0bit-kb/kil0bit-system-monitor).
