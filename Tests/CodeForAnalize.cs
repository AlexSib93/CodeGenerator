using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public static class CodeForAnalize
    {
        public static string ModelCalcFieldsCode => $@"
public class mc
{{
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int idmodelcalc {{
                get {{
                    return ((int)(this[this.tablemodelcalc.idmodelcalcColumn]));
                }}
                set {{
                    this[this.tablemodelcalc.idmodelcalcColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int idgood {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.idgoodColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'idgood\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.idgoodColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int idmodel {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.idmodelColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'idmodel\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.idmodelColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal qu {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.quColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'qu\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.quColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int thick {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.thickColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'thick\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.thickColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int height {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.heightColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'height\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.heightColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int width {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.widthColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'width\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.widthColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int thickness {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.thicknessColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'thickness\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.thicknessColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int idorder {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.idorderColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'idorder\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.idorderColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal weight {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.weightColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'weight\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.weightColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal price {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.priceColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'price\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.priceColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal sm {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.smColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'sm\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.smColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int idorderitem {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.idorderitemColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'idorderitem\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.idorderitemColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public System.DateTime deleted {{
                get {{
                    try {{
                        return ((global::System.DateTime)(this[this.tablemodelcalc.deletedColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'deleted\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.deletedColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal ang1 {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.ang1Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'ang1\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.ang1Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal ang2 {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.ang2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'ang2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.ang2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal radius1 {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.radius1Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'radius1\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.radius1Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal radius2 {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.radius2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'radius2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.radius2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal price2 {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.price2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'price2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.price2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal sm2 {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.sm2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'sm2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.sm2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal qustore {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.qustoreColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'qustore\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.qustoreColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal smbase {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.smbaseColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'smbase\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.smbaseColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal pricebase {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.pricebaseColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'pricebase\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.pricebaseColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string modelpart {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.modelpartColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'modelpart\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.modelpartColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal waste {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.wasteColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'waste\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.wasteColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string addstr {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.addstrColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'addstr\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.addstrColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal addint {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.addintColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'addint\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.addintColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string addstr2 {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.addstr2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'addstr2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.addstr2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int idcolor1 {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.idcolor1Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'idcolor1\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.idcolor1Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int idcolor2 {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.idcolor2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'idcolor2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.idcolor2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string addstr3 {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.addstr3Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'addstr3\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.addstr3Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string addstr4 {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.addstr4Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'addstr4\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.addstr4Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public byte[] smcrypt {{
                get {{
                    try {{
                        return ((byte[])(this[this.tablemodelcalc.smcryptColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'smcrypt\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.smcryptColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public byte[] smbasecrypt {{
                get {{
                    try {{
                        return ((byte[])(this[this.tablemodelcalc.smbasecryptColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'smbasecrypt\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.smbasecryptColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal smbase2 {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.smbase2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'smbase2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.smbase2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal smbase3 {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.smbase3Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'smbase3\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.smbase3Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal smbase4 {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.smbase4Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'smbase4\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.smbase4Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal sqr {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.sqrColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'sqr\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.sqrColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string good_name {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.good_nameColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'good_name\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_nameColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string good_marking {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.good_markingColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'good_marking\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_markingColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal good_waste {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.good_wasteColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'good_waste\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_wasteColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int good_idvalut {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.good_idvalutColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'good_idvalut\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_idvalutColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int good_idgoodgroup {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.good_idgoodgroupColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'good_idgoodgroup\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_idgoodgroupColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int good_idgoodtype {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.good_idgoodtypeColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'good_idgoodtype\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_idgoodtypeColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int good_idgoodtype2 {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.good_idgoodtype2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'good_idgoodtype2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_idgoodtype2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int orderitem_numpos {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.orderitem_numposColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'orderitem_numpos\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.orderitem_numposColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string orderitem_name {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.orderitem_nameColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'orderitem_name\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.orderitem_nameColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal orderitem_qu {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.orderitem_quColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'orderitem_qu\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.orderitem_quColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string goodgroup_name {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.goodgroup_nameColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'goodgroup_name\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.goodgroup_nameColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int measure_typ {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.measure_typColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'measure_typ\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.measure_typColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string measure_shortname {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.measure_shortnameColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'measure_shortname\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.measure_shortnameColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal measure_factor {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.measure_factorColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'measure_factor\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.measure_factorColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string valut_shortname {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.valut_shortnameColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'valut_shortname\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.valut_shortnameColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string goodtype_name {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.goodtype_nameColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'goodtype_name\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.goodtype_nameColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int goodtype_numpos {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.goodtype_numposColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'goodtype_numpos\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.goodtype_numposColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string goodtype_name2 {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.goodtype_name2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'goodtype_name2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.goodtype_name2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int goodtype_numpos2 {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.goodtype_numpos2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'goodtype_numpos2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.goodtype_numpos2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int good_idcolor1 {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.good_idcolor1Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'good_idcolor1\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_idcolor1Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int good_idcolor2 {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.good_idcolor2Column]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'good_idcolor2\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_idcolor2Column] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public int orderitem_constrnum {{
                get {{
                    try {{
                        return ((int)(this[this.tablemodelcalc.orderitem_constrnumColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'orderitem_constrnum\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.orderitem_constrnumColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public bool addbool {{
                get {{
                    try {{
                        return ((bool)(this[this.tablemodelcalc.addboolColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'addbool\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.addboolColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string good_colorinname {{
                get {{
                    if (this.Isgood_colorinnameNull()) {{
                        return string.Empty;
                    }}
                    else {{
                        return ((string)(this[this.tablemodelcalc.good_colorinnameColumn]));
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_colorinnameColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string good_coloroutname {{
                get {{
                    if (this.Isgood_coloroutnameNull()) {{
                        return string.Empty;
                    }}
                    else {{
                        return ((string)(this[this.tablemodelcalc.good_coloroutnameColumn]));
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.good_coloroutnameColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string addstring_info {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.addstring_infoColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'addstring_info\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.addstring_infoColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public decimal addnum_info {{
                get {{
                    try {{
                        return ((decimal)(this[this.tablemodelcalc.addnum_infoColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'addnum_info\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.addnum_infoColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public byte sourcetype {{
                get {{
                    try {{
                        return ((byte)(this[this.tablemodelcalc.sourcetypeColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'sourcetype\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.sourcetypeColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string calcsource {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.calcsourceColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'calcsource\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.calcsourceColumn] = value;
                }}
            }}
            
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            [global::System.CodeDom.Compiler.GeneratedCodeAttribute(""System.Data.Design.TypedDataSetGenerator"", ""15.0.0.0"")]
            public string assemblyunit {{
                get {{
                    try {{
                        return ((string)(this[this.tablemodelcalc.assemblyunitColumn]));
                    }}
                    catch (global::System.InvalidCastException e) {{
                        throw new global::System.Data.StrongTypingException(""The value for column \'assemblyunit\' in table \'modelcalc\' is DBNull."", e);
                    }}
                }}
                set {{
                    this[this.tablemodelcalc.assemblyunitColumn] = value;
                }}
            }}
        }}";

        public static string BuilderMessages => $@"";

        public static string OrderItemFieldsCode => $@"
partial class orderitemRow
        {{
        public int Idorderitem {{ get; set; }}
        public string Name {{ get; set; }}
        public int? Idorder {{ get; set; }}
        public int? Idmodel {{ get; set; }}
        public decimal? Qu {{ get; set; }}
        public int? Thick {{ get; set; }}
        public int? Height {{ get; set; }}
        public int? Width {{ get; set; }}
        public decimal? Price {{ get; set; }}
        public decimal? Price2 {{ get; set; }}
        public decimal? Sm {{ get; set; }}
        public decimal? Sm2 {{ get; set; }}
        public System.DateTime? Deleted {{ get; set; }}
        public string Comment {{ get; set; }}
        public string Part {{ get; set; }}
        public int? Idgood {{ get; set; }}
        public int? Numpos {{ get; set; }}
        public int? Typ {{ get; set; }}
        public int? Idversion {{ get; set; }}
        public decimal? Qustore {{ get; set; }}
        public decimal? Smbase {{ get; set; }}
        public decimal? Pricebase {{ get; set; }}
        public decimal? Sqr {{ get; set; }}
        public bool? Isglass {{ get; set; }}
        public bool? Ismoskit {{ get; set; }}
        public bool? Isaddgood {{ get; set; }}
        public decimal? Winue {{ get; set; }}
        public bool? Isstandart {{ get; set; }}
        public decimal? Winue2 {{ get; set; }}
        public decimal? Winue3 {{ get; set; }}
        public int? Idpeopleedit {{ get; set; }}
        public System.DateTime? Dtedit {{ get; set; }}
        public int? Constrnum {{ get; set; }}
        public int? Idprofsys {{ get; set; }}
        public int? Idfurnsys {{ get; set; }}
        public int? Idconstructiontype {{ get; set; }}
        public int? Idcolorin {{ get; set; }}
        public int? Idcolorout {{ get; set; }}
        public int? Quready {{ get; set; }}
        public bool? Isready {{ get; set; }}
        public decimal? Radius1 {{ get; set; }}
        public decimal? Ang1 {{ get; set; }}
        public decimal? Ang2 {{ get; set; }}
        public decimal? Radius2 {{ get; set; }}
        public decimal? Weight {{ get; set; }}
        public int? Quinmanufact {{ get; set; }}
        public decimal? Smbase2 {{ get; set; }}
        public decimal? Smbase3 {{ get; set; }}
        public decimal? Smbase4 {{ get; set; }}
        public int? Parentid {{ get; set; }}
        public string Model_name {{ get; set; }}
        public string Good_name {{ get; set; }}
        public string Good_marking {{ get; set; }}
        public decimal? Good_waste {{ get; set; }}
        public int? Measure_typ {{ get; set; }}
        public string Measure_shortname {{ get; set; }}
        public decimal? Measure_factor {{ get; set; }}
        public string Goodtype_name {{ get; set; }}
        public int? Good_idgoodtype {{ get; set; }}
        public int? Good_idgoodtype2 {{ get; set; }}
        public int? Goodtype_numpos {{ get; set; }}
        public string Goodtype_name2 {{ get; set; }}
        public int? Goodtype_numpos2 {{ get; set; }}
        public string Mdoc_name {{ get; set; }}
        public System.DateTime? Mdoc_dt {{ get; set; }}
        public decimal? Mdoc_qu {{ get; set; }}
        public int? Good_idgoodgroup {{ get; set; }}
        public short? Good_ismy {{ get; set; }}
        public string Goodgroup_name {{ get; set; }}
        public string Profsys_name {{ get; set; }}
        public string Furnsys_name {{ get; set; }}
        public string Constrtype_name {{ get; set; }}
        public int? Good_idcolor1 {{ get; set; }}
        public int? Good_idcolor2 {{ get; set; }}
        public string Colorin_name {{ get; set; }}
        public string Colorout_name {{ get; set; }}
        public int? Idproductiontype {{ get; set; }}
        public string Productiontype_name {{ get; set; }}
        public short? Pict_typ {{ get; set; }}
        public int? Productiontype_typ {{ get; set; }}
        public System.Guid? Good_guid {{ get; set; }}
        public string Productiontype_productiontypegroup {{ get; set; }}
        public decimal? Vdfield1 {{ get; set; }}
        public decimal? Sqrtotal {{ get; set; }}
        public bool? Hide {{ get; set; }}
        public int? Idpower {{ get; set; }}
        public string Power_name {{ get; set; }}
        public string Addstr {{ get; set; }}
        public string Addstr2 {{ get; set; }}
        public bool? Ispf {{ get; set; }}
        public string Assemblyunit {{ get; set; }}
        public int? Addint {{ get; set; }}
        public int? Addint2 {{ get; set; }}
        public decimal? Addnum1 {{ get; set; }}
        public decimal? Addnum2 {{ get; set; }}
        public decimal? Addnum3 {{ get; set; }}
        public decimal? Addnum4 {{ get; set; }}
        public decimal? Addnum5 {{ get; set; }}
        public decimal? Addnum6 {{ get; set; }}
        public decimal? Addnum7 {{ get; set; }}
        public decimal? Addnum8 {{ get; set; }}
        public string Colorin_name_strkey {{ get; set; }}
        public string Colorout_name_strkey {{ get; set; }}
        public string Constrtype_name_strkey {{ get; set; }}
        public string Profsys_name_strkey {{ get; set; }}
        public string Furnsys_name_strkey {{ get; set; }}        

        }}
        
        
";
    }
}
