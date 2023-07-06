using System;
using Game.Boot;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Game.Boot
{
    [Serializable]
    public class LoadingParameters
    {
        [SerializeField] private SceneField _sceneAsset;
        
        [SerializeField] private LoadSceneMode _loadSceneMode = LoadSceneMode.Additive;

        [SerializeField] private bool _isActive;
        
        public SceneField SceneAsset => _sceneAsset;

        public LoadSceneMode LoadSceneMode => _loadSceneMode;

        public bool IsActive => _isActive;
    }
}