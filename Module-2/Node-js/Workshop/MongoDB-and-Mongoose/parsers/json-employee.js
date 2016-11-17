/* globals require module*/

"use strict";

const ModelsFactory = require("../models");

function jsonToEmployee(json) {
	const newEmployee = ModelsFactory.getEmployee(
		json.firstName,
		json.middleName,
		json.lastName,
		json.insuranceNumber,
		json.age,
		json.contactDetails,
		json.itemsForSale,
		json.itemsReceived
	);

	return newEmployee;
}

module.exports = jsonToEmployee;