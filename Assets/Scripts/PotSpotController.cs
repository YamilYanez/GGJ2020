﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PotType
{
    Type1, Type2, Type3, None
}
public enum PotOwner {
    none = -1, player1 = 0, player2, player3, player4
}
[System.Serializable]
public class PotModels
{
    public GameObject Type1, Type2, Type3;
}
public class PotSpotController : MonoBehaviour
{
    public int durability = 2;
    private int hitPoints;
    public PotType defaultType = PotType.Type1;
    public PotType craftDefaultType = PotType.Type2;
    public KeyCode destroyTestKey = KeyCode.O;
    public KeyCode craftTestKey = KeyCode.P;
    public PotModels models;
    public PotType type {
        get;
        private set;
    }
    public PotOwner owner;
    public ParticleSystem pSystem;
    public AudioSource aSrcPotUncraft;
    public AudioSource aSrcPotCraft;

    // Start is called before the first frame update
    void Start()
    {
        hitPoints = durability;
        type = defaultType;
        SetModel(type);
        owner = PotOwner.none;
    }

    void SetModel(PotType type)
    {
        this.type = type;
        models.Type1.SetActive(type == PotType.Type1);
        models.Type2.SetActive(type == PotType.Type2);
        models.Type3.SetActive(type == PotType.Type3);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(destroyTestKey))
    //    {
    //        Hit();
    //    }
    //    else if (Input.GetKeyDown(craftTestKey))
    //    {
    //        Craft(craftDefaultType, 1);
    //    }
    //}

    public PotSpotController Craft(PotType type, int playerOwner)
    {
        // if (this.type == PotType.None)
        // {
        aSrcPotCraft.Play();
        SpawnParticles();
        SetModel(type);
        // }
        owner = (PotOwner)playerOwner;
        return this;
    }

    public void Hit()
    {
        
        if (type != PotType.None)
        {
            hitPoints--;
            if (hitPoints == 0)
            {
                Uncraft();
                hitPoints = durability;
            }
        }
    }

    void SpawnParticles()
    {
        pSystem.Play();
    }

    void Uncraft()
    {
        aSrcPotUncraft.Play();
        SpawnParticles();
        SetModel(PotType.None);
    }
}
