import React, { useEffect } from "react";
import { useState } from "react"
import { Navigate, useParams } from "react-router-dom";
import { initialSettings, Settings } from "../models/Settings";
import SettingsService from "../services/SettingsService";

export const SettingsPage = () => {
    const [settings, setSettings] = useState<Settings>(initialSettings);
    const [redirectTo, setRedirectTo] = useState<string>('')

    useEffect(() => {
        let currentSettings = SettingsService.getCurrentSettings();
        if (currentSettings) {
            setSettings(currentSettings);
        }
    }, [])

    if (redirectTo) {
        return <Navigate to={redirectTo} />
    }

    const setProp = (propName: string, value: any) => {
        let newSetting = { ...settings };
        newSetting[propName] = value;
        setSettings(newSetting);
    }

    const save = () => {
        SettingsService.setSettings(settings);
    }

    return <form onSubmit={save} className="form-signin">
        <h1 className="h3 mb-3 fw-normal">Настройки:</h1>

        <div className="form-check mb-3">
            <input className="form-check-input" type="checkbox" checked={settings.disableMobileView} id="flexCheckDefault" onChange={e => setProp('disableMobileView', e.target.checked)} />
            <label className="form-check-label" htmlFor="flexCheckDefault">
                Запретить сворачивание позиций на маленьких экранах
            </label>
        </div>
        <button className="w-100 btn btn-lg btn-primary mt-3" type="submit">Сохранить</button>
    </form>
}

