/* globals module require */

"use strict";

const Constants = require("../common/constants");

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

const ItemForSaleSchema = mongoose.Schema({
	name: {
		type: String,
		required: true,
		match: Constants.upperAndLowerCaseRegex
	},
	price: {
		type: Number
	},
	giveAwayStatus: {
		type: String,
		required: true,
		enum: ["Give away", "For Sale"]
	},
	offerStartDate: {
		type: Date,
		default: Date.now,
		required: true
	},
	offerEndDate: {
		type: Date,
		default: currentDatePlusOneMonth()
	}
});

function currentDatePlusOneMonth() {
	return +new Date() + 30 * 24 * 60 * 60 * 1000;
}

let ItemForSale;
ItemForSaleSchema.statics.getItemForSale = function (name, price, giveAwayStatus, offerStartDate, offerEndDate) {
	return new ItemForSale({
		name,
		price,
		giveAwayStatus,
		offerStartDate,
		offerEndDate
	});
};

mongoose.model("ItemForSale", ItemForSaleSchema);
ItemForSale = mongoose.model("ItemForSale");
module.exports = ItemForSale;