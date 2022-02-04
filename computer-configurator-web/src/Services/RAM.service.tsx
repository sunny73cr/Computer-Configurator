import { PagedResponse } from "../DomainModel/APIResponse.interface";
import { RAM } from "../DomainModel/DesktopComponents/Models/RAM.interface";

import { http, config } from "./AxiosBase.service";

export async function AllRAM() {
	let params = {};
	let response = await http.get<PagedResponse<RAM>>("/Parts/RAM/All", { ...config, params });
	return response.data;
}
