using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TextController : MonoBehaviour
{
    public TextModal text_modal;
    public TextView text_view;

    private void Awake()
    {
        
        text_modal = new TextModal();
    }
    // Start is called before the first frame update
    void Start()
    {
      
        text_view.StatsUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        text_view.StatsUpdate();
    }
}
