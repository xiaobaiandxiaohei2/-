<template>
    <div class="record-table">
        <!-- 表格 -->
        <div class="content" v-loading="loading">
            <el-table stripe :border="true" :data="records" style="width: 100%">
                <el-table-column label="序号" width="100">
                    <template #default="scope">
                        {{ (currentPage - 1) * pagesize + scope.$index + 1 }}
                    </template>
                </el-table-column>
                <el-table-column prop="guardianInfo.name" label="监护人" />
                <el-table-column prop="seniorInfo.name" label="老人" />
                <el-table-column prop="type" label="申请">
                    <template #default="scope">
                        {{ scope.row.type == 1 ? "外出申请" : "出院申请" }}
                    </template>
                </el-table-column>
                <el-table-column prop="outTime" label="外出时间" />
                <el-table-column prop="backTime" label="返回时间" />
                <el-table-column prop="auditTime" label="审核时间" />
                <el-table-column prop="adminInfo.name" label="审核人" />
                <el-table-column prop="remark" label="备注" />
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
import { dayjs, ElMessageBox } from 'element-plus';
import { Plus, Edit, Search } from '@element-plus/icons-vue';
import { ref, onMounted, computed } from 'vue';
defineProps({
    records: {
        type: Array,
        default: () => [],
    },
});
const pagesize = ref(5);
const currentPage = ref(1);
const emits = defineEmits(['after-item-click']);

// 点击按钮，通知父组件操作
const onItemClick = (item) => {
    ElMessageBox.confirm('您确定要配置吗?', '配送提示', {
        confirmButtonText: '确定',
        cancelButtonText: '取消',
        type: 'warning',
    })
        .then(() => {
            emits('after-item-click', item);
        })
        .catch(() => { });
};

</script>
<style scoped lang="less"></style>