import { useReducer } from 'react';
import './App.css';
import Header from './components/Navbar';
import Login from './pages/Login';
import { HashRouter, Route, Routes } from 'react-router-dom';
import Register from './pages/Register';
import Home from './pages/Home';
import { appReducer, ContextApp, initialAppState } from './state/state';
import { Toasts } from './common/toasts';
import { SettingsPage } from './pages/SettingsPage';
import {Projects} from './forms/Projects';
import {Models} from './forms/Models';
import {Forms} from './forms/Forms';
import { ModalEditForms } from './forms/ModalEditForms';



function App() {
  const [state, dispatch] = useReducer(appReducer, initialAppState);

  return (
    <div className="App">
      <ContextApp.Provider value={{ dispatch, state }}>
        {/* <BrowserRouter basename='/terminal'> */}
        <HashRouter basename='/'>
          <main className="container-sm">
            <Header />
            <Routes >
              <Route path="/" element={<Home />} />
              <Route path="/login" element={<Login />} />
              <Route path="/register" element={<Register />} /> 
              <Route path='/settings' element={<SettingsPage />} /> 
              <Route path='/Projects' element={<Projects items={[]} autoFetch={true} />} /> 
<Route path='/Models' element={<Models items={[]} autoFetch={true} />} /> 
<Route path='/Forms' element={<Forms items={[]} autoFetch={true} />} /> 
            </Routes>
          </main>
        {/* </BrowserRouter> */}
        </HashRouter>
        <Toasts />
        <ModalEditForms/>
      </ContextApp.Provider>
    </div>
  );
}




export default App;
