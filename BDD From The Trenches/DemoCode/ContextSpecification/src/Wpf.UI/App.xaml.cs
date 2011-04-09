using System.Windows;
using BddDemo.Framework.Dependencies;

namespace Wpf.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DependencyRegistrar.RegisterDependencies();
        }
    }
}
