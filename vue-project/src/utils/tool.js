export const checkUploadImage = (file, option = { size: 0, type: [], width: 0, height: 0 }) => {
  return new Promise((resolve, reject) => {
    // 检查文件大小
    if (file.size > option.size) {
      return reject(`图片大小不能超过${option.size}`);
    }
    // 检查文件类型
    if (!option.type.includes(file.type)) {
      return reject(`图片格式必须为${option.type.join('|')}`);
    }
    // 检查文件分辨率
    const reader = new FileReader();
    reader.onload = (readerEvent) => {
      const image = new Image();
      image.onload = (imageEvent) => {
        // width
        if (imageEvent.target.width !== imageEvent.target.height) {
          return reject('图书的宽必须等于高');
        }
        // 有效
        resolve(imageEvent.target.src);
      };
      image.onerror = () => {
        reject('加载图片失败');
      };
      image.src = readerEvent.target.result;
    };
    reader.onerror = () => {
      reject('读取文件失败');
    };
    reader.readAsDataURL(file);
  });
};
