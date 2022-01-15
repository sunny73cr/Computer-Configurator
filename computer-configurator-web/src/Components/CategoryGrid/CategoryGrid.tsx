import { Link } from "react-router-dom";

import "./CategoryGrid.css";

import { partSearchLink } from "../../index";

function CategoryCard(categoryName: string, imageAsBase64String: string): JSX.Element {
	return (
		<div className="card" key={categoryName}>
			<Link to={`${partSearchLink}/${categoryName}`}>
				<img alt={`The ${categoryName} category.`} src={`data:image/jpeg;base64,${imageAsBase64String}`} />
				<h3>{categoryName}</h3>
			</Link>
		</div>
	);
}

export interface Category {
	name: string;
	image: string;
}

export default function CategoryGrid(categories: Array<Category>): JSX.Element {
	return (
		<div className="categories">
			<div className="titleBar">
				<h2>Categories</h2>
				<Link to={partSearchLink}>View all</Link>
			</div>
			<div className="grid">{categories.map((category) => CategoryCard(category.name, category.image))}</div>
		</div>
	);
}
