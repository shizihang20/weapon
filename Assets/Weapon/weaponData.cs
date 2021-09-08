using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class weaponData
{
    public string weaponName;

    public int capacity;

    public int currentAmmo;

    public int ammunition;

    public float intervalTime;

    public GunType gunType;

    public bool swapMode;
}

public enum GunType
{
    auto,
    semi,
    burst
}
