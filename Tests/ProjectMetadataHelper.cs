﻿using CodeGenerator;
using CodeGenerator.Metadata;
using CodeGenerator.Projects;
using System.Diagnostics;

public static class ProjectMetadataHelper
{
    public static ProjectMetadata GeneratorProjectMetadata()
    {
        string nameSpace = "CodeGeneratorGUI";
        ProjectMetadata metadata = new ProjectMetadata();
        metadata.Name = "CodeGeneratorGUI";
        metadata.Description = "GUI for manage projects to gen";
        metadata.Path = @"..\..\..\..\Projects\CodeGeneratorGui";
        ModelMetadata modelMetadata = new ModelMetadata()
        {
            Name = "ModelMetadata",
            Caption = "Модель",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdModelMetadata", Caption = "ID", Type = "int", IsPrimaryKey = true, Visible = false},
                new PropMetadata() { Name = "Name", Caption = "Имя", Type = "string" },
                new PropMetadata() { Name = "InitData", Caption = "Начальные данные", Type = "string" },
                new PropMetadata() { Name = "NameSpace", Caption = "Пространство имен", Type = "string" },
                new PropMetadata() { Name = "Caption", Caption = "Отображаемое имя", Type = "string" },
                new PropMetadata { Name = "Props", Caption = "Свойства", Type = "ICollection<PropMetadata>", IsVirtual = true },
                new PropMetadata() { Name = "ProjectMetadata", Caption = "Проект", Type = "ProjectMetadata", IsVirtual = true}
            },
            InitData = @"[
  {
    ""Name"": ""ModelMetadata"",
    ""NameSpace"": ""CodeGeneratorGUI"",
    ""Caption"": ""Модель"",
    ""Props"": [
      {
        ""Name"": ""Name"",
        ""Type"": ""string"",
        ""Caption"": ""Имя""
      },
      {
        ""Name"": ""Description"",
        ""Type"": ""string"",
        ""Caption"": ""Описание""
      },
      {
        ""Name"": ""Id"",
        ""Type"": ""int"",
        ""Caption"": ""Идентификатор""
      }
    ]
  },
  {
    ""Name"": ""ProjectMetadata"",
    ""NameSpace"": ""CodeGeneratorGUI"",
    ""Caption"": ""Проект"",
    ""Props"": null
  },
  {
    ""Name"": ""FormMetadata"",
    ""NameSpace"": ""CodeGeneratorGUI"",
    ""Caption"": ""Форма"",
    ""Props"": null
  }
]"
        };
        ModelMetadata projectMetadata = new ModelMetadata()
        {
            Name = "ProjectMetadata",
            Caption = "Проект",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdProjectMetadata", Caption = "ID проекта", Type = "int", IsPrimaryKey = true , Visible = false},
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Description", Caption = "Описание", Type = "string" },
                new PropMetadata() { Name = "Path", Caption = "Путь", Type = "string"},
                new PropMetadata() { Name = "DbConnectionString", Caption = "Строка подключения к БД", Type = "string"},
                new PropMetadata() { Name = "UnitOfWork", Caption = "Объект работы с БД (MockUnit или EfUnit )", Type = "string"},
                new PropMetadata() { Name = "WebApiHttpsPort", Caption = "Порт для запуска WebApi", Type = "int"},
                new PropMetadata() { Name = "DevServerPort", Caption = "Порт для запуска WebPackDevServer", Type = "int"},
                new PropMetadata { Name = "Models", Caption = "Модели", Type = "ICollection<ModelMetadata>", IsVirtual = true},
                new PropMetadata { Name = "Forms", Caption = "Формы", Type = "ICollection<FormMetadata>", IsVirtual = true},
                new PropMetadata { Name = "EnumTypes", Caption = "Типы-перечисления", Type = "ICollection<EnumMetadata>", IsVirtual = true}
            }
        };
        ModelMetadata formMetadata = new ModelMetadata()
        {
            Name = "FormMetadata",
            Caption = "Форма",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdFormMetadata", Caption = "ID формы", Type = "int", IsPrimaryKey = true , Visible = false},
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Caption", Caption = "Отображаемое имя", Type = "string"},
                new PropMetadata() { Name = "Description", Caption = "Описание", Type = "string" },
                new PropMetadata() { Name = "AddToNavBar", Caption = "Добавить в панель навигации", Type = "bool"},
                new PropMetadata() { Name = "Components", Caption = "Компоненты формы", Type = "ICollection<ComponentMetadata>", IsVirtual = true},
                new PropMetadata() { Name = "ProjectMetadata", Caption = "Проект", Type = "ProjectMetadata", IsVirtual = true},
                new PropMetadata() { Name = "EditForm", Caption = "Форма редактирования", Type = "FormMetadata", IsVirtual = true, IsDictValueProp = true},
                new PropMetadata() { Name = "Model", Caption = "Модель", Type = "ModelMetadata", IsVirtual = true, IsDictValueProp = true}
            }
        };
        ModelMetadata propMetadata = new ModelMetadata()
        {
            Name = "PropMetadata",
            Caption = "Свойство",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdPropMetadata", Caption = "ID свойства", Type = "int", IsPrimaryKey = true , Visible = false},
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Type", Caption="Тип данных C#", Type = "string"},
                new PropMetadata() { Name = "Caption", Caption="Отображаемое имя", Type = "string" },
                new PropMetadata() { Name = "ModelMetadata", Caption="Модель", Type = "ModelMetadata", IsVirtual = true  },
                new PropMetadata() { Name = "IsPrimaryKey", Caption="Первичный ключ", Type = "bool" },
                new PropMetadata() { Name = "IsEnum", Caption="Свойство перечисления", Type = "bool" },
                new PropMetadata() { Name = "IsVirtual", Caption="Свойство внешней связи", Type = "bool" },
                new PropMetadata() { Name = "Visible", Caption="Отображать свойство в интерфейсе", Type = "bool" },
                new PropMetadata() { Name = "Editable", Caption="Доступ к редактированию поля", Type = "bool" },
                new PropMetadata() { Name = "JsonIgnore", Caption="Не передавать на клиент", Type = "bool" },
                new PropMetadata() { Name = "IsEnumerable", Caption="Перечисление", Type = "bool", Visible = false },
                new PropMetadata() { Name = "IsMasterProp", Caption="Ссылка на мастера", Type = "bool", Visible = false },
                new PropMetadata() { Name = "IsDetailsProp", Caption="Детейл", Type = "bool", Visible = false },
                new PropMetadata() { Name = "IsDictValueProp", Caption="Значение из справочника", Type = "bool", Visible = false }
            }
        };
        ModelMetadata componentMetadata = new ModelMetadata()
        {
            Name = "ComponentMetadata",
            Caption = "Компонент формы",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdComponentMetadata", Caption = "ID компонента формы", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Caption", Caption="Отображаемое имя", Type = "string" },
                new PropMetadata() { Name = "Description", Caption="Описание", Type = "string" },
                new PropMetadata() { Name = "Type", Caption="Тип данных C#", Type = "string"},
                new PropMetadata() { Name = "ModelPropMetadata", Caption="Свойство Модели для которого используется компонент", Type = "PropMetadata", IsVirtual = true  },
                new PropMetadata() { Name = "Props", Caption="Используется для табличных компонентов для передачи списка свойств и их подписей", Type = "ICollection<PropMetadata>", IsVirtual = true  },
                new PropMetadata() { Name = "ModelProp", Caption="Компонент свойства модели", Type = "bool"},
                new PropMetadata() { Name = "FormMetadata", Caption = "Форма", Type = "FormMetadata", IsVirtual = true}
            }
        };
        ModelMetadata enumMetadata = new ModelMetadata()
        {
            Name = "EnumMetadata",
            Caption = "Тип-перечисление",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdEnumMetadata", Caption = "ID типа-перечисления", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Caption", Caption="Отображаемое имя", Type = "string" },
                new PropMetadata() { Name = "Values", Caption="Значения типа-перечисления", Type = "ICollection<EnumValueMetadata>", IsVirtual = true  },
                new PropMetadata() { Name = "ProjectMetadata", Caption = "Проект", Type = "ProjectMetadata", IsVirtual = true}
            }
        };

        ModelMetadata enumValueMetadata = new ModelMetadata()
        {
            Name = "EnumValueMetadata",
            Caption = "Значение типа-перечисления",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdEnumValueMetadata", Caption = "ID значения типа-перечисления", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Caption", Caption="Отображаемое имя", Type = "string" },
                new PropMetadata() { Name = "EnumMetadata", Caption = "Тип-перечисление", Type = "EnumMetadata", IsVirtual = true}

            }
        };
        metadata.Models = new List<ModelMetadata> {
            modelMetadata,
            projectMetadata,
            formMetadata,
            propMetadata,
            componentMetadata,
            enumMetadata,
            enumValueMetadata
        };

        metadata.Forms = MetadataHelper.AutoCreateFormMetadata(metadata);

        return metadata;
    }

    public static ProjectMetadata ComplectationArmProjectMetadata()
    {
        string nameSpace = "ComplectationArm";
        ProjectMetadata metadata = new ProjectMetadata();
        metadata.Name = "ComplectationArm";
        metadata.Description = "АРМ комплектовщика Web";
        metadata.Path = @"..\..\..\..\..\std.gencode\ComplectationArm";
        ModelMetadata delivDocModelMetadata = new ModelMetadata()
        {
            Name = "DelivDoc",
            Caption = "Рейс",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "Имя", Type = "string" },
                    new PropMetadata() { Name = "IdDelivDoc", Caption = "ID", Type = "int" },
                    new PropMetadata() { Name = "Destanation", Caption = "Маршрут", Type = "string" },
                    new PropMetadata() { Name = "IdDestanation", Caption = "ID маршрута", Type = "int" },
                    new PropMetadata() { Name = "State", Caption = "Готовность", Type = "string" }
                }
        };

        ModelMetadata orderModelMetadata = new ModelMetadata()
        {
            Name = "Order",
            Caption = "Заказ",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "Имя", Type = "string" },
                    new PropMetadata() { Name = "IdOrder", Caption = "ID", Type = "int" },
                    new PropMetadata() { Name = "Destanation", Caption = "Маршрут", Type = "string" },
                    new PropMetadata() { Name = "IdDestanation", Caption = "ID маршрута", Type = "int" }
                }
        };
        ModelMetadata complectationModelMetadata = new ModelMetadata()
        {
            Name = "Complectation",
            Caption = "Комплектация",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                    new PropMetadata() { Name = "BoxOperName", Caption = "Тип комплектации", Type = "string"},
                    new PropMetadata() { Name = "IdBoxOper", Caption = "ID типа комплектации", Type = "int"},
                    new PropMetadata() { Name = "IdBox", Caption = "ID", Type = "int"},
                    new PropMetadata() { Name = "Num", Caption = "Номер", Type = "int"}
                }
        };

        metadata.Models = new List<ModelMetadata> {
                delivDocModelMetadata,
                complectationModelMetadata,
                orderModelMetadata
            };
        metadata.Forms = new List<FormMetadata>
            {
                new FormMetadata()
                {
                    Name = "ComplectationListForm",
                    Caption = "Комплектации",
                    Model = complectationModelMetadata,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Complectations", Caption = "Комплектации", Type = "Table", Props = complectationModelMetadata.Props  }
                    },
                    EditForm = new FormMetadata()
                    {
                        Name = "ComplectationEditForm",
                        Caption = "Комплектация",
                        Model = complectationModelMetadata,
                        Components = new ComponentMetadata[] {
                            new ComponentMetadata() { Name = "Name", Caption = "Наименование", Type = "Input"  },
                            //new ComponentMetadata() { Name = "Positions", Caption = "Свойства", Type = "Table", Props = complectationModelMetadata.Props },
                            new ComponentMetadata() { Type = "SubmitButton"  }
                        }
                    }

                },
                new FormMetadata()
                {
                    Name = "DelivDocs",
                    Caption = "Рейсы",
                    Model = delivDocModelMetadata,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Date", Caption = "", Type = "DateTime", ModelProp = false },
                        new ComponentMetadata() { Name = "DelivDocs", Caption = "Рейсы", Type = "Table", Props = delivDocModelMetadata.Props  }
                    }
                },
                new FormMetadata()
                {
                    Name = "Orders",
                    Caption = "Заказы",
                    Model = orderModelMetadata,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Orders", Caption = "Заказы", Type = "Table", Props = orderModelMetadata.Props  }
                    }
                }
            };


        return metadata;
    }


    public static ProjectMetadata RemakeArmProjectMetadata()
    {
        string nameSpace = "RemakeArm";
        ProjectMetadata metadata = new ProjectMetadata();
        metadata.Name = "RemakeArm";
        metadata.Description = "АРМ передельщика Web";
        metadata.Path = @"..\..\..\..\..\RemakeArm";
        ModelMetadata orderitemModelMetadata = new ModelMetadata()
        {
            Name = "RemakeOrderItem",
            Caption = "Позиция",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Order", Caption = "Заказ", Type = "string" },
                    new PropMetadata() { Name = "IdOrder", Caption = "ID заказа", Type = "int" },
                    new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                    new PropMetadata() { Name = "OrderItemNum", Caption = "Номер позиции в заказе", Type = "int" },
                    new PropMetadata() { Name = "IdOrderItem", Caption = "ID позиции заказа", Type = "int" },
                    new PropMetadata() { Name = "ProfileSystem", Caption = "Профильная система", Type = "string" },
                    new PropMetadata() { Name = "IdProfileSystem", Caption = "ID профильной системы", Type = "int" },
                    new PropMetadata() { Name = "FurnSystem", Caption = "Фурнитурная система", Type = "string" },
                    new PropMetadata() { Name = "IdFurnSystem", Caption = "ID фурнитурной системы", Type = "int" },
                    new PropMetadata() { Name = "IdColorOut", Caption = "ID внешнего цвета", Type = "int" },
                    new PropMetadata() { Name = "IdColorIn", Caption = "ID внутреннего цвета", Type = "int" },
                    new PropMetadata() { Name = "ColorOut", Caption = "Цвет внутренний", Type = "string" },
                    new PropMetadata() { Name = "ColorIn", Caption = "Цвет внешний", Type = "string" },
                    new PropMetadata() { Name = "Sign", Caption = "Статус", Type = "string" },
                    new PropMetadata() { Name = "IdSign", Caption = "ID статуса", Type = "int" },
                    new PropMetadata() { Name = "SignDate", Caption = "Время статуса", Type = "DateTime" },
                    new PropMetadata() { Name = "Picture", Caption = "Чертеж", Type = "Image" }
                }
        };

        ModelMetadata orderModelMetadata = new ModelMetadata()
        {
            Name = "RemakeOrder",
            Caption = "Переделка",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "Имя", Type = "string" },
                    new PropMetadata() { Name = "IdOrder", Caption = "ID", Type = "int" },
                    new PropMetadata() { Name = "ServiceReason", Caption = "Причина брака", Type = "string" },
                    new PropMetadata() { Name = "IdServiceReason", Caption = "ID причины брака", Type = "int" },
                    new PropMetadata() { Name = "Comment", Caption = "Комментарий", Type = "string" },
                    new PropMetadata() { Name = "Picture", Caption = "Чертеж", Type = "Image" }
                }
        };
        ModelMetadata materialModelMetadata = new ModelMetadata()
        {
            Name = "Material",
            Caption = "Материал",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                    new PropMetadata() { Name = "BoxOperName", Caption = "Тип комплектации", Type = "string"},
                    new PropMetadata() { Name = "IdBoxOper", Caption = "ID типа комплектации", Type = "int"},
                    new PropMetadata() { Name = "IdBox", Caption = "ID", Type = "int"},
                    new PropMetadata() { Name = "Num", Caption = "Номер", Type = "int"}
                }
        };

        metadata.Models = new List<ModelMetadata> {
                orderitemModelMetadata,
                materialModelMetadata,
                orderModelMetadata
            };
        metadata.Forms = new List<FormMetadata>
            {
                new FormMetadata()
                {
                    Name = "RemakeOrderListForm",
                    Caption = "Переделки",
                    Model = orderModelMetadata,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "RemakeOrders", Caption = "Переделки", Type = "Table", Props = orderModelMetadata.Props  }
                    },
                    EditForm = new FormMetadata()
                    {
                        Name = "RemakeOrderEditForm",
                        Caption = "Переделкa",
                        Model = orderModelMetadata,
                        Components = new ComponentMetadata[] {
                            new ComponentMetadata() { Name = "Name", Caption = "Наименование", Type = "Input"  },
                            new ComponentMetadata() { Name = "Comment", Caption = "Комментарий", Type = "Input" },
                            //new ComponentMetadata() { Name = "Positions", Caption = "Свойства", Type = "Table", Props = complectationModelMetadata.Props },
                            new ComponentMetadata() { Type = "SubmitButton"  }
                        }
                    }

                }
            };


        return metadata;
    }


    public static ProjectMetadata TestProjectMetadata()
    {
        ProjectMetadata metadata = new ProjectMetadata();
        metadata.Name = "TestSoloution";
        metadata.Description = "Solution for testing generator when development";
        metadata.Path = "./TestSolution";
        ModelMetadata modelMetadata1 = new ModelMetadata()
        {
            Name = "TestModel1",
            Caption = "Тестовая модель 1",
            NameSpace = "TestNamespace",
            Props = new List<PropMetadata>()
                    {
                        new PropMetadata()
                        {
                            Name = "Name",
                            Type = "string"
                        },
                        new PropMetadata()
                        {
                            Name =  "Description",
                            Type = "string"
                        },
                        new PropMetadata()
                        {
                            Name =  "Id",
                            Type = "int"
                        }
                    }

        };
        ModelMetadata modelMetadata2 = new ModelMetadata()
        {
            Name = "DebugUnit",
            Caption = "Едиица отладки",
            NameSpace = "TestNamespace",
            Props = new List<PropMetadata>()
                    {
                        new PropMetadata()
                        {
                            Name = "Name",
                            Type = "string"
                        },
                        new PropMetadata()
                        {
                            Name =  "Id",
                            Type = "int"
                        },
                        new PropMetadata()
                        {
                            Name =  "Count",
                            Type = "int?"
                        },
                        new PropMetadata()
                        {
                            Name =  "Date",
                            Type = "DateTime"
                        }
                    }

        };
        metadata.Models = new List<ModelMetadata> {
                modelMetadata1,
                modelMetadata2
            };
        metadata.Forms = new List<FormMetadata>
            {
                new FormMetadata()
                {
                    Name = "TestModelList",
                    Caption = "Тестовые модели",
                    Model = modelMetadata1,
                    AddToNavBar = true
                }
            };

        return metadata;
    }

    public static ProjectMetadata ProjectMetadataCorp()
    {
        string nameSpace = "Corp";
        ProjectMetadata metadata = new ProjectMetadata();
        metadata.Name = "Corp";
        metadata.Description = "GUI for Corp";
        metadata.Path = @"..\..\..\..\Projects\std.gencode\Corp";
        metadata.DbConnectionString = @"Password=ggdhHGHGKdgett3563@#;Persist Security Info=True;User ID=windraw-dbo;Initial Catalog=corp;Data Source=sql-wd-01.corp.lan;";
        metadata.UnitOfWork = "EfUnit";
        ModelMetadata characteristicValueMetadata = new ModelMetadata()
        {
            Name = "CharacteristicValue",
            Caption = "Значение характеристики",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdCharacteristicValue", Caption = "ID Характеристики", Type = "int", IsPrimaryKey = true, Visible = false},
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Characteristic", Caption = "ID Характеристики", Type = "Characteristic", IsVirtual=true,  },
            }
        };
        ModelMetadata characteristicMetadata = new ModelMetadata()
        {
            Name = "Characteristic",
            Caption = "Характеристика",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdCharacteristic", Caption = "ID Характеристики", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
            }
        };
        ModelMetadata characteristicObjMetadata = new ModelMetadata()
        {
            Name = "CharacteristicObj",
            Caption = "Характеристика объекта",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdCharacteristicObj", Caption = "Id характеристики объекта", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Number", Caption = "Число", Type = "int"},
                new PropMetadata() { Name = "String", Caption = "Строка", Type = "string" },
                new PropMetadata() { Name = "Characteristic", Caption = "Id характеристики", Type = "Characteristic", IsVirtual= true, IsDictValueProp = true  },
                new PropMetadata() { Name = "CharacteristicValue", Caption = "Значение характеристики", Type = "CharacteristicValue", IsVirtual= true, IsDictValueProp = true  },
                new PropMetadata() { Name = "Agreement", Caption = "Id соглашения", Type = "Agreement", IsVirtual=true, JsonIgnore = true  },
            }
        };

        ModelMetadata agreementMetadata4 = new ModelMetadata()
        {
            Name = "Agreement",
            Caption = "Договор, Соглашение",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdAgreement", Caption = "Id соглашения", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Number", Caption="Номер", Type = "int"},
                new PropMetadata() { Name = "Type", Caption="Тип", Type = "string"},
                new PropMetadata() { Name = "Link", Caption="Ссылка", Type = "string"},
                new PropMetadata() { Name = "Summ", Caption="Сумма", Type = "decimal" },
                new PropMetadata() { Name = "PrePayment", Caption="Сумма аванса, руб", Type = "decimal" },
                new PropMetadata() { Name = "TimePayKc2", Caption="Срок оплаты по КС2, дней после подписания", Type = "DateTime" },
                new PropMetadata() { Name = "WarrantyRetention", Caption="Гарантийные удержания, %от суммы КС2", Type = "decimal" },
                new PropMetadata() { Name = "StartDate", Caption = "Дата начала работ", Type = "DateTime" },
                new PropMetadata() { Name = "FinishDate", Caption="Дата окончания работ", Type = "DateTime"},
                new PropMetadata() { Name = "ReturtDateWarranty", Caption="Дата возврата гарантийных", Type = "DateTime" },
                new PropMetadata() { Name = "FinishObj", Caption="Завершение объекта, документ", Type = "string" }, //Не совсем опнял, что тут будет прям документ или что-то еще
                new PropMetadata() { Name = "PriceUp", Caption="Наценка", Type = "decimal" },
                new PropMetadata() { Name = "Obj", Caption = "Id объекта", Type = "Obj", IsVirtual = true, JsonIgnore=true },
                new PropMetadata() { Name = "ConstructionObj", Caption = "Id подрядчика", Type = "ConstructionObj", IsVirtual = true, IsDictValueProp = true },
                new PropMetadata() { Name = "Characteristics", Caption="Характеристики", Type = "ICollection<CharacteristicObj>", IsVirtual = true },
                new PropMetadata() { Name = "Kc", Caption="KC", Type = "ICollection<Kc>", IsVirtual = true },
            }
        };

        ModelMetadata objMetadata = new ModelMetadata()
        {
            Name = "Obj",
            Caption = "Объект",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdObj", Caption = "Id Объекта", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Number", Caption="Номер", Type = "int"},
                new PropMetadata() { Name = "NumberFolder", Caption="Номер Папки", Type = "int"},
                new PropMetadata() { Name = "Address", Caption="Адрес", Type = "string" },
                new PropMetadata() { Name = "NameObj", Caption="Наименование объекта", Type = "string" },
                new PropMetadata() { Name = "Agent", Caption="Контрагент", Type = "Agent", IsVirtual = true, IsDictValueProp = true  },
                new PropMetadata() { Name = "People", Caption="Пользователь", Type = "People", IsVirtual = true, IsDictValueProp = true },
                new PropMetadata() { Name = "Status", Caption="Статус Сделки", Type = "string" },
                new PropMetadata() { Name = "Gpr", Caption="ГПР", Type = "ICollection<Gpr>", IsVirtual = true },
                new PropMetadata() { Name = "Indicators", Caption="Показатели", Type = "ICollection<Indicator>", IsVirtual = true },
                new PropMetadata() { Name = "Agreement", Caption="Соглашения", Type = "ICollection<Agreement>", IsVirtual = true },

            }
        };

        ModelMetadata constructionObjMetadata = new ModelMetadata()
        {
            Name = "ConstructionObj",
            Caption = "Подрядчик",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdConstructionObj", Caption = "Id номенклатуры объекта", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
            }
        };

        ModelMetadata agentMetadata = new ModelMetadata()
        {
            Name = "Agent",
            Caption = "Контрагент",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdAgent", Caption = "Id контрагента", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Code1c", Caption = "Код контрагента из 1с", Type = "string" },
            }
        };

        ModelMetadata peopleMetadata = new ModelMetadata()
        {
            Name = "People",
            Caption = "Пользователь",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdPeople", Caption = "Id Пользователя", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
            }
        };

        ModelMetadata indicatorMetadata = new ModelMetadata()
        {
            Name = "Indicator",
            Caption = "Показатели объекта",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdIndicator", Caption = "Id показателя объекта", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "PlanSumm", Caption = "Плановая стоимость", Type = "decimal" },
                new PropMetadata() { Name = "FactSumm", Caption = "Фактическая стоимость", Type = "decimal" },
                new PropMetadata() { Name = "Date", Caption="Дата", Type = "DateTime"},
                new PropMetadata() { Name = "NameIndicator", Caption = "Показатель", Type = "NameIndicator", IsVirtual= true, IsDictValueProp = true },
                new PropMetadata() { Name = "Obj", Caption = "Объект", Type = "Obj", IsVirtual= true, JsonIgnore = true },
            }
        };

        ModelMetadata nameIndicatorMetadata = new ModelMetadata()
        {
            Name = "NameIndicator",
            Caption = "Показатель",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdNameIndicator", Caption = "Id показателя", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "TypeUpdateData", Caption = "Тип обновления данных", Type = "UpdateDataTypeEnum", IsEnum = true },
                new PropMetadata() { Name = "TypeIndicator", Caption = "Тип показателя", Type = "IndicatorTypeEnum", IsEnum = true },
            }
        };

        ModelMetadata gprMetadata = new ModelMetadata()
        {
            Name = "Gpr",
            Caption = "ГПР",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdGpr", Caption = "Id показателя", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string"},
                new PropMetadata() { Name = "PlanPercent", Caption = "План процент", Type = "decimal" },
                new PropMetadata() { Name = "FactPercent", Caption = "Факт процент", Type = "decimal" },
                new PropMetadata() { Name = "Plan", Caption = "План", Type = "decimal" },
                new PropMetadata() { Name = "Fact", Caption = "Факт", Type = "decimal" },
                new PropMetadata() { Name = "Lag", Caption = "Отставание", Type = "string"},
                new PropMetadata() { Name = "TypeWork", Caption = "Вид работ", Type = "TypeWork", IsVirtual=true, IsDictValueProp = true },
                new PropMetadata() { Name = "Obj", Caption = "Id объекта", Type = "Obj", IsVirtual = true, JsonIgnore = true },
            }
        };

        ModelMetadata typeWorkMetadata = new ModelMetadata()
        {
            Name = "TypeWork",
            Caption = "Виды работ",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdTypeWork", Caption = "Id Вида работ", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Measure", Caption = "Единица измерения", Type = "string" },
            }
        };

        ModelMetadata kcMetadata = new ModelMetadata()
        {
            Name = "Kc",
            Caption = "KC",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdKc", Caption = "Id KC", Type = "int", IsPrimaryKey = true, Visible = false },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "DateSubmission", Caption = "Дата Подачи", Type = "DateTime" },
                new PropMetadata() { Name = "PlanSumm", Caption = "План Суммы", Type = "decimal" },
                new PropMetadata() { Name = "FactSumm", Caption = "Факт Суммы", Type = "decimal" },
                new PropMetadata() { Name = "Status", Caption = "Статус", Type = "string" },
                new PropMetadata() { Name = "DateGet", Caption = "Дата прихода подписанной КС", Type = "DateTime" },
                new PropMetadata() { Name = "Agreement", Caption = "Id соглашения", Type = "Agreement", IsVirtual = true, JsonIgnore = true },
                new PropMetadata() { Name = "Payment", Caption="Платежи", Type = "ICollection<Payment>", IsVirtual = true },
            }
        };

        ModelMetadata paymentMetadata = new ModelMetadata()
        {
            Name = "Payment",
            Caption = "Платежи",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdPayment", Caption = "Id Вида работ", Type = "int", IsPrimaryKey = true, Visible = false},
                new PropMetadata() { Name = "PlanDate", Caption = "Дата план", Type = "DateTime" },
                new PropMetadata() { Name = "FactDate", Caption = "Дата факт", Type = "DateTime" },
                new PropMetadata() { Name = "PlanSumm", Caption = "План Суммы", Type = "decimal" },
                new PropMetadata() { Name = "FactSumm", Caption = "Факт Суммы", Type = "decimal" },
                new PropMetadata() { Name = "Kc", Caption = "KC", Type = "Kc", IsVirtual=true },
            }
        };

        metadata.Models = new List<ModelMetadata> {
            characteristicValueMetadata,
            characteristicMetadata,
            characteristicObjMetadata,
            agreementMetadata4,
            objMetadata,
            constructionObjMetadata,
            agentMetadata,
            peopleMetadata,
            indicatorMetadata,
            nameIndicatorMetadata,
            gprMetadata,
            typeWorkMetadata,
            kcMetadata,
            paymentMetadata
        };

        EnumMetadata indicatorTypeEnum = new EnumMetadata()
        {
            Name = "IndicatorTypeEnum",
            Caption = "Тип индикатора",
            Values = new List<EnumValueMetadata>()
            {
                new EnumValueMetadata() {
                    IdEnumValueMetadata = 1,
                    Name = "CostPrice",
                    Caption = "Себестоимость"
                },
                new EnumValueMetadata() {
                    IdEnumValueMetadata = 2,
                    Name = "Earnings",
                    Caption = "Выручка"
                }
            }
        };

        EnumMetadata updateDataTypeEnum = new EnumMetadata()
        {
            Name = "UpdateDataTypeEnum",
            Caption = "Тип обновления данных",
            Values = new List<EnumValueMetadata>()
            {
                new EnumValueMetadata() {
                    IdEnumValueMetadata = 1,
                    Name = "Overwriting",
                    Caption = "Перезапись"
                },
                new EnumValueMetadata() {
                    IdEnumValueMetadata = 2,
                    Name = "ManualInput",
                    Caption = "Ручной ввод"
                }
            }
        };

        metadata.EnumTypes = new List<EnumMetadata>() { indicatorTypeEnum, updateDataTypeEnum };

        metadata.Forms = MetadataHelper.AutoCreateFormMetadata(metadata);

        return metadata;
    }

}