<template>
	<div>
		<div id="menu-heading" class="txt-centre">
			<span v-if="!menuCollapse">App Name</span>
			<el-button v-if="menuCollapse" type="info" plain icon="el-icon-caret-right" size="mini" @click="toggleCollapse()" />
			<el-button v-if="!menuCollapse" type="info" plain icon="el-icon-caret-left" size="mini" @click="toggleCollapse()" />
		</div>
		<el-menu :default-active="activeIndex" :collapse="menuCollapse" router>
			<el-menu-item index="/">
				<icon name="map-marker" />
				<span slot="title">Home</span>
			</el-menu-item>
			<el-menu-item index="/test">
				<icon name="motorcycle" />
				<span slot="title">Test</span>
			</el-menu-item>
		</el-menu>
	</div>
</template>
<script>
import 'vue-awesome/icons/map-marker'; // icon list can be found at: https://fontawesome.com/v4.7.0/icons/
import 'vue-awesome/icons/motorcycle';
import Icon from 'vue-awesome/components/Icon';

export default {
	name: 'SideNav',
	data() {
		return {
			menuCollapse: false,
			activeIndex: '/'
		};
	},
	methods: {
		toggleCollapse() {
			this.menuCollapse = !this.menuCollapse;
			this.$emit('collapse-menu', this.menuCollapse);
		}
	},
	created: function () {
		//handle page refresh to make sure menu syncs to initial route
		this.activeIndex = this.$router.currentRoute.path;
	},
	components: {
		Icon
	}
};
</script>
<style scoped>
	#menu-heading {
		margin-top: 1em;
	}
	#menu-heading .el-button {
		padding: 7px;
	}
	.el-menu .fa-icon {
		margin-right: 5px;
		width: 24px;
		text-align: center;
		font-size: 18px;
		vertical-align: middle;
		color: #909399;
	}
	.el-menu .el-menu-item.is-active .fa-icon {
		color: inherit;
	}
</style>