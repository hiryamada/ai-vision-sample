using Azure;
using Azure.AI.Vision.ImageAnalysis;

string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT") ??  throw new InvalidOperationException("Set the VISION_ENDPOINT environment variable.");
string key = Environment.GetEnvironmentVariable("VISION_KEY") ?? throw new InvalidOperationException("Set the VISION_KEY environment variable.");

ImageAnalysisClient client = new(
    new Uri(endpoint),
    new AzureKeyCredential(key));

using FileStream stream = new("images/sample.jpg", FileMode.Open);
BinaryData imageData = BinaryData.FromStream(stream);

ImageAnalysisResult result = client.Analyze(
    imageData,
    VisualFeatures.Caption |
    VisualFeatures.DenseCaptions |
    VisualFeatures.Tags |
    VisualFeatures.Objects |
    VisualFeatures.People |
    VisualFeatures.Read,
    new ImageAnalysisOptions { GenderNeutralCaption = true });


Console.WriteLine("===========================");
Console.WriteLine("キャプション:");
Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");

Console.WriteLine("===========================");
Console.WriteLine("高密度キャプション:");
foreach (var caption in result.DenseCaptions.Values)
{
    Console.WriteLine($"   '{caption.Text}', Confidence {caption.Confidence:F4}");
}

Console.WriteLine("===========================");
Console.WriteLine("タグ:");
foreach (var tag in result.Tags.Values)
{
    Console.WriteLine($"   '{tag.Name}', Confidence {tag.Confidence:F4}");
}

Console.WriteLine("===========================");
Console.WriteLine("オブジェクト:");
foreach (var obj in result.Objects.Values)
{
    foreach (var tag in obj.Tags)
    {
        Console.WriteLine($"   '{tag.Name}', Confidence {tag.Confidence:F4}");
    }
    Console.WriteLine($"   Bounding Box: x: {obj.BoundingBox.X}, y: {obj.BoundingBox.Y}, width: {obj.BoundingBox.Width}, height: {obj.BoundingBox.Height}");
}

Console.WriteLine("===========================");
Console.WriteLine("人物:");
foreach (var person in result.People.Values)
{
    Console.WriteLine($"   '{person.BoundingBox}', Confidence {person.Confidence:F4}");
    Console.WriteLine($"   Bounding Box: x: {person.BoundingBox.X}, y: {person.BoundingBox.Y}, width: {person.BoundingBox.Width}, height: {person.BoundingBox.Height}");
}

Console.WriteLine("===========================");
Console.WriteLine("文字読み取り結果:");
foreach (DetectedTextBlock block in result.Read.Blocks)
{
    foreach (DetectedTextLine line in block.Lines)
    {
        Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
        foreach (DetectedTextWord word in line.Words)
        {
            Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence:F4}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
        }
    }
}
