# Azure AI Vision サンプル（AI-102 ラボ2）

- ラボ2を起動
- Azure portalで「Azure AI Services マルチサービスアカウント」リソースを作成
  - 作成画面: https://portal.azure.com/#create/Microsoft.CognitiveServicesAllInOne
  - リソースグループは作成済みのものを使用
  - リージョンは 米国東部、米国西部、フランス中部、韓国中部、北ヨーロッパ、東南アジア、西ヨーロッパ、東アジアのいずれかとする
- 環境変数「VISION_ENDPOINT」を作成。値: リソースのエンドポイント
- 環境変数「VISION_KEY」を作成。値: リソースのキー
- dotnet run でプログラムを実行
