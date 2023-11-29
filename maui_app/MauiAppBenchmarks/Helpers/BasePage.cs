using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiAppBenchmarks.Helpers
{
    public abstract class BasePage<T> : ContentPage where T : BaseViewModel
    {
        protected BasePage(T viewModel)
        {
            base.BindingContext = viewModel;            
        }

        protected new T BindingContext => (T)base.BindingContext;
        public abstract void Build();
        
        protected override void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            Build();
#if DEBUG
            HotReloadService.UpdateApplicationEvent += ReloadUI;
#endif
        }

        protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
        {
            base.OnNavigatedFrom(args);

#if DEBUG
            HotReloadService.UpdateApplicationEvent -= ReloadUI;
#endif
        }

        private void ReloadUI(Type[] obj)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Build();
            });
        }
    }
}
