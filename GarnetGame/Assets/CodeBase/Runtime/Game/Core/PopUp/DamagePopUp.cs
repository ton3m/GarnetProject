using System;
using PrimeTween;
using TMPro;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.PopUp
{
    public class DamagePopUp : MonoBehaviour
    {
        public event Action<DamagePopUp> End;

        [SerializeField] private TMP_Text _damageText;
        [SerializeField] private float _yEndPositionOffset;

        public void SetUp(int damage, float lifeTime = 1)
        {
            _damageText.text = damage.ToString();

            Tween.PositionY(transform, endValue: transform.position.y + _yEndPositionOffset, duration: lifeTime)
                .OnComplete(() => End?.Invoke(this));
        }

        private void OnDisable()
        {
            Tween.StopAll(onTarget: transform);
        }
    }
}
