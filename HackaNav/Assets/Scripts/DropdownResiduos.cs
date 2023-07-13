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
    [SerializeField] float tempQuantityKG;
    [SerializeField] float quantityKG;
    [SerializeField] TextMeshProUGUI totalQuantityText;
    [SerializeField] TextMeshProUGUI tempText;
    [SerializeField] TextMeshProUGUI monthResidueList, typeResidueList, quantityResidueList;
    [SerializeField] GameObject panelDeleteText;


    private void Start() 
    {
        monthResidueList.text = PlayerPrefs.GetString("ListaMes");
        typeResidueList.text =  PlayerPrefs.GetString("ListaTipo");
        quantityResidueList.text  =  PlayerPrefs.GetString("ListaQuantidade");
        quantityKG = PlayerPrefs.GetFloat("ValorQuantidade");
    }
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
        if(value == 0) monthText = "";
        if(value == 1) monthText = "Janeiro";
        if(value == 2) monthText = "Fevereiro";
        if(value == 3) monthText = "Março";
        if(value == 4) monthText = "Abril";
        if(value == 5) monthText = "Maio";
        if(value == 6) monthText = "Junho";
        if(value == 7) monthText = "Julho";
        if(value == 8) monthText = "Agosto";
        if(value == 9) monthText = "Setembro";
        if(value == 10) monthText = "Outubro";
        if(value == 11) monthText = "Novembro";
        if(value == 12) monthText = "Dezembro";
    }

    public void ChooseType(int value)
    {
        if(value == 0) typeText = "";
        if(value == 1) typeText = "Reciclável";
        if(value == 2) typeText = "Orgânico";
        if(value == 3) typeText = "Não reciclável";
        if(value == 4) typeText = "Água";
        if(value == 5) typeText = "Alimento";
        if(value == 6) typeText = "Papéis";
        if(value == 7) typeText = "Vidro";
        if(value == 8) typeText = "Plástico";
        if(value == 9) typeText = "Madeira";
        if(value == 10) typeText = "Metal";
        if(value == 11) typeText = "Eletrônico";
        if(value == 12) typeText = "Hospitalar";
        if(value == 12) typeText = "Outros";
    }

    public void ChooseQuantity(int value)
    {
        if(value == 0)
        {
            tempQuantityKG = 0;
            quantityText = "";
        }
        if(value == 1)
        {
            tempQuantityKG = 0.25f;
            quantityText = "0.25 Kg";
        }
        if(value == 2)
        {
            tempQuantityKG = 0.5f;
            quantityText = "0.5 Kg";
        }
        if(value == 3)
        {
            tempQuantityKG = 1f;
            quantityText = "1 Kg";
        }
        if(value == 4)
        {
            tempQuantityKG = 2f;
            quantityText = "2 Kg";
        }
        if(value == 5)
        {
            tempQuantityKG = 3f;
            quantityText = "3 Kg";
        }
        if(value == 6)
        {
            tempQuantityKG = 4f;
            quantityText = "4 Kg";
        }
        if(value == 7)
        {
            tempQuantityKG = 5f;
            quantityText = "5 Kg";
        }
    }

    public void TempText()
    {
        tempText.text = monthText + " || " + typeText + " || " + quantityText;
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

            PlayerPrefs.SetString("ListaMes", monthResidueList.text);
            PlayerPrefs.SetString("ListaTipo", typeResidueList.text);
            PlayerPrefs.SetString("ListaQuantidade", quantityResidueList.text);
            PlayerPrefs.SetFloat("ValorQuantidade", quantityKG);

            //zerar tudo
            monthDrop.value = 0;
            typeDrop.value = 0;
            quantityDrop.value = 0;
           CleanEverything(); 
        }
        else
        {
            monthDrop.value = 0;
            typeDrop.value = 0;
            quantityDrop.value = 0;
            CleanEverything();
            //zerar mesmo assim
            Debug.Log("Falta-se valores");
        }
        // envio o tempText para a lista
        //cadastro o texto
        //limpo o temptext

        void CleanEverything()
        {
            tempQuantityKG = 0;
            ChooseMonth(0);
            ChooseType(0);
            ChooseQuantity(0);
            TempText ();
        }
    }

    public void OpenSINIR()
    {
        Application.OpenURL("https://sinir.gov.br");
    }
    public void OpenVideo()
    {
        Application.OpenURL("https://youtu.be/9RU4BUjyxm8");
    }

    public void OpenDeletePanel()
    {
        panelDeleteText.LeanScale(new Vector3(1, 1, 1), 0.3f);
    }
    public void ConfirmDeletePanel()
    {
        panelDeleteText.LeanScale(new Vector3(0, 0, 0), 0.3f);
        monthResidueList.text = "";
        typeResidueList.text = "";
        quantityResidueList.text  = "";

        PlayerPrefs.SetString("ListaMes", "");
        PlayerPrefs.SetString("ListaTipo", "");
        PlayerPrefs.SetString("ListaQuantidade", "");
        PlayerPrefs.SetFloat("ValorQuantidade", 0);
    }

    public void CancelDeletePanel()
    {
        panelDeleteText.LeanScale(new Vector3(0, 0, 0), 0.3f);
    }
    
}
