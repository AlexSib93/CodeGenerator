import React, { forwardRef, useEffect, useImperativeHandle, useRef, useState } from 'react';
import { IFilterComp, IFilterParams } from 'ag-grid-community';

// Определяем тип для пропсов фильтра
interface EnumFilterProps {
  values: string[]; // Все возможные значения enum
  model: EnumFilterModel | null; // Текущая модель фильтра
  onModelChange: (model: EnumFilterModel | null) => void; // Колбэк при изменении
}

// Определяем интерфейс для ref фильтра
interface IEnumFilter extends IFilterComp {
  getModel: () => { values: string[] } | null;
  setModel: (model: EnumFilterModel | null) => void;
  isFilterActive: () => boolean;
}
interface EnumFilterModel {
  values: string[];
}

interface IEnumFilterParams extends IFilterParams<any, EnumFilterProps> {
  values: string[]; // Все возможные значения enum
  model: EnumFilterModel | null; // Текущая модель фильтра
  onModelChange: (model: EnumFilterModel | null) => void; // Колбэк при изменении
  suppressAndOrCondition?: boolean;
  valueGetter: (val) => any;
}

// Создаем компонент фильтра с использованием forwardRef
const EnumFilter = forwardRef<IEnumFilter, IEnumFilterParams>((props, ref) => {
  const { values, model, valueGetter, onModelChange } = props;
  const [selectedValues, setSelectedValues] = useState<string[]>(model?.values || []);

  const filterGuiRef = useRef<HTMLDivElement>(null);
  // Обработчик изменения чекбоксов
  const handleCheckboxChange = (value: string, isChecked: boolean) => {
    const newSelectedValues = isChecked
      ? [...selectedValues, value]
      : selectedValues.filter(v => v !== value);
    setSelectedValues(newSelectedValues);
    onModelChange(newSelectedValues.length > 0 ? { values: newSelectedValues } : null);
  };

  //Todo: Не работает! Отладить
  const doesFilterPass = (params: { data: any }) => {
    if (selectedValues.length === 0) return true;
    const value = valueGetter ? valueGetter(params) : params.data[props.colDef?.field as string];
    return selectedValues.includes(value);
  };

  // Реализуем обязательные методы фильтра через useImperativeHandle
  //Todo: Не работает! Отладить
  useImperativeHandle(ref, () => ({
    isFilterActive: () => selectedValues.length > 0,
    getModel: () => (selectedValues.length > 0 ? { values: selectedValues } : null),
    setModel: (model: { values: string[] } | null) => {
      setSelectedValues(model?.values || []);
    },
    doesFilterPass: (params: { data: any }) => {
      return doesFilterPass(params);
    },
    getGui: () => {
      return filterGuiRef.current!;
    },
  }));

  // Синхронизируем внутреннее состояние при изменении модели извне
  useEffect(() => {
    setSelectedValues(model?.values || []);
  }, [model]);

  return (
    <div ref={filterGuiRef} className="ag-custom-filter" style={{ padding: '10px', minWidth: '200px' }}>
      <div className="ag-filter-header" style={{ marginBottom: '10px' }}>
        <strong>Фильтровать по:</strong>
      </div>
      <div className="ag-filter-body" style={{ maxHeight: '200px', overflowY: 'auto' }}>
        <div key={"all"} style={{ margin: '5px 0' }}>
          <label style={{ display: 'flex', alignItems: 'center' }}>
            <input
              className='form-check-input'
              type="checkbox"
              checked={false}
              onChange={(e) => { }}
              style={{ marginRight: '5px', marginLeft: '5px' }}
            />
            Выбрать все
          </label>
        </div>
        {values.map(value => (
          <div key={value} style={{ margin: '5px 0' }}>
            <label style={{ display: 'flex', alignItems: 'center' }}>
              <input
                className='form-check-input'
                type="checkbox"
                checked={selectedValues.includes(value)}
                onChange={(e) => handleCheckboxChange(value, e.target.checked)}
                style={{ marginRight: '5px', marginLeft: '5px' }}
              />
              {value}
            </label>
          </div>
        ))}
      </div>
    </div>
  );
});

export default EnumFilter;