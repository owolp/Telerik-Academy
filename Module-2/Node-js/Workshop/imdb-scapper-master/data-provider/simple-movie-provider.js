/* globals console module require */

"use strict";

const httpRequester = require("./../utils/http-requester");
const htmlParser = require("./../utils/html-parser");
const modelsFactory = require("./../models");
const constants = require("./../config/constants");
const waitTimeout = require("./../utils/wait");
const urlProvider = require("./../utils/url-provider");

require("./../config/mongoose")(constants.connectionString);

const urlsQueue = urlProvider.urlsQueue;

function getMoviesFromUrl(url) {
	httpRequester.get(url)
		.then((result) => {
			const selector = constants.httpRequestSelector;
			const html = result.body;
			return htmlParser.parseSimpleMovie(selector, html);
		})
		.then(movies => {
			let dbMovies = movies.map(movie => {
				return modelsFactory.getSimpleMovie(movie.title, movie.url);
			});

			modelsFactory.insertManySimpleMovies(dbMovies);

			return waitTimeout.wait(constants.waitTime);
		})
		.then(() => {
			if (urlsQueue.isEmpty()) {
				return;
			}

			getMoviesFromUrl(urlsQueue.pop());
		})
		.catch((err) => {
			console.dir(err, {
				colors: true
			});
		});
}

function getImdbSimpleMovies() {
	for (let i = 0; i <= constants.asyncPagesCount; i++) {
		getMoviesFromUrl(urlsQueue.pop());
	}
}

module.exports.getImdbSimpleMovies = getImdbSimpleMovies;