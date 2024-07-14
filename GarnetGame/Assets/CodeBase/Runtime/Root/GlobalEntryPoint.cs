using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Constants;
using GarnnetProject.Assets.CodeBase.Runtime.Infrastructure.Utils;
using GarnnetProject.Assets.CodeBase.Runtime.Game.Root;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GarnnetProject.Assets.CodeBase.Runtime.App.Root;

namespace GarnnetProject.Assets.CodeBase.Runtime.Root
{
    public class GlobalEntryPoint
    {
        private static GlobalEntryPoint _instance;
        private Coroutines _coroutines;
        private UIRootView _uiRoot;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void AutoStart()
        {
            // глобальные настройки
            // ...

            _instance = new GlobalEntryPoint();
            _instance.RunGame();
        }

        public GlobalEntryPoint()
        {
            // создание системных утилит и сервисов и регистрация их в DontDestroyOnLoad()
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);

            var _uiRootPrefab = Resources.Load<UIRootView>("UIRoot");
            _uiRoot = Object.Instantiate(_uiRootPrefab);
            Object.DontDestroyOnLoad(_uiRoot.gameObject);
        }

        private void RunGame()
        {
#if UNITY_EDITOR
            var currentSceneName = SceneManager.GetActiveScene().name;

			if (currentSceneName == Scenes.GAME)
            {
                _coroutines.StartCoroutine(LoadAndStartGame());
				return;
            }

            if (currentSceneName == Scenes.BOOT)
            {
                return;
            }

            if (currentSceneName == Scenes.MAIN_APP)
            {
                _coroutines.StartCoroutine(LoadAndStartMainApp());
            }
#endif

            _coroutines.StartCoroutine(LoadAndStartMainApp());
        }

        private IEnumerator LoadAndStartGame()
        {
			_uiRoot.ShowLoadingCurtain();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.GAME);

            yield return new WaitForSeconds(1); // просто задержка

			var gameplayEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
			gameplayEntryPoint.Run(_uiRoot); // передача DI в этом месте

			gameplayEntryPoint.GoToMainAppSceneRequested += () =>
            {
                _coroutines.StartCoroutine(LoadAndStartMainApp());
            };

			_uiRoot.HideLoadingCurtain();
        }

        private IEnumerator LoadAndStartMainApp()
        {
            _uiRoot.ShowLoadingCurtain();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MAIN_APP);

            yield return new WaitForSeconds(1);  // просто задержка

            var gameplayEntryPoint = Object.FindFirstObjectByType<AppEntryPoint>();
			gameplayEntryPoint.Run(_uiRoot); // передача DI в этом месте

			gameplayEntryPoint.GoToGameplaySceneRequested += () =>
            {
                _coroutines.StartCoroutine(LoadAndStartGame());
            };

            _uiRoot.HideLoadingCurtain();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }

    }
}
