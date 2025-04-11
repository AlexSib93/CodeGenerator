using CodeGenerator;
using CodeGenerator.Metadata;
using CodeGenerator.Projects;
using System.Diagnostics;

internal static class ProjectMetadataHelper
{
    public static ProjectMetadata GeneratorProjectMetadata()
    {
        string nameSpace = "CodeGeneratorGUI";
        ProjectMetadata metadata = new ProjectMetadata();
        metadata.Name = "CodeGeneratorGUI";
        metadata.Description = "GUI for manage projects to gen";
        metadata.Path = @"..\..\..\..\CodeGeneratorGUI";
        ModelMetadata modelMetadata1 = new ModelMetadata()
        {
            Name = "ModelMetadata",
            Caption = "Модель",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "PrimaryKey", Caption = "ID", Type = "boolean"},
                    new PropMetadata() { Name = "Name", Caption = "Имя", Type = "string" },
                    new PropMetadata() { Name = "NameSpace", Caption = "Пространство имен", Type = "string" },
                    new PropMetadata() { Name = "Caption", Caption = "Отображаемое имя", Type = "string" },
                    new PropMetadata { Name = "Props", Caption = "Свойства", Type = "List<PropMetadata>" }
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
        ModelMetadata modelMetadata2 = new ModelMetadata()
        {
            Name = "ProjectMetadata",
            Caption = "Проект",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                    new PropMetadata() { Name = "Description", Caption = "Описание", Type = "string" },
                    new PropMetadata() { Name = "Path", Caption = "Путь", Type = "string"},
                    new PropMetadata { Name = "Models", Caption = "Модели", Type = "List<ModelMetadata>" },
                    new PropMetadata { Name = "Forms", Caption = "Формы", Type = "List<FormMetadata>" }
                }
        };
        ModelMetadata modelMetadata3 = new ModelMetadata()
        {
            Name = "FormMetadata",
            Caption = "Форма",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                    new PropMetadata() { Name =  "Caption", Caption = "Отображаемое имя", Type = "string"},
                    new PropMetadata() { Name =  "Description", Caption = "Описание", Type = "string" },
                    new PropMetadata() { Name =  "AddToNavBar", Caption = "Добавить в панель навигации", Type = "bool"}
                    //new PropMetadata() { Name = "Components", Caption = "Формы", Type = "List<ComponentMetadata>" }
                    //public IEnumerable<ComponentMetadata> Components { get; set; }
                }
        };
        ModelMetadata modelMetadata4 = new ModelMetadata()
        {
            Name = "PropMetadata",
            Caption = "Свойство",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                    new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                    new PropMetadata() { Name =  "Type", Caption="Тип данных C#", Type = "string"},
                    new PropMetadata() { Name =  "Caption", Caption="Отображаемое имя", Type = "string" },
                }
        };
        metadata.Models = new List<ModelMetadata> {
                modelMetadata1,
                modelMetadata2,
                modelMetadata3,
                modelMetadata4
            };
        metadata.Forms = new List<FormMetadata>
            {
                new FormMetadata()
                {
                    Name = "Projects",
                    Caption = "Проекты",
                    Model = modelMetadata2,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Projects", Caption = "Проекты", Type = "Table", Props = modelMetadata2.Props }
                    }
                },
                new FormMetadata()
                {
                    Name = "Models",
                    Caption = "Модели",
                    Model = modelMetadata1,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Models", Caption = "Модели", Type = "Table", Props = modelMetadata1.Props }
                    },
                    EditForm = new FormMetadata()
                    {
                        Name = "Model",
                        Caption = "Модель",
                        Model = modelMetadata1,
                        Components = new ComponentMetadata[] {
                            new ComponentMetadata() { Name = "Name", Caption = "Наименование", Type = "Input" },
                            new ComponentMetadata() { Name = "NameSpace", Caption = "Пространство имен", Type = "Input" },
                            new ComponentMetadata() { Name = "Caption", Caption = "Отображаемое имя", Type = "Input" },
                            new ComponentMetadata() { Name = "Props", Caption = "Свойства", Type = "Table", Props = modelMetadata4.Props },
                            new ComponentMetadata() { Type = "SubmitButton" }
                        }
                    }
                },
                new FormMetadata()
                {
                    Name = "Forms",
                    Caption = "Формы",
                    Model = modelMetadata3,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Forms", Caption = "Формы", Type = "Table", Props = modelMetadata3.Props }
                    },
                    EditForm = new FormMetadata()
                    {
                        Name = "Form",
                        Caption = "Форма",
                        Model = modelMetadata3,
                        Components = new ComponentMetadata[] {
                            new ComponentMetadata() { Name = "Name", Caption = "Наименование", Type = "Input" },
                            new ComponentMetadata() { Name = "Caption", Caption = "Отображаемое имя", Type = "Input" },
                            new ComponentMetadata() { Name = "Description", Caption = "Описание", Type = "Input" },
                            new ComponentMetadata() { Name = "AddToNavBar", Caption = "Добавить в панель навигации", Type = "CheckBox" },
                            new ComponentMetadata() { Type = "SubmitButton"  }
                        }
                    }
                }
            };


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
        metadata.Description = "GUI for manage projects to gen";
        metadata.Path = @"..\..\..\..\Corp";
        metadata.DbConnectionString = @"Password=ggdhHGHGKdgett3563@#;Persist Security Info=True;User ID=windraw-dbo;Initial Catalog=corp;Data Source=sql-wd-01.corp.lan;";
        metadata.UnitOfWork = "EfUnit";
        ModelMetadata modelMetadata1 = new ModelMetadata()
        {
            Name = "CharacteristicValue",
            Caption = "Значение характеристики",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdCV", Caption = "ID Характеристики", Type = "int", IsPrimaryKey = true},
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "Characteristic", Caption = "Наименование", Type = "int" },
            }
        };
        ModelMetadata modelMetadata2 = new ModelMetadata()
        {
            Name = "Characteristic",
            Caption = "Характеристика",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdCV", Caption = "ID Характеристики", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
            }
        };
        ModelMetadata modelMetadata3 = new ModelMetadata()
        {
            Name = "CharacteristicObj",
            Caption = "Характеристика объекта",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdCO", Caption = "Id характеристики объекта", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Number", Caption = "Число", Type = "int"},
                new PropMetadata() { Name = "String", Caption = "Строка", Type = "string" },
                new PropMetadata() { Name = "IdCharacteristic", Caption = "Id характеристики", Type = "int" },
                new PropMetadata() { Name = "IdAgreement", Caption = "Id соглашения", Type = "int" },
            }
        };

        ModelMetadata modelMetadata4 = new ModelMetadata()
        {
            Name = "Agreement",
            Caption = "Договор, Соглашение",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdAgreement", Caption = "Id соглашения", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Number", Caption="Номер", Type = "int"},
                new PropMetadata() { Name = "Summ", Caption="Сумма", Type = "decimal" },
                new PropMetadata() { Name = "PrePayment", Caption="Сумма аванса, руб", Type = "decimal" },
                new PropMetadata() { Name = "TimePayKC2", Caption="Срок оплаты по КС2, дней после подписания", Type = "DateTime" },
                new PropMetadata() { Name = "WarrantyRetention", Caption="Гарантийные удержания, %от суммы КС2", Type = "decimal" },
                new PropMetadata() { Name = "FinishObj", Caption="Завершение объекта, документ", Type = "string" }, //Не совсем опнял, что тут будет прям документ или что-то еще
                new PropMetadata() { Name = "IdObj", Caption = "Id объекта", Type = "Obj", IsVirtual = true },
                new PropMetadata() { Name = "IdСontractor", Caption = "Id подрядчика", Type = "Сontractor", IsVirtual = true },
            }
        };

        ModelMetadata modelMetadata5 = new ModelMetadata()
        {
            Name = "Obj",
            Caption = "Объект",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdObj", Caption = "Id Объекта", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Number", Caption="Номер", Type = "int"},
                new PropMetadata() { Name = "Address", Caption="Адрес", Type = "string" },
                new PropMetadata() { Name = "StartDate", Caption = "Дата начала работ", Type = "DateTime" },
                new PropMetadata() { Name = "FinishDate", Caption="Дата окончания работ", Type = "DateTime"},
                new PropMetadata() { Name = "ReturtDateWarranty", Caption="Дата возврата гарантийных", Type = "DateTime" },
                new PropMetadata() { Name = "IdAgent", Caption="Контрагент", Type = "Agent", IsVirtual = true },
                new PropMetadata() { Name = "IdPeople", Caption="Пользователь", Type = "People", IsVirtual = true },

            }
        };

        ModelMetadata modelMetadata6 = new ModelMetadata()
        {
            Name = "Сontractor",
            Caption = "Подрядчик",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdСontractor", Caption = "Id номенклатуры объекта", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
            }
        };

        ModelMetadata modelMetadata7 = new ModelMetadata()
        {
            Name = "Agent",
            Caption = "Контрагент",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdAgent", Caption = "Id контрагента", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "INN", Caption="ИНН", Type = "string"},
                new PropMetadata() { Name = "BankAccount", Caption="Счет", Type = "string"},
            }
        };

        ModelMetadata modelMetadata8 = new ModelMetadata()
        {
            Name = "People",
            Caption = "Пользователь",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdPeople", Caption = "Id Пользователя", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "FirstName", Caption = "Фамилия", Type = "string" },
                new PropMetadata() { Name = "Name", Caption = "Имя", Type = "string" },
                new PropMetadata() { Name = "LastName", Caption = "Отчество", Type = "string" },
                new PropMetadata() { Name = "Role", Caption = "Роль", Type = "string" },

            }
        };

        ModelMetadata modelMetadata9 = new ModelMetadata()
        {
            Name = "Indicator",
            Caption = "Показатели объекта",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdIndicator", Caption = "Id показателя объекта", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "PlanSumm", Caption = "Плановая стоимость", Type = "decimal" },
                new PropMetadata() { Name = "FactSumm", Caption = "Фактическая стоимость", Type = "decimal" },
                new PropMetadata() { Name = "IdNameIndicator", Caption = "Показатель", Type = "NameIndicator", IsVirtual= true },
            }
        };

        ModelMetadata modelMetadata10 = new ModelMetadata()
        {
            Name = "NameIndicator",
            Caption = "Наименование показателя",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdNameIndicator", Caption = "Id показателя", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
            }
        };

        ModelMetadata modelMetadata11 = new ModelMetadata()
        {
            Name = "GPR",
            Caption = "ГПР",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdGPR", Caption = "Id показателя", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Plan", Caption = "План", Type = "decimal" },
                new PropMetadata() { Name = "Fact", Caption = "Факт", Type = "decimal" },
                new PropMetadata() { Name = "IdTypeWork", Caption = "Вид работ", Type = "TypeWork", IsVirtual=true },
            }
        };

        ModelMetadata modelMetadata12 = new ModelMetadata()
        {
            Name = "TypeWork",
            Caption = "Виды работ",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdTypeWork", Caption = "Id Вида работ", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
            }
        };

        ModelMetadata modelMetadata13 = new ModelMetadata()
        {
            Name = "KC",
            Caption = "KC",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdKC", Caption = "Id KC", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "Name", Caption = "Наименование", Type = "string" },
                new PropMetadata() { Name = "DateSubmission", Caption = "Дата Подачи", Type = "DateTime" },
                new PropMetadata() { Name = "PlanSumm", Caption = "План Суммы", Type = "decimal" },
                new PropMetadata() { Name = "FactSumm", Caption = "Факт Суммы", Type = "decimal" },
                new PropMetadata() { Name = "Status", Caption = "Статус", Type = "string" },
                new PropMetadata() { Name = "DateGet", Caption = "Дата прихода подписанной КС", Type = "DateTime" },
                new PropMetadata() { Name = "IdObj", Caption = "Id объекта", Type = "Obj", IsVirtual = true },
            }
        };

        ModelMetadata modelMetadata14 = new ModelMetadata()
        {
            Name = "Payment",
            Caption = "Платежи",
            NameSpace = nameSpace,
            Props = new List<PropMetadata>() {
                new PropMetadata() { Name = "IdPayments", Caption = "Id Вида работ", Type = "int", IsPrimaryKey = true },
                new PropMetadata() { Name = "PlanDate", Caption = "Дата план", Type = "DateTime" },
                new PropMetadata() { Name = "FactDate", Caption = "Дата факт", Type = "DateTime" },
                new PropMetadata() { Name = "PlanSumm", Caption = "План Суммы", Type = "decimal" },
                new PropMetadata() { Name = "FactSumm", Caption = "Факт Суммы", Type = "decimal" },
                new PropMetadata() { Name = "IdKC", Caption = "KC", Type = "KC", IsVirtual=true },
            }
        };

        metadata.Models = new List<ModelMetadata> {
            modelMetadata1,
            modelMetadata2,
            modelMetadata3,
            modelMetadata4,
            modelMetadata5,
            modelMetadata6,
            modelMetadata7,
            modelMetadata8,
            modelMetadata9,
            modelMetadata10,
            modelMetadata11,
            modelMetadata12,
            modelMetadata13,
            modelMetadata14
        };
        metadata.Forms = new List<FormMetadata>
        {
            new FormMetadata()
            {
                Name = "CharacteristicValues",
                Caption = "Значения характеристик",
                Model = modelMetadata1,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "CharacteristicValue", Caption = "Значение характеристики", Type = "Table", Props = modelMetadata1.Props }
                }
            },
            new FormMetadata()
            {
                Name = "Characteristics",
                Caption = "Характеристики",
                Model = modelMetadata2,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "Characteristic", Caption = "Характеристика", Type = "Table", Props = modelMetadata2.Props }
                }
            },
            new FormMetadata()
            {
                Name = "CharacteristicObjs",
                Caption = "Характеристики объекта",
                Model = modelMetadata3,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "CharacteristicObj", Caption = "Характеристика объекта", Type = "Table", Props = modelMetadata3.Props }
                }
            },
            new FormMetadata()
            {
                Name = "Agreements",
                Caption = "Договоры, Соглашения",
                Model = modelMetadata4,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "Agreement", Caption = "Договор, Соглашения", Type = "Table", Props = modelMetadata4.Props }
                },
                EditForm = new FormMetadata()
                    {
                        Name = "AgreementsEditForm",
                        Caption = "Договор, Соглашение",
                        Model = modelMetadata4,
                        Components = new ComponentMetadata[] {
                            new ComponentMetadata() { Name = "Number", Caption = "Номер", Type = "Input"  },       
                            new ComponentMetadata() { Name = "Summ", Caption = "Сумма", Type = "Input"  },       
                            new ComponentMetadata() { Name = "PrePayment", Caption = "Сумма аванса, руб", Type = "Input"  },       
                            new ComponentMetadata() { Name = "TimePayKC2", Caption = "Срок оплаты по КС2, дней после подписания", Type = "DateTime"  },
                            new ComponentMetadata() { Name = "WarrantyRetention", Caption = "Гарантийные удержания, %от суммы КС2", Type = "Input"  },
                            new ComponentMetadata() { Name = "FinishObj", Caption = "Завершение объекта, документ", Type = "Input"  },
                            new ComponentMetadata() { Type = "SubmitButton"  }
                        }
                    }
            },
            new FormMetadata()
            {
                Name = "Objects",
                Caption = "Объекты",
                Model = modelMetadata5,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "Obj", Caption = "Объект", Type = "Table", Props = modelMetadata5.Props }
                },
                EditForm = new FormMetadata()
                    {
                    Name = "ObjectEditForm",
                    Caption = "Объект",
                    Model = modelMetadata5,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Number", Caption = "Номер", Type = "Input"  },
                        new ComponentMetadata() { Name = "Address", Caption = "Адрес", Type = "Input"  },
                        new ComponentMetadata() { Name = "StartDate", Caption = "Дата начала работ", Type = "DateTime"  },
                        new ComponentMetadata() { Name = "FinishDate", Caption = "Дата окончания работ", Type = "DateTime"  },
                        new ComponentMetadata() { Name = "ReturtDateWarranty", Caption = "Дата возврата гарантийных", Type = "DateTime"  },
                        new ComponentMetadata() { Type = "SubmitButton"  }
                    }
                }
            },
            new FormMetadata()
            {
                Name = "Сontractors",
                Caption = "Подрядчик",
                Model = modelMetadata6,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "Nomenclature", Caption = "Номенклатура объекта", Type = "Table", Props = modelMetadata6.Props.Where(p => !p.IsVirtual).ToList() }
                }
            },
            new FormMetadata()
            {
                Name = "Agents",
                Caption = "Контрагент",
                Model = modelMetadata7,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "Agents", Caption = "Контрагент", Type = "Table", Props = modelMetadata7.Props }
                }
            },
            new FormMetadata()
            {
                Name = "Peoples",
                Caption = "Пользователи",
                Model = modelMetadata8,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "Peoples", Caption = "Пользователи", Type = "Table", Props = modelMetadata8.Props }
                }
            },
            new FormMetadata()
            {
                Name = "Indicators",
                Caption = "Показатели объекта",
                Model = modelMetadata9,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "Indicators", Caption = "Показатели объекта", Type = "Table", Props = modelMetadata9.Props }
                }
            },
            new FormMetadata()
            {
                Name = "NameIndicators",
                Caption = "Наименование показателя",
                Model = modelMetadata10,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "NameIndicators", Caption = "Наименование показателя", Type = "Table", Props = modelMetadata10.Props }
                }
            },
            new FormMetadata()
            {
                Name = "GPRs",
                Caption = "ГПР",
                Model = modelMetadata11,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "GPRs", Caption = "ГПР", Type = "Table", Props = modelMetadata11.Props }
                }
            },
            new FormMetadata()
            {
                Name = "TypeWorks",
                Caption = "Виды работ",
                Model = modelMetadata12,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "TypeWorks", Caption = "Виды работ", Type = "Table", Props = modelMetadata12.Props }
                }
            },
            new FormMetadata()
            {
                Name = "KCs",
                Caption = "KC",
                Model = modelMetadata13,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "KCs", Caption = "KC", Type = "Table", Props = modelMetadata13.Props }
                }
            },
            new FormMetadata()
            {
                Name = "Payments",
                Caption = "Платежи",
                Model = modelMetadata14,
                AddToNavBar = true,
                Components = new ComponentMetadata[] {
                    new ComponentMetadata() { Name = "Payments", Caption = "Платежи", Type = "Table", Props = modelMetadata14.Props }
                }
            },

        };


        return metadata;
    }

}