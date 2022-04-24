using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiButton : MonoBehaviour
{
    public Button button;
    private Color32 greys = new Color32(66, 66, 66, 255);
    private Color32 reds = new Color32(235, 19, 70, 255);
    public GameObject pos;

    public GameObject background;
    public GameObject top;
    // Start is called before the first frame update
    void Start()
    {
       Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(SystemButtonFunction);
    }

    void SystemButtonFunction()
    {
        Color32 currentColor = background.GetComponent<Image>().color;

            background.GetComponent<Image>().color = reds;
            top.transform.position = Vector3.MoveTowards(top.transform.position, pos.transform.position, Time.deltaTime * 1000f);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
