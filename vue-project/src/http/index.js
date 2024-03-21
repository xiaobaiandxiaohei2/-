import axios from 'axios';

// 实例配置
const requestIntstance = axios.create({
  baseURL: '',
});

// 实例拦截器
requestIntstance.interceptors.response.use(
  (res) => {
    return res.data;
  },
  ({ response }) => {
    console.log('请求失败：', response);
    if (response.status == 401) {
      return Promise.reject('请登录');
    }
    return Promise.reject(response.data);
  }
);

//
const buildFormData = (data) => {
  const formData = new FormData();
  for (let [key, value] of Object.entries(data)) {
    formData.append(key, value);
  }
  return formData;
};

export default {
  //
  getCategories() {
    return requestIntstance.get('/category/list');
  },
  createNewCategory(name) {
    return requestIntstance.post('/category/create', { name });
  },
  updateCategory(id, name) {
    return requestIntstance.post('/category/update', { id, name });
  },

  getPublishers() {
    return requestIntstance.get('/publisher/list');
  },
  getAuthors() {
    return requestIntstance.get('/author/list');
  },
  getBooks({ categoryId = '', publisherId = '', keyword = '' }) {
    return requestIntstance.get('/book/list', {
      params: { categoryId, publisherId, keyword },
    });
  },
  createBook(book) {
    const formData = buildFormData(book);
    return requestIntstance.post('/book/create', formData);
  },
  updateBook(book) {
    const formData = buildFormData(book);
    return requestIntstance.post('/book/update', formData);
  },
  getAllRecords() {
    return requestIntstance.get('/Transaction/GetAllBorrowRecords');
  },
  // 配送
  distribute(orderId) {
    return requestIntstance.get('/Transaction/Distribution', {
      params: { orderId },
    });
  },
  getStatisticData() {
    return requestIntstance.get('/Statistic/list');
  },

  // 登录
  login(phone, password) {
    return requestIntstance.post('/api/Admin/login', { phone, password });
  },
  //入住记录
  getRecordings({ StartTime = '', EndTime = '', keyword = '' }) {
    return requestIntstance.get(
      '/api/HospitalizationRecord/GetHospitalizationRecords',
      {
        params: { StartTime, EndTime, keyword },
      }
    );
  },
  //老人查询
  getSeniors(keyword) {
    return requestIntstance.get('/api/Senior/GetSeniors', {
      params: { keyword },
    });
  },
  //新增护工
  createSenior(senior) {
    // const formData = buildFormData(caregiver);
    return requestIntstance.post('/api/Senior/CreateSenior', {
      Name: senior.name,
      IdentificationCard: senior.identificationCard,
      Sex: senior.sex,
      AvatarPath: senior.avatarPath,
      Province: senior.province,
      City: senior.city,
      District: senior.district,
      Address: senior.address,
      UnderlyingDisease: senior.underlyingDisease,
      State: senior.state,
    });
  },
  //护工查询
  getCaregivers({ Sex = '', Grade = '', State = '', keyword = '' }) {
    return requestIntstance.get('/api/Caregiver/GetCaregivers', {
      params: { Sex, Grade, State, keyword },
    });
  },
  //新增护工
  createCaregiver(caregiver) {
    // const formData = buildFormData(caregiver);
    return requestIntstance.post('/api/Caregiver/CreateCaregiver', {
      Name: caregiver.name,
      Sex: caregiver.sex,
      IdentificationCard: caregiver.identificationCard,
      WorkYears: caregiver.workYears,
      Grade: caregiver.grade,
      AvatarPath: caregiver.avatarPath,
      Remark: caregiver.remark,
      State: caregiver.state,
    });
  },
  //编辑护工
  EditCaregiver(caregiver) {
    return requestIntstance.put(
      `/api/Caregiver/EditCaregiver/${caregiver.id}`,
      {
        Name: caregiver.name,
        Sex: caregiver.sex,
        IdentificationCard: caregiver.identificationCard,
        WorkYears: caregiver.workYears,
        Grade: caregiver.grade,
        AvatarPath: caregiver.avatarPath,
        Remark: caregiver.remark,
        State: caregiver.state,
      }
    );
  },
  //删除护工
  DeleteCaregiver(id) {
    return requestIntstance.delete(`/api/Caregiver/DeleteCaregiver/${id}`);
  },
  //房间查询
  getRooms({ RoomNumber = '', State = '' }) {
    return requestIntstance.get('/api/Room/GetRooms', {
      params: { RoomNumber, State },
    });
  },
  //监护人查询
  getGuardians(keyword) {
    return requestIntstance.get('/api/Guardian/GetGuardians', {
      params: { keyword },
    });
  },
  //健康项目查询
  getHealthDataItems(keyword) {
    return requestIntstance.get('/api/HealthDataItem/GetHealthDataItemInfos', {
      params: { keyword },
    });
  },
  //预约查询
  getBookings(keyword) {
    return requestIntstance.get('/api/Booking/GetBookings', {
      params: { keyword },
    });
  },
  //申请查询
  getApplications() {
    return requestIntstance.get('/api/Application/GetApplications');
  },
};
