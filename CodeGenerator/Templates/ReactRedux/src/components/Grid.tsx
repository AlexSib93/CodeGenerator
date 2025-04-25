import { AgGridReact } from "ag-grid-react";
import { PropMetadata } from "./Table";


export interface IGridProps {
    items: any[],
    props: PropMetadata[],
    onEdit?: (item: any) => void,
    onDelete?: (item: any) => void,
    onAdd?: (item: any) => void,
    enableFilters?: boolean
}

export const getDefs = (props: PropMetadata[], enableFilters?: boolean) => {

    return props.map(p => {
        return { field: p.Name, headerName: p.Caption, filter:true, flex: 1 }
    });
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

    const CustomButtonComponent = (props) => {
        return ((onEdit) || (onDelete)) && <div className="btn-group" aria-label="Операции">
            {onEdit && <button className="btn btn-warning" onClick={(e) => onClickEdit(e, props.data) } >Изменить</button>}
            {onDelete && <button className="btn btn-danger" onClick={(e) => onClickDelete(e, props.data)} >Удалить</button>}
        </div>
    }

    return <div>
        <div className='ag-theme-balham w-100 mb-3'>
            <AgGridReact
                rowData={items}
                columnDefs={[...getDefs(props.props, enableFilters), { field: "buttons", headerName: '', cellRenderer: CustomButtonComponent, flex: 1 }]}
                rowGroupPanelShow="always"
                suppressAggFuncInHeader={true}
                enableBrowserTooltips={true}
                suppressDragLeaveHidesColumns={true}
                domLayout='autoHeight'
            />
        </div>
        {onAdd && <button className="w-100 btn btn-success" onClick={onAdd} >Добавить</button>}
    </div>;
}
