<template>
    <div class="page transaction-page">
        <div class="tabs-box">
            <ToolBox>
                <el-button type="primary" :icon="Plus" @click="onCreateNew">新增</el-button>
                <el-form :inline="true" :model="formModel">
                    <el-form-item>
                        <el-select v-model="formModel.State" placeholder="房间状态">
                            <el-option label="状态不限" value="" />
                            <el-option label="待维修" value="0" />
                            <el-option label="维修中" value="1" />
                            <el-option label="可入住" value="2" />
                            <el-option label="已满员" value="3" />
                        </el-select>
                    </el-form-item>
                    <el-form-item>
                        <el-input v-model="formModel.RoomNumer" placeholder="房间号" />
                    </el-form-item>
                    <el-form-item>
                        <el-button type="primary" @click="onSearch">查询</el-button>
                    </el-form-item>
                </el-form>
            </ToolBox>
        </div>
        <!-- 表格 -->
        <div class="content" v-loading="loading">
            <el-table stripe :border="true" :data="rooms" style="width: 100%">
                <el-table-column label="序号" width="100">
                    <template #default="scope">
                        {{ (currentPage - 1) * pagesize + scope.$index + 1 }}
                    </template>
                </el-table-column>
                <el-table-column prop="roomNumber" label="房间号" width="160" />
                <el-table-column prop="remark" label="备注" width="320" />
                <el-table-column prop="State" label="状态" width="160">
                    <template #default="scope">
                        {{ scope.row.state == 0 ? "待维修" : scope.row.state == 1 ? "维修中" : scope.row.state == 2 ? "可入住" :
                    "已满员" }}
                    </template>
                </el-table-column>
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
    RoomNumer: '',
    State: '',
});
const rooms = ref([]);
const pagesize = ref(5);
const currentPage = ref(1);
// computed


// 待配送记录列表
const willDistributionRecords = computed(() => {
    return searchResult.value.filter((item) => item.State === 1);
});

// 待归还记录列表

const willReturnRecords = computed(() => {
    return searchResult.value.filter((item) => item.State === 3);
});

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

//房间查询
const getRooms = async () => {
    try {
        const res = await http.getRooms(formModel.value);
        console.log(res);
        rooms.value = res;
    } catch {
        ElMessage.error('加载失败');
    }
};
// 搜索
const onSearch = () => {
    getRooms();
};

// life
onMounted(() => {
    getRooms();
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