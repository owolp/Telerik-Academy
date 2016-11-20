/* globals module require */

const SimpleMovie = require("./simple-movie-model");
const DetailMovie = require("./detail-movie-model");

module.exports = {
	getSimpleMovie(name, url) {
		return SimpleMovie.getSimpleMovieByNameAndUrl(name, url);
	},
	insertManySimpleMovies(movies) {
		SimpleMovie.insertMany(movies);
	},
	getDetailMovie(movie) {
		return DetailMovie.getDetailMovie(movie);
	},
	insertManyDetailMovies(movies) {
		DetailMovie.insertMany(movies);
	}
};