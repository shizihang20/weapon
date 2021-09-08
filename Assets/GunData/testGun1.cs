using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunData",menuName ="Assests/GunData GunAssests")]
public class testGun1 : ScriptableObject
{
    public string weaponName;

    public int capacity;

    public int currentAmmo;

    public int ammunition;

    public float intervalTime;

    public GunType gunType;

    public bool swapMode;

}
