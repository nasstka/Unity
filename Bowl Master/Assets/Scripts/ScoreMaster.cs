using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMaster
{
    // Return a list of individual frame scores, NOT cumulative
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();

        // Code

        return frameList;
    }
    // Return a list of cumulative scores, like a normal scored card
    public static List<int>ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int farmeScore in ScoreFrames(rolls))
        {
            runningTotal += farmeScore;
            cumulativeScores.Add(runningTotal);
        }
        return cumulativeScores;
    }
}
