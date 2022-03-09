using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    private Field _field;
    
    public void Generate(GameParameters gameParameters)
    {
        _field = new Field(gameParameters);
    }
}
