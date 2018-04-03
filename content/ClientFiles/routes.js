import Login from './pages/login.vue';
import Main from './pages/main.vue';
import Home from './pages/main/home.vue';

const routes = [
	{
		path: '/', component: Main, name: 'main',
		children: [
			{ path: '', component: Home, name: 'default', meta: { title: 'Template Home Page' } },
		]
	},
	{ path: '/login', component: Login, name: 'login' },
	{ path: '*', redirect: '/' }
];

export default routes;
