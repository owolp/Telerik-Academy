/* globals Navigo controllers $ dataService document */

let router = new Navigo(null, false);

router
	.on('/', function () {
		window.location = '#/home';
	})
	.on('#/home', homeController.all)
	.on('#/register', userController.register)
	.on("#/todo", todoController.all)
	.on("#/todo/add", todoController.add)
	// .on("#/events", controllersInstance.events)
	// .on(() => router.navigate("#/"))
	.resolve();