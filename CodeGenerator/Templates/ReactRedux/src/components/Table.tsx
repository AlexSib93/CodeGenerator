
const Row = (item: any, props: PropMetadata[], onEdit: (item: any) => void, onDelete: (item: any) => void) => {
    return (<tr>
        {props.map(p => <td>{item[p.Name]}</td>)}
        <td>
            {onEdit && <button className="btn btn-secondary" onClick={() => onEdit(item)} >Edit</button>}
            {onDelete && <button className="btn btn-danger" onClick={() => onDelete(item)} >Delete</button>}
        </td>
    </tr>);
}

export interface ITableProps {
    items: any[], 
    props: PropMetadata[], 
    onEdit?: (item: any) => void,
    onDelete?: (item: any) => void,
    onAdd?: (item: any) => void
}

export const Table = (props: ITableProps) => {
    let {items, onAdd, onEdit, onDelete } = props;
    return <table className="table table-striped table-sm">
        <thead>
            <tr>
                {props.props.map(p => <th>{p.Caption}</th>)}

                <th></th>
            </tr>
        </thead>
        <tbody>
            {(items) && items.map(o => Row(o, props.props, onEdit, onDelete))}
        </tbody>
        {onAdd && <button className="w-100 btn btn-success" onClick={onAdd} >Add</button>}
    </table>;
}

export interface PropMetadata {
    Name: string,
    Type?: string,
    Caption: string
}