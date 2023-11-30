using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObject/Player/Bullet", order = 0)]
public class BulletSO : ScriptableObject
{
    public int index;
    public Sprite bala;
    public float damage;
    public float range;
    public float speed;
}
