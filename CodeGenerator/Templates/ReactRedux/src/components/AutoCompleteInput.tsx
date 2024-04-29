
import React, { SyntheticEvent, useState } from "react"
import { Item } from "../models/item";
import SearchApiService from "../services/SearchApiService";

export interface AutoCompleteInputProps {
    value?: Item,
    label?: string,
    hrefSearchApi?: string,
    onChange?: (value: Item) => void
}

export const AutoCompleteInput = (props: AutoCompleteInputProps) => {
    const [suggestions, setSuggestions] = useState([]);
    const { label, hrefSearchApi, onChange, value } = props;
    const [selectedItem, setSelectedItem] = useState<Item | null>(null);
    const [text, setText] = useState(value?.name ?? "");

    let items = [
        { id: 1, name: 'qwerty' },
        { id: 2, name: 'qwertyiop' },
        { id: 4, name: 'qwevsp' },
        { id: 6, name: 'sdf' },
        { id: 8, name: 'qwecxvxcsp' }
    ];

    const [serchedItems, setSearchedItems] = useState(items)

    const search = (substring: string) => {
        if (hrefSearchApi) {
            SearchApiService.get(hrefSearchApi, substring).then((items: Item[]) => {
                setSearchedItems(items.sort());
            });
        }
    }

    const filterSuggestions = (value: string, serchedItems: Item[]) => {
        let sugg = [];
        if (value.length > 3) {
            const regexp = new RegExp(`^${value}`, 'i');
            sugg = serchedItems.filter(v => regexp.test(v.name) && v.name !== value);
        }
        return sugg;
    }

    const onchange = (value: string) => {
        setText(value);
        if (value.length === 3) {
            search(value);
        }

        findSuggestionForSelect(value);

        setSuggestions(filterSuggestions(value, serchedItems));

    }

    const changeSelectedItem = (item: Item) => {
        if (onChange) {
            onChange(item);
        }
        setSelectedItem(item);
    }

    const findSuggestionForSelect = (value: string) => {
        let findedSuggestion = serchedItems.find((item: Item) => item.name === value);
        if (findedSuggestion) {
            changeSelectedItem(findedSuggestion);
        }

    }

    const suggestionSelected = (value: Item) => {
        setText(value.name);
        changeSelectedItem(value);
        setSuggestions([]);
    }

    const show = (suggestions.length > 0)
        ? 'show'
        : '';

    return (
        <div className="dropdown ">
            <div className="form-floating">
                <input id="input-autocomplete" aria-expanded={suggestions.length > 0} data-bs-toggle="dropdown" data-bs-display="static" className={`form-control dropdown-toggle ${show}`} type="text" value={text} onChange={(e) => onchange(e.target.value)} autoComplete='off' placeholder={label} />
                <label htmlFor="input-autocomplete">{label}</label>
                <ul className={`dropdown-menu dropdown-menu-lg-end ${show}`}>
                    {suggestions.map((item) =>
                        <li data-bs-popper="static" key={item.id}>
                            <button className="dropdown-item" type="button" onClick={() => suggestionSelected(item)}>
                                {item.name}
                            </button>
                        </li>
                    )}
                </ul>
            </div>
        </div>

    )
}
