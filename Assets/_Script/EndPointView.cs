using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointView : CatchableView
{
    [SerializeField] private Sprite free, catched;
    [SerializeField] private ParticleSystem catchParticle;
    private void Start()
    {
        GetComponent<SpriteRenderer>().SetSprite(free);
    }
    protected override void OnCatch(Candy player)
    {
        catchParticle.Play();
        GetComponent<SpriteRenderer>().SetSprite(catched);
        player.GetComponent<SpriteRenderer>().SetActive(false);
    }
}
