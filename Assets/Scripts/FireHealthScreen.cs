using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FireHealthScreen : MonoBehaviour
{   
    public Text fireHealthText;
    public void Setup(int health)
    {
        gameObject.SetActive(true);
        fireHealthText.text = "Health: " + health.ToString();
    }
}
