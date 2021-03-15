using System.Collections;
using UnityEngine;

namespace Plantack.Enemy.AI.LeftRightMovement
{
    public class ReactState : State	
    {
        public ReactState(LeftRightMovement leftRightMovement) : base(leftRightMovement)
        {
        }


        public override IEnumerator Start()
        {
            LeftRightMovement.SetAnimatorStop();
            LeftRightMovement.SetVelocity(Vector2.zero);
            yield return new WaitForSeconds(LeftRightMovement.stopTime);
            LeftRightMovement.SetState(new MovementState(LeftRightMovement, LeftRightMovement.GetTimeLeft()));
        }
    }
}