const todoService = (() => {
	const URLS = {
		GET: 'api/todos',
		ADD: 'api/todos'
	};

	function all() {
		let headers = {};
		let loggedUser = userService.isLogged();
		if (loggedUser) {
			let user = userService.load();
			headers = {
				'x-auth-key': user.authKey
			};
		} else {
			console.log('Not logged in');
		}

		return requester.get(URLS.GET, headers);
	}

	function add(item) {

		let headers = {};
		let loggedUser = userService.isLogged();

		if (loggedUser) {
			let user = userService.load();
			headers = {
				'x-auth-key': user.authKey
			};
		} else {
			console.log('Not logged in');
		}

		return requester.postJSON(URLS.ADD, item, headers);
			// .then((response) => {
			// 	return response.result;
			// });
	}

	return {
		all,
		add
	};
})();