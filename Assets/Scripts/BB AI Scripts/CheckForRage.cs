using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBUnity.Conditions
{
    [Condition("Basic/CheckForRage")]
    [Help("Checks whether a target is close depending on a given distance")]
    public class CheckForRage : GOCondition
    {
        [InParam("Mono")]
        public MonoHP _instance;   

        public override bool Check()
        {
            if (_instance.IsRaging == true) {
                return true;
            }
            else {
                return false;
            }

        }
    }
}

