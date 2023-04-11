using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointView : CatchableView
{
    protected override void OnCatch(Weight player)
    {
        GetComponent<SpriteRenderer>().color = Color.green;
        player.GetComponent<SpriteRenderer>().SetActive(false);
    }
}
