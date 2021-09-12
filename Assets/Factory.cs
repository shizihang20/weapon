using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Factory
{
    public static weaponData ConvertScriptableObject(testGun1 source)
    {
        weaponData temp = new weaponData();
        temp.ammunition = source.ammunition;
        temp.capacity = source.capacity;
        temp.currentAmmo = temp.capacity;
        temp.gunType = source.gunType;
        temp.intervalTime = source.intervalTime;
        temp.weaponName = source.weaponName;

        return DeepCopy<weaponData>(temp);
        
    }

    public static T DeepCopy<T>(T source)
    {
        if (!typeof(T).IsSerializable)
            throw new ArgumentException("the type must be serializable", "source");
        if(System.Object.ReferenceEquals(source,null))
        {
            return default(T);
        }

        IFormatter formatter = new BinaryFormatter();

        Stream stream = new MemoryStream();

        using(stream)
        {
            formatter.Serialize(stream, source);
            stream.Seek(0, SeekOrigin.Begin);
            return (T)formatter.Deserialize(stream);
        }
    }    
}
