/* globals require module */

"use strict";

const constants = require("./../config/constants");
const imdbUrlExtractor = require("./../utils/imdb-url-extractor");
const _ = require("lodash");

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

let SimpleMovieSchema = new Schema({
	name: {
		type: String,
		required: true
	},
	imdbId: {
		type: String,
		required: true
	}
});

let SimpleMovie;
SimpleMovieSchema.statics.getSimpleMovieByNameAndUrl =
	function (name, url) {
		let imdbId = imdbUrlExtractor(url);
		return new SimpleMovie({
			name,
			imdbId
		});
	};

SimpleMovieSchema.virtual.imdbUrl = function () {
	return constants.imdbUrl({
		"imdbId": this.imdbId
	});
};

mongoose.model("SimpleMovie", SimpleMovieSchema);
SimpleMovie = mongoose.model("SimpleMovie");
module.exports = SimpleMovie;