using UnityEngine;

public class ToggleObjectVisiblity : MonoBehaviour
{
    public static void ToggleObjectVisible(string floorName, bool active)
    {
        GameObject objectWithTag = GameObject.Find(floorName);
        objectWithTag.SetActive(active);
    }
}
