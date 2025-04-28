import { AgGridReact } from "ag-grid-react";
import { DetailPropMetadata } from "./DetailPropMetadata";
import { FormEvent } from "react";
import { ColDef, ColGroupDef } from "ag-grid-community/dist/types/src/entities/colDef";
import { ExcelStyle } from "ag-grid-community";


export interface IGridProps {
    items: any[],
    props: DetailPropMetadata[],
    onEdit?: (item: any) => void,
    onDelete?: (item: any) => void,
    onAdd?: (item: any) => void,
    enableFilters?: boolean
}

export const Grid = (props: IGridProps) => {
    let { items, onAdd, onEdit, onDelete, enableFilters } = props;

    const columnTypes = {
        // date: {
        //     valueFormatter: p => new Date(p).toLocaleDateString()
        // },
    };

    const getDefs = (props: DetailPropMetadata[], enableFilters?: boolean): (ColDef | ColGroupDef)[] | null => {
        return props.map(p => {
            const baseColDef: ColDef = {
                field: p.Name,
                headerName: p.Caption,
                filter: enableFilters ? getFilter(p.Type) : false,
                flex: 1,
                hide: !p.Visible,
                type: getType(p.Type),
                filterParams: getFilterParams(p.Type),
                cellClass: p.Type === "DateTime" ? 'dateISO' : ''
            };
    
            // Добавляем форматирование в зависимости от типа данных
            switch (p.Type) {
                case "DateTime":
                    return {
                        ...baseColDef,
                        valueFormatter: params => {
                            if (!params.value) return '';
                            try {
                                const date = new Date(params.value);
                                return isNaN(date.getTime()) 
                                    ? params.value 
                                    : date.toLocaleDateString('ru-RU');
                            } catch {
                                return params.value;
                            }
                        },
                        filter: 'agDateColumnFilter',
                        filterParams: {
                            comparator: (filterLocalDate: Date, cellValue: string) => {
                                const cellDate = new Date(cellValue);
                                return cellDate.getTime() - filterLocalDate.getTime();
                            }
                        }
                    };
    
                case "Integer":
                case "Decimal":
                case "Double":
                    return {
                        ...baseColDef,
                        valueFormatter: params => {
                            if (params.value === null || params.value === undefined) return '';
                            return Number(params.value).toLocaleString('ru-RU');
                        },
                        filter: 'agNumberColumnFilter'
                    };
    
                case "String":
                default:
                    return {
                        ...baseColDef,
                        valueFormatter: params => params.value ?? '',
                        filter: 'agTextColumnFilter'
                    };
            }
        });
    };
    const excelStyles: ExcelStyle[] = [
        {
            id: 'dateISO',
            dataType: 'DateTime',
            numberFormat: {
                format: 'yyy-mm-ddThh:mm:ss'
            }
        }
    ];

    const getFilterParams = (type: string) => {
        let filterOptions = getFilterOptions(type);

        let res: any = { closeOnApply: true };
        if (filterOptions.length > 0) {
            res = { ...res, filterOptions };
        }

        return res
    }

    const getFilterOptions = (type: string) => {
        let res = [];

        switch (type) {
            case 'string':
                res = ['contains'];
                break;
            default:
                break;
        }
        return res;
    }

    const getFilter = (type: string) => {

        let res = 'true';
        switch (type) {
            case 'string':
                res = 'agTextColumnFilter';
                break;
            case 'int':
                res = 'agNumberColumnFilter';
                break;
            case 'DateTime':
                res = 'agDateColumnFilter';
                break;
            case 'Set':
                res = 'agSetColumnFilter';
                break;
        }

        return res;
    }

    const getType = (type: string) => {

        let res = type;
        switch (type) {
            case 'string':
                res = 'text';
                break;
            case 'int':
                res = 'number';
                break;
            case 'DateTime':
                res = 'date';//'dateString'; //date
                break;
            case 'bool':
                res = 'boolean';
                break;
            case 'object':
                res = 'boolean';
                break;
        }

        return res;
    }

    const CustomButtonComponent = (props) => {
        return ((onEdit) || (onDelete)) && <div className="btn-group" aria-label="Операции">
            {onEdit && <button className="btn btn-warning" type='button'  onClick={() => onEdit( props.data)} >Изменить</button>}
            {onDelete && <button className="btn btn-danger" type='button'  onClick={() => onDelete( props.data)} >Удалить</button>}
        </div>
    }

    return <div>
        <div className='ag-theme-balham w-100 mb-3'>
            <AgGridReact
                rowData={items}
                columnDefs={[...getDefs(props.props, enableFilters), { field: "buttons", headerName: '', cellRenderer: CustomButtonComponent, width: 220 }]}
                columnTypes={columnTypes}
                suppressAggFuncInHeader={true}
                enableBrowserTooltips={true}
                suppressDragLeaveHidesColumns={true}
                domLayout='autoHeight'
                excelStyles={excelStyles}
            />
        </div>
        {onAdd && <button className="w-100 btn btn-success" onClick={onAdd} >Добавить</button>}
    </div>;
}
