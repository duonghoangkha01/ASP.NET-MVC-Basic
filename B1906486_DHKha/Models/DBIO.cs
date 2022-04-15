using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B1906486_DHKha.Models
{
    public class DBIO
    {
        B1906486_DHKhaEntities mydb = new B1906486_DHKhaEntities();
        //hàm getList_KHACHHANG() để thực hiện một câu truy vấn
        //trả về một danh sách dùng iQuery
        public List<KHACHHANG> getList_KHACHHANG()
        {
            //access to the KHACHHANG table to read all rows
            return mydb.KHACHHANGs.ToList();
        }
        //hàm getObject_KHACHHANG(string id) trả về một KHACHHANG theo id
        public KHACHHANG getObject_KHACHHANG(string id)
        {
            //biểu thức so sánh có cú pháp như C#
            //chứ không phải của SQL
            return mydb.KHACHHANGs.Where(c => c.MAKH == id).FirstOrDefault();
        }
        //hàm addObject_KHACHHANG(KHACHHANG kh) thêm vào một KHACHHANG
        public void addObject_KHACHHANG(KHACHHANG kh)
        {
            mydb.KHACHHANGs.Add(kh);
            mydb.SaveChanges();
        }
        //hàm editObject_HOCVIEN(KHACHHANG kh) sửa một KHACHHANG
        public void editObject_KHACHHANG(KHACHHANG kh)
        {
            KHACHHANG x = getObject_KHACHHANG(kh.MAKH);
            x.TENKH = kh.TENKH;
            x.NGAYSINH = kh.NGAYSINH;
            x.GIOITINH = kh.GIOITINH;
            x.EMAIL = kh.EMAIL;
            x.DIENTHOAI = kh.DIENTHOAI;
            x.DIACHI = kh.DIACHI;
            mydb.SaveChanges();
        }
        //hàm deleteObject_KHACHHANG(KHACHHANG kh) xóa một KHACHHANG
        public void deleteObject_KHACHHANG(KHACHHANG kh)
        {
            KHACHHANG x = getObject_KHACHHANG(kh.MAKH);
            mydb.KHACHHANGs.Remove(x);
            mydb.SaveChanges();
        }
    }
}