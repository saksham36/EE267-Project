using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ReloadScreen : MonoBehaviour
{
    private bool waitbool;
    public void Activate()
    {
        gameObject.SetActive(true);
        // waitbool = false;
        // Debug.Log("Wait Start");
        // StartCoroutine(reloadMessageWait());
        // Debug.Log("Wait End");
        // if (waitbool == true)
        // {
        //     Debug.Log("its me i waited");
        // }
        // gameObject.SetActive(false);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    IEnumerator reloadMessageWait()
    {
        yield return new WaitForSeconds(5);
        Debug.Log("hey i waited 5 secs of my life");
        waitbool = true;
        yield return null;
    
    }
}
