using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
public class TickManiger : MonoBehaviour
{

    // sets how long in between ticks in this case 100 miliseconds
    [SerializeField]
    private int TimeBetweenTicks;

    public static int Tick;
    public static Timer tickTimer;
    private void Awake()
    {
        StartTicking();
    }
    void StartTicking()
    {
        Tick = 0;
        tickTimer = new Timer();
        tickTimer.Interval = TimeBetweenTicks;
        tickTimer.Enabled = true;
        TickManiger.tickTimer.Elapsed += delegate (object sender, System.Timers.ElapsedEventArgs e)
        {
            Tick++;
            Debug.Log("Tick:"+Tick);
        };
    }
}
