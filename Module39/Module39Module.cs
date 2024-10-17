using Module39.Views;
using Prism.Ioc;
using Prism.Modularity;
//using Prism.Navigation.Regions;
using Prism.Regions;

namespace Module39
{
    public class Module39Module : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(StudentList));
            regionManager.RegisterViewWithRegion("PersonDetailsRegion", typeof(StudentDetail));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }
    }
}