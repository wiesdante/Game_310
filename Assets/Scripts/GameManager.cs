using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int targetFrameRate = 60;

    private void Start()
    {
        Application.targetFrameRate = targetFrameRate;
        
    }
}
