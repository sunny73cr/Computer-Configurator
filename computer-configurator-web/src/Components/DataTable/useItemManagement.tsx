import "./ItemManagement.css";

export interface UniqueItem {
	//a table item (row) must have a unique identifier
	Id: number;
}

export type FieldUpdates<Type> = {
	[FieldName in keyof Partial<Type>]: Type[FieldName];
};

export interface ItemUpdates<Type> {
	[Id: number]: FieldUpdates<Type>;
}

export enum CellType {
	"readonly",
	"text",
	"number"
}

export interface ReadonlyCellConfiguration<ItemType> {
	FieldName: keyof ItemType;
	CellType: CellType.readonly;
}

export interface WriteableCellConfiguration<ItemType> {
	FieldName: keyof ItemType;
	CellType: CellType.text | CellType.number;
	PlaceHolder: string;
	Validator(userInput: any): Array<string> | undefined;
}

export default function useItemManagementNext<ItemType extends UniqueItem>(
	hiddenColumns: Array<keyof ItemType>,
	fieldConfigurations: Array<ReadonlyCellConfiguration<ItemType> | WriteableCellConfiguration<ItemType>>,
	items: Array<ItemType>,
	addItemUpdate: (itemId: number, fieldName: keyof ItemType, fieldValue: any) => void
) {
	function ErrorTooltip(cellIdentifier: string, cellErrors: Array<string>) {
		return (
			<div key={`${cellIdentifier}-errors`} className="toolTip">
				{<p>{cellErrors.map((error) => error + "\n")}</p>}
			</div>
		);
	}

	function renderField(itemId: number, fieldName: keyof ItemType, fieldValue: any, fieldConfiguration: ReadonlyCellConfiguration<ItemType> | WriteableCellConfiguration<ItemType>): JSX.Element {
		let cellIdentifier = `${itemId}-${fieldName}`;

		//if this is a readonly cell, render a div containing its value.
		if (fieldConfiguration.CellType === CellType.readonly) {
			return (
				//identify it by the item id and field name. Style it based on the field name.
				<div key={cellIdentifier} className="cell">
					<p className="readonly">{fieldValue}</p>
				</div>
			);
		}

		//at this point the cell must be writeable, convert the configuration to access the extra properties.
		let writeableCellConfiguration = fieldConfiguration as WriteableCellConfiguration<ItemType>;

		//get the errors for this cell using the provided validator
		let cellErrors = writeableCellConfiguration.Validator(fieldValue);

		//render an editable cell based on the provided cell type.
		switch (writeableCellConfiguration.CellType) {
			case CellType.text:
				return (
					<div key={cellIdentifier} className="cellGroup">
						<input
							type="text"
							key={`${cellIdentifier}-input`}
							className={`cell ${cellErrors ? "invalid" : ""}`}
							placeholder={writeableCellConfiguration.PlaceHolder}
							value={fieldValue.toString()}
							onChange={(event) => addItemUpdate(itemId, writeableCellConfiguration.FieldName, event.currentTarget.value)}
						/>
						{cellErrors ? ErrorTooltip(cellIdentifier, cellErrors) : undefined}
					</div>
				);
			case CellType.number:
				return (
					<div key={cellIdentifier} className="cellGroup">
						<input
							type="number"
							key={`${cellIdentifier}-input`}
							className={`cell ${cellErrors ? "invalid" : ""}`}
							placeholder={writeableCellConfiguration.PlaceHolder}
							value={parseFloat(fieldValue)}
							onChange={(event) => {
								let userInput = event.currentTarget.valueAsNumber;
								//don't allow non-numeric input.
								if (isNaN(userInput)) return;
								addItemUpdate(itemId, writeableCellConfiguration.FieldName, userInput);
							}}
						/>
						{cellErrors ? ErrorTooltip(cellIdentifier, cellErrors) : undefined}
					</div>
				);
			default:
				throw new Error("Unrecognised CellType.");
		}
	}

	function renderItem(item: ItemType, fieldConfigurations: Array<ReadonlyCellConfiguration<ItemType> | WriteableCellConfiguration<ItemType>>): JSX.Element {
		let itemId = item.Id;
		let renderedCells: Array<JSX.Element> = [];
		for (let fieldName in item) {
			if (hiddenColumns.includes(fieldName)) continue;
			let fieldConfiguration = fieldConfigurations.find((config) => config.FieldName === fieldName);
			if (!fieldConfiguration) throw new Error(`Could not find a Cell Configuration for ${fieldName}. Please provide a configuration.`);
			let fieldValue = item[fieldName];
			let cell = renderField(itemId, fieldName, fieldValue, fieldConfiguration);
			renderedCells.push(cell);
		}

		return (
			<div key={itemId} className="row">
				{renderedCells}
			</div>
		);
	}

	return (
		<div className="dataTable">
			<div className="rows">{items.map((item) => renderItem(item, fieldConfigurations))}</div>
		</div>
	);
}
