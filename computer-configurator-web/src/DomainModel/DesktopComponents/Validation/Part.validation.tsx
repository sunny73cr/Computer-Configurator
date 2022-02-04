import { validateMaximumLength, validateMaximumValue, validateMinimumLength, validateMinimumValue } from "../../../Services/InputValidation.service";

export function ValidateManufacturer(userInput: string) {
	let errors: Array<string> = [];

	errors.push(validateMinimumLength(userInput, 1));

	errors.push(validateMaximumLength(userInput, 50));

	let filteredErrors = errors.filter((error) => error.length > 0);
	if (filteredErrors.length > 0) return filteredErrors;
	else return undefined;
}

export function ValidateDescription(userInput: string) {
	let errors: Array<string> = [];

	errors.push(validateMinimumLength(userInput, 1));

	errors.push(validateMaximumLength(userInput, 50));

	let filteredErrors = errors.filter((error) => error.length > 0);
	if (filteredErrors.length > 0) return filteredErrors;
	else return undefined;
}

export function ValidatePrice(userInput: number) {
	let errors: Array<string> = [];

	errors.push(validateMinimumValue(userInput, 1));

	errors.push(validateMaximumValue(userInput, 999999));

	let filteredErrors = errors.filter((error) => error.length > 0);
	if (filteredErrors.length > 0) return filteredErrors;
	else return undefined;
}
