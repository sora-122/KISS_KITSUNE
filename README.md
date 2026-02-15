# Project: KiSS KiTSUNE (Technical Preview)

ライブ演出制御システムの技術実証デモプロジェクトです。

## 概要
楽曲『キスキツネ』の演出を、外部（Python）からのOSC信号によってリアルタイムに制御するシステムの構築を目指しています。「映像美」の前提となる「システム制御の堅牢性（エンジニアリング）」を証明することを主眼に置いています。

## 現在のフェーズ：通信基盤の技術検証 (PoC)
本プロジェクトは、ライブ演出システム構築の前段階として、Python-Unity間のOSC通信プロトコルの確立と、MVPアーキテクチャへの適用検証を目的としています。

### 実施済みの検証
- **OSC Pipeline:** Python (python-osc) から Unity (uOSC) への低遅延通信。
- **Architecture:** VContainer を用いた依存性注入（DI）と、MVPパターンによる受信・ロジック・演出の分離。
- **Real-time Control:** 外部トリガーによる URP Emission 強度のリアルタイム制御。

## 技術スタック
- **Unity:** Unity 6 (URP)
- **C# Libraries:** VContainer, UniTask, uOSC
- **External:** Python 3.x (python-osc, pynput)
- **Architecture:** MVP (Model-View-Presenter)

## Future Roadmap
- Timeline制御信号の受信実装
- URPを用いたルックデヴと演出作成
- シーケンス制御の自動化

---
Created by Sora (20, Game Developer / INFJ)