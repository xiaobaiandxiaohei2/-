<template>
  <div class="page transaction-page">
    <div class="tabs-box">
      <ToolBox>
        <el-button type="primary" :icon="Plus" @click="onCreateNew">新增</el-button>
        <el-form :inline="true" :model="formModel">
          <el-form-item>
            <el-select v-model="formModel.Grade" placeholder="等级不限">
              <el-option label="等级不限" value="" />
              <el-option label="1" value="1" />
              <el-option label="2" value="2" />
              <el-option label="3" value="3" />
              <el-option label="4" value="4" />
              <el-option label="5" value="5" />
            </el-select>
          </el-form-item>
          <el-form-item>
            <el-select v-model="formModel.Sex" placeholder="性别不限">
              <el-option label="性别不限" value="" />
              <el-option label="男" value="男" />
              <el-option label="女" value="女" />
            </el-select>
          </el-form-item>
          <el-form-item>
            <el-select v-model="formModel.State" placeholder="工作状态">
              <el-option label="状态不限" value="" />
              <el-option label="在职" value="1" />
              <el-option label="不在职" value="0" />
            </el-select>
          </el-form-item>
          <el-form-item>
            <el-input v-model="formModel.keyword" placeholder="姓名、身份证" />
          </el-form-item>
          <el-form-item>
            <el-button type="primary" @click="onSearch">查询</el-button>
          </el-form-item>
        </el-form>
      </ToolBox>
    </div>
    <!-- 表格 -->
    <div class="content" v-loading="loading">
      <el-table stripe :border="true" :data="caregivers" style="width: 100%">
        <el-table-column label="头像" width="100">
          <template #default="scope">
            <img class="cover" :src="scope.row.avatarPath" alt="" />
          </template>
        </el-table-column>
        <el-table-column prop="name" label="姓名" width="160" />
        <el-table-column prop="identificationCard" label="身份证" width="160" />
        <el-table-column prop="sex" label="性别" width="160" />
        <el-table-column prop="workYears" label="工龄" width="160" />
        <el-table-column prop="grade" label="等级" width="100" />
        <el-table-column prop="state" label="状态" width="100">
          <template #default="scope">
            {{ scope.row.state == 1 ? "在职" : "不在职" }}
          </template>
        </el-table-column>
        <el-table-column label="操作" width="180" align="center">
          <template #default="scope">
            <el-button size="small" :icon="Edit" type="warning" @click="onEdit(scope.$index, scope.row)">编辑</el-button>
            <el-button size="small" :icon="Edit" type="primary" @click="onDelete(scope.$index)">删除</el-button>
          </template>
        </el-table-column>
        <template #empty>
          <el-empty description="暂无数据" />
        </template>
      </el-table>
    </div>
  </div>
  <Teleport to="body">
    <CaregiverManager ref="caregiverRef"></CaregiverManager>
  </Teleport>
</template>
<script setup>
import { ref, onMounted, computed, defineAsyncComponent } from 'vue';
import { ElMessage } from 'element-plus';
import { Plus, Search, Edit } from "@element-plus/icons-vue";
import http from '../../http';
import { all } from 'axios';

const CaregiverManager = defineAsyncComponent(() => import('./components/CaregiverManager.vue'));

// states
const formModel = ref({
  State: '',
  Grade: '',
  Sex: '',
  keyword: '',
});
const caregivers = ref([]);
const caregiverRef = ref();
// computed

// const searchResult = computed(() => {
//   if (keyword.value.length === 0) {
//     return allRecords.value;
//   }
//   return allRecords.value.filter((item) => item.BookName.toLowerCase().includes(keyword.value.toLowerCase()));
// });

// 配送
const distribute = async (orderId) => {
  try {
    await http.distribute(orderId);
    // 更新
    getAllRecords();
    ElMessage.success({
      message: '借阅记录配送成功',
      duration: 1000,
    });
  } catch {
    ElMessage.error('借阅记录配送失败');
  }
};

// methods
// 监听子组件点击操作
const onAfterItemClick = (record) => {
  console.log('操作的记录:', record);
  // 检查操作(1->配送, 3->归还)
  if (record.State === 1) {
    distribute(record.Id);
  } else if (record.State == 3) {
  }
};

// 获取所有记录
// const getAllRecords = async () => {
//   try {
//     const res = await http.getAllRecords();
//     console.log(res);
//     allRecords.value = res;
//   } catch {
//     ElMessage.error('加载借阅记录失败');
//   }
// };

//获取护工信息
const getCaregivers = async () => {
  try {
    const res = await http.getCaregivers(formModel.value);
    console.log(res);
    caregivers.value = res;
  } catch {
    ElMessage.error('加载失败');
  }
};

// 搜索
const onSearch = () => {
  getCaregivers();
};

// 新增
const onCreateNew = () => {
  caregiverRef.value.show(null, (newCaregiver) => {
    console.log('新增成功,更新本地');
    getCaregivers();
  });
};

// 启动编辑
const onEdit = (index, item) => {
  console.log(item);
  caregiverRef.value.show(JSON.parse(JSON.stringify(item)), (editedCaregiver) => {
    console.log('更新后', editedCaregiver);
    getCaregivers();
  });
};

// 启动删除
const onDelete = async (index) => {
  try {
    const res = await http.DeleteCaregiver(index);
    console.log(res);
    getCaregivers();
  } catch {
    ElMessage.error('加载失败');
  }

}

// life
onMounted(() => {
  getCaregivers();
});
</script>
<style scoped lang="less">
.tabs-box {
  position: relative;
}

.right-extra {
  position: absolute;
  right: 0;
  top: 0;
}

.el-form--inline .el-form-item {
  margin-right: 0;
  margin-left: 16px;
}
</style>./components/CaregiverManager.vue
