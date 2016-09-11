/* beforeach: start */
var utils = (function() {
	var CONSTS = {
		NAME: {
			MIN: 2,
			MAX: 40
		},
		DESCRIPTION: {
			MIN: 1,
			MAX: 1000
		},
		ISBN10: {
			LENGTH: 10
		},
		ISBN13: {
			LENGTH: 13
		},
		GENRE: {
			MIN: 2,
			MAX: 20
		},
		DURATION: {
			MIN: 0,
			MAX: 10000
		},
		RATING: {
			MIN: 1,
			MAX: 5
		},
		CHARS: 'QWERTYUIOPASDFGHJKLZXCVBNM _.-?!,\'\":;',
		DIGIS: '0123456789'
	};

	function getRandom(min, max) {
		if (typeof(max) === 'undefined') {
			max = min;
			min = 0;
		}
		/* jshint ignore: start */
		return (Math.random() * (max - min) + min) | 0;
		/* jshint ignore: end */
	}

	function getRandomString(chars, length) {
		return Array.apply(null, {
			length: length
		}).map(function() {
			return chars[getRandom(chars.length)];
		}).join('');
	}

	var utils = {
		valid: {
			getName: function() {
				var length = getRandom(CONSTS.NAME.MIN, CONSTS.NAME.MAX);
				return getRandomString(CONSTS.CHARS, length);
			},
			getISBN10: function() {
				var length = 10;
				return getRandomString(CONSTS.DIGIS, length);
			},
			getISBN13: function() {
				var length = 13;
				return getRandomString(CONSTS.DIGIS, length);
			},
			getGenre: function() {
				var length = getRandom(CONSTS.GENRE.MIN, CONSTS.GENRE.MAX);
				return getRandomString(CONSTS.CHARS, length);
			},
			getDescription: function() {
				var length = getRandom(CONSTS.DESCRIPTION.MIN, CONSTS.DESCRIPTION.MAX);
				return getRandomString(CONSTS.CHARS, length);
			},
			getDuration: function() {
				return getRandom(0, 1000);
			},
			getRating: function() {
				return getRandom(1, 5);
			}
		},
		invalid: {
			getShorterName: function() {
				var length = getRandom(0, CONSTS.NAME.MIN - 1);
				return getRandomString(CONSTS.CHARS, length);
			},
			getLongerName: function() {
				var length = getRandom(CONSTS.NAME.MAX + 1, CONSTS.NAME.MAX * 2);
				return getRandomString(CONSTS.CHARS, length);
			},
			getInvalidISBN10WithLetters: function() {
				var isbn = utils.valid.getISBN10().split(''),
					index = getRandom(isbn.length);
				isbn.splice(index, 1, 'a');
				return isbn;
			},
			getInvalidISBN13WithLetters: function() {
				return utils.valid.getISBN13().substring(1);
			},
			getInvalidISBNNot10or13: function() {
				var isbn = utils.valid.getISBN13().split(''),
					index = getRandom(isbn.length);
				isbn.splice(index, 1, 'a');
				return isbn;
			},
			getShorterDescription: function() {
				var length = getRandom(0, CONSTS.DESCRIPTION.MIN - 1);
				return getRandomString(CONSTS.CHARS, length);
			},
			getLongerDescription: function() {
				var length = getRandom(CONSTS.DESCRIPTION.MAX + 1, CONSTS.DESCRIPTION.MAX * 2);
				return getRandomString(CONSTS.CHARS, length);
			},
			getShorterGenre: function() {
				var length = getRandom(0, CONSTS.GENRE.MIN - 1);
				return getRandomString(CONSTS.CHARS, length);
			},
			getLongerGenre: function() {
				var length = getRandom(CONSTS.GENRE.MAX + 1, CONSTS.GENRE.MAX * 2);
				return getRandomString(CONSTS.CHARS, length);
			},
			getSmallRating: function() {
				return 0;
			},
			getLargeRating: function() {
				return getRandom(6, 1000);
			}
		}
	};

	return utils;
}());
/* beforeach: end */

