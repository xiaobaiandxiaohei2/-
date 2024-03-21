<template>
  <div class="category-page">
    <!-- 工具栏 -->
    <ToolBox>
      <el-button type="primary" :icon="Plus" @click="onCreateNew">新增</el-button>
      <el-form :inline="true" :model="formModel">
        <el-form-item label="Start-Time" prop="StartTime">
          <el-date-picker value-format="YYYY-MM-DD" type="date" placeholder="开始时间" v-model="formModel.StartTime" />
        </el-form-item>
        <el-form-item label="End-Time" prop="EndTime">
          <el-date-picker value-format="YYYY-MM-DD" type="date" placeholder="结束时间" v-model="formModel.EndTime" />
        </el-form-item>
        <el-form-item>
          <el-input placeholder="老人、监护人、护工、房间" v-model="formModel.keyword" />
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="onSearch">查询</el-button>
        </el-form-item>
      </el-form>
    </ToolBox>
    <div class="content">
      <el-table stripe :border="true" :data="paginationData" style="width: 100%">
        <el-table-column label="序号" width="100">
          <template #default="scope">
            {{ (currentPage - 1) * pagesize + scope.$index + 1 }}
          </template>
        </el-table-column>
        <el-table-column prop="seniorInfo.name" label="老人姓名" />
        <el-table-column prop="enterTime" label="入住时间">
          <template #default="scope">
            {{ formatDate(scope.row.enterTime) }}
          </template>
        </el-table-column>
        <el-table-column prop="exitTime" label="出院时间">
          <template #default="scope">
            {{ formatDate(scope.row.exitTime) }}
          </template>
        </el-table-column>
        <el-table-column prop="guardianInfo.name" label="监护人" />
        <el-table-column prop="roomInfo.roomNumber" label="房间号" />
        <el-table-column prop="caregiverInfo.name" label="护工" />
        <el-table-column label="操作" width="120" align="center">
          <template #default="scope">
            <el-button size="small" :icon="Edit" type="warning" @click="onEdit(scope.$index, scope.row)">编辑</el-button>
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
    </div>
  </div>

  <Teleport to="body">
    <CategoryManager ref="categoryRef"></CategoryManager>
  </Teleport>
</template>
<script setup>
import { Plus, Edit, Search } from '@element-plus/icons-vue';
import { ref, onMounted, computed, defineAsyncComponent } from 'vue';
import { ElMessage } from 'element-plus';
import http from '../../http';

// import CategoryManager from './components/CategoryManager.vue';
const CategoryManager = defineAsyncComponent(() => import('./components/RecordingManager.vue'));

// state
const keyword = ref('');

const recordings = ref([]);

const categoryRef = ref();

const pagesize = ref(5);

const currentPage = ref(1);

const formModel = ref({
  StartTime: '',
  EndTime: '',
  keyword: '',
});
// 筛选后的数据

const searchResult = computed(() => {
  if (keyword.value.length === 0) {
    return recordings.value;
  }
  return recordings.value.filter((item) => item.Name.includes(keyword.value));
});

const size = computed(() => {
  return searchResult.value.length;
});

// 分页数据
const paginationData = computed(() => {
  const startIndex = (currentPage.value - 1) * pagesize.value;
  const endIndex = currentPage.value * pagesize.value;
  return searchResult.value.slice(startIndex, endIndex);
});

//methods
// 切换页码
// const onCurrentChange = () => {};

const formatDate = (timestamp) => {
  if (timestamp != null) {
    const date = new Date(timestamp);
    const year = date.getFullYear();
    let month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : "0" + month;
    let day = date.getDate().toString();
    day = day.length > 1 ? day : "0" + day;
    return `${year}-${month}-${day}`;
  }
};

// 获取入住记录
const getRecordings = async () => {
  try {
    const res = await http.getRecordings(formModel.value);
    recordings.value = res;
    console.log(res);
  } catch (ex) {
    ElMessage.error(ex);
    console.log("asd");
  }
}
// 查询
const onSearch = () => {
  getRecordings();
}

// 新增
const onCreateNew = () => {
  categoryRef.value.show(null, (newCategory) => {
    console.log('新增成功,更新本地');
    // categories.value.push(newCategory);
    getCategories();
  });
};
// 启动编辑
const onEdit = (index, item) => {
  categoryRef.value.show(JSON.parse(JSON.stringify(item)), (editedCategory) => {
    console.log('更新后的图书分类', editedCategory);
    getCategories();
  });
};


onMounted(() => {
  getRecordings();
});
</script>
<style scoped lang="less">
.category-page {
  height: 100%;
  overflow-x: hidden;
  overflow-y: auto;
  padding: 16px;
  background-color: #fff;
}

.tool-box {
  display: flex;
  align-items: center;
  justify-content: space-between;
}

.content {
  margin-top: 16px;
}

.el-input-group__append .el-button {
  background-color: var(--el-button-bg-color) !important;
  border-color: var(--el-button-border-color);
  color: var(--el-button-text-color);
  display: inline-flex;
  align-items: center;
  border-top-left-radius: 0;
  border-bottom-left-radius: 0;
}

.el-input-group__append .el-button:hover {
  color: var(--el-button-hover-text-color);
  border-color: var(--el-button-hover-border-color);
  background-color: var(--el-button-hover-bg-color) !important;
  outline: 0;
}

.pagination-box {
  margin-top: 16px;
  display: flex;
  justify-content: flex-end;
}
</style>./components/RecordingManager.vue
