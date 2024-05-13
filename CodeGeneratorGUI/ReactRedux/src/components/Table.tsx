
const ModelMetadataRow = (item: any, props: PropMetadata[], editClick: (item: any) => void) => {
    return (<tr>
        {props.map(p => <td>{item[p.Name]}</td>)}
        <td>
            {editClick && <button className="btn btn-secondary" onClick={() => editClick(item)} >Edit</button>}
        </td>
    </tr>);
}

export interface ITableProps {
    items: any[], 
    props: PropMetadata[], 
    addItem?: () => void, 
    editClick?: (item: any) => void
}

export const Table = (props: ITableProps) => {
    let {items, addItem, editClick } = props;
    return <table className="table table-striped table-sm">
        <thead>
            <tr>
                {props.props.map(p => <th>{p.Caption}</th>)}

                <th></th>
            </tr>
        </thead>
        <tbody>
            {(items) && items.map(o => ModelMetadataRow(o, props.props, editClick))}
        </tbody>
        {addItem && <button className="w-100 btn btn-lg btn-primary" onClick={addItem} >Добавить</button>}
    </table>;
}

export interface PropMetadata {
    Name: string,
    Type?: string,
    Caption: string
}