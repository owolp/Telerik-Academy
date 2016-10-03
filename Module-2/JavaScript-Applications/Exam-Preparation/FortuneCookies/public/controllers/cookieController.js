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

	return {
		main
	};
})();