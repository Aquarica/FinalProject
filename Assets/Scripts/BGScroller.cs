using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float someLength;
    private Vector3 startPosition;

    public GameController gameControllerZ;
    int scoreThere;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, someLength );
        transform.position = startPosition + Vector3.forward * newPosition;

        scoreThere = gameControllerZ.score;

        if (scoreThere >= 100)
        {
            scrollSpeed = -10.0F;
        }
    }
}
