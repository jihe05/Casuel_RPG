using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   public Move move;
    
    public void StopPlay()
    {
        move.enabled = false;
    }

    public void StartPlay()
    {
        move.enabled = true;

    }


}
