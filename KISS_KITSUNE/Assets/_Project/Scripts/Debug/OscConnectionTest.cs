using UnityEngine;
using uOSC;

namespace KISS_KITSUNE.Debug
{
    /// <summary>
    /// 技術検証用: OSC信号を受信し、ログ出力するクラス
    /// </summary>
    public class OscConnectionTest : MonoBehaviour
    {
        private uOscServer _server;

        private void Awake()
        {
            _server = GetComponent<uOscServer>();
        }

        private void OnEnable()
        {
            _server.onDataReceived.AddListener(OnDataReceived);
        }

        private void OnDisable()
        {
            _server.onDataReceived.RemoveListener(OnDataReceived);
        }

        private void OnDataReceived(Message message)
        {
            // アドレスフィルタリング ("/kiss_kitsune/test/value")
            if (message.address == "/kiss_kitsune/test/value")
            {
                if (message.values.Length > 0 && message.values[0] is float value)
                {
                    UnityEngine.Debug.Log($"<color=cyan>[OSC Recv]</color> Value: {value:F4} (Time: {Time.time:F2})");
                }
            }
        }
    }
}
