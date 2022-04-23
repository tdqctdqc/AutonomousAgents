using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorProfile
{
    public BehaviorProfile(float arrive, float avoid, float avoidCol, float avoidColNor, float evade, float pursue, float pursueArrive, float seek, float wander, float cohes, float align, float separ, float form)
    {
        this.arrive = arrive;
        this.avoid = avoid;
        this.avoidCol = avoidCol;
        this.avoidColNor = avoidColNor;
        this.evade = evade;
        this.pursue = pursue;
        this.pursueArrive = pursueArrive;
        this.seek = seek;
        this.wander = wander;
        this.cohes = cohes;
        this.align = align;
        this.separ = separ;
        this.form = form;
    }

    public float arrive { get; private set; }
    public float avoid { get; private set; }
    public float avoidCol { get; private set; }
    public float avoidColNor { get; private set; }
    public float evade { get; private set; }
    public float pursue { get; private set; }
    public float pursueArrive { get; private set; }
    public float seek { get; private set; }
    public float wander { get; private set; }
    public float cohes { get; private set; }
    public float align { get; private set; }
    public float separ { get; private set; }
    public float form { get; private set; }
}
