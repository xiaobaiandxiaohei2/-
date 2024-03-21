<template>
  <div class="page book-page">
    <ToolBox>
      <el-button type="primary" :icon="Plus" @click="onCreateNew">新增</el-button>
      <el-form :inline="true">
        <el-form-item>
          <el-input v-model="keyword" placeholder="请输入关键字" />
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="onSearch">查询</el-button>
        </el-form-item>
      </el-form>
    </ToolBox>
    <!-- 表格 -->
    <div class="content" v-loading="loading">
      <el-table stripe :border="true" :data="seniors" style="width: 100%">
        <el-table-column label="头像" width="100">
          <template #default="scope">
            <img class="cover" :src="scope.row.avatarPath" alt="" />
          </template>
        </el-table-column>
        <el-table-column prop="name" label="姓名" width="160" />
        <el-table-column prop="identityCard" label="身份证" width="160" />
        <el-table-column prop="sex" label="性别" width="160" />
        <el-table-column prop="district" label="地址" width="160" />
        <el-table-column prop="underlyingDisease" label="基础病" width="100" />
        <el-table-column prop="state" label="状态" width="100">
          <template #default="scope">
            {{ scope.row.state == 1 ? "已入住" : "未入住" }}
          </template>
        </el-table-column>
        <el-table-column label="操作" width="180" align="center">
          <template #default="scope">
            <el-button size="small" :icon="Edit" type="warning" @click="onEdit(scope.row)">编辑</el-button>
            <el-button size="small" :icon="Edit" type="primary">删除</el-button>
          </template>
        </el-table-column>
        <template #empty>
          <el-empty description="暂无数据" />
        </template>
      </el-table>
      <div class="pagination-box">
        <el-pagination v-model:current-page="currentPage" v-model:page-size="pagesize" background
          layout="prev, pager, next" :total="size" />
      </div>
      <Teleport to="body">
        <SeniorManager ref="seniorRef"></SeniorManager>
      </Teleport>
    </div>
  </div>

</template>
<script setup>
import ToolBox from '../../components/ToolBox.vue';
import { ref, onMounted, defineAsyncComponent } from 'vue';
import { Plus, Edit, Search } from '@element-plus/icons-vue';
import { ElMessage } from 'element-plus';
import http from '../../http';
import SeniorManager from './components/SeniorManager.vue';

// state
const loading = ref(false);
const seniorRef = ref();
const seniors = ref([]);
const keyword = ref("");
// methods

// 新增
const onCreateNew = () => {
  seniorRef.value.show(null, () => {
    getSeniors();
  });
};

// 编辑
const onEdit = (item) => {
  console.log(JSON.parse(JSON.stringify(item)));
  bookRef.value.show(JSON.parse(JSON.stringify(item)), () => {
    getBooks();
    ElMessage.success({
      message: '更新图书成功',
      duration: 1000,
    });
  });
};

// 查询
const onSearch = () => {
  getSeniors();
};

//获取老人信息
const getSeniors = async () => {
  try {
    const res = await http.getSeniors(keyword.value);
    seniors.value = res;
    console.log(res);
  } catch (ex) {
    ElMessage.error(ex);
    console.log("asd");
  }
}

// life
onMounted(() => {
  // getBooks();
  // getCategories();
  // getPublishers();
  // getAuthors();
  getSeniors();
});
</script>
<style scoped lang="less">
.cover {
  width: 60px;
  display: block;
  margin: auto;
  cursor: pointer;
}

.el-form--inline .el-form-item {
  margin-right: 0;
  margin-left: 16px;
}
</style>./components/SeniorManager.vue
