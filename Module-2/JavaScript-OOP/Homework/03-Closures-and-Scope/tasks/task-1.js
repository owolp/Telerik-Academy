'use strict';

function solve() {
	var library = (function() {
		var books = [];
		var categories = [];

		function listBooks() {
			let args = arguments[0];
			if (books.length === 0) {
				return [];
			} else if (books.length === 1) {
				if (!args || books[0].category === args.category) {
					return books;
				} else {
					return [];
				}
			} else if (args) {
				books = books.filter(function(book) {
					return book.category === args.category;
				});
			}

			books = books.sort(function(a, b) {
				return a.id - b.id;
			});

			return books;
		}

		function addBook(book) {
			checkStringLength(book.title);
			checkStringLength(book.category);
			checkBookAuthor(book.author);
			checkIsbn(book.isbn);
			checkBookTitle(book);
			checkIsbnRepeating(book);
			checkCategoryRepeating(book);

			book.ID = books.length + 1;
			books.push(book);
			return book;

			function checkStringLength(value) {
				const MIN_LENGTH = 2;
				const MAX_LENGTH = 100;
				const length = value.length;
				if (length < MIN_LENGTH || length > MAX_LENGTH) {
					throw new Error();
				}
			}

			function checkBookAuthor(value) {
				let bookAuthor = value.author;
				if (bookAuthor === '') {
					throw new Error();
				}
			}

			function checkIsbn(value) {
				const length = value.length;
				const ISBN_FIRST_LENGTH = 10;
				const ISBN_SECOND_LENGTH = 13;
				if (length !== ISBN_FIRST_LENGTH && length !== ISBN_SECOND_LENGTH) {
					throw new Error();
				}
			}

			function checkBookTitle(value) {
				let bookTitle = value.title;
				for (let i = 0, length = books.length; i < length; i += 1) {
					let currentBookTitle = books[i].title;
					if (currentBookTitle === bookTitle) {
						throw new Error();
					}
				}
			}

			function checkIsbnRepeating(value) {
				let bookIsbn = value.isbn;
				for (let i = 0, length = books.length; i < length; i += 1) {
					let currentBookIsbn = books[i].isbn;
					if (currentBookIsbn === bookIsbn) {
						throw new Error();
					}
				}
			}

			function checkCategoryRepeating(value) {
				let currentBookCategory = value.category;
				let isFound = false;
				for (let i = 0, length = categories.length; i < length; i += 1) {
					let currentCategory = categories[i];
					if (currentCategory === currentBookCategory) {
						isFound = true;
					}
				}

				if (!isFound) {
					categories.push(currentBookCategory);
				}
			}
		}

		function listCategories() {
			return categories;
		}

		return {
			books: {
				list: listBooks,
				add: addBook
			},
			categories: {
				list: listCategories
			}
		};
	}());

	return library;
}

module.exports = solve;