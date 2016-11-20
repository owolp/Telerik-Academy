/* globals module require */

"use strict";

const SimpleMovieProvider = require("./simple-movie-provider");
const DetailMovieProvider = require("./detail-movie-provider");

module.exports = {
	getSimpleMovieProvider() {
		return SimpleMovieProvider.getImdbSimpleMovies();
	},
	getDetailMovieProvider() {
		return DetailMovieProvider.getImdbDetailMovies();
	}
};