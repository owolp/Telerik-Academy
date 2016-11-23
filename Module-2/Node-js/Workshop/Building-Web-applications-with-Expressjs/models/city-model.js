/* globals module require */

"use strict";

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

const CitySchema = new mongoose.Schema({
	name: {
		type: String,
		unique: true,
		min: 2,
		max: 30
	}
});

let City;
CitySchema.statics.getCity = (city) => {
	return new City({
		name: city.name
	});
};
mongoose.model("City", CitySchema);
CitySchema = mongoose.model("City");
module.exports = mongoose.model("City");

// Each city has a name and country- Create

//     Between 2 and 30 characters long
//     Unique
