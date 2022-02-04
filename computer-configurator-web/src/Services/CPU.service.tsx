import { PagedResponse } from "../DomainModel/APIResponse.interface";
import { CPU } from "../DomainModel/DesktopComponents/Models/CPU.interface";

import { http, config } from "./AxiosBase.service";

export async function AllCPU() {
	let params = {};
	let response = await http.get<PagedResponse<CPU>>("/Parts/CPU/All", { ...config, params });
	return response.data;
}
