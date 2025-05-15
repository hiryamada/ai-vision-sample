using Azure;
using Azure.AI.Vision.ImageAnalysis;

string endpoint = Environment.GetEnvironmentVariable("VISION_ENDPOINT") ??  throw new InvalidOperationException("Set the VISION_ENDPOINT environment variable.");
string key = Environment.GetEnvironmentVariable("VISION_KEY") ?? throw new InvalidOperationException("Set the VISION_KEY environment variable.");

ImageAnalysisClient client = new(
    new Uri(endpoint),
    new AzureKeyCredential(key));

ImageAnalysisResult result = client.Analyze(
    new Uri("https://learn.microsoft.com/azure/ai-services/computer-vision/media/quickstarts/presentation.png"),
    VisualFeatures.Caption | VisualFeatures.Read,
    new ImageAnalysisOptions { GenderNeutralCaption = true });

Console.WriteLine("Image analysis results:");
Console.WriteLine(" Caption:");
Console.WriteLine($"   '{result.Caption.Text}', Confidence {result.Caption.Confidence:F4}");

Console.WriteLine(" Read:");
foreach (DetectedTextBlock block in result.Read.Blocks)
    foreach (DetectedTextLine line in block.Lines)
    {
        Console.WriteLine($"   Line: '{line.Text}', Bounding Polygon: [{string.Join(" ", line.BoundingPolygon)}]");
        foreach (DetectedTextWord word in line.Words)
        {
            Console.WriteLine($"     Word: '{word.Text}', Confidence {word.Confidence.ToString("#.####")}, Bounding Polygon: [{string.Join(" ", word.BoundingPolygon)}]");
        }
    }
