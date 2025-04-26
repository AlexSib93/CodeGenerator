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

    const onClickDelete = (e: FormEvent, item: any) => {
        e.preventDefault();
        onDelete(item)

    }

    const onClickEdit = (e: FormEvent, item: any) => {
        e.preventDefault();
        onEdit(item)

    }
    const columnTypes = {
        // date: {
        //     valueFormatter: p => new Date(p).toLocaleDateString()
        // },
    };

    const getDefs = (props: DetailPropMetadata[], enableFilters?: boolean): (ColDef | ColGroupDef)[] | null => {
        return props.map(p => {
            return {
                field: p.Name,
                headerName: p.Caption,
                filter: enableFilters ? getFilter(p.Type) : false,
                flex: 1,
                hide: !p.Visible,
                type: getType(p.Type),
                filterParams: getFilterParams(p.Type),
                cellClass: (p.Type==="DateTime") ? 'dateISO' : ''
            }
        });
    }
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
            {onEdit && <button className="btn btn-warning" onClick={(e) => onClickEdit(e, props.data)} >Изменить</button>}
            {onDelete && <button className="btn btn-danger" onClick={(e) => onClickDelete(e, props.data)} >Удалить</button>}
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
