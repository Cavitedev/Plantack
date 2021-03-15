using UnityEngine;

namespace Plantack.Enemy.AI.LeftRightMovement
{
    public class StateMachine : MonoBehaviour
    {
        public State State;

        public void SetState(State state)
        {
            State = state;
            StartCoroutine(state.Start());
        }
    }
}