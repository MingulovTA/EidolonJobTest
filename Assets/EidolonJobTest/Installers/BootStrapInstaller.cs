using EidolonJobTest.Analytics;
using EidolonJobTest.RequestsSender;
using EidolonJobTest.ServerProvider;
using UnityEngine;
using Zenject;

namespace EidolonJobTest.Installers
{
    public class BootStrapInstaller : MonoInstaller<BootStrapInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<EventService>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IServerUriProvider>()
                .To<ServerUriProvider>()
                .AsSingle()
                .NonLazy();

            Container.Bind<IRequestSender>()
                .To<LogRequestSender>()
                .AsSingle()
                .NonLazy();

            Container.Bind<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .AsSingle()
                .NonLazy();
        }
    }
}