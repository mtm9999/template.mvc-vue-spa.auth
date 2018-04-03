import Vue from 'vue';
import axios from 'axios';

Vue.mixin({
	beforeCreate() {
		const options = this.$options;
		if (options.userSvc) {
			this.$userSvc = options.userSvc;
		} else if (options.parent && options.parent.$userSvc) {
			this.$userSvc = options.parent.$userSvc;
		}
	}
});

const urlBase = '/api/auth/';
const storeKeyUsr = 'stratosExplorer.currUser';

/*jshint sub:true*/
export default class UserService {
	constructor(router) {
		const self = this;
		this.router = router;
		//create handler for api requests
		this.authHttp = axios.create();
		//setup interceptors for api requests
		this.authHttp.interceptors.response.use(function(response) {
			return response;
		}, function(error) {
			if (error.response.status === 401) {
				console.log('user creds no longer valid - logout');
				self.logout();
			} else {
				Promise.reject(error);
			}
		});
		const usr = this.currUser();
		if (usr !== null) {
			//set header for api requests
			this.authHttp.defaults.headers.common['Authorization'] = 'Bearer ' + usr.token;
		}
		//setup router to check for authorization befdore navigating to next page
		router.beforeEach((to, from, next) => {
			console.log('nav to: ' + to.name + '; auth = ' + self.isAuthorized());
			if ((to.name !== 'login') && !self.isAuthorized()) {
				console.log('user is not authorized, redirecting');
				next('/login');
			} else {
				next();
			}
		});
	}

	isAuthorized() {
		return this.currUser() != null;
	}

	currUser() {
		const userObj = localStorage.getItem(storeKeyUsr);
		if (userObj == null) {
			return null;
		}
		return JSON.parse(userObj);
	}

	login(username, password) {
		const data = {
			username,
			password
		};
		const self = this;
		const http = axios.create();
		http.interceptors.response.use(function (response) {
			//store user data
			localStorage.setItem(storeKeyUsr, JSON.stringify(response.data));
			//set header for subsequent api requests
			self.authHttp.defaults.headers.common['Authorization'] = 'Bearer ' + response.data.token;
			return response;
		}, function (error) {
			return Promise.reject(error);
		});
		//make auth request
		return http.post(urlBase + 'login', data);
	}

	logout() {
		localStorage.removeItem(storeKeyUsr);
		this.router.push({ name: 'login' });
	}

	verifyLogin(router) {
		const usr = this.currUser();
		if (usr == null) {
			return;
		}
		this.authHttp.get(urlBase + 'curruser')
			.then(response => {
				console.log('hard refresh - user still valid');
			});
	}

	getHttp() {
		return this.authHttp;
	}
}