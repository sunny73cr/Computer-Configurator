import { useState } from "react";
import { Link } from "react-router-dom";

import "./Header.css";

import { aboutLink, configureComputerLink, partSearchLink } from "../../index";

function Header() {
	const [navExpanded, setNavExpanded] = useState<Boolean>(false);

	function NavBar() {
		return (
			<div className={`navSidebar ${navExpanded ? "showLeft" : "hideRight"}`} onClick={() => setNavExpanded(!navExpanded)}>
				<Link to={aboutLink}>About</Link>
				<Link to={partSearchLink}>Part Search</Link>
				<Link to={configureComputerLink}>System Configuration</Link>
			</div>
		);
	}

	return (
		<header>
			<div className="titleBar">
				<Link to="/">Computer Configurator</Link>
				<button onClick={() => /*Toggle nav*/ setNavExpanded(!navExpanded)}>
					<span className={`bi ${navExpanded ? "bi-x-lg" : "bi-list"}`}></span>
				</button>
			</div>
			{NavBar()}
		</header>
	);
}

export default Header;
