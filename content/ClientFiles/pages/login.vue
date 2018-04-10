<template>
	<el-container>
		<el-header>
			<h1>Spa-Auth Template</h1>
			<span class="version pull-right">Version: {{ version }}</span>
		</el-header>
		<el-main>
			<el-row :span="24">
				<el-row>
					<el-col :span="14" :offset="5" class="well">
						<el-row>
							<el-col :span="16" :offset="4" v-loading="loading">
								<h2>Please Login</h2>
								<el-alert v-if="errMsg != ''" :title="errMsg" type="error" show-icon closable="" style="margin-bottom: 1em;" />
								<el-form ref="form" :model="loginForm" :rules="validation">
									<el-form-item prop="username">
										<el-input placeholder="Username" v-model="loginForm.username" autofocus />
									</el-form-item>
									<el-form-item prop="password">
										<el-input placeholder="Password" v-model="loginForm.password" type="password" @keyup.enter.native="submitForm" />
									</el-form-item>
									<el-form-item>
										<el-button type="primary" style="width: 100%" @click="submitForm">Login</el-button>
									</el-form-item>
								</el-form>
							</el-col>
						</el-row>
					</el-col>
				</el-row>
				<el-row :span="24" class="txt-centre" style="font-size: 0.8em; padding-top: 1em; color: #717171;">
					Powered by You &copy; 2018 All rights reserved
				</el-row>
			</el-row>
		</el-main>
	</el-container>
</template>
<script>
export default {
	name: 'Login',
	data() {
		return {
			version: '',
			errMsg: '',
			loginForm: {
				username: '',
				password: ''
			},
			validation: {
				username: [{ required: true, message: 'Please input your Username', trigger: 'blur' }],
				password: [{ required: true, message: 'Please input your Password', trigger: 'blur' }]
			},
			loading: false
		};
	},
	methods: {
		submitForm() {
			this.errMsg = '';
			this.loading = true;
			this.$refs['form'].validate(valid => {
				if (valid) {
					this.$userSvc
						.login(this.loginForm.username, this.loginForm.password)
						.then(response => {
							this.loading = false;
							this.$router.push({ name: 'default' });
						})
						.catch(error => {
							this.loading = false;
							this.errMsg = error.data && error.data != '' ? error.data : 'Invalid username or password';
						});
				} else {
					return false;
				}
			});
		}
	},
	beforeMount() {
		this.loading = false;
		this.version = window.app__inject_version;
	}
};
</script>
<style scoped>
.el-header {
	background-color: #f8f8f8;
	border-top: 4px solid #39b392;
	border-bottom: 1px solid #e3e3e3;
	padding: 0 20px;
}
.el-header h1 {
	display: inline-block;
	color: #515151;
	font-size: 140%;
	font-weight: 600;
	line-height: 1.1;
	margin: 0 0 5px;
	padding: 10px;
}
.version {
	font-size: 10px;
	margin-top: 1.5em;
}
.well {
	background-color: #f8f8f8;
	border: 1px solid #e8e8e8;
	padding: 2em;
	margin-top: 2em;
	color: #515151;
}
</style>
