var router = (function () {
	const navigo = new Navigo(null, true);
	const containerId = '#content';

	function start() {
		navigo.resolve();
	}

	navigo.on(() => {
		navigo.navigate('/home');
	});

	// navigo.on('/home', () => {
	// 	homeController.main();
	// });

	navigo.on('/login', () => {
		loginController.login();
	});

	navigo.on('/logout', () => {
		loginController.logout();
	});

	navigo.on('/my-cookie', () => {
		cookieController.main();
	});

	navigo.on('/add-cookie', () => {
		cookieController.add();
	});


	navigo.on('/home/:type/:id', (params) => {
		const cookie = {
			type: params.type,
			id: params.id
		};

		loginController.like(cookie);
		window.location = '#/';
	});

	navigo.on('/home', () => {
		const hash = window.location.hash;
		const params = getQueryParams(hash);

		homeController.main(containerId, params);
	});

	navigo.notFound(() => {
		navigo.navigate('/home');
	});

	function getQueryParams(hash) {
		hash = String(hash);

		let params = {};
		if (hash.indexOf('?') < 0) {
			return params;
		}

		const inputParams = hash.split('?')[1].split('&');
		inputParams.forEach(param => {
			const split = param.split('=');
			params[split[0]] = split[1];
		});

		return params;
	}

	return {
		start
	}
})();