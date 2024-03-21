import { createRouter, createWebHistory } from 'vue-router';

const routes = [
  { path: '/', redirect: '/login' },
  {
    path: '/login',
    name: 'login',
    component: () => import('../pages/login/LoginPage.vue'),
  },
  {
    path: '/layout',
    component: () => import('../pages/layout/LayoutPage.vue'),
    meta: { title: '控制台' },
    children: [
      { path: '', redirect: '/layout/recording' },
      {
        path: 'welcome',
        name: 'welcome',
        component: () => import('../pages/welcome/WelcomePage.vue'),
        meta: { title: '欢迎页' },
      },
      {
        path: 'recording',
        name: 'recording',
        component: () => import('../pages/recording/RecordingPage.vue'),
        meta: { title: '入住记录' },
      },
      {
        path: 'senior',
        name: 'senior',
        component: () => import('../pages/senior/SeniorPage.vue'),
        meta: { title: '老人管理' },
      },
      {
        path: 'caregiver',
        name: 'caregiver',
        component: () => import('../pages/caregiver/CaregiverPage.vue'),
        meta: { title: '护工管理' },
      },
      {
        path: 'room',
        name: 'room',
        component: () => import('../pages/room/RoomPage.vue'),
        meta: { title: '房间管理' },
      },
      {
        path: 'guardian',
        name: 'guardian',
        component: () => import('../pages/guardian/GuardianPage.vue'),
        meta: { title: '监护人管理' },
      },
      {
        path: 'healthDataItem',
        name: 'healthDataItem',
        component: () =>
          import('../pages/healthDataItem/HealthDataItemPage.vue'),
        meta: { title: '健康项目管理' },
      },
      {
        path: 'booking',
        name: 'booking',
        component: () => import('../pages/booking/BookingPage.vue'),
        meta: { title: '预约管理' },
      },
      {
        path: 'application',
        name: 'application',
        component: () => import('../pages/application/ApplicationPage.vue'),
        meta: { title: '申请管理' },
      },
    ],
  },
];

const router = createRouter({
  routes,
  history: createWebHistory(),
});

// router.beforeEach((to, from, next) => {
//   next();
// });

export default router;
