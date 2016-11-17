/* globals module require */

"use strict";

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

const ItemReceivedSchema = mongoose.Schema({
	name: String
});

let ItemReceived;
ItemReceivedSchema.statics.getItemReceived = function(name) {
	return new ItemReceived({
		name
	});
};

mongoose.model("ItemReceived", ItemReceivedSchema);
ItemReceived = mongoose.model("ItemReceived");
module.exports = ItemReceived;