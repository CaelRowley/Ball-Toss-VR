using UnityEngine;
using System.Collections;

public class PopUpController : MonoBehaviour
{
    public float popUpDelay;
    public string popUpType;
    private PopUp popUp;

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("PopUpController OnTriggerEnter()");
        StartCoroutine("UsePopUp");
    }

    private IEnumerator UsePopUp()
    {
        Debug.Log("PopUpController UsePopUp()");
        popUp = (PopUp)transform.parent.GetComponent(popUpType);
        yield return new WaitForSeconds(popUpDelay);
        popUp.Activate();
    }
}
