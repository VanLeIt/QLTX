//window.addEventListener('DOMContentLoaded', event => {
  
//    const datatablesSimple = document.getElementById('datatablesSimple');
//    if (datatablesSimple) {
//        new simpleDatatables.DataTable(datatablesSimple);
//    }
//});
window.addEventListener('DOMContentLoaded', event => {
    const datatablesSimple = document.getElementById('datatablesSimple');
    if (datatablesSimple) {
        new simpleDatatables.DataTable(datatablesSimple, {
            labels: {
                placeholder: "Tìm kiếm...",
                perPage: "Bản ghi mỗi trang",
                noRows: "Không có dữ liệu để hiển thị",
                info: "Hiển thị {start} đến {end} tổng {rows} mục",
                noResults: "Không tìm thấy kết quả phù hợp",
            }
        });
    }
});