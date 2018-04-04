<template>
	<div class="app-page">
		<el-header>
			<h1>{{ pageTitle }}</h1>
			<el-dropdown @command="handleHdrCmd" class="pull-right">
				<span class="el-dropdown-link">
					<i class="el-icon-setting" />
				</span>
				<el-dropdown-menu slot="dropdown">
					<el-dropdown-item command="logout">Logout</el-dropdown-item>
				</el-dropdown-menu>
			</el-dropdown>
			<span class="pull-right username">
				{{ currUser }}
			</span>
		</el-header>
		<el-container>
			<el-aside :width="sideNavWidth()">
				<side-nav @collapse-menu="onSideNavToggle" />
			</el-aside>
			<el-main>
				<el-row :span="24">
					<router-view />
				</el-row>
			</el-main>
		</el-container>
	</div>
</template>
<script>
import sideNav from './main/sideNav.vue';

export default {	
	name: 'MainPage',
	data() {
		return {
			currUser: '',
			subMenuCollapse: false,
			pageTitle: 'Stratos Explorer'
		};
	},
	methods: {
		handleHdrCmd(command) {
			switch (command) {
			case 'logout':
				this.$userSvc.logout();
				break;
			}
		},
		sideNavWidth() {
			return this.subMenuCollapse ? '65px' : '200px';
		},
		onSideNavToggle(args) {
			this.subMenuCollapse = args;
		}
	},
	components: {
		'side-nav': sideNav
	},
	beforeMount() {
		var usr = this.$userSvc.currUser();
		this.currUser = usr.username;
		this.$router.beforeEach((to, from, next) => {
			if (to.meta && to.meta.title) {
				this.pageTitle = to.meta.title;
			}
			next();
		});
		var currRt = this.$router.currentRoute;
		if (currRt.meta && currRt.meta.title) {
			this.pageTitle = currRt.meta.title;
		}
	}
};
</script>
<style scoped>
	.el-header {
		color: #fff;
		background-color: #2e3539;
		padding: 0 20px;
	}
	.el-header h1 {
		display: inline-block;
		margin: 0 0 5px;
		padding: 10px;
	}
	.username {
		color: #37B398;
		font-size: 14px;
		margin-top: 1.2em;
	}
	.el-dropdown-link i {
		color: #37B398;
		font-size: 18px;
		margin-top: 0.9em;
		margin-left: 20px;
	}
</style>
