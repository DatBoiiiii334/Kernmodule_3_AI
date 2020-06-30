using Pada1.BBCore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BBUnity.Conditions
{
    /// <summary>
    /// It is a perception condition to check if the objective is close depending on a given distance.
    /// </summary>
    [Condition("Basic/CheckPos")]
    [Help("Checks whether a target is close depending on a given distance")]
    public class CheckPos : GOCondition
    {
        ///<value>Input Target Parameter to to check the distance.</value>
        private bool mybool;

        public override bool Check()
        {
            if (mybool == true) {
                Debug.Log("Made it");
                return true;
            }
            else {
                return false;
            }

        }

        public void Rage(bool startRaging)
        {
            Debug.Log("Shit");
            mybool = startRaging;
        }
    }
}
