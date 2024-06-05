using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Infrastructure
{
    public interface ISceneLoader
    {
        public float Progress { get; }
        public void Load(string name, Action onLoaded = null, bool allowSceneActivation = true);
        public AsyncOperation WaitNextScene { get; set; }
    }

    public class SceneLoadService : ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        private AsyncOperation _waitNextScene;

        private float _progress = 0f;

        public Action OnStartedLoad;

        public float Progress { get => _progress; }
        public AsyncOperation WaitNextScene { get => _waitNextScene; set => _waitNextScene = value; }

        public SceneLoadService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }


        public void Load(string name, Action onLoaded = null, bool allowSceneActivation = true)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded, allowSceneActivation));
        }


        private IEnumerator LoadScene(string nextScene, Action onLoaded = null, bool allowSceneActivation = true)
        {
            OnStartedLoad?.Invoke();
            _waitNextScene = SceneManager.LoadSceneAsync(nextScene);
            _waitNextScene.allowSceneActivation = allowSceneActivation;
            while (!_waitNextScene.isDone)
            {
                _waitNextScene.allowSceneActivation = allowSceneActivation;
                _progress = _waitNextScene.progress;
                yield return null;
            }

            onLoaded?.Invoke();
        }
    }

}
