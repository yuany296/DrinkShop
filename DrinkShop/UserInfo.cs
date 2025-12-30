using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkShop
{
    // 用户信息类
    public class UserInfo
    {
        public string Phone { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string RegisterTime { get; set; }
        public int OrderCount { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
