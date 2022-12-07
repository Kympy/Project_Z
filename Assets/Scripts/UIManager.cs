using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image aim;
    private void Update()
    {
        if (PlayerHandler.Instance.IsAim)
        {
            aim.transform.localScale = Vector3.Lerp(aim.transform.localScale, new Vector3(0.5f, 0.5f, 0.5f), Time.deltaTime * 2f);
        }
        else
        {
            if (aim.transform.localScale == new Vector3(1f, 1f, 1f)) return;
            aim.transform.localScale = Vector3.Lerp(aim.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 5f);
        }
    }
}
