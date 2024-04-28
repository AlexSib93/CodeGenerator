import React, { useState } from "react";
import { Navigate } from "react-router-dom";
import { BarcodeInput } from "../components/BarcodeInput";
import { OrderItem } from "../models/OrderItem";
import BarcodeService from "../services/BarcodeService";
import { ContextApp } from "../state/state";
import { showErrorSnackbar } from "../state/ui-state";

const Home = () => {
    const { state, dispatch } = React.useContext(ContextApp);
    const [orderItem, setOrderItem] = useState<OrderItem | null>(null)
    const [redirectTo, setRedirectTo] = useState<string>('')

    const scanBarcode = async (barcode: string) => {
        if (barcode.length === 11) {
            if (barcode.startsWith('2') || barcode.startsWith('1') || barcode.startsWith('3')) {
                setRedirectTo(`/RotoxHousein/${barcode}`);
            }
            else if (barcode.startsWith('6')) {
                setRedirectTo(`/DelivDocRotoxHouse/${barcode.substring(1)}`);
            }
            else if (barcode.startsWith('7777') || barcode.startsWith('0000')) {
                setRedirectTo(`/RotoxHouseOut/${barcode}`);
            }
        } else {
            dispatch(showErrorSnackbar('Длина баркода должна составлять 11 символов'));
        }

    }

    if (redirectTo) {
        return <Navigate to={redirectTo} />
    }

    console.log(state);

    if (state && (!state.auth || !state.auth.user)) {
        return <Navigate to={'/login'} />
    }

    return (
        <>
            <BarcodeInput scanBarcode={scanBarcode} />
            <OrderItemCard orderitem={orderItem} />
        </>
    );
};

const OrderItemCard = (props: { orderitem: OrderItem }) => {
    let { orderitem } = props;
    return (orderitem && <tr>
        <td>{orderitem.name}</td>
        <td>{orderitem.storage}</td>
        <td>{orderitem.weight}</td>
        <td>{orderitem.delivDocName}</td>
    </tr>);
}

export default Home;