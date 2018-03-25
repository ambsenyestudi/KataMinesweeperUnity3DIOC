using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;

public class SurraundingIndexesUT
{
    [Test]
    public void Given0SourroundingIndexesShouldMatch()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        var result = indexService.FigureSuroundingIndexes(0, 5, 25);
        Assert.AreEqual(-1, result[0]);
        Assert.AreEqual(-1, result[1]);
        Assert.AreEqual(1, result[2]);
        Assert.AreEqual(6, result[3]);
        Assert.AreEqual(5, result[4]);
        Assert.AreEqual(-1, result[5]);
        Assert.AreEqual(-1, result[6]);
        Assert.AreEqual(-1, result[7]);

    }

    [Test]
    public void Given1SourroundingIndexesShouldMatch()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        var result = indexService.FigureSuroundingIndexes(1, 5, 25);
        Assert.AreEqual(-1, result[0]);
        Assert.AreEqual(-1, result[1]);
        Assert.AreEqual(2, result[2]);
        Assert.AreEqual(7, result[3]);
        Assert.AreEqual(6, result[4]);
        Assert.AreEqual(5, result[5]);
        Assert.AreEqual(0, result[6]);
        Assert.AreEqual(-1, result[7]);

    }
    [Test]
    public void Given4SourroundingIndexesShouldMatch()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        var result = indexService.FigureSuroundingIndexes(4, 5, 25);
        Assert.AreEqual(-1, result[0]);
        Assert.AreEqual(-1, result[1]);
        Assert.AreEqual(-1, result[2]);
        Assert.AreEqual(-1, result[3]);
        Assert.AreEqual(9, result[4]);
        Assert.AreEqual(8, result[5]);
        Assert.AreEqual(3, result[6]);
        Assert.AreEqual(-1, result[7]);
        
    }
    [Test]
    public void Given5SourroundingIndexesShouldMatch()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        var result = indexService.FigureSuroundingIndexes(5, 5, 25);
        Assert.AreEqual(0, result[0]);
        Assert.AreEqual(1, result[1]);
        Assert.AreEqual(6, result[2]);
        Assert.AreEqual(11, result[3]);
        Assert.AreEqual(10, result[4]);
        Assert.AreEqual(-1, result[5]);
        Assert.AreEqual(-1, result[6]);
        Assert.AreEqual(-1, result[7]);
    }
    [Test]
    public void Given9SourroundingIndexesShouldMatch()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        var result = indexService.FigureSuroundingIndexes(9, 5, 25);
        Assert.AreEqual(4, result[0]);
        Assert.AreEqual(-1, result[1]);
        Assert.AreEqual(-1, result[2]);
        Assert.AreEqual(-1, result[3]);
        Assert.AreEqual(14, result[4]);
        Assert.AreEqual(13, result[5]);
        Assert.AreEqual(8, result[6]);
        Assert.AreEqual(3, result[7]);

    }
    [Test]
    public void Given6SourroundingIndexesShouldMatch()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        var result = indexService.FigureSuroundingIndexes(6, 5, 25);
        Assert.AreEqual(1, result[0]);
        Assert.AreEqual(2, result[1]);
        Assert.AreEqual(7, result[2]);
        Assert.AreEqual(12, result[3]);
        Assert.AreEqual(11, result[4]);
        Assert.AreEqual(10, result[5]);
        Assert.AreEqual(5, result[6]);
        Assert.AreEqual(0, result[7]);
    }
    [Test]
    public void Given24SourroundingIndexesShouldMatch()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        var result = indexService.FigureSuroundingIndexes(24, 5, 25);
        Assert.AreEqual(19, result[0]);
        Assert.AreEqual(-1, result[1]);
        Assert.AreEqual(-1, result[2]);
        Assert.AreEqual(-1, result[3]);
        Assert.AreEqual(-1, result[4]);
        Assert.AreEqual(-1, result[5]);
        Assert.AreEqual(23, result[6]);
        Assert.AreEqual(18, result[7]);
    }
    [Test]
    public void Given23SourroundingIndexesShouldMatch()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        var result = indexService.FigureSuroundingIndexes(23, 5, 25);
        Assert.AreEqual(18, result[0]);
        Assert.AreEqual(19, result[1]);
        Assert.AreEqual(24, result[2]);
        Assert.AreEqual(-1, result[3]);
        Assert.AreEqual(-1, result[4]);
        Assert.AreEqual(-1, result[5]);
        Assert.AreEqual(22, result[6]);
        Assert.AreEqual(17, result[7]);
    }

    [Test]
    public void Given5on25LowerLeftShouldBeNone()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        //var result = indexService.FigureSuroundingIndexes(5, 5, 25);
        var result = indexService.FigureLowerLeftIndex(5, 5, 25);
        Assert.AreEqual(-1, result);
    }
    [Test]
    public void Given4on25UpperRightShouldBeNone()
    {
        // Use the Assert class to test conditions.
        var indexService = new SurroundingIndexService();
        
        var result = indexService.FigureUpperRightIndex(4, 5);
        Assert.AreEqual(-1, result);
    }



}