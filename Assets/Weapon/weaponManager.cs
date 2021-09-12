using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class weaponManager : MonoBehaviour
{
    //public Action Fire;
    //public Action StartReload;
    //public Action FinishReload;
    //public Action StartPutIn;

    //public delegate void EventHandler();
    //public event EventHandler FireEvent;
    //public event EventHandler ReadyEvent;

    public List<Weapon> weapons;
    public Weapon currentWeapon;
    public int index;



    public void Start()
    {
        Initialization();
        
    }

    public void Initialization()
    {
        var temp = GetComponentsInChildren<Weapon>();
        foreach (var item in temp)
        {
            weapons.Add(item);
            item.Initialize(GetComponent<Animator>());
        }
        index = 0;
        currentWeapon = weapons[index];
        currentWeapon.gameObject.SetActive(true);
    }

    public void PutOut(int index)
    {
        weapons[index].OnPutOut();
    }

    public void PutIn()
    {
        currentWeapon.OnPutIn();
    }

    public void GunFire()
    {
        currentWeapon.Onfire();
    }

    public void Reload()
    {
        currentWeapon.OnReload();
    }

    public void Update()
    {
        
        if (currentWeapon.runtimeData.gunType == GunType.semi || currentWeapon.runtimeData.gunType == GunType.burst)
        {
            if (Input.GetMouseButtonDown(0))
                GunFire();
        }
        else
        { 
            if(Input.GetMouseButton(0))
                GunFire(); 
        }
        if (Input.GetKeyDown(KeyCode.R))
            Reload();
        if (Input.GetKeyDown(KeyCode.Q))
            SwitchWeapon();
        if (Input.GetMouseButtonDown(1))
        {
            SwitchFireMode();
        }
    }

    public void SwitchWeapon()
    {
        if (index == this.weapons.Count-1)
            index = 0;
        else
            index++;
        currentWeapon.OnPutIn();
        currentWeapon = weapons[index];
        currentWeapon.OnPutOut();
    }    

    private void SwitchFireMode()
    {
        currentWeapon.OnSwitchMode();
    }
}
