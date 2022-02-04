export function validateMinimumLength(userInput: string, value: number) {
	let description = value === 1 ? "character" : "characters";
	let errorMessage: string = `Must be at least ${value} ${description}.`;

	if (userInput.length < value) return errorMessage;
	else return "";
}

export function validateMaximumLength(userInput: string, value: number) {
	let description = value === 1 ? "character" : "characters";
	let errorMessage: string = `Must be ${value} ${description} or less.`;

	if (userInput.length > value) return errorMessage;
	else return "";
}

export function validateMinimumValue(userInput: number, value: number) {
	let errorMessage: string = `Must be at least ${value}.`;

	if (userInput < value) return errorMessage;
	else return "";
}

export function validateMaximumValue(userInput: number, value: number) {
	let errorMessage: string = `Must be ${value} or less.`;

	if (userInput > value) return errorMessage;
	else return "";
}
