const Row = (item: any, props: PropMetadata[], onEdit: (item: any) => void, onDelete: (item: any) => void) => {
    let tdArray = props.map(p => {
        let propArr = p.Name.split('.');
        let resData = item;
        propArr.forEach( prop => {
            if (resData != null)
            {
                resData = isIsoDateTimeString(resData[prop])?(new Date(resData[prop]).toLocaleDateString()):resData[prop];
            }
            else
            {
                resData=null;
            }
        });

        return <td>{resData}</td>
    })
    return (<tr>
        {tdArray}
        <td>
            {((onEdit) || (onDelete)) && <div className="btn-group" role="group" aria-label="Операции">
                {onEdit && <button className="btn btn-secondary" onClick={() => onEdit(item)} >Редактировать</button>}
                {onDelete && <button className="btn btn-danger" onClick={() => onDelete(item)} >Удалить</button>}
            </div>
            }
        </td>
    </tr>);
}

const isIsoDateTimeString = (str: string): boolean => {
    // Регулярное выражение для проверки формата YYYY-MM-DDTHH:MM:SS
    const isoDateTimeRegex = /^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(\.\d{1,3})?$/;

    if (!isoDateTimeRegex.test(str)) {
      return false;
    }
    
    // Дополнительная проверка с помощью Date.parse
    const date = new Date(str);
    return !isNaN(date.getTime());
  };

export interface ITableProps {
    items: any[],
    props: PropMetadata[],
    onEdit?: (item: any) => void,
    onDelete?: (item: any) => void,
    onAdd?: (item: any) => void
}

export const Table = (props: ITableProps) => {
    let { items, onAdd, onEdit, onDelete } = props;
    return <div>
        <table className="table table-striped table-sm">
            <thead>
                <tr>
                    {props.props.map(p => <th>{p.Caption}</th>)}

                    <th></th>
                </tr>
            </thead>
            <tbody>
                {(items) && items.map(o => Row(o, props.props, onEdit, onDelete))}
            </tbody>
        </table>
        {onAdd && <button className="w-100 btn btn-success" onClick={onAdd} >Добавить</button>}
    </div>;
}

export interface PropMetadata {
    Name: string,
    Type?: string,
    Caption: string
}