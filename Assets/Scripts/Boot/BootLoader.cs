using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Game.Boot
{
    public class BootLoader : MonoBehaviour
    {
        [SerializeField] private List<LoadingParameters> _loadingParameters;

        
        [Inject]
        private void Construct(InventoryManager inventoryManager)
        {
        }
        private async void Start()
        {
            foreach (var loadingParameters in _loadingParameters)
            {
                var loadingScene = SceneManager.LoadSceneAsync(loadingParameters.SceneAsset.SceneName, loadingParameters.LoadSceneMode);
                
                await UniTask.WaitWhile(() => !loadingScene.isDone);
                
                if (loadingParameters.IsActive)
                {
                    var scene = SceneManager.GetSceneByName(loadingParameters.SceneAsset.SceneName);
                    SceneManager.SetActiveScene(scene);
                }
            }

            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}