using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private Field _field;
    
    public void GenerateField(GameParameters gameParameters)
    {
        _field = new Field(gameParameters);
    }
}
