<template>
	<div>
		<el-row :span="24">
			<h1>Home Page</h1>
			<hr>
		</el-row>
		<el-row>
			<el-col :span="8">
				<img src="../../assets/logo.png">
			</el-col>
			<el-col :span="16">
				<p class="msg">{{ msg }}</p>
			</el-col>
		</el-row>
	</div>
</template>
<script>
import apiSvc from '../../services/apiService.js';

export default {
	name: 'Home',
	data() {
		return {
			msg: ''
		};
	},
	methods: {
		refresh() {
			this.api
				.getIt()
				.then(response => {
					this.msg = response.data;
				})
				.catch(error => {
					console.log('ERR: ' + JSON.stringify(error));
				});
		}
	},
	beforeMount() {
		const svc = new apiSvc(this.$userSvc);
		this.api = svc.testApi();
		this.refresh();
	}
};
</script>
<style>
.msg {
	padding: 30px 20px 150px;
	font-size: 300%;
}
</style>