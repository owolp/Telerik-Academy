const cookiesService = (() => {
	const URLS = {
		ALL: 'api/cookies',
		MY: 'api/my-cookie'
	};

	function all() {
		return requester.get(URLS.ALL);
	}

	function myCookie() {
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

		return requester.get(URLS.MY, headers);
	}

	return {
		all,
		myCookie
	}
})();