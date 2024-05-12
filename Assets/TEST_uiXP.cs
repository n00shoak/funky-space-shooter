using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TEST_uiXP : MonoBehaviour
{
    public TextMeshProUGUI text; 
    public DT_Player player;

    private void Update()
    {
        text.text = " XP = " + player.xp;
    }
}
