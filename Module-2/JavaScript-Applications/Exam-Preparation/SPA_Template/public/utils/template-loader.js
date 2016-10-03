const templates = (() => {

	function get(name) {
		var promise = new Promise(function (resolve, reject) {
			var url = `/templates/${name}.html`;
			$.get(url, function (html) {
				var template = Handlebars.compile(html);
				resolve(template);
			});
		});

		return promise;
	};

	return {
		get
	};
})();