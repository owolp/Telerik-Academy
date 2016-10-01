var todoController = function () {
	const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
		LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

	function all() {
		// var options = {
		// 	headers: {
		// 		'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
		// 	}
		// };
		// return requester.getTodo('api/todos', options)
		// 	.then(function (res) {
		// 		// console.log(res);
		// 		// console.log(res.result);
		// 		return res.result;
		// 	});

		templates.get('todo')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			});
	}

	function add() {
		templates.get('todo-add')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			});

		// attach button events
		$('#btn-todo-add').on('click', function () {
			let todo = {
				text: $('#tb-todo-text').val(),
				category: $('#tb-todo-category').val()
			};
			data.addTODO(todo)
				.then(function () {
					toastr.success('Todo added');
					document.location = '#/todo';
				})
		});
	}

	return {
		all: all,
		add: add
	};
}();