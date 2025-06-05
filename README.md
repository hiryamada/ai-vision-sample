# Azure AI Vision サンプル（AI-102 ラボ2）

- ラボ2を起動（以下の手順はラボ内で実施）
- Azure portalで「Azure AI Services マルチサービスアカウント」リソースを作成
  - 作成画面: https://portal.azure.com/#create/Microsoft.CognitiveServicesAllInOne
  - リソースグループは作成済みのものを使用
  - リージョンは 米国東部、米国西部、フランス中部、北ヨーロッパ、西ヨーロッパ、東南アジア、東アジア、韓国中部、のいずれかとする
- 環境変数「VISION_ENDPOINT」を作成。値: リソースのエンドポイント
- 環境変数「VISION_KEY」を作成。値: リソースのキー
- Visual Studio Codeを起動（以下の手順はVisual Studio Code内で実施）
- 本リポジトリをクローン
- ターミナルを起動し、dotnet run でプログラムを実行
- キャプション、高密度キャプション、タグ、オブジェクト、人物、文字読み取り結果が表示される
