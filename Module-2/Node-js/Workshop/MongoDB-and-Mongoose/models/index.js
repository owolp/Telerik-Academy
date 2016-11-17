/* globals module require */

"use strict";

const Employee = require("./employee-model");
const ItemForSale = require("./item-for-sale-model");
const ItemReceived = require("./item-received-model");
const ContactDetails = require("./contact-details-model");

module.exports = {
	getEmployee(firstName, middleName, lastName, insuranceNumber, age, contactDetails, itemsForSale, itemsReceived) {
		return Employee.getEmployee(firstName, middleName, lastName, insuranceNumber, age, contactDetails, itemsForSale, itemsReceived);
	},
	insertManyEmployees(employees) {
		Employee.insertMany(employees);
	},
	getContactDetails(phoneNumber, emailAddress, workRoomNumber) {
		return ContactDetails.getContactDetails(phoneNumber, emailAddress, workRoomNumber);
	},
	getItemForSale(name, price, giveAwayStatus, offerStartDate, offerEndDate) {
		return ItemForSale(name, price, giveAwayStatus, offerStartDate, offerEndDate);
	},
	getItemReceived(name) {
		return ItemReceived(name);
	}
};