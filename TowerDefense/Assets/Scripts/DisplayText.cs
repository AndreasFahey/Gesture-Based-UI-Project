using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public TextMeshPro livesText;
    public TextMeshPro bloonsText;
    private int bloonPopCount = 0;
    private int livesLeft = 6;

    // Update is called once per frame
    void Update()
    {
        bloonsText.text = "Bloons Burst: " + bloonPopCount.ToString();
        livesText.text = "Lives: " + livesLeft.ToString();
        // Restart Game if Lives at 0
        if (livesLeft == 0){
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }

    // Bloons Pop Count
    public void BloonPopIncrease()
    {
        bloonPopCount++;
    }

    // Lives Count
    public void LivesDecrease()
    {
        livesLeft--;
    }
}