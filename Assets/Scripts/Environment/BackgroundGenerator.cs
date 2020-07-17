using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public int timerForChange;
    public int leastTimeToChange, mostTimeToChange;

    public float backgroundSpeed;
    public float backgroundSpeedMin, backgroundSpeedMax;
    public float offsetX, offsetY;

    public int width, height;

    Renderer myRenderer;
    float scale;
    int timeChanged = 0;
    int change = 0;

    void Awake()
    {
        GenerateTextureVariables();

        myRenderer = GetComponent<Renderer>();
        CreateNewBackground();
    }

    void Update()
    {
        // if ((int)Time.time > timeChanged + timerForChange)
        // {
        //     GenerateTextureVariables();

        //     CreateNewBackground();
        //     GetTimeForChange();
        // }

        if ((int)Time.time > timeChanged + timerForChange)
        {
            change = Random.Range(-90, 90);
            backgroundSpeed = Random.Range(backgroundSpeedMin, backgroundSpeedMax);
            GetTimeForChange();
        }

        offsetX += (float)backgroundSpeed * Mathf.Cos(change) * Time.deltaTime;
        offsetY += (float)backgroundSpeed * Mathf.Sin(change) * Time.deltaTime;
        CreateNewBackground();
    }

    void GenerateTextureVariables()
    {
        scale = Random.Range(0.1f, 1f);
        offsetX = Random.Range(0f, 100f);
        offsetY = Random.Range(0f, 100f);
    }

    void GetTimeForChange()
    {
        timeChanged = (int)Time.time;
        timerForChange = Random.Range(leastTimeToChange, mostTimeToChange);
    }

    void CreateNewBackground()
    {
        myRenderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x,y, color);
            }
        }

        texture.Apply();

        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + offsetX;
        float yCoord = (float)y / height * scale + offsetY;

        float sample = Mathf.PerlinNoise(xCoord, yCoord);

        float colorOffset = Random.Range(0.1f, 1f);

        if (sample + colorOffset < 0.01f)
            sample = Random.Range(0.01f, 0.1f);

        return new Color(sample + colorOffset, sample, sample + colorOffset);
    }
}
