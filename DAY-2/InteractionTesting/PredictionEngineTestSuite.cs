using Moq;

namespace PredictionEngine.Tests;

public class Tests
{
    [TestCase("How are y","y")]
    [TestCase("How are you doing","doing")]
    [TestCase("","")]
    public void ShouldCallUniGramWhenInputIsPartialWord(string inputString, string lastWord)
    {
        var mockAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);
        string predictedWord = predictionEngine.predict(inputString);
        mockAlgo.Verify(p => p.predictUsingMonogram(lastWord),Times.Once());
    }

    [TestCase("How are you ","you")]
    [TestCase("How are you doing ","doing")]
    [TestCase(" ","")]
    public void ShouldCallBiGramWhenInputIsEndingWithSpace(string inputString, string lastWord)
    {
        var mockAlgo = new Mock<ILanguageModelAlgo>();
        PredictionEngine predictionEngine = new PredictionEngine(mockAlgo.Object);
        string predictedWord = predictionEngine.predict(inputString);
        mockAlgo.Verify(p => p.predictUsingBigram(lastWord),Times.Once());
    }

}
