export interface PagedResponse<ArrayType> {
	PageNumber: number;
	TotalPages: number;
	Data: Array<ArrayType>;
}
