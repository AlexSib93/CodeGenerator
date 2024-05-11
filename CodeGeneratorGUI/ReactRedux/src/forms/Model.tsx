import React, { useState, ChangeEvent, FormEvent, useEffect } from 'react';
import { ModelMetadata } from "../models/ModelMetadata";
import ModelMetadataService from "../services/ModelMetadataService";

 interface EditFormProps {
   model: ModelMetadata;
   onSave: (updatedUser: ModelMetadata) => void;
 }
 
 const EditForm: React.FC<EditFormProps> = ({ model: user, onSave }) => {
   const [editedUser, setEditedUser] = useState<ModelMetadata>({ ...user },);

   const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
     const { name, value } = e.target;
     setEditedUser({ ...editedUser, [name]: value });
   };
 
   const handleSubmit = (e: FormEvent) => {
     e.preventDefault();
     onSave(editedUser);
   };
 
   return (
     <form onSubmit={handleSubmit} className="form">
       <h1 className="h3 mb-3 fw-normal">Модель</h1>
            <div className="form-floating">
                <input name="name" className="form-control" id="floatingInput1" placeholder="Имя" value={editedUser.name}
                    onChange={ handleInputChange}
                />
                <label htmlFor="floatingInput1">Имя</label>
            </div>      
            <div className="form-floating">
                <input name="caption" className="form-control" id="floatingInput2" placeholder="Видимое имя" value={editedUser.caption}
                    onChange={ handleInputChange}
                />
                <label htmlFor="floatingInput2">Видимое имя</label>
            </div>      
            <div className="form-floating">
                <input name="nameSpace" className="form-control" id="floatingInput3" placeholder="Пространствоо имен" value={editedUser.nameSpace}
                    onChange={ handleInputChange}
                />
                <label htmlFor="floatingInput3">Пространствоо имен</label>
            </div>      
            
            <button className="w-100 btn btn-lg btn-primary" type="submit">Сохранить</button>
     </form>
   );
 };
 
 export default EditForm;