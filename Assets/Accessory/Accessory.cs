using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : MonoBehaviour
{
    public AccessoryData accessoryData;

    public virtual void OnAdd(Weapon weapon)
    {
        weapon.runtimeData.capacity += accessoryData.increaseAmmo;
        weapon.runtimeData.intervalTime -= accessoryData.intervalDecrese;
    }

    public virtual void OnRemove(Weapon weapon)
    {
        weapon.runtimeData.capacity -= accessoryData.increaseAmmo;
        weapon.runtimeData.intervalTime += accessoryData.intervalDecrese;
    }

    //ֱ���޸ĸ����ݻ�����������
}
