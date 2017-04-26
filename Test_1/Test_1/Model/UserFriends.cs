using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;

namespace Test_1.Model
{
    class UserFriends
    {
        [ForeignKey(typeof(User))]
        public int UserId { set; get; }
        [ForeignKey(typeof(User))]
        public int FriendId { set; get; }
    }
}
