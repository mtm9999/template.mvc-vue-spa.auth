<template>
	<div>
		<el-row :span="24">
			<h1>Test Page</h1>
			<hr>
		</el-row>
		<el-row :span="24" class="txt-centre">
			<p class="msg">{{ msg }}</p>
		</el-row>
	</div>
</template>
<script>
import apiSvc from '../../services/apiService.js';

export default {
	name: 'TestPg',
	data() {
		return {
			msg: ''
		};
	},
	methods: {
		refresh() {
			this.api.getIt()
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
		font-size: 200%;
	}
</style>
