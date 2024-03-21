<template>
  <div class="layout-page">
    <div class="sidebar">
      <div class="sidebar-header">
        <div class="logo" v-if="!isCollapse">养老院管理系统</div>
        <div class="logo" v-else>MIS</div>
      </div>
      <div class="sidebar-content">
        <el-scrollbar height="100%">
          <el-menu router :default-active="currentPath" class="el-menu-vertical-demo" text-color="#fff"
            active-text-color="#409eff" background-color="#2f3447" :collapse="isCollapse">
            <el-menu-item index="/layout/welcome">
              <el-icon>
                <HomeFilled />
              </el-icon>
              <template #title>首页</template>
            </el-menu-item>
            <el-menu-item index="/layout/recording">
              <el-icon><icon-menu /></el-icon>
              <template #title>入住记录</template>
            </el-menu-item>
            <el-menu-item index="/layout/senior">
              <el-icon>
                <Notebook />
              </el-icon>
              <template #title>老人管理</template>
            </el-menu-item>
            <el-menu-item index="/layout/caregiver">
              <el-icon><icon-menu /></el-icon>
              <template #title>护工管理</template>
            </el-menu-item>
            <el-menu-item index="/layout/room">
              <el-icon><icon-menu /></el-icon>
              <template #title>房间管理</template>
            </el-menu-item>
            <el-menu-item index="/layout/guardian">
              <el-icon><icon-menu /></el-icon>
              <template #title>监护人管理</template>
            </el-menu-item>
            <el-menu-item index="/layout/healthDataItem">
              <el-icon><icon-menu /></el-icon>
              <template #title>健康项目管理</template>
            </el-menu-item>
            <el-menu-item index="/layout/booking">
              <el-icon><icon-menu /></el-icon>
              <template #title>预约审批</template>
            </el-menu-item>
            <el-menu-item index="/layout/application">
              <el-icon><icon-menu /></el-icon>
              <template #title>申请审批</template>
            </el-menu-item>
            <el-menu-item index="10">
              <el-icon><icon-menu /></el-icon>
              <template #title>意见查看</template>
            </el-menu-item>

          </el-menu>
        </el-scrollbar>
      </div>
    </div>
    <div class="container">
      <div class="page-header">
        <div class="page-header-left">
          <el-icon size="24" color="#666" @click="isCollapse = !isCollapse">
            <Fold v-if="!isCollapse" />
            <Expand v-else />
          </el-icon>
          <!-- 路径 -->
          <el-breadcrumb separator="/">
            <el-breadcrumb-item to="/layout/welcome">控制台</el-breadcrumb-item>
            <el-breadcrumb-item>{{ title }}</el-breadcrumb-item>
          </el-breadcrumb>
        </div>

        <div>
          <el-dropdown trigger="click">
            <div class="page-header-right">
              <div class="username">登录名</div>
              <el-avatar :size="40" :src="avatar" />
            </div>
            <template #dropdown>
              <el-dropdown-menu>
                <el-dropdown-item :icon="Lock">修改密码</el-dropdown-item>
                <el-dropdown-item :icon="SwitchButton" divided>退出</el-dropdown-item>
              </el-dropdown-menu>
            </template>
          </el-dropdown>
        </div>
      </div>

      <div class="page-content">
        <router-view v-slot="{ Component }">
          <transition name="fade" mode="out-in">
            <keep-alive>
              <div :key="route.name">
                <component :is="Component"></component>
              </div>
            </keep-alive>
          </transition>
        </router-view>
      </div>
    </div>
  </div>
</template>
<script setup>
import { Menu as IconMenu, HomeFilled, Notebook, Fold, Expand, Lock, SwitchButton, Watch } from '@element-plus/icons-vue';
import { ref, computed, watch } from 'vue';
import { useRoute } from 'vue-router';
import defaultAvatar from '../../assets/images/avatar.jpg';

const isCollapse = ref(false);
const avatar = ref(defaultAvatar);
const route = useRoute();
const title = ref(route.meta.title);

console.log(
  route.matched.map((item) => {
    return {
      path: item.path,
      title: item.meta.title,
    };
  })
);

//
const currentPath = computed(() => {
  return route.path;
});

watch(
  () => route.path,
  () => {
    console.log('路由变化', route);
    title.value = route.meta.title;
  }
);
</script>
<style scoped lang="less">
.layout-page {
  height: 100%;
  overflow: hidden;
  display: flex;
}

.sidebar {
  background-color: #2f3447;
  height: 100%;
  overflow: hidden;
  display: flex;
  flex-direction: column;

  .sidebar-content {
    flex: 1;
    overflow: hidden;
  }
}

.page-header-left {
  display: flex;
  align-items: center;

  .el-breadcrumb {
    margin-left: 16px;
  }
}

.container {
  flex: 1;
  height: 100%;
  overflow: hidden;
  background-color: #f6f6f6;
  display: flex;
  flex-direction: column;

  .page-header {
    height: 60px;
    background-color: #fff;
    display: flex;
    justify-content: space-between;
    align-items: center;
    padding: 0 16px;
  }

  .page-content {
    flex: 1;
    padding: 16px;
    overflow: hidden;
  }
}

.logo {
  height: 60px;
  line-height: 60px;
  text-align: center;
  font-size: 24px;
  font-weight: 500;
  color: #fff;
  padding: 0 16px;
}

.el-menu-vertical-demo:not(.el-menu--collapse) {
  width: 200px;
}

.el-menu {
  border-right: none;
}

.el-icon {
  cursor: pointer;
}

.page-header-right {
  display: flex;
  align-items: center;
  cursor: pointer;

  .username {
    margin-right: 8px;
    color: #666;
  }
}

.fade-enter-active,
.fade-leave-active {
  transition: all 0.5s ease;
}

.fade-enter-from {
  opacity: 0;
  transform: translate3d(10%, 0, 0);
}

.fade-leave-to {
  opacity: 0;
  transform: translate3d(-10%, 0, 0);
}
</style>
