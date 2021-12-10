# UniduxSceneTransitionSample

## Description

Unidux を利用した状態制御・画面遷移機構のサンプルプロジェクトです．  
hands-on ブランチをチェックアウトすることで，穴埋め方式で Unidux (+α) のアウトプットを行うことができます．

## Folder Configuration

フォルダ配置は以下のようになっています．

```
Assets
├─@UniduxSceneTransitionSample # 本プロジェクトのルート
│  ├─ResourceFiles # リソースデータを格納するフォルダ
│  │  ├─Images 
│  │  └─Presets
│  │  └─... (Prefabs, Audios, Materials, Animations etc...)
│  ├─Scenes # Unity Scene を格納するフォルダ
│  │  ├─Page # ページとして利用する Unity Scene を格納するフォルダ (View, Presenter, Navigation...)
│  │  │  ├─01_Title
│  │  │  ├─02_Main
│  │  │  └─03_Result
│  │  └─Domain # ドメインの塊として利用する Unity Scene を格納するフォルダ (Service, Repository, Application Layer, Infrastructure Layers...)
│  │      ├─0A_AAAA 
│  │      ├─0B_BBBB
│  │      └─0Z_UniduxBase # Unidux Service Scene
│  └─Scripts # スクリプトを格納するフォルダ
│      ├─Progression # プログレッションレイヤー (初期化・終端処理・中断処理・実行処理等のライフサイクル処理を定める) 
│      ├─Application # アプリケーションレイヤー 
│      │  └─Transitioner # トランジショナー (画面遷移機構)
│      ├─Domain # ドメインレイヤー (サービスやモデルデータを配置しています) <<Service は必要に応じてMonoBehaviourを継承する>>
│      │  ├─MainService # メインゲーム画面に関するドメインフォルダ
│      │  │  ├─PageData # ページデータ (Unidux画面遷移関連に利用)
│      │  │  └─Service # メインサービス (ここにドメイン関心に関するサービスを置く)
│      │  │  └─DataEntity # データエンティティ (データのエンティティを置く)
│      │  │  └─Repository # リポジトリ (データベース情報・ScritableObject スクリプト等)
│      │  │  └─...
│      │  ├─Progression # プログレッションサービスに関するフォルダ
│      │  ├─ResultService # リザルト画面に関するドメインフォルダ
│      │  │  ├─PageData
│      │  │  └─Service
│      │  │  └─DataEntity
│      │  │  └─Repository
│      │  │  └─...
│      │  └─Unidux # Unidux Domain Service を格納するフォルダです
│      ├─LifeCycle # ライフサイクルレイヤー (ここでは MonoInstaller or LifetimeScope を配置し，初期化・終端処理の順番を定めます) <<MonoBehaviour継承>>
│      │  ├─01_Title 
│      │  ├─02_Main
│      │  ├─03_Result
│      │  └─0Z_UniduxBase
│      └─Presention # プレゼンテーションレイヤー を格納するフォルダです 
│          ├─Navigator # ナビゲータレイヤー (必要に応じて Scene 内に存在する View 群との間の行き来等の処理を司る) <<MonoBehaviourを継承しない>>
│          │  └─01_Title
│          ├─Presenter # プレゼンタレイヤー (View と Domain との橋渡し処理を司る) <<MonoBehaviourを継承しない>>
│          │  ├─01_Title
│          │  ├─02_Main
│          │  └─03_Result
│          └─View # ビューレイヤー (入力イベント・出力表示用の処理を司る) <<UIBehaviour継承>>
│              ├─01_Title
│              ├─02_Main
│              └─03_Result
└─ThirdParty # サードパーティアセット格納用フォルダ
    ├─TextMesh Pro
    └─...
    └─...

```

## Dependencies

* Unity 2020.3.16f1

## Third Party Assets

* [Unidux 0.4.2](https://github.com/mattak/Unidux)

Copyright © 2016 MARUYAMA Takuma (mattak)

* [UniRx 7.1.0](https://github.com/neuecc/UniRx)

Copyright (c) 2018 Yoshifumi Kawai

* [UniTask 2.2.5](https://github.com/Cysharp/UniTask)

Copyright (c) 2019 Yoshifumi Kawai / Cysharp, Inc.

* [Zenject 9.2.0](https://github.com/modesttree/Zenject)

Copyright (c) 2010-2021 Modest Tree Media Inc. ZENJECT and EXTENJECT are a trademark of Modest Tree Media Inc.

* [MessagePipe 1.6.1](https://github.com/Cysharp/MessagePipe)

Copyright (c) 2021 Cysharp, Inc.

## Licence

This project is licensed under the MIT License excluding third party assets.
