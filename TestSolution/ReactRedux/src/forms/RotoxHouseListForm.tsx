import { useEffect, useState } from "react";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import { RotoxHouse } from "../models/RotoxHouse";
import SettingsService from "../services/SettingsService";

export interface IRotoxHouseListForm2Props {
    items: RotoxHouse[],
    autoFetch: boolean
}

export const RotoxHouseListForm = (props: IRotoxHouseListForm2Props) => {
    const { items } = props;

    let { disableMobileView } = SettingsService.getCurrentSettings();

    return (
        <div>
            {(items && items.length > 0) && <Button>
                {items.length}
            </Button>}
            <div className="table-responsive">
                {(items && items.length > 0) && <table className="table table-striped table-sm">
                    <thead>
                        <tr>
                            <th scope="col">Задание</th>
                            <th scope="col">Позиция</th>
                            <th scope="col">Пирамида</th>
                            <th scope="col">Зона</th>
                            {/* <th scope="col">Уд. склад</th> */}
                        </tr>
                    </thead>
                    <tbody>
                        {items && items.map(o => <RotoxHouseRow allowMobileView={!disableMobileView} rotoxHouse={o} />)}
                    </tbody>
                </table>
                }
            </div>
        </div>
    );
};

const RotoxHouseRow = (props: { rotoxHouse: RotoxHouse, allowMobileView?: boolean }) => {
    let { rotoxHouse, allowMobileView } = props;
    let [hideMobile, setHideMobile] = useState(true);
    let classes = 'bg-warning text-dark';
    let spanClasses = 'text-danger';
    switch (rotoxHouse.state) {
        case 1:
        case 2:
            classes = 'bg-yellow text-dark';
            break;
        case 3:
            classes = 'bg-success text-white';
            spanClasses = 'text-warning';
            break;
    }
    let dtString = (rotoxHouse.logistDate)
        ? new Date(rotoxHouse.logistDate).toLocaleDateString()
        : '';

    let space = (rotoxHouse.row && rotoxHouse.cell)
        ? `${rotoxHouse.row}  ${rotoxHouse.cell} `
        : "Не определено ";

    let zone = (rotoxHouse.zoneRow && rotoxHouse.zoneCell)
        ? `${rotoxHouse.zoneRow}  ${rotoxHouse.zoneCell} `
        : "Не определено ";

    let mdStat = `${rotoxHouse.mfCntOnSgp} из ${rotoxHouse.mfCntAll}`;

    let weight = (rotoxHouse.weight) ? ` вес=${rotoxHouse.weight}` : '';
    let orderInfo = (rotoxHouse.idOrderItem) ? `\\${rotoxHouse.numPos}\\${rotoxHouse.orderItemNum} ` : '';
    let orderDestanation = (rotoxHouse.idOrderItem) ? `${rotoxHouse.destanationName} ${dtString}` : '';

    let hideOnSmClass = (hideMobile && allowMobileView) ? 'd-none d-lg-block' : '';
    return (<tr key={rotoxHouse.idManufactDocPos} onClick={() => { setHideMobile(!hideMobile) }} className={classes} style={{ backgroundColor: 'yellow' }}>
        <td className={classes}>
            <div className={hideOnSmClass}>
                <span className={spanClasses}>{mdStat}</span> {weight}
            </div>
            <div>
                <Link className={classes} to={`/mdrotoxhouse/${rotoxHouse.idManufactDoc}`}>
                    {rotoxHouse.manufactDocName}
                </Link> 
                {(rotoxHouse.parentManufactDocName) &&
                    <Link className={classes} to={`/mdrotoxhouse/${rotoxHouse.parentIdManufactDoc}`}>
                        ({rotoxHouse.parentManufactDocName})
                    </Link>
                }
            </div>
        </td>
        <td className={classes}>
            <div className={hideOnSmClass}>
                <Link className={classes} to={`/orderrotoxhouse/${rotoxHouse.idOrder}`}>{rotoxHouse.orderName}</Link>
                {orderInfo}
                <span className={spanClasses}>
                    {orderDestanation}
                </span>
            </div>
            <div><Link className={classes} to={""} >
                {rotoxHouse.itemName}
            </Link>
            </div>
        </td>
        <td>
            <div>
                {rotoxHouse.storeDepart}
            </div>
            <div>
                {space}
            </div>
        </td>
        <td>
            <div>
                {rotoxHouse.zoneStoreDepart}
            </div>
            <div>
                {zone}
            </div>
        </td>
        {/* <td>
            <div>
                {rotoxHouse.remoteStore}
            </div>
        </td> */}
    </tr>);
}
