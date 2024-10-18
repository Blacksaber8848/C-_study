using Module40.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Module40
{
    public class Module40Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion2", typeof(StudentList));
            regionManager.RegisterViewWithRegion("PersonDetailsRegion2", typeof(StudentDetail));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}