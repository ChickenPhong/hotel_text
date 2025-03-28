using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomNo { get; set; }
        public string RoomType { get; set; }
        public string Bed { get; set; }
        public long Price { get; set; }
    }
}
