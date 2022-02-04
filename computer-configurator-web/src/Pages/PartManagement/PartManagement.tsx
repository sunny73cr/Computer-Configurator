import { useEffect, useRef, useState } from "react";
import useItemManagement, { CellType, FieldUpdates, ItemUpdates, ReadonlyCellConfiguration, WriteableCellConfiguration } from "../../Components/DataTable/useItemManagement";
import Part from "../../DomainModel/DesktopComponents/Models/Part.interface";
import { ValidateDescription, ValidateManufacturer, ValidatePrice } from "../../DomainModel/DesktopComponents/Validation/Part.validation";
import { AllParts } from "../../Services/Part.service";

import "./PartManagement.css";

//TODO: add a staged changes panel and merge process - selectively confirm or cancel updates
//TODO: compare updates to original data; if update was 'cancelled' by typing original data, remove it.

export default function PartManagement() {
	let dbData: Array<Part> = [
		{
			Id: 1,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3500u",
			Price: 100
		},
		{
			Id: 2,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3300X",
			Price: 150
		},
		{
			Id: 3,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3600",
			Price: 300
		},
		{
			Id: 4,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3700X",
			Price: 500
		},
		{
			Id: 5,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3800X",
			Price: 900
		},
		{
			Id: 6,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3900X",
			Price: 1000
		},
		{
			Id: 7,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3900X",
			Price: 1000
		},
		{
			Id: 8,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3900X",
			Price: 1000
		},
		{
			Id: 9,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3900X",
			Price: 1000
		},
		{
			Id: 10,
			Manufacturer: "AMD",
			Description: "Ryzen 5 3900X",
			Price: 1000
		}
	];

	let IdConfig: ReadonlyCellConfiguration<Part> = {
		FieldName: "Id",
		CellType: CellType.readonly
	};

	let ManufacturerConfig: WriteableCellConfiguration<Part> = {
		FieldName: "Manufacturer",
		CellType: CellType.text,
		PlaceHolder: "Manufacturer",
		Validator: ValidateManufacturer
	};

	let DescriptionConfig: WriteableCellConfiguration<Part> = {
		FieldName: "Description",
		CellType: CellType.text,
		PlaceHolder: "Description",
		Validator: ValidateDescription
	};

	let PriceConfig: WriteableCellConfiguration<Part> = {
		FieldName: "Price",
		CellType: CellType.number,
		PlaceHolder: "Price",
		Validator: ValidatePrice
	};

	let cellConfigurations = [IdConfig, ManufacturerConfig, DescriptionConfig, PriceConfig];

	let hiddenColumns: Array<keyof Part> = [];

	function performUpdates(part: Part, updatesTo: FieldUpdates<Part>): Part {
		if (updatesTo.Manufacturer !== undefined) part.Manufacturer = updatesTo.Manufacturer;
		if (updatesTo.Description !== undefined) part.Description = updatesTo.Description;
		if (updatesTo.Price !== undefined) part.Price = updatesTo.Price;

		return part;
	}

	let partsCache = useRef(dbData).current;

	const [searchValue, setSearchValue] = useState<string>("");

	const [parts, setParts] = useState<Array<Part>>(partsCache);

	const [itemUpdates, setItemUpdates] = useState<ItemUpdates<Part>>({});

	const [pendingUpdates, setPendingUpdates] = useState<number>(0);

	const [showUpdatesReview, setShowUpdatesReview] = useState<boolean>(false);

	useEffect(() => {
		let count = 0;
		for (let update in itemUpdates) count++;
		setPendingUpdates(count);
	}, [itemUpdates]);

	function addItemUpdate(itemId: number, fieldName: keyof Part, fieldValue: any) {
		//copy the item updates collection.
		let _itemUpdates = { ...itemUpdates };
		let fieldUpdate = { [fieldName]: fieldValue } as FieldUpdates<Part>;
		//append or replace the field update in the item updates for this item id.
		_itemUpdates[itemId] = { ..._itemUpdates[itemId], ...fieldUpdate };

		//copy the parts collection.
		let _itemCollection = [...parts];
		//create a field update object
		//find the index of the item to edit by its Id.
		let index = _itemCollection.findIndex((item) => item.Id === itemId);
		//if not found; data was corrupted. Should not happen.
		//A row will not be rendered for a non-existent item;
		//thus, a non existent item can not be edited.
		if (index === -1) throw new Error("could not find a Item with that Id.");
		//find the item by its index.
		let item = _itemCollection[index];
		//update the item.
		let updatedItem = performUpdates(item, _itemUpdates[itemId]);
		//save the updates.
		_itemCollection[index] = updatedItem;

		//update items with the modified array
		setParts(_itemCollection);
		//update field updates with the modified array.
		setItemUpdates(_itemUpdates);
	}

	async function fetchItems() {
		try {
			let parts = await AllParts();
			setSearchValue("");
			partsCache = parts;
			setParts(parts);
		} catch (error) {}
	}

	function filterItems(parts: Array<Part>, searchTerm: string): Array<Part> {
		let filtered = parts.filter((part) => part.Description.includes(searchTerm));
		console.log("filtered parts", filtered);
		return filtered;
	}

	function reviewUpdates() {
		return (
			<div className="overlay">
				<p>Review updates:</p>
				<button onClick={() => setShowUpdatesReview(false)}>Close</button>
			</div>
		);
	}

	return (
		<div className="partManagement">
			{showUpdatesReview && reviewUpdates()}
			<h1 className="heading">Parts</h1>
			<div className="updateControl">
				<p>Pending updates:</p>
				<p className="indicator">{pendingUpdates > 9 ? "9+" : pendingUpdates}</p>
				{pendingUpdates > 0 ? <button onClick={() => setShowUpdatesReview(true)}>Review</button> : undefined}
			</div>

			<input
				className="searchBar"
				type="search"
				placeholder="Search this list..."
				value={searchValue}
				onChange={(event) => {
					let userInput = event.currentTarget.value;
					let updated = partsCache.map((part) => {
						let thisPartUpdates = itemUpdates[part.Id];
						if (!thisPartUpdates) return part;
						else return performUpdates(part, thisPartUpdates);
					});
					setParts(filterItems(updated, userInput));
					setSearchValue(userInput);
				}}
			/>
			{useItemManagement<Part>(hiddenColumns, cellConfigurations, parts, addItemUpdate)}
		</div>
	);
}
