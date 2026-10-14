using UnityEngine;

public class Objective : MonoBehaviour
{
    private bool isScored;
    
    private void Start()
    {
        isScored = false;
    }

    public bool IsScored
    {
        get => isScored;
    }

    public void Score()
    {
        isScored = true;
    }
}
