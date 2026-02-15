using KISS_KITSUNE.Presenters;
using KISS_KITSUNE.Settings;
using KISS_KITSUNE.Views;
using uOSC;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace KISS_KITSUNE.Installers
{
    /// <summary>
    /// Root LifetimeScope: ライブ演出システムの依存関係を定義
    /// </summary>
    public class LiveLifetimeScope : LifetimeScope
    {
        [SerializeField] private uOscServer _oscServer;
        [SerializeField] private ColorView _colorView;
        [SerializeField] private OscAddressSettings _oscAddressSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            // 1. Hierarchy 上のコンポーネントを登録 (Instance として)
            builder.RegisterComponent(_oscServer);
            builder.RegisterComponent(_colorView);
            builder.RegisterInstance(_oscAddressSettings); // ScriptableObject を注入

            // 2. Presenter を登録 (EntryPoint として = Start/Dispose が自動で呼ばれる)
            builder.RegisterEntryPoint<OscColorPresenter>();
        }
    }
}