import {
	data
} from './data.js'

import {
	templateLoader as tl
} from './template-loader.js'

var router = (() => {
	let navigo;

	function init() {
		navigo = new Navigo(null, false);

		navigo.on('/threads/:id', (params) => {
				Promise.all([data.threads.getById(params.id), tl.get('messages')])
					.then(([data, template]) => $('#content').append(template(data)))
					.catch(console.log)
			})
			.on('/threads', () => {
				Promise.all([data.threads.get(), tl.get('threads')])
					.then(([data, template]) => $('#content').html(template(data)))
					.catch(console.log)
			})
			.on('/gallery', () => {
				// Test http://server:port/gallery, should clg the text;
				// console.log('Navigo works!');
				Promise.all([data.gallery.get(), tl.get('gallery')])
					.then(([data, template]) => $('#content').html(template(data)))
					.catch(console.log)
			}).resolve();
	}

	return {
		init
	}
})();

export {
	router
};