using System;
using System.Collections.Generic;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Core.PopUp;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Pool
{
    public class ObjectPool<T> : IDisposable where T : Behaviour
    {
        private Queue<T> _pool;

        public IEnumerable<DamagePopUp> Pool => (IEnumerable<DamagePopUp>)_pool;

        public ObjectPool(T[] objectsToPool)
        {
            _pool = new Queue<T>();

            for (int i = 0; i < objectsToPool.Length; i++)
            {
                _pool.Enqueue(objectsToPool[i]);
                objectsToPool[i].gameObject.SetActive(false);
            }
        }

        public T GetPool()
        {
            if (_pool.Count != 0)
            {
                var pooledObject = _pool.Dequeue();
                return pooledObject;
            }
            else
                throw new ArgumentOutOfRangeException("Out of Pool!");
        }

        public void ReturnPool(T objectToReturn)
        {
            _pool.Enqueue(objectToReturn);
            objectToReturn.gameObject.SetActive(false);
        }

        public void Dispose()
        {
            _pool.Clear();
        }
    }
}
