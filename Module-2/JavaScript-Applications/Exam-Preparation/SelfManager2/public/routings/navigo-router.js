var router = (function () {
	const router = new Navigo(null, true);
	const containerId = '#content';

	function start() {
		router.resolve();
	}

	router.on(() => {
		router.navigate('/home');
	});


	router.on('/login', () => {
		userController.login();
	});

	router.on('/logout', () => {
		userController.logout();
	});

	router.on('/todos', () => {
		todosController.load();
	});

	// router.on('/home/:type/:id', (params) => {
	// 	const cookie = {
	// 		type: params.type,
	// 		id: params.id
	// 	};

	// 	userController.like(cookie);
	// 	window.location = '#/';
	// });

	router.on('/home', () => {
		const hash = window.location.hash;
		const params = getQueryParams(hash);

		homeController.load(containerId, params);
	});

	router.notFound(() => {
		router.navigate('/home');
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