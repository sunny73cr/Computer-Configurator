import React, { useEffect, useRef, useState } from "react";
import { Link } from "react-router-dom";
import { AxiosError } from "axios";

import "./useSelectPart.css";

import Part from "../../DomainModel/DesktopComponents/Models/Part.interface";
import Loading from "../Loading/Loading";
import { PagedResponse } from "../../DomainModel/APIResponse.interface";
import { ErrorWithoutResponse, ErrorWithResponse, StatusCode } from "../../Services/AxiosBase.service";

export default function useSelectPart(
	numberToSelect: number,
	selectedPart: number | undefined,
	setSelectedPart: React.Dispatch<React.SetStateAction<number | undefined>>,
	partCategory: string,
	partService: (pageNumber: number) => Promise<PagedResponse<Part>>
) {
	const [initialised, setInitialised] = useState<boolean>(false);

	const [currentPage, setCurrentPage] = useState<number>(1);

	const [parts, setParts] = useState<Array<Part> | undefined>(undefined);

	const [filteredParts, setFilteredParts] = useState<Array<Part> | undefined>(undefined);

	let pageNumbers = useRef<Array<number>>([]);

	const [searchTerm, setSearchTerm] = useState<string>("");

	async function fetchParts(pageNumber: number) {
		try {
			setInitialised(false);

			let fetchedParts = await partService(pageNumber);

			let numbers = new Array<number>();
			for (let page = 1; page === fetchedParts.TotalPages; page++) {
				numbers = [...numbers, page];
			}
			pageNumbers.current = numbers;

			setParts(fetchedParts.Data);

			setInitialised(true);
		} catch (error) {
			let axiosError = error as AxiosError;
			if (axiosError.response) alert(ErrorWithResponse(axiosError));
			else alert(ErrorWithoutResponse(axiosError));
		}
	}

	useEffect(() => {
		async function init() {
			await fetchParts(1);
		}
		init();
	}, []);

	function renderPartRow(part: Part) {
		return (
			<tr key={part.Id}>
				<td>
					<input type="radio" name="partSelection" value={part.Id} onInput={(event) => setSelectedPart(event.currentTarget.valueAsNumber)}></input>
				</td>
				<td>{part.Manufacturer}</td>
				<td>{part.Description}</td>
				<td>{part.Price}</td>
				<td>
					<Link to={`/parts/${part.Id}`}>Details</Link>
				</td>
			</tr>
		);
	}

	useEffect(() => {
		if (searchTerm === "") setFilteredParts([]);
		else {
			let timeout = setTimeout(
				() =>
					setFilteredParts(
						//search will not render if parts is undefined
						parts!.filter((part) => {
							if (part.Description.includes(searchTerm)) return part;
						})
					),
				200 /* Milliseconds delay */
			);
			clearTimeout(timeout);
		}
	}, [searchTerm]);

	function previousPage(): void {
		if (currentPage === 1) return;
		else setCurrentPage(currentPage - 1);
	}

	function nextPage(): void {
		if (currentPage === pageNumbers.current.length) return;
		else setCurrentPage(currentPage + 1);
	}

	useEffect(() => {
		fetchParts(currentPage);
	}, [currentPage]);

	function partTable() {
		//this will not render if the parts array is undefined.
		if (!parts) throw new Error("Must not happen!");
		else {
			return (
				<div className="partTable">
					<h4>Selected: {selectedPart ? parts[selectedPart].Description : <p className="danger">None</p>}</h4>
					<input type="search" placeholder="Search..." value={searchTerm} onInput={(event) => setSearchTerm(event.currentTarget.value)}></input>
					<button type="reset" onClick={async () => fetchParts(currentPage)}>
						Refresh
					</button>
					<table>
						<thead>
							<tr>
								<th>{/*Radio Button*/}</th>
								<th>Manufacturer</th>
								<th>Description</th>
								<th>Price</th>
								<th>{/*Details*/}</th>
							</tr>
						</thead>
						<tbody>{searchTerm === "" ? parts.map((part) => renderPartRow(part)) : filteredParts!.map((part) => renderPartRow(part))}</tbody>
					</table>
					<button onClick={() => previousPage()}>Previous</button>
					<button onClick={() => nextPage()}>Next</button>
				</div>
			);
		}
	}

	if (!initialised) return Loading("momentarily fetching parts...");
	else {
		return (
			<div className="selectPart">
				<h3>{partCategory}:</h3>
				{parts || filteredParts ? partTable() : <p>No parts matched your search</p>}
			</div>
		);
	}
}
