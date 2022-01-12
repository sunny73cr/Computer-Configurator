import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "./Header.css";

function Header() {
	const [isNavExpanded, setIsNavExpanded] = useState<Boolean>(false);

	useEffect(() => {
		console.log("navbar is expanded?", isNavExpanded);
	}, [isNavExpanded]);

	function NavBar() {
		return (
			<div className="navDropdown">
				<Link to="/about">About</Link>
			</div>
		);
	}

	return (
		<header>
			<div className="titleBar">
				<Link to="/">
					<h1>Computer Configurator</h1>
				</Link>
				<button onClick={() => setIsNavExpanded(!isNavExpanded)}>
					<span className={`bi ${isNavExpanded ? "bi-x-lg" : "bi-list"}`}></span>
				</button>
			</div>
			{isNavExpanded ? NavBar() : /*Empty*/ <div />}
		</header>
	);
}

export default Header;
