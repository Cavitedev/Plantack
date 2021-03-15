using Plantack.Enemy.AI.LeftRightMovement;
using Plantack.Player;
using UnityEngine;

namespace Plantack.Enemy
{
    [RequireComponent(typeof(LeftRightMovement))]
    public class LeftRightEnemyDamage : DamageObject
    {
        private LeftRightMovement _enemyMovement;

        private void Start()
        {
            _enemyMovement = GetComponent<LeftRightMovement>();
        }

        public override void StatsCollide(PlayerStats playerStats)
        {
            _enemyMovement.Stop();
            base.StatsCollide(playerStats);
        }
    }
}