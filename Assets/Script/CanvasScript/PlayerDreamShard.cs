using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDreamShard : MonoBehaviour
{
    public Slider sli;
    // Start is called before the first frame update
    void Start()
    {
        sli.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sli.value = PlayerHead.dreamShard;
    }
}
