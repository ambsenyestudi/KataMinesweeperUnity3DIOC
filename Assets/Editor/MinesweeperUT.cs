using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MinesweeperUT {
    //TODO 
    /*
     * .  generates 0
     * 
     * .. generates 00
     * 
     * ..           00
     * .. generates 00
     * 
     * *  generates *
     * 
     * *. generates *1
     * 
     * 
     */
	[Test]
	public void GivenDotShouldGetZero() {
        // Use the Assert class to test conditions.
        var generator = new TileGenerator();
        var field = generator.GenerateField(1, 1, new string[]{ "." });
        Assert.AreEqual(field[0], "0");
    }

    [Test]
    public void GivenTwoOneDotFieldShouldGetZero()
    {
        // Use the Assert class to test conditions.
        var generator = new TileGenerator();
        var field = generator.GenerateField(2, 1, new string[] { ".." });
        Assert.AreEqual(field[0], "00");
    }
    [Test]
    public void GivenTwoTwoDotFieldShouldGetZero()
    {
        // Use the Assert class to test conditions.
        var generator = new TileGenerator();
        var field = generator.GenerateField(2, 2, new string[] { "..", ".." });
        Assert.AreEqual(field[0], "00");
        Assert.AreEqual(field[1], "00");
    }
    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
	public IEnumerator MyUTWithEnumeratorPasses() {
		// Use the Assert class to test conditions.
		// yield to skip a frame
		yield return null;
	}
}
