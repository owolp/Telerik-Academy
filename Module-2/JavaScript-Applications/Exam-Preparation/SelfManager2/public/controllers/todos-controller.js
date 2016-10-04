const todosController = function () {

	function load() {

		return Promise.all([
				templates.get('todos-template'),
				todosService.all()
			])
			.then(([template, data]) => {
				let todos = data.result;

				return [template, todos];
			})
			.then(([template, todos]) => {
				let html = template(todos);
				$('#container').html(html);
			});
	}

	return {
		load
	};
}();