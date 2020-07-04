using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("Perception/EnemyHealth")]
    [Help("Checks if the gameObject needs healing")]
    public class EnemyHealth : GOCondition
    {
        [InParam("health")]
        [Help("this is my current health")]
<<<<<<< Updated upstream
        public int health;
=======
        public float health;
>>>>>>> Stashed changes
        [InParam("EnemyMono")]
        public MonoHP _instance;

        public override bool Check()
        {
            health = _instance.health;
            if(health <= 0) {
                return true;
            }
            else{
                return false;
            }
        }
    }
}