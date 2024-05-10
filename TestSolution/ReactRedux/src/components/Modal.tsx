import { MouseEventHandler } from "react"
import { Modal, Button, Form, InputGroup, Row, Col } from 'react-bootstrap';

export interface IMessageBoxProps {
    onConfirm?: () => void,
    onHide?: () => void,
    title: string,
    text: string,
    show: boolean
}

export const MessageBox = (props: IMessageBoxProps) => {
    let { show, onConfirm, onHide, title, text } = props
    return (
        <Modal show={show} onHide={onHide}>
            <Modal.Header closeButton>
                <Modal.Title>{title}</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                {text}
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