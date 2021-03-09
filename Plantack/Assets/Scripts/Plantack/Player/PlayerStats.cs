using System;
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
        
        
        
        
        
        [SerializeField, Range(2,5)] private int maxHealth = 2;
        [SerializeField] private HeartsUI heartsUI;

        private int _minHearts = 2;
        private int _maxHearts = 5;
        
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
        public float Health
        {
            get => health;
            set
            {
                if (value <= 0)
                {
                    health = 0;
                    ONHealthChange(health);
                    onDie?.Invoke();
                    return;
                }
                health = Math.Min(value, maxHealth);
                ONHealthChange(health);
            }
        }
        public delegate void OnHealthChange(float newValue);
        public OnHealthChange ONHealthChange;
        
        public delegate void OnDie();
        public OnDie onDie;
        
        
        private void OnValidate()
        {
            ONHealthChange = heartsUI.UpdateHealth;
            MaxHealth = maxHealth;
            Health = health;
        }
        
        private void Start()
        {
            ONHealthChange += heartsUI.UpdateHealth;
        }
        
    }
}
