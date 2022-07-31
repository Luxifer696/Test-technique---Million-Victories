using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelJSON : MonoBehaviour
{
    public GameObject ButtonID;

    public GameObject ButtonIDParent;

    [SerializeField]
    private Text panelText;

    private float m_currentHeightGap;
    private float m_heightGap;

    public void OnEnable()
    {
        m_heightGap = ButtonID.GetComponent<RectTransform>().sizeDelta.y * 1.5f;
    }

    public void CreateJSONButtonTitle(DataList dataList)
    {
        CleanButton();

        foreach (Data data in dataList.data)
        {
            // Instancie bouton et lui donne parent
            GameObject ButtonIDClone = Instantiate(ButtonID);
            ButtonIDClone.transform.parent = ButtonIDParent.transform;

            // Corrige rectTransform et place le bouton en dessous du precedent (le bouton d'origine se trouvant au sommet du Content)
            Vector3 rectPosition = new Vector2(ButtonID.GetComponent<RectTransform>().anchoredPosition.x, ButtonID.GetComponent<RectTransform>().anchoredPosition.y - m_currentHeightGap);
            ButtonIDClone.GetComponent<RectTransform>().anchoredPosition = rectPosition;
            ButtonIDClone.GetComponent<RectTransform>().localScale = ButtonID.GetComponent<RectTransform>().localScale;

            m_currentHeightGap += m_heightGap;

            // Titre le bouton
            ButtonIDClone.GetComponentInChildren<Text>().text = data.title;

            // Ajoute listener au click
            ButtonIDClone.GetComponent<Button>().onClick.AddListener(() => { ShowJSONContent(data.content); });
        }
    }

    public void CleanButton()
    {
        foreach(Button button in ButtonIDParent.transform.GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }

        m_currentHeightGap = 0;
    }

    public void CleanContent()
    {
        panelText.text = "";
    }

    public void ShowJSONContent(string dataContent)
    {
        panelText.text = dataContent;
    }


}
