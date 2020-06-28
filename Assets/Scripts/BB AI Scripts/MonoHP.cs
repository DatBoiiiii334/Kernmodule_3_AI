using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoHP : MonoBehaviour, Idamagable
{
    public void GiveDamage(int damage)
    {
        EnemyManager.health -= damage;
    }
}
