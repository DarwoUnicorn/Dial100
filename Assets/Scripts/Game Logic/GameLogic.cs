using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameLogic : MonoBehaviour
{
    private Field _field;
    private GameParameters _gameParameters;
    
    public void GenerateField(GameParameters gameParameters)
    {
        _field = new Field(gameParameters);
        _gameParameters = gameParameters;
    }

}
