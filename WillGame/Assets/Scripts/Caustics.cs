using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Caustics : MonoBehaviour
{
    private Projector projector;
    public Texture2D[] frames;
    private float fps = 25;
    private int frameIndex;

    //// Start is called before the first frame update
    void Start()
    {
        projector = GetComponent<Projector>();

        NextFrame();
        InvokeRepeating("NextFrame", 1 / fps, 1 / fps);
    }

    void NextFrame()
    {
        projector.material.SetTexture("_ShadowTex", frames[frameIndex]);
        frameIndex++;
        if (frameIndex >= frames.Length)
        {
            frameIndex = 0;
        }
    }
}
