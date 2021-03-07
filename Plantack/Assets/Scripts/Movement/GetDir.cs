using UnityEngine;
namespace Plantack.PlayerController
{
    public class GetDir : MonoBehaviour
    {
        bool ladder = false;
        [SerializeField]
        Vector2 XYdir;
        public Vector2 Activate(GetInput Input, PlayerVariables Character, Rigidbody2D rb)
        {
            GetY(Input, Character, rb);
            GetX(Input);
            return XYdir;
        }
        private void GetY(GetInput input,PlayerVariables vars, Rigidbody2D rb)
        {
            if (ladder)
                XYdir.y = input.Climb;
            else
                XYdir.y = 1;

        }
        private void GetX(GetInput input)
        {
            if (!input.Dash)
                XYdir.x = input.Basic;
            else
                XYdir.x = 1f;
        }
    }
}