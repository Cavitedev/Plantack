using UnityEngine;
namespace Plantack.PlayerController
{
    public class GetDir : MonoBehaviour
    {
        bool ladder = false;
        Vector2 XYdir;
        public Vector2 Activate(GetInput Input, PlayerVariables Character, Rigidbody2D rb)
        {
            GetY(Input, Character, rb);
            GetX(Input);
            return XYdir;
        }
        private void GetY(GetInput input,PlayerVariables vars, Rigidbody2D rb)
        {
            if (input.Jump)
                XYdir.y = Jump();
            else if (ladder)
                XYdir.y = input.Climb;
            else
                XYdir.y = rb.velocity.y;

        }
        private void GetX(GetInput input)
        {
            if (!input.Dash)
                XYdir.x = input.Basic;
            else
                XYdir.x = 1;
        }
        
        float Jump()
        {
            float Ydir = 0f;
            return Ydir;
        }
    }
}