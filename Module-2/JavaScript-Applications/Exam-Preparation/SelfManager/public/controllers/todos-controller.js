const todoController = (() => {

	function all() {

		return Promise.all([
				templates.load('todo'),
				todoService.all()
			])
			.then(([view, todos]) => {
				let html = view(todos.result);
				$('#container').html(html);
			});
	}

	function add() {
		templates.load('todo-add')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			})
			.then(() => {
				$('#btn-todo-add').on('click', function () {
					let todo = {
						text: $('#tb-todo-text').val(),
						category: $('#tb-todo-category').val()
					};

					todoService.add(todo)
						.then((todo) => {
							toastr.success(`TODO "${todo.result.text}" added!`);
							window.location = '#/todos';
						})
				});
			});
	}

	return {
		all,
		add
	};
})();