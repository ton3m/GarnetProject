using System;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.Damageable;
using PrimeTween;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.LayerSystem
{
    public class Layer : MonoBehaviour, IDamageable
    {
        public event Action LayerDestroyed;

        [SerializeField, Min(1)] private int _maxHealth = 100;
        [SerializeField] private float _shakeStrength;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeFrequency;
        private Health _health;
        private bool _isDamageable;

        public void Init()
        {
            _health = new Health(_maxHealth);
            _isDamageable = true;
        }

        private void OnDisable()
        {
            _isDamageable = false;
            Tween.StopAll(onTarget: transform);
        }

        public void ApplyDamage(int damage)
        {
            if(!_isDamageable)
                return;

            Debug.Log(transform.name + " Layer hit!");
            _health.Decrease(damage);

            var punchDir = new Vector3(Random.Range(-1, 1), Random.Range(-1, 0), Random.Range(-1, 1));
            Tween.PunchLocalPosition(transform, strength: punchDir, duration: _shakeDuration, frequency: _shakeFrequency);

            if(_health.CurrentHealth <= 0)
                LayerDestroyed?.Invoke();
        }
    }
}
