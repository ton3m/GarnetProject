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
        [SerializeField] private MeshRenderer _material;

        [Header("Animation Settings")]
        [SerializeField] private float _shakeStrength;
        [SerializeField] private float _shakeDuration;
        [SerializeField] private float _shakeFrequency;
        private Health _health;
        private bool _isDamageable;

        public void SetUpMaterial(LayerMaterialContext layerMaterialContext)
        {
            _material.material.color = layerMaterialContext.MaterialColor;
        }
            
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

        public bool ApplyDamage(int damage)
        {
            if(!_isDamageable)
                return false;

            _health.Decrease(damage);

            PlayHitAnimation();
            CheckDestroy();

            return true;
        }

        private void PlayHitAnimation()
        {
            var punchDir = new Vector3(Random.Range(-1, 1), Random.Range(-1, 0), Random.Range(-1, 1));
            Tween.PunchLocalPosition(transform, strength: punchDir, duration: _shakeDuration, frequency: _shakeFrequency);
        }

        private void CheckDestroy()
        {
            if(_health.CurrentHealth <= 0)
                LayerDestroyed?.Invoke();
        }
    }
}
