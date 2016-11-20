/* globals module require Promise */

"use strict";

const constants = require("./../config/constants");

const jsdom = require("jsdom").jsdom,
	doc = jsdom(),
	window = doc.defaultView,
	$ = require("jquery")(window);

function parseDetailMovie(html) {
	$("body").html(html);

	let movie = {
		title: $(constants.titleSelector).text().trim(),
		description: $(constants.descriptionSelector).text().trim(),
		cover: $(constants.coverSelector).attr("src"),
		trailer: $(constants.trailerSelector).attr("href")
	};

	return Promise.resolve()
		.then(() => {
			return movie;
		});
}

module.exports.parseSimpleMovie = (selector, html) => {
	$("body").html(html);
	let items = [];
	$(selector).each((index, item) => {
		const $item = $(item);

		items.push({
			title: $item.html(),
			url: $item.attr(constants.attributeToParseMovie)
		});
	});

	return Promise.resolve()
		.then(() => {
			return items;
		});
};

module.exports.parseDetailMovie = parseDetailMovie;