const swiper = new Swiper('.swiper', {
  // Tùy chọn vòng xoay cho phiên bản Swiper đầu tiên
  direction: 'horizontal', // Các slide di chuyển theo chiều ngang
  loop: false,               // Không quay lại đầu
  pagination: {
    el: '.swiper-pagination-bullets', // Sử dụng phần tử hiện có với lớp 'swiper-pagination-bullets' cho các chấm đánh dấu phân trang
    clickable: true,                   // Cho phép nhấp vào các chấm đánh dấu phân trang để điều hướng
  },
  navigation: {
    nextEl: '.s-button-next',        // Sử dụng phần tử hiện có với lớp 's-button-next' cho nút điều hướng "Tiếp theo"
    prevEl: '.s-button-prev',        // Sử dụng phần tử hiện có với lớp 's-button-prev' cho nút điều hướng "Trước"
  },
});

const swiper2 = new Swiper('.swiper2', {
  direction: 'horizontal',
  loop: true,                // Quay lại đầu khi đến cuối slide
  navigation: {
    nextEl: '.swiper-response-next',
    prevEl: '.swiper-response-prev',
  },
});
