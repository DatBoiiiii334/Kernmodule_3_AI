using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the objective is close depending on a given distance.
    /// </summary>
    [Condition("Perception/EnemyHealth")]
    [Help("Checks whether a target is close depending on a given distance")]
    public class EnemyHealth : GOCondition
    {
        ///<value>Input Target Parameter to to check the distance.</value>
        [InParam("health")]
        [Help("Target to check the distance")]
        public int health;

        public override bool Check()
        {
            health = EnemyManager.health;
            if(health <= 0) {
                return true;
            }
            else{
                return false;
            }
        }

        public void healthCheck(int damage)
        {
            health -= damage;
        }
    }
}

//public class MonoHP : MonoBehaviour, Idamagable
//{
//    //public int health;

//    public void GiveDamage(int damage)
//    {
//        health -= damage;
//    }
//}
