import Vue from 'vue';
import VueRouter from 'vue-router';
import ElementUI from 'element-ui';
import 'element-ui/lib/theme-chalk/index.css';
import locale from 'element-ui/lib/locale/lang/en';
import './assets/site.css';

Vue.use(VueRouter);
Vue.use(ElementUI, { locale, size: 'small' });

//root component
import App from './App.vue';

import routes from './routes.js';
const router = new VueRouter({
	routes
});

//services
import UserService from './services/userService.js';
const userSvc = new UserService(router);

//see if user is already logged in after a hard refresh
userSvc.verifyLogin(router);

new Vue({
	router,
	userSvc,
	el: '#app',
	render: h => h(App)
});