using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Assistant : MonoBehaviour
{
    private Text messageText;
    TextWriter.TextWriterSingle textWriterSingle;
    void Awake()
    {
        messageText = GetComponent<Text>();
    }

    private void Start() {
        // messageText.text = "Hello Wolrd";
        string str = "Federico es uno de los mas grandes desarrolladores del mundo jamas conocidos";
        textWriterSingle = TextWriter.AddWriter_Static(messageText, str, .05f, true, false, null);
    }
}
