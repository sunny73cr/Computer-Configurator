import { PagedResponse } from "../DomainModel/APIResponse.interface";
import Part from "../DomainModel/DesktopComponents/Models/Part.interface";

import { http, config } from "./AxiosBase.service";

export async function AllParts() {
	let params = {};
	let response = await http.get<PagedResponse<Part>>("/Parts/All", { ...config, params });
	let pagedParts = response.data;
	return pagedParts.Data;
}
