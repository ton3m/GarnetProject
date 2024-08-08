using System;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.AssetsProvide;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Factory;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Pool;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.PopUp
{
    public class DamagePopUpController : IDisposable
    {
        private ObjectPool<DamagePopUp> _pool;

        public DamagePopUpController(IAssetProvider assetProvider)
        {
            DamagePopUp[] _popUps = new DamagePopUp[15];
            
            DamagePopUp popUpPrefab = assetProvider.Load<DamagePopUp>("DamagePopUp");

            ObjectFactory factory = new ObjectFactory();
            factory.Create<DamagePopUp>(popUpPrefab, ref _popUps, null);

            foreach (var popUp in _popUps)
                popUp.End += ReturnPopUpToPool;

            _pool = new ObjectPool<DamagePopUp>(_popUps);
        }

        public void Show(Vector2 coords, int damage)
        {
            var popUp = _pool.GetPool();

            popUp.transform.position = new Vector3(coords.x, coords.y, -3);
            popUp.gameObject.SetActive(true);
            popUp.SetUp(damage, 2);
        }

        private void ReturnPopUpToPool(DamagePopUp popUp)
        {
            _pool.ReturnPool(popUp);
        }

        public void Dispose()
        {
            foreach (var popUp in _pool.Pool)
            {
                popUp.End -= ReturnPopUpToPool;
            }

            _pool.Dispose();
        }
    }
}
