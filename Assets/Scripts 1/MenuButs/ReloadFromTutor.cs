using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadFromTutor : ReloadGame
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            OnClick();
        }
    }
}
