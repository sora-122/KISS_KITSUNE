using System;
using KISS_KITSUNE.Settings;
using KISS_KITSUNE.Views;
using uOSC;
using VContainer;
using VContainer.Unity;
using UnityEngine;

namespace KISS_KITSUNE.Presenters
{
    /// <summary>
    /// Presenter: OSC 受信イベントと View 操作の仲介
    /// プレーンな C# クラスとして定義し、VContainer にライフサイクルを委ねる
    /// </summary>
    public class OscColorPresenter : IStartable, IDisposable
    {
        private readonly uOscServer _server;
        private readonly ColorView _view;
        private readonly OscAddressSettings _settings;

        // コンストラクタインジェクション (依存性注入)
        public OscColorPresenter(
            uOscServer server,
            ColorView view,
            OscAddressSettings settings
        )
        {
            _server = server;
            _view = view;
            _settings = settings;
        }

        public void Start()
        {
            // イベント購読
            _server.onDataReceived.AddListener(OnDataReceived);
            UnityEngine.Debug.Log("<color=orange>[Presenter] OSC Monitoring Started.</color>");
        }

        public void Dispose()
        {
            // イベント解除 (メモリリーク防止)
            _server.onDataReceived.RemoveListener(OnDataReceived);
        }

        private void OnDataReceived(Message message)
        {
            // 信号到達確認ログ
            UnityEngine.Debug.Log($"[Presenter] Received: {message.address}");

            if (message.address == _settings.ColorChangeAddress)
            {
                _view.ToggleColor();
                UnityEngine.Debug.Log("<color=green>[Presenter] Address Match! Calling View...</color>");
            }
        }
    }
}