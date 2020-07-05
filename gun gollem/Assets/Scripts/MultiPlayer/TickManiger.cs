using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickManiger : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs
    {
        public int tick;
    }

    public static EventHandler<OnTickEventArgs> OnTick;
    // sets how long in between ticks in this case 100 miliseconds
    private const float TimeBetweenTicks = .05f;

    private int Tick;
    private float TickTimer;
    private bool ticking=false;
    private void Awake()
    {
        StartTicking();
    }
    void StartTicking()
    {
        ticking = true;
        Tick = 0;
    }
    private void Update()
    {
        if (ticking==true)
        {
            TickTimer += Time.deltaTime;
            if (TickTimer >= TimeBetweenTicks)
            {
                TickTimer -= TimeBetweenTicks;
                Tick++;
                //if there are subscribers to the event
                if (OnTick != null)
                {
                    OnTick(this, new OnTickEventArgs { tick = Tick });
                }
            }
        }
    }
}
