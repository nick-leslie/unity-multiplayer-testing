using System;
using System.Collections.Generic;
using System.Text;

namespace Server
{
    static class roomManiger
    {
       private static Dictionary<int, string> _userNameList = new Dictionary<int, string>();
        
        public static string getUser(int id)
        {
            string user="";
            if (_userNameList.Count >0)
            {
                if (_userNameList.TryGetValue(id, out user)==true)
                {
                    return user;
                }
                //empty string
                return user;
            }
            //empty string
            return user;
        }
        public static void addUser(int id,string user)
        {
            _userNameList.Add(id, user);
        }
        public static void removeUser(int id)
        {
            _userNameList.Remove(id);
        }
        public static void changeUserName(int id, string userName)
        {
            _userNameList[id] = userName;
            //TODO add in changeing id
        }
    }
}
