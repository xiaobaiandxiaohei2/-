<template>
  <el-dialog v-model="visible" title="入住记录管理" width="420">
    <el-form ref="formRef" :model="category" label-width="100px" :rules="rules">
      <el-form-item label="老人姓名" prop="Name">
        <el-select v-model="value" filterable placeholder="Select" style="width: 240px">
          <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
        </el-select>
      </el-form-item>
      <el-form-item label="监护人姓名" prop="Name">
        <el-select v-model="value" filterable placeholder="Select" style="width: 240px">
          <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
        </el-select>
      </el-form-item>
      <el-form-item label="入住时间" prop="Name">
        <el-date-picker value-format="YYYY-MM-DD" type="date" placeholder="开始时间" style="width: 240px" />
      </el-form-item>
      <el-form-item label="房间号" prop="Name">
        <el-select v-model="value" filterable placeholder="Select" style="width: 240px">
          <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
        </el-select>
      </el-form-item>
      <el-form-item label="护工等级">
        <el-select v-model="value" placeholder="等级不限" style="width: 240px">
          <el-option label="等级不限" value="" />
          <el-option label="1" value="1" />
          <el-option label="2" value="2" />
          <el-option label="3" value="3" />
          <el-option label="4" value="4" />
          <el-option label="5" value="5" />
        </el-select>
      </el-form-item>
      <el-form-item label="护工姓名" prop="Name">
        <el-select v-model="value" filterable placeholder="Select" style="width: 240px">
          <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value" />
        </el-select>
      </el-form-item>
    </el-form>
    <template #footer>
      <span class="dialog-footer">
        <el-button @click="visible = false">取消</el-button>
        <el-button type="success" @click="onSave(formRef)"> 保存 </el-button>
      </span>
    </template>
  </el-dialog>
</template>
<script setup>
import { ElMessage } from 'element-plus';
import { ref, reactive } from 'vue';
import http from '../../../http';

// state
const formRef = ref();
const visible = ref(false);
const category = ref({
  Name: '',
  Priority: 99,
});
const rules = reactive({
  Name: [
    { required: true, message: '分类名称不能为空', trigger: 'blur' },
    { pattern: /^[\u2E80-\u9FFF]{2,}$/, message: '分类名称必须为2位以上中文', trigger: 'blur' },
  ],
});
let callbackFn = null;
const options = [
  {
    value: 'Option1',
    label: 'Option1',
  },
  {
    value: 'Option2',
    label: 'Option2',
  },
  {
    value: 'Option3',
    label: 'Option3',
  },
  {
    value: 'Option4',
    label: 'Option4',
  },
  {
    value: 'Option5',
    label: 'Option5',
  },
]
// methods
// 新增
const createNewCategory = async () => {
  // 请求服务器，完成新增
  try {
    const res = await http.createNewCategory(category.value.Name);
    ElMessage({
      message: '新增分类成功',
      duration: 1000,
      type: 'success',
      onClose: () => {
        // 通过父组件，更新本地
        if (typeof callbackFn === 'function') {
          callbackFn(res);
        }
        visible.value = false;
      },
    });
  } catch (ex) {
    ElMessage.error(ex);
  }
};

// 更新
const updateCategory = async () => {
  // 请求服务器，完成新增
  try {
    const res = await http.updateCategory(category.value.Id, category.value.Name);
    ElMessage({
      message: '更新分类成功',
      duration: 1000,
      type: 'success',
      onClose: () => {
        // 通过父组件，更新本地
        if (typeof callbackFn === 'function') {
          callbackFn(res);
        }
        visible.value = false;
        category.value = {};
      },
    });
  } catch (ex) {
    ElMessage.error(ex);
  }
};

// 点击保存
const onSave = (formElement) => {
  if (!formElement) {
    return;
  }
  formElement.validate((valid) => {
    if (valid) {
      // 有效, 检查是否新增还是更新

      console.log(category.value);

      if (!category.value.Id) {
        createNewCategory();
      } else {
        updateCategory();
      }

      return;
    }
    ElMessage.error('图书分类信息无效');
  });
};

//
const show = (_category = null, _callbackFn = null) => {
  if (_category) {
    category.value = _category;
  }
  callbackFn = _callbackFn;
  visible.value = true;
};

// 公开方法
defineExpose({
  show,
});
</script>
<style scoped lang="less"></style>
