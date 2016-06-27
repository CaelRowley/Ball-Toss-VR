﻿using UnityEngine;
using System.Collections;

public class Lifespan : MonoBehaviour
{
    public float lifespan;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }

    public void setLifeSpan(int newLifeSpan)
    {
        lifespan = newLifeSpan;
    }
}
