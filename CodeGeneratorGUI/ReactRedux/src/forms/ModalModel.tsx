import { Modal, Button, Form, InputGroup, Row, Col } from 'react-bootstrap';
import { Table } from "../components/Table";
import { ModelMetadata } from '../models/ModelMetadata';

export interface IModalModelProps {
    onConfirm?: () => void,
    onHide?: () => void,
    title: string,
    show: boolean,
    editedItem: ModelMetadata
}

export const ModalModel = (props:  IModalModelProps) => {
    let { show, onConfirm, onHide, title, editedItem } = props
    
    const handleInputChange = () => {

    }

    return (
        <Modal show={show} onHide={onHide}>
            <Modal.Header closeButton>
                <Modal.Title>{title}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <form onSubmit={onConfirm} className="form">
                    <h1 className="h3 mb-3 fw-normal">Модель</h1>

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
                        {/* <Table items={editedItem.props} props={[{Name:'name', Caption: 'Наименование'}, {Name:'type', Caption: 'Тип данных C#'}, {Name:'caption', Caption: 'Отображаемое имя'}]} /> */}
                    </div>
                    <button className="w-100 btn btn-success" type="submit">Сохранить</button>
                </form>
            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={onHide}>
                    Отмена
                </Button>
                <Button variant="primary" onClick={onConfirm}>
                    Ок
                </Button>
            </Modal.Footer>
        </Modal>
    )
}