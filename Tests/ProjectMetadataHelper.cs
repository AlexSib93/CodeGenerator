using CodeGenerator;
using CodeGenerator.Metadata;
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
                    //new PropMetadata { Name = "Components", Caption = "Формы", Type = "List<ComponentMetadata>" }
                    //    public IEnumerable<ComponentMetadata> Components { get; set; }
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
                        new ComponentMetadata() { Name = "Projects", Caption = "Проекты", Type = "Table", Props = modelMetadata2.Props  }
                    }

                },
                new FormMetadata()
                {
                    Name = "Models",
                    Caption = "Модели",
                    Model = modelMetadata1,
                    AddToNavBar = true,
                    Components = new ComponentMetadata[] {
                        new ComponentMetadata() { Name = "Models", Caption = "Модели", Type = "Table", Props = modelMetadata1.Props  }
                    },
                    EditForm = new FormMetadata()
                    {
                        Name = "Model",
                        Caption = "Модель",
                        Model = modelMetadata1,
                        Components = new ComponentMetadata[] {
                            new ComponentMetadata() { Name = "Name", Caption = "Наименование", Type = "Input"  },
                            new ComponentMetadata() { Name = "NameSpace", Caption = "Пространство имен", Type = "Input"  },
                            new ComponentMetadata() { Name = "Caption", Caption = "Отображаемое имя", Type = "Input"  },
                            new ComponentMetadata() { Name = "Props", Caption = "Свойства", Type = "Table", Props = modelMetadata4.Props },
                            new ComponentMetadata() { Type = "SubmitButton"  }
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
                        new ComponentMetadata() { Name = "Forms", Caption = "Формы", Type = "Table", Props = modelMetadata3.Props  }
                    },
                    EditForm = new FormMetadata()
                    {
                        Name = "Form",
                        Caption = "Форма",
                        Model = modelMetadata3,
                        Components = new ComponentMetadata[] {
                            new ComponentMetadata() { Name = "Name", Caption = "Наименование", Type = "Input"  },
                            new ComponentMetadata() { Name = "Caption", Caption = "Отображаемое имя", Type = "Input"  },
                            new ComponentMetadata() { Name = "Description", Caption = "Описание", Type = "Input"  },
                            new ComponentMetadata() { Name = "AddToNavBar", Caption = "Добавить в панель навигации", Type = "CheckBox"  },
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

}