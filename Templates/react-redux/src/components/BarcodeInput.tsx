import { useEffect, useRef } from "react";

export interface IBarcodeInputProps {
    scanBarcode: (barcode: string) => void
}

export const BarcodeInput = (props: IBarcodeInputProps) => {
    let { scanBarcode } = props;
    let barcodeInput: any;
    let ticking: any;

    const SetAutofocusTimer = () => {
        ticking = setInterval(() => {
            if (barcodeInput) {
                barcodeInput.focus();
            }
        }, 100);
    }

    const ClearAutofocusTimer = () => {
        clearInterval(ticking);
    }

    useEffect(() => {
        SetAutofocusTimer();

        return ClearAutofocusTimer;
    });

    const submit = (e: React.FormEvent) => {
        e.preventDefault();
        console.log(e);

        scanBarcode(barcodeInput.value);
        barcodeInput.value = '';
    }

    return (
        <form onSubmit={submit} className="form-barcode pb-4">
            <input type="name" id="outlined-basic" placeholder="Сканируйте баркод" className="form-control" autoFocus
                autoComplete="off"
                ref={(input) => { barcodeInput = input; }}
                style={{ width: '100%' }} />
            {/* <CircularProgress id="progress-bar" style={{ "display": "none" }} /> */}
        </form>
    )
}