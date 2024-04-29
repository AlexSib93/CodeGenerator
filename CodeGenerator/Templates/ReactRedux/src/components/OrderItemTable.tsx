import { OrderItem } from '../models/OrderItem'

export const OrderItemTable = (props: { items: OrderItem[] }) => {
    const { items } = props;
    return (
        <div className="table-responsive">
            <table className="table table-striped table-sm">
                <thead>
                    <tr>
                        <th scope="col">#</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {items.map(oi => OrderItemRow(oi))}
                </tbody>
            </table>
        </div>
    )
}

const OrderItemRow = (orderItem: OrderItem) => {
    return (<tr>
        <td>
            <div className="btn-group" role="group" aria-label="Basic example">
                <button type="button" className="btn btn-danger">-</button>
                <button type="button" className="btn btn-secondary">Edit</button>
            </div>
        </td>
    </tr>);
}

export default OrderItemTable