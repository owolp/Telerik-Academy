const userService = (() => {
	const URLS = {
		USERS: 'api/users',
		AUTH: 'api/users/auth'
	};

	function login(user) {
		return requester.putJSON(URLS.AUTH, user)
			.then((response) => {
				window.localStorage.setItem('username', response.result.username);
				window.localStorage.setItem('authKey', response.result.authKey);
				return response;
			});
	}

	function register(user) {
		return requester.postJSON(URLS.USERS, user);
	}

	function logout() {
		return new Promise((resolve, reject) => {
			window.localStorage.removeItem('username');
			window.localStorage.removeItem('authKey');
			resolve();
		});
	}

	return {
		login,
		register,
		logout
	}
})();