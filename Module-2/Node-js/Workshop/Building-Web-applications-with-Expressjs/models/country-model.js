/* globals module require */

"use strict";

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

const PlanetSchema = require("./planet-model");

const CountrySchema = new mongoose.Schema({
	name: {
		type: String,
		required: true,
		unique: true,
		min: 2,
		max: 30
	},
	planet: {
		type: Schema.Types.ObjectId,
		ref: "PlanetSchema"
	}
});

let Country;
CountrySchema.statics.getCountry = (country) => {
	return new Country({
		name: country.name
	});
};
mongoose.model("Country", CountrySchema);
Country = mongoose.model("Country");
module.exports = mongoose.model("Country");

// Each country has a "planet":

//     name:
//         Between 2 and 30 characters long
//         Unique