using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Game.Services.AssetsProvide
{
    public interface IAssetProvider
    {
        T Load<T>(string path) where T : Object;
    }
}
