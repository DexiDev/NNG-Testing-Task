using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boot
{
    [Serializable]
    public class LoadingParameters
    {
        [SerializeField] private SceneAsset _sceneAsset;
        
        [SerializeField] private LoadSceneMode _loadSceneMode = LoadSceneMode.Additive;

        [SerializeField] private bool _isActive;
        
        public SceneAsset SceneAsset => _sceneAsset;

        public LoadSceneMode LoadSceneMode => _loadSceneMode;

        public bool IsActive => _isActive;
    }
}