# CodeGenerator

CodeGenerator for .ts react, .cs webapi files

## Генерация

При генерации сущностей поле для ID объекта формирутся автоматически в формате id[ModelName] целочисленный тип int для генерации поле с типом IDENTITY (автоматическое присвоение ID при создании)

### Скрипт обновления БД

Для виртуальных полей модели создаются ссылки на таблицу типа - ограничения на вторичный ключ

### Замена текста

При копировнии файлов шаблоных проектов, производится замена текста на основании метеданных проекта:
- `"TemplateProjectName"` -> `ProjectMetadata.Name`
- `"DefaultConnectionString"` -> `ProjectMetadata.DbConnectionString`
- `"TemplateProjectNamespace"` -> `ProjectMetadata.Namespace`
- `"TemplateProjectCaption"` -> `ProjectMetadata.Caption`
- `"TemplateProjectWebApiPort"` -> `ProjectMetadata.WebApiHttpsPort`
- `"TemplateProjectDevServerPort"` -> `ProjectMetadata.DevServerPort`