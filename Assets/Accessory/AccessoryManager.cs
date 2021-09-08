using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AccessoryManager : MonoBehaviour
{
    private List<Accessory> accessories;

    private Weapon weapon;

    public void Initialize(Weapon weapon)
    {
        this.weapon = weapon;
        accessories = GetComponentsInChildren<Accessory>().ToList();
        foreach (var item in accessories)
        {
            Add(item);
        }
    }

    public void Add(Accessory accessory)
    {
        accessory.OnAdd(weapon);
    }

    public void Remove(int index)
    {
        Accessory removeItem = accessories[index];
        Accessory[] tempL = removeItem.GetComponentsInChildren<Accessory>();
        foreach (var item in tempL)
        {
            item.OnRemove(weapon);
        }
    }

    public void Remove(Accessory accessory)
    {
        
    }


    public List<Accessory> GetAccessories()
    {
        return this.accessories;
    }

    //允不允许在游戏途中更改配件
}
