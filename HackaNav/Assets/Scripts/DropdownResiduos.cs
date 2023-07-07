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
    [SerializeField] int tempQuantityKG;
    [SerializeField] int quantityKG;
    [SerializeField] TextMeshProUGUI totalQuantityText;
    [SerializeField] TextMeshProUGUI tempText;
    [SerializeField] TextMeshProUGUI monthResidueList, typeResidueList, quantityResidueList;

    public void ChoosePage(int value)
    {
        if(value == 0)
        {
            monthResidueList.pageToDisplay = 1;
            typeResidueList.pageToDisplay = 1;
            quantityResidueList.pageToDisplay = 1;
        }
        if(value == 1)
        {
            monthResidueList.pageToDisplay = 2;
            typeResidueList.pageToDisplay = 2;
            quantityResidueList.pageToDisplay = 2;
        }
        if(value == 2)
        {
            monthResidueList.pageToDisplay = 3;
            typeResidueList.pageToDisplay = 3;
            quantityResidueList.pageToDisplay = 3;
        }
    }
    
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
            tempQuantityKG = 0;
            quantityText = "";
        }
        else if(value == 1)
        {
            tempQuantityKG = 1;
            quantityText = "1 Kg";
        }
        else if(value == 2)
        {
            tempQuantityKG = 2;
            quantityText = "2 Kg";
        }
        else if(value == 3)
        {
            tempQuantityKG = 3;
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
            quantityKG += tempQuantityKG;
            totalQuantityText.text = "TOTAL = " + quantityKG.ToString();

            monthResidueList.text += "• " + monthText + "\n";
            typeResidueList.text += "• " + typeText + "\n";
            quantityResidueList.text += "• " + quantityText + "\n";
            
            //zerar tudo
            tempText.text = null; 
            tempQuantityKG = 0;
            monthDrop.value = 0;
            typeDrop.value = 0;
            quantityDrop.value = 0;
            ChooseMonth(0);
            ChooseType(0);
            ChooseQuantity(0);
        }
        else
        {
            //zerar mesmo assim
            Debug.Log("Falta-se valores");
            monthDrop.value = 0;
            typeDrop.value = 0;
            quantityDrop.value = 0;
            tempQuantityKG = 0;
        }
        // envio o tempText para a lista
        //cadastro o texto
        //limpo o temptext
    }

    
}
