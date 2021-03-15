using System.Collections;
using UnityEngine;

namespace Plantack.Enemy.AI.LeftRightMovement
{
    public class MovementState : State
    {

        private float _time;
        
        public MovementState(LeftRightMovement leftRightMovement, float time) : base(leftRightMovement)
        {
            _time = time;
        }
        
        
        public override IEnumerator Start()
        {
            LeftRightMovement.SetAnimatorMove();
            LeftRightMovement.SetVelocity(LeftRightMovement.currentDir);
            yield return new WaitForSeconds(_time);
            LeftRightMovement.SetState(new IdleState(LeftRightMovement));
        }

        public override void Stop()
        {
            LeftRightMovement.StopAllCoroutines();
            LeftRightMovement.SetState(new ReactState(LeftRightMovement));
            
        }
    }
}