using EidolonJobTest.Analytics;
using Zenject;

namespace EidolonJobTest.Installers
{
    public class BootStrapInstaller : MonoInstaller<BootStrapInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IEventService>()
                .To<EventService>()
                .AsSingle()
                .NonLazy();
        }
    }
}