using System;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.AssetsProvide;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Pool;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Core.PopUp
{
    public class DamagePopUpController : IDisposable
    {
        private ObjectPool<DamagePopUp> _pool;

        public DamagePopUpController(IAssetProvider assetProvider)
        {
            var _popUps = new DamagePopUp[15];
            var popUpPrefab = assetProvider.Load<DamagePopUp>("DamagePopUp");

            for (int i = 0; i < 15; i++)
            {
                DamagePopUp popUpObject = Object.Instantiate(popUpPrefab, Vector3.zero, Quaternion.identity, null);

                popUpObject.gameObject.SetActive(false);
                _popUps[i] = popUpObject;
                
                popUpObject.End += ReturnPopUpToPool;
            }

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
