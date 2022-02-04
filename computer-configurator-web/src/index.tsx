import React from "react";
import ReactDOM from "react-dom";
import reportWebVitals from "./reportWebVitals";

import App from "./App";

/* Links */
export const homeLink: string = "/";
export const aboutLink: string = "/about";
export const partSearchLink: string = "/partSearch";
export const configureComputerLink: string = "/configureSystem";

ReactDOM.render(
	<React.StrictMode>
		<App />
	</React.StrictMode>,
	document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
