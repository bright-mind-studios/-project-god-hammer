using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMinigameEvents : MinigameEvents
{
    public override void OnResourceDestroy()
    {
        Debug.Log("Me voy a generar a otra parte");
    }

    public override void OnResourceUse(ResourceStation resourceStation)
    {
        resourceStation.GenerateMetalRock();
    }

    public override void OnResourceUnload(ResourceStation resourceStation)
    {
        Debug.Log("Vuelve pronto!");
        resourceStation.StopAllCoroutines();
        resourceStation.gameObject.SetActive(false);
    }

    public override void OnResourceLoad(ResourceStation resourceStation)
    {
        Debug.Log("Soy una piedra y me he creado");
        resourceStation.gameObject.SetActive(true);
    }
}
