import { defineStore } from 'pinia';
import { ref } from 'vue';
import storage from '../utils/storage';

// option api

// composition api

export const useAccountStore = defineStore('account', () => {
  //
  const account = ref(storage.getCurrentAccount());
  //
  const login = (payload) => {
    account.value = payload;
    storage.login(payload);
  };
  const logout = () => {
    account.value = null;
    storage.logout();
  };

  return { account, login, logout };
});
