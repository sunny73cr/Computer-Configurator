import { useState } from "react";
import { Link } from "react-router-dom";
import "./Header.css";

function Header() {
  const [isNavCollapsed, setIsNavCollapsed] = useState<Boolean>(true);

  return (
    <header>
      <Link to="/">
        <h1>Computer Configurator</h1>
      </Link>
      <button onClick={() => setIsNavCollapsed(!isNavCollapsed)}>
        <span className={`bi ${isNavCollapsed ? "bi-list" : "bi-x-lg"}`}></span>
      </button>
    </header>
  );
}

export default Header;
