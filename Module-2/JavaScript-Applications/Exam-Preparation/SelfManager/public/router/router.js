var router = (function () {
	const navigo = new Navigo(null, true);

	function start() {
		navigo.resolve();
	}

	navigo.on(() => {
		navigo.navigate('/home');
	});

	navigo.on('/home', () => {
		homeController.main();
	});

	navigo.on('/login', () => {
		loginController.login();
	});


	navigo.on('/logout', () => {
		loginController.logout();
	});

	// navigo.on('/home', homeController.main);

	// navigo.on('/login', loginController.login);

	// navigo.on('/logout', loginController.logout);

	navigo.notFound(() => {
		navigo.navigate('/home');
	});

	return {
		start
	}
})();