/* globals module require */

"use strict";

const City = require("./city-model");
const Country = require("./country-model");
const Planet = require("./planet-model");
const Power = require("./power-model");
const User = require("./user-model");

module.exports = {
	getCity(city) {
		return City.getCity(city);
	},
	getCountry(country) {
		return Country.getCity(country);
	},
	getPlanet(planet) {
		return Planet.getPlanet(planet);
	},
	getPower(power) {
		return Power.getPower(power);
	},
	getUser(user) {
		return User.getUser(user);
	}
};