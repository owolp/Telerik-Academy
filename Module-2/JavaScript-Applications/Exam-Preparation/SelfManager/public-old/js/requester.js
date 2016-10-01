/* globals $ Promise */

let requester = {
	register(url, body, options = {}) {
		let promise = new Promise((resolve, reject) => {
			var headers = options.headers || {};

			$.ajax({
				url,
				headers,
				method: "POST",
				contentType: "application/json",
				data: JSON.stringify(body),
				success(response) {
					resolve(response);
				}
			});
		});
		return promise;
	},

	login(url, body, options = {}) {
		let promise = new Promise((resolve, reject) => {
			var headers = options.headers || {};

			$.ajax({
				url,
				headers,
				method: "PUT",
				contentType: "application/json",
				data: JSON.stringify(body),
				success(response) {
					resolve(response);
				}
			});
		});
		return promise;
	},

	getTodo(url, options) {
		let promise = new Promise((resolve, reject) => {
			var headers = options.headers || {};

			$.ajax({
				url,
				method: "GET",
				contentType: "application/json",
				headers,
				success(response) {
					resolve(response);
				}
			});
		});
		// console.log(promise);
		return promise;
	},

};