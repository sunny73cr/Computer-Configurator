import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter, Route, Routes } from "react-router-dom";
import reportWebVitals from "./reportWebVitals";

import "./index.css";
import "./overlayFade.css";

/* Components */
import Header from "./Components/Header/Header";

/* Pages */
import Home from "./Pages/Home";
import About from "./Pages/About";
import PartSearch from "./Pages/PartSearch";
import ConfigureComputer from "./Pages/ConfigureComputer";

/* Links */
export const homeLink: string = "/";
export const aboutLink: string = "/about";
export const partSearchLink: string = "/partSearch";
export const configureComputerLink: string = "/configureSystem";
//export const Link: string = "";

ReactDOM.render(
	<React.StrictMode>
		<BrowserRouter>
			<span className="overlay fadeIn toTop" />
			<Header />
			<div className="content">
				<Routes>
					<Route path={homeLink} element={<Home />} />
					<Route path={aboutLink} element={<About />} />
					<Route path={partSearchLink} element={<PartSearch />} />
					<Route path={configureComputerLink} element={<ConfigureComputer />} />
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
