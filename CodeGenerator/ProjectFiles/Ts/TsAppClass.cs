using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Ts
{
    public class TsAppClass : IGenerator
    {
        public string Name { get; set; }
        public IEnumerable<FormMetadata> Forms { get; set; }
        public string ParamName => StringHelper.ToLowerFirstChar(ClassInfo.Name);
        public TsAppClass(IEnumerable<FormMetadata> formsInfo)
        {
            Forms = formsInfo;
        }

        public ModelMetadata ClassInfo { get; set; }

        public string Header => $@"import {{ useReducer }} from 'react';
import './App.css';
import Header from './components/Navbar';
import Login from './pages/Login';
import {{ HashRouter, Route, Routes }} from 'react-router-dom';
import Register from './pages/Register';
import Home from './pages/Home';
import {{ appReducer, ContextApp, initialAppState }} from './state/state';
import {{ Toasts }} from './common/toasts';
import {{ SettingsPage }} from './pages/SettingsPage';
{GetUsingFormsText(Forms)}";

        private object GetUsingFormsText(IEnumerable<FormMetadata> forms)
        {
            return string.Join(Environment.NewLine, forms.Select(x => GetUsingFormText(x)));
        }

        private string GetUsingFormText(FormMetadata form)
        {
            return $@"import {{{ form.Name }}} from './forms/{form.Name}';";
        }
        public string Body => $@"

function App() {{
  const [state, dispatch] = useReducer(appReducer, initialAppState);

  return (
    <div className=""App"">
      <ContextApp.Provider value={{{{ dispatch, state }}}}>
        {{/* <BrowserRouter basename='/terminal'> */}}
        <HashRouter basename='/'>
          <main className=""container-sm"">
            <Header />
            <Routes >
              <Route path=""/"" element={{<Home />}} />
              <Route path=""/login"" element={{<Login />}} />
              <Route path=""/register"" element={{<Register />}} /> 
              <Route path='/settings' element={{<SettingsPage />}} /> 
              {GetFormRoutesText(Forms)}
            </Routes>
          </main>
        {{/* </BrowserRouter> */}}
        </HashRouter>
        <Toasts />
      </ContextApp.Provider>
    </div>
  );
}}
";
        public string Footer => $@"

export default App;
";

        private string GetFormRoutesText(IEnumerable<FormMetadata> forms)
        {
            return string.Join(Environment.NewLine, forms.Select(x => GetFormRouteText(x)));
        }

        private string GetFormRouteText(FormMetadata form)
        {
            return $@"<Route path='/{form.Name}' element={{<{form.Name} items={{[]}} autoFetch={{true}} />}} /> ";
        }

        public string Gen()
        {
            return $"{Header}\n\n{Body}\n\n{Footer}";
        }

    }
}
