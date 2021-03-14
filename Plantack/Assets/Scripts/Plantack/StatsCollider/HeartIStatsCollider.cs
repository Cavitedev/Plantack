using Plantack.Player;
using UnityEngine;

namespace Plantack.Collectable
{
    public class HeartIStatsCollider : MonoBehaviour, IStatsCollider
    {
        [SerializeField] private float value;
        
        
        
        public void StatsCollide(PlayerStats playerStats)
        {
            playerStats.Health += value;
            Destroy(gameObject);
        }
    }
}