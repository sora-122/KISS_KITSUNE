using UnityEngine;

namespace KISS_KITSUNE.Views
{
    /// <summary>
    /// View: オブジェクトの色変更を担当
    /// ロジックは持たず、公開メソッドを通じて制御される
    /// </summary>
    public class ColorView : MonoBehaviour
    {
        [SerializeField] private MeshRenderer _meshRenderer;
        private Material _targetMaterial;

        // 発光色の定義 (HDR)
        [ColorUsage(true, true)][SerializeField] private Color _activeColor = Color.cyan * 4.0f; // 強度 4 のシアン
        [SerializeField] private Color _inactiveColor = Color.black;

        private bool _isLit = false;

        private void Awake()
        {
            if (_meshRenderer == null) _meshRenderer = GetComponent<MeshRenderer>();
            // インスタンス化されたマテリアルを取得 (他への影響を防ぐ)
            _targetMaterial = _meshRenderer.material;
            // 初期状態は消灯
            UpdateVisual();
        }

        /// <summary>
        /// 発光状態を切り替える
        /// </summary>
        public void ToggleColor()
        {
            _isLit = !_isLit;
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            Color targetColor = _isLit ? _activeColor : _inactiveColor;

            // 1. 色の設定
            _targetMaterial.SetColor("_EmissionColor", targetColor);

            // 2. キーワードの強制有効化
            _targetMaterial.EnableKeyword("_EMISSION");

            // 3. グローバル照明への反映通知
            _targetMaterial.globalIlluminationFlags = _isLit
                ? MaterialGlobalIlluminationFlags.RealtimeEmissive
                : MaterialGlobalIlluminationFlags.EmissiveIsBlack;

            // デバッグログ: 実際に設定された色とキーワード状態を出力
            UnityEngine.Debug.Log($"[ColorView] IsLit: {_isLit}, Color: {targetColor}, Keyword: {_targetMaterial.IsKeywordEnabled("_EMISSION")}");
        }

        private void OnDestroy()
        {
            // 動的に生成したマテリアルのメモリ開放
            if (_targetMaterial != null) Destroy(_targetMaterial);
        }

        // Inspectorのコンポーネント名を右クリックして実行可能にする
        [ContextMenu("Debug Toggle Color")]
        public void DebugToggleColor() => ToggleColor();
    }
}
