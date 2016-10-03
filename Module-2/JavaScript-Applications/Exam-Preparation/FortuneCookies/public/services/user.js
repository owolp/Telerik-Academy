const userService = (() => {
	const URLS = {
		REGISTER: '/api/users',
		LOGIN: '/api/auth',
		LIKE: '/api/cookies/'
	};

	function login(user) {
		return requester.putJSON(URLS.LOGIN, user)
			.then(respUser => {
				let user = respUser.result
				let stringifiedUser = JSON.stringify(user);
				localStorage.setItem('loggedUser', stringifiedUser);
				localStorage.setItem('isLogged', 'loggedUser');
				localStorage.setItem("username", respUser.result.username);
				localStorage.setItem("authKey", respUser.result.authKey);

				let username = user.username;

				return username;
			});
	}

	function register(user) {
		return requester.postJSON(URLS.REGISTER, user);
	}

	function logout() {
		return Promise.resolve()
			.then(() => {
				localStorage.removeItem("username");
				localStorage.removeItem("authKey");
				localStorage.removeItem("loggedUser");
				localStorage.removeItem("isLogged");
			});
	}

	function isLogged() {
		const isLogged = localStorage.isLogged ? true : false;

		return isLogged;
	}

	function load() {
		if (!isLogged) {
			return;
		}

		const stringifiedUser = localStorage.getItem('loggedUser');
		const user = JSON.parse(stringifiedUser);

		return user;
	}

	function like(cookie) {
		let headers = {};
		let loggedUser = isLogged();

		if (loggedUser) {
			let user = load();
			headers = {
				'x-auth-key': user.authKey
			};
		}

		const url = URLS.LIKE + cookie.id;
		const json = {
			type: cookie.type
		};

		return requester.putJSON(url, json, headers);
	}

	function encode(username, password) {
		return sha1(username + password)
	}

	return {
		login,
		register,
		logout,
		isLogged,
		load,
		like
	}
})();