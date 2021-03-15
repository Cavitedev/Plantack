using System.Collections;
using UnityEngine;

namespace Plantack.Enemy.AI.LeftRightMovement
{
    public class IdleState : State
    {
        public IdleState(LeftRightMovement leftRightMovement) : base(leftRightMovement)
        {
        }

        public override IEnumerator Start()
        {
            LeftRightMovement.SetAnimatorStop();
            LeftRightMovement.SetVelocity(Vector2.zero);
            yield return new WaitForSeconds(LeftRightMovement.waitTime);
            LeftRightMovement.FlipDir();
            LeftRightMovement.SetState(new MovementState(LeftRightMovement, LeftRightMovement.moveTime));
        }
        
    }
}