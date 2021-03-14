using Plantack.Collectable;
using Plantack.Player;
using UnityEngine;

namespace Plantack.Enemy
{
    [RequireComponent(typeof(SimpleEnemyMovement))]
    public class EnemyStats : MonoBehaviour, IStatsCollider
    {

        [SerializeField] private float damage;

        private SimpleEnemyMovement _enemyMovement;

        private void Start()
        {
            _enemyMovement = GetComponent<SimpleEnemyMovement>();
        }

        public void StatsCollide(PlayerStats playerStats)
        {
            _enemyMovement.Stop();
            playerStats.Health -= damage;
        }
    }
}