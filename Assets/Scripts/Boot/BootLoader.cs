using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boot
{
    public class BootLoader : MonoBehaviour
    {
        [SerializeField] private List<LoadingParameters> _loadingParameters;

        private async void Start()
        {
            foreach (var loadingParameters in _loadingParameters)
            {
                var loadingScene = SceneManager.LoadSceneAsync(loadingParameters.SceneAsset.name, loadingParameters.LoadSceneMode);
                
                await UniTask.WaitWhile(() => !loadingScene.isDone);
                
                if (loadingParameters.IsActive)
                {
                    var scene = SceneManager.GetSceneByName(loadingParameters.SceneAsset.name);
                    SceneManager.SetActiveScene(scene);
                }
            }

            SceneManager.UnloadScene(gameObject.scene);
            
            
            
        }
    }
}