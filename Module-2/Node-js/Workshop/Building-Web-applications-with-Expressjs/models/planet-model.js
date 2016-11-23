/* globals module require */

"use strict";

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

const PlanetSchema = new mongoose.Schema({
	name: {
		type: String,
		unique: true,
		min: 2,
		max: 30
	}
});

let Planet;
PlanetSchema.statics.getPlanet = (planet) => {
	return new Planet({
		name: planet.name
	});
};
mongoose.model("Planet", PlanetSchema);
PlanetSchema = mongoose.model("Planet");
module.exports = mongoose.model("Planet");