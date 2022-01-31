
# app

- お勉強を兼ねたクリーンアーキテクチャで実装したUnityのコードのサンプル実装

## 責務分担のメモ

- `Data層`
  - `Entity`
    - 外部データの表現を担当する。
      - 外部データとは
        - サーバから取得するデータ
        - 端末のストレージから取得するデータ etc
    - Entityのデータはアプリ内部のアプリ仕様に特化したデータ形式にしない。
    - 外部とのやり取りに特化したデータ形式のまま扱う。
    - Entityはどの他の役割のクラスにもアクセスできない。
  - `DataStore`
    - 外部とのやり取りを担当する。
      - ここでの外部とは
        - サーバ,端末のストレージ etc
    - 外部から取得したデータを元にEntityを生成したり。
    - Entityの情報を外部に渡したり。
    - DataStoreはEntityにアクセスできる。
  - `Repository`
    - Data層とDomein層の間に属する。
    - Domein層(UseCase)からデータ層(DataStore)へのアクセスを担当する。
    - RepositoryはDataStoreにアクセスできる。
    - DataStoreが複数存在する場合はRepositoryがDataStoreを切り替えアクセスする。

- `Domain層`
  - `Model`
    - 内部データの表現を担当する。
    - Modelはアプリ仕様に特化した形式の内部データを表現する。
    - Viewに値の変更を伝えるため監視したい値変数はUniRxのReactiveProperty\<T\>を使用して定義する。
    - Modelはどの他の役割のクラスにもアクセスできない。
  - `Translator`
    - EntityとModelの相互変換を担当する。
    - TranslatorはEntityとModelにアクセルできる。
  - `UseCase`
    - ビジネスロジックの実装を担当する。
    - Presenterから処理を依頼される。
    - Repositoryを通じてDataStoreに処理を依頼したり。
    - Translatorを使用してEntityとModelの変換をしたり。
    - UseCaseはRepositoryとTranslatorとModelにアクセスできる。

- `Presentation層`
  - `View`
    - 画面表示とユーザ入力の検知とアニメーションも担当。
    - Viewはどの他の役割のクラスにもアクセスできない。
  - `Presenter`
    - UseCaseから伝わってくる値の変更を監視
    - その値の変更を元にViewを操作する。
    - Viewのユーザ入力イベントを監視しイベントを元にUseCaseの呼び出す。

