const KEY_CURRENT_ACCOUNT = 'KEY_CURRENT_ACCOUNT';

export default {
  getCurrentAccount() {
    return JSON.parse(sessionStorage.getItem(KEY_CURRENT_ACCOUNT));
  },
  login(account) {
    sessionStorage.setItem(KEY_CURRENT_ACCOUNT, JSON.stringify(account));
  },
  logout() {
    sessionStorage.removeItem(KEY_CURRENT_ACCOUNT);
    sessionStorage.clear();
  },
};
