/* globals require module */

"use strict";

const queuesFactory = require("./../data-structures/queue");
const constants = require("./../config/constants");

let urlProvider = queuesFactory.getQueue();

constants.genres.forEach(genre => {
    for (let i = 0; i < constants.pagesCount; i += 1) {
        let url = constants.imdbMovieUrl({
            "genre": genre.toString(),
            "page": i + 1
        });
        urlProvider.push(url);
    }
});

module.exports.urlsQueue = urlProvider;