Hướng dẫn sử dụng chương trình 

B1: giải nén file và mở file
B2: mở file CuaHangThietBiDienTu.sln
B3: Chạy file CuaHangThietBiDienTu.sql và tạo dữ liệu
B3: Vào file Web.Config sửa đường dẫn đến máy chủ sql bằng cách sửa datasource thành tên máy chủ sql, 
thêm integrated security=True nếu sử dụng local host, nếu xác minh đăng nhập thì nhập id và password vào, 
cái này e không sử dụng nên cũng không nhớ cách sử dụng
B5: để sử dụng chức năng tìm kiếm sản phẩm, chạy file debug Index.cshtml trong thư mục Views/Home
B6: Sử dụng các chức năng còn lại thì Vào thư mục Area/Admin/Views/Home bấm vào file Index.cshtml và chạy, bấm vào các mục Quản
lí hóa đơn và quản lí chi tiết hóa đơn để có thể thao tác xem, thêm, sửa, xóa trên dữ liệu

Hệ thống chưa đầy đủ các chức năng của một hệ thống đầy đủ, Chức năng tìm kiếm còn có giới hạn bởi vì chỉ có thể 
tìm kiếm theo tên sản phẩm hoặc mã sản phẩm, bộ lọc đang bị lỗi và vẫn chưa hoạt động được, sử dụng template mẫu
nên có đôi chỗ hiển thị dữ liệu của mẫu, chưa có chức năng đăng nhập cho admin, chưa có chức năng giỏ hàng

