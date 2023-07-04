using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownResiduos : MonoBehaviour
{
    [SerializeField] TMP_Dropdown monthDrop;
    [SerializeField] TMP_Dropdown typeDrop;
    [SerializeField] TMP_Dropdown quantityDrop;
    [SerializeField] string monthText;
    [SerializeField] string typeText;
    [SerializeField] string quantityText;
    [SerializeField] TextMeshProUGUI tempText;
    [SerializeField] TextMeshProUGUI monthResidueList, typeResidueList, quantityResidueList;

    public void ChooseMonth(int value)
    {
        if(value == 0) // nada
        {
            monthText = "";
        }
        if(value == 1)
        {
            monthText = "Julho";
        }
        if(value == 2)
        {
            monthText = "Agosto";
        }

        if(value == 3)
        {
            monthText = "Setembro";
        }
    }

    public void ChooseType(int value)
    {
        if(value == 0) // nada
        {
            typeText = "";
        }
        if(value == 1)
        {
            typeText = "tipoUm";
        }
        if(value == 2)
        {
            typeText = "tipoDois";
        }

        if(value == 3)
        {
            typeText = "tipoTres";
        }
    }

    public void ChooseQuantity(int value)
    {
        if(value == 0) // nada
        {
            quantityText = "";
        }
        else if(value == 1)
        {
            quantityText = "1 Kg";
        }
        else if(value == 2)
        {
            quantityText = "2 Kg";
        }
        else if(value == 3)
        {
            quantityText = "3 Kg";
        }
    }

    public void TempText()
    {
        tempText.text = monthText + " - " + typeText + " - " + quantityText;
    }

    public void SubmitText()
    {
        if(monthText != "" && typeText != "" && quantityText != "")
        {
            monthResidueList.text += "• " + monthText + "\n";
            typeResidueList.text += "• " + typeText + "\n";
            quantityResidueList.text += "• " + quantityText + "\n";
            tempText.text = null; 
            ChooseMonth(0);
            ChooseType(0);
            ChooseQuantity(0);
        }
        else
        {
            Debug.Log("Falta-se valores");
            monthDrop.value = 0;
            typeDrop.value = 0;
            quantityDrop.value = 0;
        }
        // envio o tempText para a lista
        //cadastro o texto
        //limpo o temptext
    }

    
}
