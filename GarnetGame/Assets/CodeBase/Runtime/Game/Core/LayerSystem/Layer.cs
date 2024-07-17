using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.Damageable;
using UnityEngine;

namespace GarnnetProject
{
    public class Layer : MonoBehaviour, IDamageable
    {
        public void ApplyDamage(int damage)
        {
            Debug.Log("Layer hit!");
        }
    }
}
