using System;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.Damageable
{
    public class Health
    {
        private int _currentHealth;

        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
            }
        }

        public int MaxHealth { get; }

        public void Decrease(int value)
        {
            if (value <= 0)
                return;

            CurrentHealth -= value;
        }

        public void Increase(int value)
        {
            if (value <= 0)
                return;

            CurrentHealth += value;
        }

        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }
    }

}
