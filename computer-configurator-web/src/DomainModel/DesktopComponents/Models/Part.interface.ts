import { UniqueItem } from "../../../Components/DataTable/useItemManagement";

export default interface Part extends UniqueItem {
	Manufacturer: string;
	Description: string;
	Price: number;
}
