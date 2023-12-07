using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bullet", menuName = "ScriptableObject/Player/Bullet", order = 0)]
public class BulletSO : ScriptableObject
{
    public Sprite municionSprite;
    public float damage;
    public float range;
    public float speed;
    public int municion;
}
