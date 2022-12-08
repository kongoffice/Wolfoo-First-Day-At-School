using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

namespace SCN.Common
{
    public class LoadSceneManager : MonoBehaviour
    {
        static LoadSceneManager _instance;
        static LoadSceneManager Instance
        {
            get
            {
                Setup();
                return _instance;
            }
        }

        public static void Setup()
        {
            if (_instance != null)
            {
                return;
            }

            _instance = Instantiate(LoadSource.LoadObject<GameObject>("Load scene canvas"), DDOL.Instance.transform)
                .GetComponent<LoadSceneManager>();

            var canvas = _instance.GetComponent<Canvas>();
            canvas.worldCamera = Camera.main;
            canvas.sortingLayerName = LoadSceneSettings.Instance.Layer;
            canvas.sortingOrder = LoadSceneSettings.Instance.OrderInLayer;
            
            _loadAnim = Instantiate(LoadSceneSettings.Instance.LoadAnim.gameObject, _instance.transform)
                .GetComponent<AnimLoadSceneBase>();

            if (_loadAnim == null)
            {
                Debug.LogError("Cannot find ILoadScene");
            }
            _loadAnim.Default();
        }

        public static System.Action<string> OnLoadSceneDone;
        public static System.Action<string> OnSceneReady;

        public static System.Action BeforeExitScene;
        public static System.Action OnLoadingScene;

        public static string CurrentScene => SceneManager.GetActiveScene().name;
        public static string LastScene = "";

        public static bool IsLoading { get; private set; }

        static AnimLoadSceneBase _loadAnim;

        [SerializeField]

        public static void LoadScene(string sceneName, System.Action onDone = null)
        {
            FreeRAM();
            IsLoading = true;

            Setup();
            _loadAnim.BeforeLoad(sceneName, () =>
            {
                _ = Instance.StartCoroutine(LoadSceneIE(sceneName, onDone));
            });
        }

        static IEnumerator LoadSceneIE(string sceneName, System.Action onDone = null)
        {
            _loadAnim.StartLoad(sceneName);

            var _lastScene = CurrentScene;

            BeforeExitScene?.Invoke();
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName.ToString());

            LastScene = _lastScene;

            bool check = true;
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);

                if (progress > 0.5f && check)
                {
                    OnLoadingScene?.Invoke();
                    check = false;
                }
                yield return null;
            }

            _instance.GetComponent<Canvas>().worldCamera = Camera.main;
            OnLoadSceneDone?.Invoke(sceneName);
            onDone?.Invoke();

            _loadAnim.EndLoad(sceneName, () =>
            {
                OnSceneReady?.Invoke(sceneName);
            });
        }

        public static void FreeRAM()
        {
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
        }
    }
}
