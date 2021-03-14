using Plantack.Player;
using UnityEngine;

namespace Plantack.Collectable
{
    public class Enemy : MonoBehaviour, IStatsCollider
    {
        [SerializeField, Range(0,5)] private float damage;

        public void StatsCollide(PlayerStats playerStats)
        {
            playerStats.Health -= damage;
        }
    }
}