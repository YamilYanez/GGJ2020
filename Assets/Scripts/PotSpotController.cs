using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PotType
{
    Red, Blue, Green, None
}
[System.Serializable]
public class PotModels
{
    public GameObject Red, Blue, Green;
}

public class PotSpotController : MonoBehaviour
{
    public int durability = 2;
    private int hitPoints;
    public PotType defaultType = PotType.Red;
    public PotType craftDefaultType = PotType.Blue;
    public KeyCode destroyTestKey = KeyCode.O;
    public KeyCode craftTestKey = KeyCode.P;
    public PotModels models;
    private PotType type;
    public ParticleSystem pSystem;
    // Start is called before the first frame update
    void Start()
    {
        hitPoints = durability;
        type = defaultType;
        SetModel(type);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(destroyTestKey))
        {
            Hit();
        }
        if (Input.GetKeyDown(craftTestKey))
        {
            Craft(craftDefaultType);
        }
    }

    void SetModel(PotType type)
    {
        this.type = type;
        models.Red.SetActive(type == PotType.Red);
        models.Green.SetActive(type == PotType.Green);
        models.Blue.SetActive(type == PotType.Blue);
    }

    public PotSpotController Craft(PotType type)
    {
        if (this.type == PotType.None)
        {
            SpawnParticles();
            SetModel(type);
        }
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
        SpawnParticles();
        SetModel(PotType.None);
    }
}
