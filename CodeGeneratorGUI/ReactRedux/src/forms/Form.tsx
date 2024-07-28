
import React, { useState, ChangeEvent, FormEvent, useEffect } from 'react';
import { FormMetadata } from "../models/FormMetadata";
import FormMetadataService from "../services/FormMetadataService";
import {Table} from "../components/Table";


 interface FormProps {
   model: FormMetadata;
   onSave: (updatedUser: FormMetadata) => void;
 }
 
 const Form: React.FC<FormProps> = ({ model: user, onSave }) => {
   const [editedItem, setEditedItem] = useState<FormMetadata>({ ...user },);

   const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
     const { name, value } = e.target;
     setEditedItem({ ...editedItem, [name]: value });
   };

   const handleCheckBoxChange = (e: ChangeEvent<HTMLInputElement>) => {
    const { name, checked } = e.target;
    setEditedItem({ ...editedItem, [name]: checked });
  };

   const handleSubmit = (e: FormEvent) => {
     e.preventDefault();
     onSave(editedItem);
   };
 
   return (
     <form onSubmit={handleSubmit} className="form">
       <h1 className="h3 mb-3 fw-normal">Форма</h1>
           
      <div className="form-floating m-3">                
        <input name="name" className="form-control" id="floatingInputName" placeholder="Наименование" autocomplete="off" value={editedItem.name} onChange={ handleInputChange } />
        <label htmlFor="floatingInputName">Наименование</label>
      </div>

      <div className="form-floating m-3">                
        <input name="caption" className="form-control" id="floatingInputCaption" placeholder="Отображаемое имя" autocomplete="off" value={editedItem.caption} onChange={ handleInputChange } />
        <label htmlFor="floatingInputCaption">Отображаемое имя</label>
      </div>

      <div className="form-floating m-3">                
        <input name="description" className="form-control" id="floatingInputDescription" placeholder="Описание" autocomplete="off" value={editedItem.description} onChange={ handleInputChange } />
        <label htmlFor="floatingInputDescription">Описание</label>
      </div>

      <div className="form-check m-3">
        <input name="addToNavBar" className="form-check-input" type="checkbox" checked={editedItem.addToNavBar} id="flexCheckAddToNavBar" onChange={ handleCheckBoxChange } />
        <label className="form-check-label" htmlFor="flexCheckAddToNavBar">Добавить в панель навигации</label>
      </div>
         <button className="w-100 btn btn-success" type="submit">Сохранить</button>
     </form>
   );
 };



 export default Form;
  