
import React, { useState, ChangeEvent, FormEvent, useEffect } from 'react';
import { ModelMetadata } from "../models/ModelMetadata";
import ModelMetadataService from "../services/ModelMetadataService";
import {Table} from "../components/Table";


 interface ModelProps {
   model: ModelMetadata;
   onSave: (updatedUser: ModelMetadata) => void;
 }
 
 const Model: React.FC<ModelProps> = ({ model: user, onSave }) => {
   const [editedItem, setEditedItem] = useState<ModelMetadata>({ ...user },);

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
       <h1 className="h3 mb-3 fw-normal">Модель</h1>
           
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



 export default Model;
  