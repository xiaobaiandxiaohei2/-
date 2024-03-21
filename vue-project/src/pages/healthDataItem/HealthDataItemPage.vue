<template>
    <div class="page transaction-page">
        <div class="tabs-box">
            <ToolBox>
                <el-button type="primary" :icon="Plus" @click="onCreateNew">新增</el-button>
                <el-form :inline="true" :model="formModel">
                    <el-form-item>
                        <el-input v-model="formModel.keyword" placeholder="项目名" />
                    </el-form-item>
                    <el-form-item>
                        <el-button type="primary" @click="onSearch">查询</el-button>
                    </el-form-item>
                </el-form>
            </ToolBox>
        </div>
        <!-- 表格 -->
        <div class="content" v-loading="loading">
            <el-table stripe :border="true" :data="healthDataItems" style="width: 100%">
                <el-table-column label="序号" width="100">
                    <template #default="scope">
                        {{ (currentPage - 1) * pagesize + scope.$index + 1 }}
                    </template>
                </el-table-column>
                <el-table-column prop="name" label="项目名称" width="160" />
                <el-table-column prop="weight" label="权重" width="320" />
                <el-table-column label="操作" width="180" align="center">
                    <template #default="scope">
                        <el-button size="small" :icon="Edit" type="warning" @click="onEdit(scope.row)">编辑</el-button>
                    </template>
                </el-table-column>
                <template #empty>
                    <el-empty description="暂无数据" />
                </template>
            </el-table>
        </div>
    </div>
</template>
<script setup>
import { ref, onMounted, computed } from 'vue';
import { ElMessage } from 'element-plus';
import http from '../../http';
import { all } from 'axios';

// states
const activeState = ref(-1);
const allRecords = ref([]);
const cloneAllRecords = ref([]);

const formModel = ref({
    keyword: '',
});
const healthDataItems = ref([]);
const pagesize = ref(5);
const currentPage = ref(1);
// computed

// methods

//监护人查询
const getHealthDataItems = async () => {
    try {
        const res = await http.getHealthDataItems(formModel.value);
        healthDataItems.value = res;
    } catch {
        ElMessage.error('加载失败');
    }
};
// 搜索
const onSearch = () => {
    getHealthDataItems();
};

// life
onMounted(() => {
    getHealthDataItems();
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
</style>