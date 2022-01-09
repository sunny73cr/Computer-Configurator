import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import "./index.css";
import "./overlayFade.css";
import reportWebVitals from "./reportWebVitals";

import Header from "./Components/Header";
import Home from "./Pages/Home";

ReactDOM.render(
  <React.StrictMode>
    <BrowserRouter>
      {/* <span className="overlay fadeIn toCenter"/> */}
      <Header />
      <div className="content">
        <Routes>
          <Route path="/" element={<Home />} />
        </Routes>
      </div>
    </BrowserRouter>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
