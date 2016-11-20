/* globals require module */

"use strict";

const _ = require("lodash");

module.exports = {
    connectionString: "mongodb://localhost/moviesDb",
    genres: ["action", "sci-fi", "fantasy", "horror", "comedy"],
    pagesCount: 50,
    asyncPagesCount: 15,
    waitTime: 1000,

    // simple-movie-model
    stringAfterMovieId: "/?ref",
    stringBeforeMovieId: "/title/",
    imdbUrl: "http://imdb.com/title/<%= imdbId %>/?ref_=adv_li_tt",

    httpRequestSelector: ".col-title span[title] a",

    titleSelector: "div.title_wrapper h1",
    descriptionSelector: "div.plot_summary_wrapper div.plot_summary div.summary_text",
    coverSelector: "div.poster img",
    trailerSelector: "div.slate a",
    genresSelector: "span.itemprop[itemprop='genre']",

    //html-parse
    attributeToParseMovie: "href",

    // lodash
    imdbMovieUrl: _.template("http://www.imdb.com/search/title?genres=<%= genre %>&title_type=feature&0sort=moviemeter,asc&page=<%= page %>&view=simple&ref_=adv_nxt")
};