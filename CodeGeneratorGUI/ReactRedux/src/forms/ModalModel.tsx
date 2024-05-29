import { Modal, Button, Form, InputGroup, Row, Col } from 'react-bootstrap';
import { Table } from "../components/Table";
import { ModelMetadata } from '../models/ModelMetadata';
import { useContext } from 'react';
import { ContextApp, ContextType } from '../state/state';
import { closeAction } from '../state/editforms-state';

export interface IModalModelProps {
    onConfirm?: () => void,
    onHide?: () => void,
    title: string,
    show: boolean,
    editedItem: ModelMetadata
}

export const ModalModel = (props: IModalModelProps) => {
    let { show, onConfirm, onHide, title, editedItem } = props

    const { state, dispatch } = useContext<ContextType>(ContextApp);
    const handleInputChange = () => {

    }

    const onCancel = () => {
        if (onHide) {
            onHide();
        }
        dispatch(closeAction());
    }

    const onOk = () => {
        if (onConfirm) {
            onConfirm();
        }
        dispatch(closeAction());
    }

    return (
        <Modal show={show} onHide={onCancel}>
            <Modal.Header closeButton>
                <Modal.Title>{title}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <form onSubmit={onConfirm} className="form">
                    <div className="form-floating m-3">
                        <input name="name" className="form-control" id="floatingInputName" placeholder="Наименование" value={editedItem.name} onChange={handleInputChange} />
                        <label htmlFor="floatingInputName">Наименование</label>
                    </div>

                    <div className="form-floating m-3">
                        <input name="nameSpace" className="form-control" id="floatingInputNameSpace" placeholder="Пространство имен" value={editedItem.nameSpace} onChange={handleInputChange} />
                        <label htmlFor="floatingInputNameSpace">Пространство имен</label>
                    </div>

                    <div className="form-floating m-3">
                        <input name="caption" className="form-control" id="floatingInputCaption" placeholder="Отображаемое имя" value={editedItem.caption} onChange={handleInputChange} />
                        <label htmlFor="floatingInputCaption">Отображаемое имя</label>
                    </div>
                    <div className="m-3">
                        <h1 className="h4 mt-4 fw-normal">Свойства</h1>
                        <Table items={editedItem.props} props={[{ Name: 'name', Caption: 'Наименование' }, { Name: 'type', Caption: 'Тип данных C#' }, { Name: 'caption', Caption: 'Отображаемое имя' }]} />
                    </div>
                </form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={onCancel}>
                    Отмена
                </Button>
                <Button variant="primary" onClick={onOk}>
                    Ок
                </Button>
            </Modal.Footer>
        </Modal>
    )
}