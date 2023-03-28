using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper
{
    //This class is intended to be expanded upon with more helpful and simple functions to help clean up code
    //in other scrpits and reduce how much rewriting needs to be done
    public float RandomFloatGen(float min, float max)
    {
        float newRandom;
        newRandom = Random.Range(min, max);

        float RandomFloatGen = newRandom;
        return RandomFloatGen;
    }
    public int RandomIntGen(int min, int max)
    {
        int newRandom;
        newRandom = Random.Range(min, max);

        int RandomIntGen = newRandom;
        return RandomIntGen;
    }
}
