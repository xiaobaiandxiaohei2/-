<template>
  <div class="login-page">
    <el-card>
      <template #header>
        <div class="card-header">
          <h2>管理员登录</h2>
        </div>
      </template>
      <!-- 表单 -->
      <el-form ref="ruleFormRef" :model="user" status-icon :rules="rules">
        <el-form-item prop="phone">
          <el-input :prefix-icon="Iphone" placeholder="请输入手机号码" v-model="user.phone" type="text" autocomplete="off" />
        </el-form-item>
        <el-form-item prop="password">
          <el-input :prefix-icon="Lock" placeholder="请输入密码" v-model="user.password" type="password"
            autocomplete="off" />
        </el-form-item>

        <el-form-item>
          <el-button :loading="loading" size="large" type="primary" @click="submitForm(ruleFormRef)">登录</el-button>
        </el-form-item>
      </el-form>
    </el-card>
  </div>
</template>
<script setup>
import { reactive, ref } from 'vue';
import { Lock, Iphone } from '@element-plus/icons-vue';
import { ElMessage } from 'element-plus';
import http from '../../http';
import { useRouter } from 'vue-router';
import { useAccountStore } from '../../store/account';

// state
const ruleFormRef = ref();
const user = reactive({
  phone: '18751346665',
  password: '123',
});

const rules = reactive({
  phone: [
    { required: true, message: '手机号码不能为空', trigger: 'blur' },
    { pattern: /^1[3-9]\d{9}$/, message: '手机号码格式无效', trigger: 'blur' },
  ],
  password: [
    { required: true, message: '密码不能为空', trigger: 'blur' },
    // { pattern: /^\d{4,}$/, message: '密码格式无效', trigger: 'blur' },
  ],
});

const loading = ref(false);
const router = useRouter();
const accountStore = useAccountStore();

// 登录
const login = async () => {
  try {
    const res = await http.login(user.phone, user.password);
    console.log(res);
    // 保存状态
    accountStore.login(res);
    // 提示并跳转
    ElMessage({
      message: '登录成功',
      duration: 1000,
      type: 'success',
      onClose: () => {
        router.replace('/layout');
      },
    });
  } catch (ex) {
    ElMessage.error({
      message: ex,
      type: 'error',
      duration: 1000,
      onClose: () => {
        loading.value = false;
      },
    });
  }
};

// 提交表单(登录)
const submitForm = (formEl) => {
  if (!formEl) return;

  loading.value = true;

  formEl.validate((valid) => {
    if (valid) {
      login();
      return;
    }
    console.log('请输入有效的登录信息');
    ElMessage.error({
      message: '请输入有效的登录信息',
      duration: 1000,
      type: 'error',
      onClose: () => {
        loading.value = false;
      },
    });
  });
};

// 重置
</script>
<style scoped lang="less">
.login-page {
  height: 100%;
  overflow: hidden;
  background-color: #f6f6f6;
}

.el-card {
  width: 420px;
  margin: 100px auto;
}

.el-button {
  width: 100%;
}
</style>
