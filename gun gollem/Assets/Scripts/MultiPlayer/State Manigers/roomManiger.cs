
using System.Collections;
using System.Collections.Generic;

public  static class roomManiger
{
    private static int _userID;
    public static int userID
    {
        get
        {
            return _userID;
        }
    }
    public static int currentPlayers;
    public static int currentReadyPlayers;
    public static void setUserId(int _id)
    {
        if (_userID==0)
        {
            _userID = _id;
        }
    }
}
