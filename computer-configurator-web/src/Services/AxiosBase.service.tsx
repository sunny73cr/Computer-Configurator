import axios, { AxiosRequestConfig, AxiosInstance, AxiosError } from "axios";

const serverAddress: string = "https://localhost:8000/api/";

export enum StatusCode {
	OK = 200,
	Created = 201,
	NoContent = 204,
	BadRequest = 400,
	Unauthorized = 401,
	NotFound = 404,
	Conflict = 409,
	InternalServerError = 500
}

export function ErrorWithResponse(axiosError: AxiosError): string {
	let response = axiosError.response!;
	return `${response.status} : ${response.statusText} - ${response.data}`;
}

export function ErrorWithoutResponse(axiosError: AxiosError): string {
	let errorCode: boolean = axiosError.code ? true : false;

	if (errorCode) return `${axiosError.code} : ${axiosError.message}`;
	else return `FATAL : ${axiosError.message}`;
}

export const config: AxiosRequestConfig = {
	baseURL: serverAddress,
	timeout: 1000,
	headers: {},
	withCredentials: true,
	responseType: "json",
	responseEncoding: "UTF8"
};

export const http: AxiosInstance = axios.create(config);
