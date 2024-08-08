using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Services.Factory
{
    public class ObjectFactory
    {
        public T[] Create<T>(T prefabToCreate, int count, Transform parent = null) where T : Behaviour
        {
            var createdObjects = new T[count];

            for (int i = 0; i < count; i++)
            {
                T generatedObject = Object.Instantiate(prefabToCreate, Vector3.zero, Quaternion.identity, parent);

                generatedObject.gameObject.SetActive(false);
                createdObjects[i] = generatedObject;
            }

            return createdObjects;
        }

        public void Create<T>(T prefabToCreate, ref T[] array, Transform parent = null) where T : Behaviour
        {
            for (int i = 0; i < array.Length; i++)
            {
                T generatedObject = Object.Instantiate(prefabToCreate, Vector3.zero, Quaternion.identity, parent);

                generatedObject.gameObject.SetActive(false);
                array[i] = generatedObject;
            }
        }
    }
}
