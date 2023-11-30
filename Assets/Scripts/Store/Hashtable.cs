using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hashtable<T>
{
    public class Hash
    {
        public T Key { get; set; }
        public int Index { get; set; }
        public Hash(T k, int i)
        {
            Key = k;
            Index = i;
        }
    }
    private Hash[] HashArray = new Hash[28];

    private int length = 0;

    public int Add(T key)
    {
        int index = HashFunction01(key);

        Hash hash = new Hash(key, index);

        int i = 0;
        bool checkIndex = true;

        while (checkIndex)
        {
            if (HashArray[hash.Index] != null)
            {
                i++;
                hash.Index = HashFunction02(index, i);
                checkIndex = true;
            }
            else
            {
                HashArray[hash.Index] = hash;
                checkIndex = false;
            }
        }
        Debug.Log(hash.Key + " #" + hash.Index);
        length++;

        return hash.Index;
    }
    public T GetKey(int index)
    {
        return HashArray[index].Key;
    }
    public void GetHash(int index)
    {
        Debug.Log(HashArray[index].Key + " #" + +index);
    }
    public int HashFunction01(T key)
    {
        dynamic keyCurrent = key;
        Bullet keyWeapon = keyCurrent;
        int k = 0;

        for (int i = 0; i < keyWeapon.name.Length; i++)
        {
            k += (int)keyWeapon.name[i];
        }
        return k % 19;
    }
    public int HashFunction02(int k, int i)
    {
        return (k + i) % 29;
    }
}
