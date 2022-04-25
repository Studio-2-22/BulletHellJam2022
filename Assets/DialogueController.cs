using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    public float typingSpeed = 0.1f;
    public string[] dialogues;
    public string fullText;
    private string currentText = "";
    private int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        fullText = dialogues[0];
        StartCoroutine(ShowText());
    }


    IEnumerator ShowText(){
        for (int i = 0; i < fullText.Length; i++){
            currentText = fullText.Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }
        index++;
        if (index < dialogues.Length){
            fullText = dialogues[index];
            yield return new WaitForSeconds(60);
            StartCoroutine(ShowText());
        }
    }
}
