use serde::{Serialize, Deserialize};
use std::fs;
use std::path::PathBuf;

#[derive(Serialize, Deserialize, Debug, Clone)]
#[serde(default)]
pub struct AppConfig {
    pub show_cpu: bool,
    pub show_mem: bool,
    pub show_gpu: bool,
    pub show_temp_gpu: bool,
    pub show_net_up: bool,
    pub show_net_down: bool,
    pub show_cpu_freq: bool,
    pub font_family: String,
    pub text_color_hex: String,
    pub network_adapter: String,
    pub display_variant: String,
    pub locked_drag: bool,
    pub bg_color_hex: String,   // background color e.g. "#000000"
    pub bg_opacity: f32,        // 0.0 (transparent) to 1.0 (opaque)
    pub auto_start: bool,
    pub show_overlay: bool,
    pub overlay_x: i32,
    pub overlay_y: i32,
}

impl Default for AppConfig {
    fn default() -> Self {
        Self {
            show_cpu: true,
            show_mem: true,
            show_gpu: true,
            show_temp_gpu: true,
            show_net_up: true,
            show_net_down: true,
            show_cpu_freq: true,
            font_family: "System Default".to_string(),
            text_color_hex: "#FFFFFF".to_string(),
            network_adapter: "All Adapters".to_string(),
            display_variant: "Standard".to_string(),
            locked_drag: false,
            bg_color_hex: "#000000".to_string(),
            bg_opacity: 0.55,
            auto_start: false,
            show_overlay: true,
            overlay_x: 0,
            overlay_y: 0,
        }
    }
}

impl AppConfig {
    fn get_config_path() -> PathBuf {
        let mut path = dirs::config_dir().unwrap_or_else(|| PathBuf::from("."));
        path.push("kil0bit-system-monitor");
        fs::create_dir_all(&path).ok();
        path.push("config.json");
        path
    }

    pub fn load() -> Self {
        let path = Self::get_config_path();
        if path.exists() {
            if let Ok(contents) = fs::read_to_string(&path) {
                if let Ok(config) = serde_json::from_str(&contents) {
                    return config;
                }
            }
        }
        Self::default()
    }

    pub fn save(&self) {
        let path = Self::get_config_path();
        if let Ok(json) = serde_json::to_string_pretty(self) {
            let _ = fs::write(path, json);
        }
    }
}
