'use strict'

function solve() {
	function* IdGenerator() {
		// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/yield
		let indexId = 0;
		while (true) {
			yield indexId += 1;
		}
	}

	function findIndexOfId(collection, id) {
		let i, len;
		for (i = 0, len = collection.length; i < len; i++) {
			if (collection[i].id == id) {
				return i;
			}
		}

		return -1;
	}

	const playerIdGenerator = IdGenerator(),
		playListIdGenerator = IdGenerator(),
		playableIdGenerator = IdGenerator(),
		CONSTANTS = {
			TEXT_MIN_LENGTH: 3,
			TEXT_MAX_LENGTH: 25,
			IMDB_MIN_RATING: 1,
			IMDB_MAX_RATING: 5,
			MAX_NUMBER: 9007199254740992
		};

	class Validator {
		static validateIfUndefined(value) {
			if (value === undefined) {
				throw new Error();
			}
		}

		static validateIfObject(value) {
			if (typeof value !== 'object') {
				throw new Error();
			}
		}

		static validateIfNumber(value) {
			if (typeof value !== 'number') {
				throw new Error();
			}
		}

		static validateString(value) {
			if (typeof value !== 'string') {
				throw new Error();
			}

			if (value.length < CONSTANTS.TEXT_MIN_LENGTH ||
				CONSTANTS.TEXT_MAX_LENGTH < value.length) {
				throw new Error();
			}
		}

		static validatePositiveNumber(value) {
			this.validateIfUndefined(value);
			this.validateIfNumber(value);

			if (value <= 0) {
				throw new Error();
			}
		}

		static validateImdbRating(value) {
			this.validateIfUndefined(value);
			this.validateIfNumber(value);

			if (value < CONSTANTS.IMDB_MIN_RATING || CONSTANTS.IMDB_MAX_RATING < value) {
				throw new Error();
			}
		}

		static validateId(value) {
			if (typeof value !== 'number') {
				value = value.id;
			}

			this.validateIfNumber(value);

			return value;
		}

		static validatePage(value) {
			if (value < 0) {
				throw new Error();
			}
		}

		static validateSize(page, size, maxElements) {
			if (page * size > maxElements) {
				throw new Error();
			}
		}
	}

	class Player {
		constructor(name) {
			Validator.validateString(name, 'Name');

			this.name = name;
			this.id = playerIdGenerator.next().value;
			this.playlist = [];
		}

		addPlaylist(playlistToAdd) {
			Validator.validateIfUndefined(playlistToAdd);

			if (!(playlistToAdd instanceof Playlist)) {
				throw new Error();
			}

			this.playlist.push(playlistToAdd);
			return this;
		}

		getPlaylistById(id) {
			Validator.validateIfUndefined(id);
			Validator.validateIfNumber(id);
			Validator.validateId(id);

			let foundIndex = findIndexOfId(this.playlist, id);
			if (foundIndex < 0) {
				return null;
			}

			return this.playlist[foundIndex];
		}

		removePlaylist(id) {
			Validator.validateIfUndefined(id);
			Validator.validateIfNumber(id);
			Validator.validateId(id);

			id = Validator.validateId(id);

			let foundIndex = findIndexOfId(this.playlist, id);
			if (foundIndex < 0) {
				throw new Error();
			}

			this.playlist.splice(foundIndex, 1);

			return this;
		}

		listPlaylists(page, size) {
			Validator.validateIfUndefined(page);
			Validator.validateIfNumber(page);
			Validator.validatePage(page);

			Validator.validateIfUndefined(size);
			Validator.validateIfNumber(size);
			Validator.validateSize(size);

			// TODO:
		}

		contains(playable, playlist) {
			// TODO:
		}

		search(pattern) {
			// TODO
		}
	}

	class Playlist {
		constructor(name) {
			Validator.validateString(name, 'Name');

			this.id = playListIdGenerator.next().value;
			this.name = name;
			this.playables = [];
		}

		addPlayable(playable) {
			this.playables.push(playable);

			return this;
		}

		getPlayableById(id) {
			Validator.validateIfUndefined(id);
			Validator.validateIfNumber(id);
			Validator.validateId(id);

			let foundIndex = findIndexOfId(this.playables, id);
			if (foundIndex < 0) {
				return null;
			}

			return this.playables[foundIndex];
		}

		removePlayable(id) {
			Validator.validateIfUndefined(id);
			Validator.validateId(id);

			id = Validator.validateId(id);

			let foundIndex = findIndexOfId(this.playables, id);
			if (foundIndex < 0) {
				throw new Error();
			}

			this.playables.splice(foundIndex, 1);

			return this;
		}
	}

	class Playable {
		constructor(title, author) {
			Validator.validateString(title);
			Validator.validateIfUndefined(title);

			Validator.validateString(author);
			Validator.validateIfUndefined(author);

			this.id = playableIdGenerator().next().value;
			this.title = title;
			this.author = author;
		}

		play() {
			return `${this.id}. ${this.title} - ${this.author}`;
		}
	}

	class Audio extends Playable {
		constructor(title, author, length) {
			Validator.validateIfUndefined(length);
			Validator.validateIfNumber(length);
			Validator.validatePositiveNumber(length);

			super(title, author);
			this.length = length;
		}

		play() {
			return `${super.play()} - ${this.length}`;
		}
	}

	class Video extends Playable {
		constructor(title, author, imdbRating) {
			Validator.validateIfUndefined(imdbRating);
			Validator.validateIfNumber(imdbRating);
			Validator.validateImdbRating(imdbRating);

			super(title, author);
			this.imdbRating = imdbRating;
		}

		play() {
			return `${super.play()} - ${this.imdbRating}.`;
		}
	}

	return {
		getPlayer: function(name) {
			return new Player(name);
		},
		getPlaylist: function(name) {
			return new Playlist(name);
		},
		getAudio: function(title, author, length) {
			return new Audio(title, author, length);
		},
		getVideo: function(title, author, imdbRating) {
			return new Video(title, author, imdbRating);
		}
	};
}

module.exports = solve;

// var result = solve();

// var name, player, playlist, returnedPlayer;
// name = 'Rock and roll';
// player = result.getPlayer(name);
// playlist = result.getPlaylist(name);
// // expect(player.addPlaylist).to.exist;
// // expect(player.addPlaylist).to.be.a('function');
// // expect(player.addPlaylist).to.have.length(1);

// returnedPlayer = player.addPlaylist(playlist);
// // return expect(returnedPlayer).to.equal(player);