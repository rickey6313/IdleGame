using System.Collections;
using UnityEngine;
using TMPro;
using System.Text;

public class ItemTooltipBehaviour : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI mDescText;


    public void SetDescripton(string text)
    {
        mDescText.text = text;
    }
}
