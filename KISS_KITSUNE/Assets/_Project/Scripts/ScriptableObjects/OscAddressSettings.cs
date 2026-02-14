using UnityEngine;

namespace KISS_KITSUNE.Settings
{
    /// <summary>
    /// Model: OSC アドレスの設定データを管理する
    /// </summary>
    [CreateAssetMenu(fileName = "OscAddressSettings", menuName = "KISS_KITSUNE/OscAddressSettings")]
    public class OscAddressSettings : ScriptableObject
    {
        [Header("Trigger Addresses")]
        [Tooltip("色切り替えトリガーのアドレス")]
        [SerializeField] private string _colorChangeAddress = "/kiss_kitsune/trigger/color_change";

        // 公開プロパティ
        public string ColorChangeAddress => _colorChangeAddress;
    }
}