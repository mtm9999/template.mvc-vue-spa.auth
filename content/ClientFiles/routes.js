﻿import Login from './pages/login.vue';
const Main = () => import(/* webpackChunkName: "app" */ './pages/main.vue');
const Home = () => import(/* webpackChunkName: "app" */ './pages/main/home.vue');
const Test = () => import(/* webpackChunkName: "app" */ './pages/main/testPg.vue');

const routes = [
	{
		path: '/',
		component: Main,
		children: [
			{ path: '', component: Home, name: 'default', meta: { title: 'Template Home Page' } },
			{ path: 'test', component: Test, name: 'test', meta: { title: 'Template Test Page' } }
		]
	},
	{ path: '/login', component: Login, name: 'login' },
	{ path: '*', redirect: '/' }
];

export default routes;
