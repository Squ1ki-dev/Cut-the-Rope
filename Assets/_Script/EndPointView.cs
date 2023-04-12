using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointView : CatchableView
{
    [SerializeField] private ParticleSystem catchParticle;
    protected override void OnCatch(Weight player)
    {
        catchParticle.Play();
        GetComponent<SpriteRenderer>().color = Color.green;
        player.GetComponent<SpriteRenderer>().SetActive(false);
    }
}
