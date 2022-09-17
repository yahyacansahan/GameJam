using UnityEngine;

[CreateAssetMenu(fileName ="New Conversation", menuName = "Dialogue/New Conversation")]
public class Conversation : ScriptableObject
{
    [SerializeField] private DialogueLine[] allines;

    public DialogueLine GetLineByIndex(int index)
    {
        return allines[index];
    }

    public int GetLenght()
    {
        return allines.Length - 1;
    }

}
