//https://stackoverflow.com/questions/63553724/filter-interface-keys-for-a-sub-list-of-keys-based-on-value-type
//
//keys in Type with a value type of ValueType are:
type KeysWithValueType<Type, ValueType> = {
	//if the value type for the FieldName in keys of Type extends ValueType
	[FieldName in keyof Type]: Type[FieldName] extends ValueType ? FieldName : never;
	//true: return the type of FieldName - is a key in Type with a value type of ValueType.
	//false: never returns - not a key in Type with a value type of ValueType.
};
//get the value type for a key in Type.
export type ValueOf<Type> = Type[keyof Type];
//searchable keys in Type are the value of KeysWithValueType 'string' in Type.
export type SearchableKeys<Type> = ValueOf<KeysWithValueType<Type, string>>;

// function filterItems(parts: Array<Part>, fieldName: SearchableKeys<Part>, searchTerm: string): Array<Part> {
// 	let filtered = parts.filter((part) => part[fieldName].includes(searchTerm));
// 	console.log("filtered parts", filtered);
// 	return filtered;
// }
