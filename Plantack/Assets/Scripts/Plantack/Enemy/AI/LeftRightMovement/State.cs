using System.Collections;

namespace Plantack.Enemy.AI.LeftRightMovement
{
    public abstract class State
    {

        protected LeftRightMovement LeftRightMovement;

        public State(LeftRightMovement leftRightMovement)
        {
            LeftRightMovement = leftRightMovement;
        }

        public virtual IEnumerator Start()
        {
            yield break;
        }

        public virtual void Stop()
        {
        }


    }
}