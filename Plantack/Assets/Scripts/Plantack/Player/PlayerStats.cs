using System;
using System.Collections;
using Plantack.UI;
using UnityEngine;

namespace Plantack.Player
{
    public class PlayerStats : MonoBehaviour
    {

        
        
        private int _coins;
        public int Coins
        {
            get => _coins;
            set
            {
                _coins = value;
                ONCoinChange(value);
            }
        }
        public delegate void OnCoinChange(int newValue);
        public OnCoinChange ONCoinChange;
        
        
        
        
        
        [SerializeField, Range(1,5)] private int maxHealth = 2;
        [SerializeField] private HeartsUI heartsUI;

        private const int _minHearts = 1;
        private const int _maxHearts = 5;
        
        public int MaxHealth
        {
            get => maxHealth;
            set
            {
                maxHealth = Math.Max(_minHearts,Math.Min(_maxHearts,value));
                heartsUI.SetMaxHearts(maxHealth);
            } 
        }
        
        
        [SerializeField, Range(0,5)] private float health;
        [SerializeField] private float _invulnerableTime = 1;
        private bool _invulnerable = false;
        
        public float Health
        {
            get => health;
            set
            {
                if (_invulnerable) return;
                
                if (value < health)
                {
                    onDamage?.Invoke();
                    _invulnerable = true;
                    StartCoroutine(ResetVulnerability());
                }
                
                if (value <= 0)
                {
                    health = 0;
                    onHealthChange?.Invoke(health);
                    onDie?.Invoke();
                    return;
                }
                health = Math.Min(value, maxHealth);
                onHealthChange?.Invoke(health);
            }
        }

        private IEnumerator ResetVulnerability()
        {
            yield return new WaitForSeconds(_invulnerableTime);
            _invulnerable = false;
        }
        
        public delegate void OnHealthChange(float newValue);
        public OnHealthChange onHealthChange;
        
        public delegate void OnDamage();
        public OnDamage onDamage;
        
        public delegate void OnDie();
        public OnDie onDie;
        
        
        private void OnValidate()
        {
            onHealthChange = (f) => heartsUI.UpdateHealth(f);
            MaxHealth = maxHealth;
            Health = health;
        }
        
        private void Start()
        {
            onHealthChange += heartsUI.UpdateHealth;
        }
        
    }
}
