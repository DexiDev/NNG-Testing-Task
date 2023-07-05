using Zenject;

namespace Game.Inventory
{
    public class InventoryManagerInstaller : MonoInstaller<InventoryManagerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<InventoryManager>().AsSingle();
        }
    }
}