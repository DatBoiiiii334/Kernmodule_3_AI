using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("Basic/NoHealth")]
    [Help("Checks whether the game object has 0 or lower health")]
    public class NoHealth : GOCondition
    {
        [InParam("health")]
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
            if (health <= 0) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}