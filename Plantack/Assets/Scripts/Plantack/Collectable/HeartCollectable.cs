using Plantack.Player;
using UnityEngine;

namespace Plantack.Collectable
{
    public class HeartCollectable : MonoBehaviour, ICollectable
    {
        [SerializeField] private float value;
        
        
        
        public void Collect(PlayerStats playerStats)
        {
            playerStats.Health += value;
            Destroy(gameObject);
        }
    }
}