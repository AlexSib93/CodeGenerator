
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
 
   const handleSubmit = (e: FormEvent) => {
     e.preventDefault();
     onSave(editedItem);
   };
 
   return (
     <form onSubmit={handleSubmit} className="form">
       <h1 className="h3 mb-3 fw-normal">Модель</h1>
           
      <div className="form-floating m-3">                
        <input name="name" className="form-control" id="floatingInputName" placeholder="Наименование" value={editedItem.name} onChange={ handleInputChange} />
        <label htmlFor="floatingInputName">Наименование</label>
      </div>

      <div className="form-floating m-3">                
        <input name="nameSpace" className="form-control" id="floatingInputNameSpace" placeholder="Пространство имен" value={editedItem.nameSpace} onChange={ handleInputChange} />
        <label htmlFor="floatingInputNameSpace">Пространство имен</label>
      </div>

      <div className="form-floating m-3">                
        <input name="caption" className="form-control" id="floatingInputCaption" placeholder="Отображаемое имя" value={editedItem.caption} onChange={ handleInputChange} />
        <label htmlFor="floatingInputCaption">Отображаемое имя</label>
      </div>
      <div className="m-3">    
       <h1 className="h4 mt-4 fw-normal">Свойства</h1>
       <Table items={editedItem.props} props={[{Name:'name', Caption: 'Наименование'}, {Name:'type', Caption: 'Тип данных C#'}, {Name:'caption', Caption: 'Отображаемое имя'}]} />
      </div>
         <button className="w-100 btn btn-success" type="submit">Сохранить</button>
     </form>
   );
 };



 export default Model;
  