using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Services.AssetsProvide
{
    public class AssetProvider : IAssetProvider
    {
        public T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }
    }
}
