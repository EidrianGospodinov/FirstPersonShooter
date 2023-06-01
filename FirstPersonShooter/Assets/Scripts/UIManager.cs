using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    
    


    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        Text textComponent = GetComponent<Text>();
        if (textComponent != null)
        {
        textComponent.text = $"Round: {FindObjectOfType<GameManager>().round.ToString()}";
        }

    }
}
