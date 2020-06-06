using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy
{
    public class EnemyIdleState : EnemyState
    {
        public override void onEnterState()
        {
            base.onEnterState();

            //Debug.Log("Entered Idle state");
        }

        public override void onExitState()
        {
            base.onExitState();


        }
    }
}

