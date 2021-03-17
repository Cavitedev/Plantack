using UnityEngine;

namespace Plantack.Player
{
    [CreateAssetMenu(fileName = "PlayerUI", menuName = "PlayerUI", order = 0)]
    public class PlayerUI : ScriptableObject
    {

        
        public RuntimeAnimatorController animator;
        public Sprite defaultImage;
        public Sprite jumpImage;
        public Sprite runImage;
        public Sprite attackImage;
        public Sprite climbImage;


    }
}