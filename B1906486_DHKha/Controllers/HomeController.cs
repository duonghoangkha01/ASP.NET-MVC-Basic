using B1906486_DHKha.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace B1906486_DHKha.Controllers
{
    public class HomeController : Controller
    {
        DBIO db = new DBIO(); //mục đích của tạo đối tượng db là để gọi dùng các method của nó
                              // GET: Home
        public ActionResult Index()
        {
            List<KHACHHANG> list = db.getList_KHACHHANG(); //trả về một danh sách
            return View(list);
        }
        //Không dùng tham số gì cả cho Create()
        public ActionResult Create()
        {
            return View();
        }
        //Khi gọi đến phương thức addObject_KHACHHANG(KHACHHANG s) in DBIO.cs
        //thì đồng thời ta cần một thông điệp nào đó để nó load dữ liệu lên
        //=> dùng [HttpPost]
        [HttpPost]
        public ActionResult Create(KHACHHANG kh)
        {
            db.addObject_KHACHHANG(kh);
            //sau khi thêm rồi, ta điều hướng người dùng đến trang Index
            return RedirectToAction("Index");
        }
        //Sửa khach hang phức tạp hơn thêm (create) vì ta cần biết sửa khach hang nào?
        //Ta cần biết id của khach hang bạn đang định sửa
        public ActionResult Edit(string id)
        {
            KHACHHANG s = db.getObject_KHACHHANG(id);
            return View(s); //lấy ra khach hang thì sau đó mới sửa được
        }
        [HttpPost] //Ý nghĩa là khi bạn gọi Edit nó cần gửi lên thông điệp để sửa thông tin này
        public ActionResult Edit(KHACHHANG kh) //phải đặt tên là Edit như hàm bên trên, không dùng tên khác
        {
            db.editObject_KHACHHANG(kh);
            return RedirectToAction("Index"); //Khi sửa rồi thì hệ thống sẽ điều hướng quay về trang chủ
        }
        //Xóa một khach hang
        //Ta cần biết id của khach hang bạn đang định xóa
        public ActionResult Delete(string id)
        {
            KHACHHANG kh = db.getObject_KHACHHANG(id);
            return View(kh); //lấy ra khach hang thì sau đó mới xóa được
        }
        [HttpPost] //Ý nghĩa là khi bạn gọi Delete nó cần gửi lên thông điệp để xóa thông tin này
        public ActionResult Delete(KHACHHANG kh)
        {
            db.deleteObject_KHACHHANG(kh);
            return RedirectToAction("Index"); //Khi xóa rồi thì hệ thống sẽ điều hướng quay về trang chủ
        }
        //Xem một quyển sách
        //Ta cần biết id của khach hang bạn đang định xem chi tiết
        public ActionResult Details(string id)
        {
            KHACHHANG kh = db.getObject_KHACHHANG(id);
            return View(kh); //lấy ra quyển sách cần xem
        }
    }
}