/* globals module */
function solve() {
	const getId = (function() {
		let id = 0;

		return function() {
			id += 1;
			return id;
		};
	}());

	const itemIdGenerator = CONSTANTS = {
		ITEM_NAME_MIN_LENGTH: 2,
		ITEM_NAME_MAX_LENGTH: 40,
		BOOK_ISBN_MIN_LENGTH: 10,
		BOOK_ISBN_MAX_LENGTH: 13,
		BOOK_GENRE_MIN_LENGTH: 2,
		BOOK_GENRE_MAX_LENGTH: 20
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

		static validateIfString(value) {
			if (typeof value !== 'string') {
				throw new Error();
			}
		}

		static validateIfStringIsEmpty(value) {
			if (value === '') {
				throw new Error();
			}
		}

		static validateLengthIsExact(value, firstValue, secondValue) {
			if (value.length !== firstValue &&
				secondValue !== value.length) {
				throw new Error();
			}
		}

		static validateLength(value, min, max) {
			if (value.length < min ||
				value.length > max) {
				throw new Error();
			}
		}

		static validateIfContainsOnlyDigits(value) {
			let isNum = value.match(/^[0-9]*$/);
			if (!isNum) {
				throw new Error();
			}
		}
	}

	class Item {
		constructor(name, description) {
			this.name = name;
			this.description = description;
			this.id = getId();
		}

		get name() {
			return this._name;
		}
		set name(name) {
			Validator.validateIfUndefined(name);
			Validator.validateIfString(name);
			Validator.validateLength(name, CONSTANTS.ITEM_NAME_MIN_LENGTH, CONSTANTS.ITEM_NAME_MAX_LENGTH);

			this._name = name;
		}

		get description() {
			return this._description;
		}
		set description(description) {
			Validator.validateIfUndefined(description);
			Validator.validateIfString(description);
			Validator.validateIfStringIsEmpty(description);

			this._description = description;
		}
	}

	class Book extends Item {
		constructor(name, isbn, genre, description) {
			super(name, description);
			this.isbn = isbn;
			this.genre = genre;
		}

		get isbn() {
			return this._isbn;
		}
		set isbn(isbn) {
			Validator.validateIfUndefined(isbn);
			Validator.validateIfString(isbn);
			Validator.validateIfContainsOnlyDigits(isbn);
			Validator.validateLengthIsExact(isbn, CONSTANTS.BOOK_ISBN_MIN_LENGTH, CONSTANTS.BOOK_ISBN_MAX_LENGTH);

			this._isbn = isbn;
		}

		get genre() {
			return this._genre;
		}
		set genre(genre) {
			Validator.validateIfUndefined(genre);
			Validator.validateIfString(genre);

			if (genre.length < CONSTANTS.BOOK_GENRE_MIN_LENGTH ||
				genre.length >= CONSTANTS.BOOK_GENRE_MAX_LENGTH) {
				throw new Error();
			}

			this._genre = genre;
		}
	}

	class Media extends Item {
		constructor(name, rating, duration, description) {
			super(name, description);
			this.rating = rating;
			this.duration = duration;
		}

		get rating() {
			return this._rating;
		}
		set rating(rating) {
			Validator.validateIfUndefined(rating);
			Validator.validateIfNumber(rating);

			if (rating < 1 ||
				rating >= 5) {
				throw new Error();
			}

			this._rating = rating;
		}

		get duration() {
			return this._duration;
		}
		set duration(duration) {
			Validator.validateIfUndefined(duration);
			Validator.validateIfNumber(duration);

			if (duration <= 0) {
				throw new Error();
			}

			this._duration = duration;
		}
	}

	class Catalog {
		constructor(name) {
			this.id = getId();
			this.name = name;
			this.items = [];
		}

		get name() {
			return this._name;
		}
		set name(name) {
			Validator.validateIfUndefined(name);
			Validator.validateIfString(name);
			Validator.validateLength(name, 2, 40);

			this._name = name;
		}

		add(...items) {
			if (Array.isArray(items[0])) {
				items = items[0];
			}

			if (items.length === 0) {
				throw 'The array is empty';
			}

			for (let i = 0, length = this.items.length; i < length; i += 1) {
				let currentItem = this.items[i];
				if (!(currentItem instanceof Item)) {
					throw 'Not an Item object';
				}
			}

			this.items.push(...items);

			return this;
		}

		find(param) {
			Validator.validateIfUndefined(param);

			if (typeof param === 'number') {
				for (let i = 0, length = this.items.length; i < length; i += 1) {
					let currentItem = this.items[i];
					if (currentItem.id === param) {
						return currentItem;
					}
				}

				return null;
			} else if (param !== null && typeof param === 'object') {

			} else {
				throw new Error();
			}
		}

		search(pattern) {
			Validator.validateIfUndefined(pattern);
			Validator.validateIfString(pattern);
			Validator.validateIfStringIsEmpty(pattern);

			return this.items.filter(function(item) {
				return item.name.indexOf(pattern) >= 0 ||
					item.description.indexOf(pattern) >= 0;
			});
		}

		getSortedByDuration() {
			this.items.sort((a, b) => {
				if (a.duration === b.duration) {
					return a.id < b.id;
				}

				return a.duration > b.duration;
			});
		}
	}

	class BookCatalog extends Catalog {
		constructor(name) {
			super(name);
		}

		add(...books) {
			Validator.validateIfUndefined(...books);

			if (Array.isArray(books[0])) {
				books = books[0];
			}

			for (let i = 0, length = books.length; i < length; i += 1) {
				let currentItem = books[i];
				if (!(currentItem instanceof Book)) {
					throw 'Not a Book object';
				}
			}

			return super.add(...books);
		}

		getGenres() {
			let uniq = {};
			this.items.forEach(x => uniq[x.genre] = true);
			return Object.keys(uniq);
		}

		find(x) {
			return super.find(x);
		}
	}

	class MediaCatalog extends Catalog {
		constructor(name) {
			super(name);
		}

		add(...media) {
			Validator.validateIfUndefined(...media);

			if (Array.isArray(media[0])) {
				media = media[0];
			}

			for (let i = 0, length = media.length; i < length; i += 1) {
				let currentItem = media[i];
				if (!(currentItem instanceof Media)) {
					throw 'Not a Media object';
				}
			}

			return super.add(...media);
		}

		getTop(count) {
			Validator.validateIfNumber(count);
			if (count < 1) {
				throw "Count is less than 1";
			}


		}
	}

	return {
		getBook: function(name, isbn, genre, description) {
			return new Book(name, isbn, genre, description);
		},
		getMedia: function(name, rating, duration, description) {
			return new Media(name, rating, duration, description);
		},
		getBookCatalog: function(name) {
			return new BookCatalog(name);
		},
		getMediaCatalog: function(name) {
			return new MediaCatalog(name);
		}
	};
}

module.exports = solve;
// var result = solve();

// var name = utils.valid.getName(),
// 	catalog = result.getMediaCatalog(name);

// // expect(result.getMediaCatalog).to.exist;
// // expect(result.getMediaCatalog).to.be.a('function');
// // expect(catalog).to.be.a('object');
// // expect(catalog.name).to.be.a('string');
// // expect(catalog.name).to.equal(name);

// // expect(catalog.items).to.exist;
// // expect(Array.isArray(catalog.items)).to.be.true;

// // expect(catalog.add).to.exist;
// // expect(catalog.add).to.be.a('function');

// // expect(catalog.find).to.exist;
// // expect(catalog.find).to.be.a('function');
// // expect(catalog.find.length).to.equal(1);

// // expect(catalog.search).to.exist;
// // expect(catalog.search).to.be.a('function');
// // expect(catalog.search.length).to.equal(1);

// // expect(catalog.getTop).to.exist;
// // expect(catalog.getTop).to.be.a('function');
// // expect(catalog.getTop.length).to.equal(1);

// // expect(catalog.getSortedByDuration).to.exist;
// // expect(catalog.getSortedByDuration).to.be.a('function');
// // expect(catalog.getSortedByDuration.length).to.equal(0);