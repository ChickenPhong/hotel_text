using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using TransferObject;
using DataLayer;

namespace BusinessLayer
{
    public class RoomService
    {
        function fn = new function();

        public List<Room> GetAllRooms()
        {
            var list = new List<Room>();
            DataSet ds = fn.getData("SELECT * FROM rooms");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(new Room
                {
                    RoomId = Convert.ToInt32(row["roomid"]),
                    RoomNo = row["roomNo"].ToString(),
                    RoomType = row["roomType"].ToString(),
                    Bed = row["bed"].ToString(),
                    Price = Convert.ToInt64(row["price"])
                });
            }

            return list;
        }

        public void AddRoom(Room room)
        {
            string query = $"INSERT INTO rooms (roomNo, roomType, bed, price) VALUES ('{room.RoomNo}', '{room.RoomType}', '{room.Bed}', {room.Price})";
            fn.setData(query, "Thêm phòng thành công");
        }
    }
}
