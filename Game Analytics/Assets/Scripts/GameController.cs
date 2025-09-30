using UnityEngine;

public class GameController : MonoBehaviour
{
    public int score { get; private set; }

    public void IncrementScore()
    {
        score++;
    }
}
