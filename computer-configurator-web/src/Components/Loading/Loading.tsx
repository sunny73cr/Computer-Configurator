import "./Loading.css";

export default function Loading(description: string) {
	return (
		<div className="loading">
			<div className="spinner"></div>
			<h1>{description}</h1>
		</div>
	);
}
