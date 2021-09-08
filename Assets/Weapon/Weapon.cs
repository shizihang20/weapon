using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Weapon : MonoBehaviour
{
    public ScriptableObject gunData;

    public weaponData basicData;

    public weaponData runtimeData;

    public AccessoryManager accessoryManager;

    public Animator animator;

    private float timer = 0;

    //private void Update()
    //{
    //    if (Input.GetMouseButton(0))
    //    {
    //        Onfire();
    //    }
    //    if (Input.GetKeyDown(KeyCode.R))
    //        OnReload();
    //}

    //public virtual void Initialize(weaponManager weaponManager)
    public virtual void Initialize(Animator animator)
    {
        basicData = Instantiate(gunData) as weaponData;

        runtimeData = DeepClone.DeepCopy<weaponData>(basicData);
        this.animator = animator;
        accessoryManager = GetComponent<AccessoryManager>();
        this.gameObject.SetActive(false);
        accessoryManager.Initialize(this);
    }

    public virtual void OnPutOut()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void OnPutIn()
    {
        this.gameObject.SetActive(false);
    }

    public virtual void Onfire()
    {
        if (!ReadyFire())
            return;
        if (runtimeData.gunType == GunType.semi)
            semiFire();
        else if (runtimeData.gunType == GunType.burst)
            burstFire();
        else
            autoFire();
    }

    public virtual void OnReload()
    {
        if (runtimeData.currentAmmo >= runtimeData.capacity)
            return;
        

        if(runtimeData.ammunition >= runtimeData.capacity)
        {
            int used = runtimeData.capacity - runtimeData.currentAmmo;
            runtimeData.currentAmmo = runtimeData.capacity;
            runtimeData.ammunition -= used;
        }
        else
        {
            runtimeData.currentAmmo = runtimeData.ammunition;
            runtimeData.ammunition = 0;
        }
    }

    public virtual void OnSwitchMode()
    {
        if (runtimeData.gunType == GunType.auto)
            runtimeData.gunType = GunType.semi;
        if (runtimeData.gunType == GunType.semi)
            runtimeData.gunType = GunType.auto;
        runtimeData.swapMode = false;        
    }

    private void autoFire()
    {        
        if(Time.time >= timer && runtimeData.currentAmmo >= 0)
        {
            runtimeData.currentAmmo--;
            timer = Time.time + runtimeData.intervalTime;
        }
        //生成子弹或调用对象池
    }

    private void semiFire()
    {
        runtimeData.currentAmmo--;
        //生成子弹或调用对象池
    }

    private void burstFire()
    {
        if (runtimeData.currentAmmo > 0 && runtimeData.currentAmmo < 3)
            runtimeData.currentAmmo -= runtimeData.currentAmmo;
        else
            runtimeData.currentAmmo -= 3;
    }

    private bool ReadyFire()
    {
        if (runtimeData.currentAmmo <= 0)
            return false;
        return true;
    }
}
