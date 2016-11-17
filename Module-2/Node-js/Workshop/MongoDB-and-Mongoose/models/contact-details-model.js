/* globals module require */

"use strict";

const Constants = require("../common/constants");

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

const ContactDetailsSchema = mongoose.Schema({
	phoneNumber: {
		type: String,
		match: Constants.phoneNumber
	},
	emailAddress: {
		type: String,
		required: true,
		match: Constants.emailRegex
	},
	workRoomNumber: {
		type: Number,
		required: true,
		min: 100,
		max: 999
	}
});

let ContactDetails;
ContactDetailsSchema.statics.getContactDetails = function (phoneNumber, emailAddress, workRoomNumber) {
	return new ContactDetails({
		phoneNumber,
		emailAddress,
		workRoomNumber
	});
};

mongoose.model("ContactDetails", ContactDetailsSchema);
ContactDetails = mongoose.model("ContactDetails");
module.exports = ContactDetails;