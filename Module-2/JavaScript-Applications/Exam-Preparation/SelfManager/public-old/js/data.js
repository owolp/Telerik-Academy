/* globals requester localStorage */
const LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
	LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key';

var data = {
	register(user) {
		return requester.register('/api/users', user)
			.then(function (resp) {
				var user = resp.result;
				localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, user.username);
				localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, user.authKey);
			});
	},

	login(user) {
		return requester.login('/api/users/auth', user);
	},

	all() {
		var options = {
			headers: {
				'x-auth-key': localStorage.getItem(LOCAL_STORAGE_AUTHKEY_KEY)
			}
		};
		return requester.getTodo('/api/todos', options);
	},

	addTODO(todo) {

	}
};