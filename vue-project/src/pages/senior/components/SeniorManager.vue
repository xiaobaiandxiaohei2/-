<template>
  <el-dialog v-model="visible" title="老人信息管理" width="500" center="true">
    <el-form ref="formRef" :model="caregiver" :rules="rules" label-width="100px">
      <el-form-item label="姓名" prop="name">
        <el-input v-model="caregiver.name" placeholder="请输入护工姓名" />
      </el-form-item>
      <el-form-item label="身份证" prop="identificationCard">
        <el-input v-model="caregiver.identificationCard" placeholder="请输入护工身份证" />
      </el-form-item>
      <el-form-item label="性别">
        <el-select v-model="caregiver.sex" style="width: 350px;">
          <el-option label="男" value="男" />
          <el-option label="女" value="女" />
        </el-select>
      </el-form-item>
      <el-form-item label="地址" prop="identificationCard">
        <el-input v-model="caregiver.identificationCard" placeholder="省" />
        <el-input v-model="caregiver.identificationCard" placeholder="市" />
        <el-input v-model="caregiver.identificationCard" placeholder="区" />
        <el-input v-model="caregiver.identificationCard" placeholder="具体地址" />
      </el-form-item>
      <el-form-item label="状态">
        <el-select v-model="caregiver.state" style="width: 350px;">
          <el-option label="已入住" value="1" />
          <el-option label="未入住" value="0" />
        </el-select>
      </el-form-item>
      <el-form-item label="头像">
        <el-upload v-model:file-list="fileList" list-type="picture-card" :auto-upload="false" :on-change="onFileChange">
          <el-icon>
            <Plus />
          </el-icon>
        </el-upload>
      </el-form-item>
      <el-form-item label="基础病">
        <el-input v-model="caregiver.remark" :rows="8" type="textarea" placeholder="请输入备注" />
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
import { ref } from 'vue';
import http from '../../../http';
import { Plus } from '@element-plus/icons-vue';
import { checkUploadImage } from '../../../utils/tool';

// props

// state
const fileList = ref([]);
const visible = ref(false);
const formRef = ref(null);
const caregiver = ref({
  id: '',
  name: '',
  sex: '男',
  identificationCard: '',
  province: '江苏省',
  province: '苏州市',
  city: '',
  district: '',
  grade: '1',
  avatarPath: '',
  underlyingDisease: '',
  state: '1',
});
const rules = ref({
  name: [{ required: true, message: '姓名不能为空', trigger: 'change' }],
  sexex: [{ required: true, message: '性别不能为空', trigger: 'change' }],
  identificationCard: [{ required: true, message: '身份证不能为空', trigger: 'change' }],
  workYears: [{ required: true, message: '工龄不能为空', trigger: 'change' }],
  grade: [{ required: true, message: '级别不能为空', trigger: 'change' }],
  state: [{ required: true, message: '状态不能为空', trigger: 'change' }],
});

let callbackFn = null;

// methods

// 编辑
const editCaregiver = async () => {
  try {
    const res = await http.EditCaregiver(caregiver.value);
    ElMessage.success({
      message: '编辑护工成功',
      duration: 1000,
      onClose: () => {
        visible.value = false;
        if (typeof callbackFn === 'function') {
          callbackFn(res);
        }
      },
    });
  } catch (ex) {
    console.log(ex);
    ElMessage.error('编辑失败');
  }
};

// 新增
const createCaregiver = async () => {
  try {
    console.log(caregiver.value);
    const res = await http.createCaregiver(caregiver.value);
    ElMessage.success({
      message: '新增护工成功',
      duration: 1000,
      onClose: () => {
        visible.value = false;
        if (typeof callbackFn === 'function') {
          callbackFn(res);
        }
      },
    });
  } catch (ex) {
    console.log(ex);
    ElMessage.error('新增护工失败');
  }
};

// 保存
const onSave = (formElement) => {
  if (!formElement) {
    return;
  }
  formElement.validate((valid) => {
    if (valid) {
      // 检查是否选择封面
      // if (fileList.value.length === 0) {
      //   ElMessage.warning('请选择封面');
      //   return;
      // }
      // 新增
      if (!caregiver.value.id) {
        // caregiver.value.AvatarPath = fileList.value[0].raw;
        caregiver.value.avatarPath = "";
        createCaregiver();
      } else {
        // 编辑
        // console.log(fileList.value[0]);
        // if (fileList.value[0].raw) {
        // fileList.value[0].raw;
        caregiver.value.avatarPath = "";
        // }
        editCaregiver();
      }

      return;
    }
    ElMessage.error('请输入有效数据');
  });
};

// 显示
const show = (_caregiver = null, _callbackFn) => {
  caregiver.value = {
    id: '',
    name: '',
    sex: '男',
    identificationCard: '',
    workYears: '',
    grade: '1',
    avatarPath: '',
    remark: '',
    state: '1',
  };
  if (_caregiver) {
    // 图书基本信息
    caregiver.value = {
      ..._caregiver
    };

    // 封面
    // fileList.value = [
    //   {
    //     name: _caregiver.Id,
    //     // url: _caregiver.AvatarPath,
    //     // raw:null -> File
    //   },
    // ];
    console.log(caregiver.value);
  }
  callbackFn = _callbackFn;

  visible.value = true;
};

// 上传

// 检查上传的文件
const onFileChange = async (file, files) => {
  try {
    // const base64String = await checkUploadImage(file.raw, { size: 500 * 1024, type: ['image/jpeg'], width: 200, height: 200 });
    // console.log(base64String);

    // if (files.length > 1) {
    //   files.splice(0, 1);
    // }
    // return true;
  } catch (message) {
    ElMessage.error(message);
    files.splice(-1, 1);
    return false;
  }
};

defineExpose({
  show,
});

//
</script>
<style scoped lang="less"></style>
