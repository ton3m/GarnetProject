using System;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.Damageable;
using PrimeTween;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.OreSystem
{
    public class Ore : MonoBehaviour, IDamageable
    {
        public event Action<Ore> Destroyed;

        [Header("Animation Settings")]
        [SerializeField] private float _shakeStrength;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeFrequency;
        private Health _health;
        private bool _isDamageable;

        public void Init(int maxHealth)
        {
            _health = new Health(maxHealth);

            if (_health != null)
                _isDamageable = true;
        }

        public bool ApplyDamage(int damage)
        {
            if (!_isDamageable)
                return false;

            _health.Decrease(damage);

            PlayHitAnimation();
            CheckDestroy();

            return true;
        }

        private void OnDisable()
        {
            _isDamageable = false;
            Tween.StopAll(onTarget: transform);
        }

        private void PlayHitAnimation()
        {
            Vector3 punchDir = new Vector3(Random.Range(-1, 1), Random.Range(-1, 0), Random.Range(-1, 1));
            Tween.PunchLocalPosition(transform, strength: punchDir, duration: _shakeDuration, frequency: _shakeFrequency);
        }

        private void CheckDestroy()
        {
            if (_health.CurrentHealth <= 0)
                Destroyed?.Invoke(this);
        }
    }
}