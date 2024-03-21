import { createApp } from 'vue';
import 'element-plus/dist/index.css';
// import 'element-plus/theme-chalk/el-message.css';
import './style.less';
import App from './App.vue';

import router from './router';
import pinia from './store';

createApp(App).use(router).use(pinia).mount('#app');
