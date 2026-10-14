using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    [SerializeField] private int levelID;
    [SerializeField] private UnityEvent<int> LevelSelect;
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }

    public void OnClick()
    {
        LevelSelect.Invoke(levelID);
    }
}
