using Plantack.Player;

namespace Plantack.Enemy
{
    public class EnemyDamage : DamageObject
    {
        private SimpleEnemyMovement _enemyMovement;

        private void Start()
        {
            _enemyMovement = GetComponent<SimpleEnemyMovement>();
        }

        public override void StatsCollide(PlayerStats playerStats)
        {
            _enemyMovement.Stop();
            base.StatsCollide(playerStats);
        }
    }
}