using Plantack.Collectable;
using Plantack.Player;
using UnityEngine;

namespace Plantack.Enemy
{
    
    public class DamageObject : MonoBehaviour, IStatsCollider
    {

        [SerializeField] private float damage = 1;



        public virtual void StatsCollide(PlayerStats playerStats)
        {
            playerStats.Health -= damage;
        }
    }
}