using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster
{
    // Return a list of individual frame scores.
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frames = new List<int>();

        // Index i pints to 2nd bowl of frame
        for (int i = 1; i < rolls.Count; i += 2)
        {   
            if (frames.Count == 10)  // Prevents 11th frame score
            {
                break;
            }

            if (rolls[i - 1] + rolls[i] < 10)  // Normal OPEN frame
            {
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            if (rolls.Count - i <= 1)  // Insufficient look-ahead
            {
                break;
            }

            if (rolls[i - 1] == 10)     // STRIKE frame has just one bowl
            {
                i--;
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if (rolls[i - 1] + rolls[i] == 10)  // Calculate SPARE bonus
            {
                frames.Add(10 + rolls[i + 1]);
            }
        }

        return frames;
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
