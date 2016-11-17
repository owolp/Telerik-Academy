/* globals module require */

"use strict";

const ItemForSaleSchema = require("./item-for-sale-model");
const ItemReceivedSchema = require("./item-received-model");
const ContactDetailsSchema = require("./contact-details-model");
const Constants = require("../common/constants");

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

const nameValidator = [{
	validator: function (v) {
		return (Constants.upperAndLowerCaseRegex).test(v);
	},
	message: "The {v} must start with an uppercase letter."
}, {
	validator: function (v) {
		return (Constants.englishLettersRegex).test(v);
	},
	message: "The {v} must contain only english letters."
}];

const EmployeeSchema = mongoose.Schema({
	firstName: {
		type: String,
		required: true
		// validate: nameValidator
	},
	middleName: {
		type: String,
		required: true
		// validate: nameValidator
	},
	lastName: {
		type: String,
		required: true
		// validate: nameValidator
	},
	insuranceNumber: {
		type: String,
		required: true,
		match: Constants.insuranceNumberRegex
	},
	age: {
		type: Number,
		min: 0,
		max: 120,
		required: true
	},
	contactDetails: {
		type: Schema.Types.ObjectId,
		ref: "ContactDetails"
	},
	itemsForSale: [{
		type: Schema.Types.ObjectId,
		ref: "ItemForSale"
	}],
	itemsReceived: [{
		type: Schema.Types.ObjectId,
		ref: "ItemReceived"
	}]
});

EmployeeSchema.virtual("fullName").get(function () {
	return `${this.firstName} ${this.middleName} ${this.lastName}`;
});

EmployeeSchema.virtual("fullName").set(function (fullName) {
	const names = fullName.split(" ");
	this.set("firstName", names[0]);
	this.set("middleName", names[1]);
	this.set("lastName", names[2]);
});

let Employee;
EmployeeSchema.statics.getEmployee = function (firstName, middleName, lastName, insuranceNumber, age, contactDetails, itemsForSale, itemsReceived) {
	let emp = new Employee({
		firstName,
		middleName,
		lastName,
		insuranceNumber,
		age,
		contactDetails,
		itemsForSale,
		itemsReceived
	});

	return emp;
};

mongoose.model("Employee", EmployeeSchema);
Employee = mongoose.model("Employee");
module.exports = Employee;