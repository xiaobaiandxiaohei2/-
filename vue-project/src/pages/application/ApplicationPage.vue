<template>
    <div class="page transaction-page">
        <div class="tabs-box">
            <el-tabs v-model="activeState">
                <el-tab-pane label="全部记录" :name="-1">
                    <RecordTable :records="applicationsAll"></RecordTable>
                </el-tab-pane>
                <el-tab-pane label="未审核" :name="0">
                    <RecordTable :records="applicationsZero"></RecordTable>
                </el-tab-pane>
                <el-tab-pane label="已通过" :name="1">
                    <RecordTable :records="applicationsOne"></RecordTable>
                </el-tab-pane>
                <el-tab-pane label="未通过" :name="2">
                    <RecordTable :records="applicationsTwo"></RecordTable>
                </el-tab-pane>
            </el-tabs>
            <div class="right-extra">
                <el-form :inline="true" :model="formModel">
                    <el-form-item>
                        <el-input v-model="formModel.keyword" placeholder="手机号" />
                    </el-form-item>
                </el-form>
            </div>

        </div>

    </div>
</template>
<script setup>
import { ref, onMounted, computed } from 'vue';
import { ElMessage } from 'element-plus';
import RecordTable from './components/RecordTable.vue';
import http from '../../http';
import { all } from 'axios';

// states
const activeState = ref(-1);
const allRecords = ref([]);
const cloneAllRecords = ref([]);

const formModel = ref({
    keyword: '',
});
const keyword = ref();
const applications = ref([]);
const pagesize = ref(5);
const currentPage = ref(1);
// computed
const applicationsAll = computed(() => {
    return applications.value;
})

const applicationsZero = computed(() => {
    return applicationsAll.value.filter((application) => application.state === "0");
});

const applicationsOne = computed(() => {
    return applicationsAll.value.filter((application) => application.state === "1");
});

const applicationsTwo = computed(() => {
    return applicationsAll.value.filter((application) => application.state === "2");
});

// methods

//监护人查询
const getApplications = async () => {
    try {
        const res = await http.getApplications();
        applications.value = res;
        console.log(applications.value);
    } catch {
        console.log("shi");
        ElMessage.error('加载失败');
    }
};

// life
onMounted(() => {
    getApplications();
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