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
import {TestModelList} from './forms/TestModelList';



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
              <Route path='/TestModelList' element={<TestModelList items={[]} autoFetch={true} />} /> 
            </Routes>
          </main>
        {/* </BrowserRouter> */}
        </HashRouter>
        <Toasts />
      </ContextApp.Provider>
    </div>
  );
}




export default App;
