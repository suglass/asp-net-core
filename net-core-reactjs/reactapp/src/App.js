import { BrowserRouter, Routes, Route } from "react-router-dom";
import INavbar from './INavbar'
import Investors from "./Investors";
import InvestorDetail from "./InvestorDetail";

function App() {
  return (
    <div className="App">
      <header className="App-header">
          <BrowserRouter>
            <INavbar/>
            <Routes>
              <Route path="/">
                <Route index element={<>You're welcome</>} />
                <Route path="/investors">
                  <Route index element={<Investors />}/>
                </Route>
                <Route path="investors/:id" element={<InvestorDetail/>} />
              </Route>
            </Routes>
          </BrowserRouter>
      </header>
    </div>
  );
}

export default App;
