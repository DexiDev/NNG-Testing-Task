using System;
using Game.Inventory;
using UnityEngine;

namespace Game.InteractableObjects
{
    public interface IGeneratedBuilding : IBuilding
    {
        Item ItemOut { get; }
        
        void GenerateItem();
        
        void CreateItem(Transform targetTransform);
    }
}