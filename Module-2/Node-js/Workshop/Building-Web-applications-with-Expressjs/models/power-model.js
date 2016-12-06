/* globals module require */

"use strict";

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

const PowerSchema = new mongoose.Schema({
	name: {
		type: String,
		unique: true,
		min: 3,
		max: 35
	}
});

let Power;
PowerSchema.statics.getPower = (power) => {
	return new Power({
		name: power.name
	});
};
mongoose.model("Power", PowerSchema);
Power = mongoose.model("Power");
module.exports = mongoose.model("Power");