using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Constants;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

namespace GarnnetProject.Assets.CodeBase.Runtime.Root
{
    public class GlobalEntryPoint
    {
        private static GlobalEntryPoint _instance;
        private Coroutines _coroutines;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void AutoStart()
        {
            // глобальные настройки
            // ...
            Application.targetFrameRate = 60;

            _instance = new GlobalEntryPoint();
            _instance.RunGame();
        }

        public GlobalEntryPoint()
        {
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);
        }

        private void RunGame()
        {
#if UNITY_EDITOR
            var currentSceneName = SceneManager.GetActiveScene().name;

			if (currentSceneName == Scenes.GAME)
            {
                _coroutines.StartCoroutine(LoadFirstScene(Scenes.GAME));
				return;
            }

            if (currentSceneName == Scenes.BOOT)
                return;
            
            if (currentSceneName == Scenes.MAIN_APP)
            {
                _coroutines.StartCoroutine(LoadFirstScene(Scenes.MAIN_APP));
                return;
            }
#endif

            _coroutines.StartCoroutine(LoadFirstScene(Scenes.MAIN_APP));
        }

        private IEnumerator LoadFirstScene(string firstSceneToLoad)
        {
            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(firstSceneToLoad);
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

    }
}
