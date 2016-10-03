const cookieController = (() =>  {

	function main() {

		var cookie;
		cookiesService.myCookie()
			.then((cookiesResponse) => {
				cookie = cookiesResponse;

				return templates.load('myCookie');
			})
			.then((templateHtml) => {
				let html = templateHtml(cookie);
				$('#container').html(html);
			})
	}

	function add() {
		templates.load('addCookie')
			.then((templateHtml) => {
				$('#container').html(templateHtml);
			})
			.then(() => {
				$('#btn-add-cookie').on('click', function () {
					let cookie = {
						text: $('#tb-cookie-text').val(),
						img: $('#tb-cookie-img').val(),
						category: $('#tb-cookie-category').val()
					};

					cookiesService.add(cookie)
						.then((cookie) => {
							toastr.success(`Cookie "${cookie.result.text}" added!`);
							window.location = '#/home';
						})
				});
			});
	}

	return {
		main,
		add
	};
})();