using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle: MonoBehaviour
{
    private ParticleSystem ps;
    public float hSliderValue;

    public GameController gameControllerZ;
    int scoreHere;



    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }
    void Update()
    {
        var main = ps.main;
        main.simulationSpeed = hSliderValue;

        scoreHere = gameControllerZ.score;

        if (scoreHere >= 100)
        {
            hSliderValue = 50.0F;
        }


    }


}
