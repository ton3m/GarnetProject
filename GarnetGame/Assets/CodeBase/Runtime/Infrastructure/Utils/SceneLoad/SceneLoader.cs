using UnityEngine.SceneManagement;

namespace GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils.SceneLoad
{
    public class SceneLoader : ISceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
