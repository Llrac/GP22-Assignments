using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolicCurve : ProcessingLite.GP21
{
    [Range(0.1f, 2f)]
    [SerializeField] float spaceBetweenLines = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Background(0);
        StrokeWeight(0.1f);

        for (int i = 0; i < Height / spaceBetweenLines; i++)
        {
            if (i % 3 == 0)
            {
                Stroke(Random.Range(0, 256), Random.Range(0, 256), Random.Range(0, 256));
            }
            else
            {
                Stroke(255);
            }
            Line(0, Height - i * spaceBetweenLines, (i * Width) / (Height / spaceBetweenLines), 0);
        }
    }
}
