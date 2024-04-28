import { initialSettings, Settings } from "../models/Settings";

class SettingsService {
  setSettings(settings: Settings) {
    localStorage.setItem("settings", JSON.stringify(settings));
  }

  getCurrentSettings(): Settings {
    let res: Settings;
    let s = localStorage.getItem('settings');
    if (s) {
      res = JSON.parse(s);
    } else {
      res = {...initialSettings};
    }

    return res;
  }
}

export default new SettingsService();