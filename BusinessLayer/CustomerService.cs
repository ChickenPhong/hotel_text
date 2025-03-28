using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;


namespace BusinessLayer
{
    public class CustomerService
    {
        function fn = new function();

        // Lấy toàn bộ danh sách khách hàng
        public DataTable GetAllCustomers()
        {
            string query = "SELECT * FROM customer";
            return fn.getData(query).Tables[0];
        }

        // Lấy khách chưa checkout
        public DataTable GetCheckedInCustomers()
        {
            string query = "SELECT * FROM customer WHERE checkout IS NULL";
            return fn.getData(query).Tables[0];
        }

        // Lấy khách đã checkout
        public DataTable GetCheckedOutCustomers()
        {
            string query = "SELECT * FROM customer WHERE checkout IS NOT NULL";
            return fn.getData(query).Tables[0];
        }

        // Tìm kiếm khách hàng đang ở
        public DataTable SearchCustomerByName(string name)
        {
            string query = $"SELECT * FROM customer WHERE cname LIKE '{name}%' AND chekout = 'NO'";
            return fn.getData(query).Tables[0];
        }

        // Trả phòng (checkout)
        public void CheckOutCustomer(int cid, string checkoutDate, string roomNo)
        {
            string query = $"UPDATE customer SET chekout = 'YES', checkout = '{checkoutDate}' WHERE cid = {cid}; " +
                           $"UPDATE rooms SET booked = 'NO' WHERE roomNo = '{roomNo}'";
            fn.setData(query, "Thanh toán thành công");
        }

        // Đăng ký khách vào phòng
        public void AllotCustomer(string name, long mobile, string nationality, string gender, string dob,
                                  string idproof, string address, string checkin, int roomId, string roomNo)
        {
            string query = $"INSERT INTO customer (cname, mobile, nationality, gender, dob, idproof, address, checkin, roomid) " +
                           $"VALUES ('{name}', {mobile}, '{nationality}', '{gender}', '{dob}', '{idproof}', '{address}', '{checkin}', {roomId}); " +
                           $"UPDATE rooms SET booked = 'YES' WHERE roomNo = '{roomNo}'";
            fn.setData(query, $"Số Phòng {roomNo} Đăng ký khách hàng thành công.");
        }

        // Lấy danh sách phòng trống theo loại giường và loại phòng
        public DataTable GetAvailableRooms(string bed, string roomType)
        {
            string query = $"SELECT roomNo FROM rooms WHERE bed = '{bed}' AND roomType = '{roomType}' AND booked = 'NO'";
            return fn.getData(query).Tables[0];
        }

        // Lấy giá tiền và roomid theo roomNo
        public (int Price, int RoomId) GetRoomInfo(string roomNo)
        {
            string query = $"SELECT price, roomid FROM rooms WHERE roomNo = '{roomNo}'";
            DataSet ds = fn.getData(query);
            int price = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
            int roomId = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
            return (price, roomId);
        }
    }
}
