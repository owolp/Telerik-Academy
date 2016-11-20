/* globals require module */

"use strict";

const _ = require("lodash");

const mongoose = require("mongoose"),
	Schema = mongoose.Schema;

let DetailMovieSchema = new Schema({
	title: {
		type: String,
		required: true
	},
	description: {
		type: String,
		required: true
	},
	releaseDate: {
		type: String,
		require: true
	},
	coverImage: {
		type: String,
		required: true
	},
	trailer: {
		type: String
	},
	genres: [{
		type: String
	}],
	actors: [{
		role: String,
		name: String,
		imdbId: String,
		profileImage: String
	}]
});

let DetailMovie;
DetailMovieSchema.statics.getDetailMovie =
	function (movie) {
		return new DetailMovie({
			title: movie.title,
			description: movie.description,
			coverImage: movie.cover,
			trailer: movie.trailer
		});
	};


mongoose.model("DetailMovie", DetailMovieSchema);
DetailMovie = mongoose.model("DetailMovie");
module.exports = DetailMovie;