using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class StackCommands : MonoBehaviour
{
    public GameObject[] allPanels = new GameObject[10];
    public GameObject cmdPanel;
    public GameObject currentCmd;
    public string cmdName = "Command Panel";
    public Font font;
    public short activePnl = 0;
    public short maxPnl = 0;
    public Button right;
    public Button left;
    public int maxCommands = 10;
    public float checkTime = 1;

    private void Awake()
    {
        cmdPanel = allPanels[activePnl];
    }

    private void Update()
    {
        cmdPanel = allPanels[activePnl];
        checkButtonActivity();
        StartCoroutine(checkActive(checkTime));
    }

    IEnumerator checkActive(float sec)
    {
        for(int i = 0; i <= maxPnl; i++)
        {
            if(i == activePnl)
            {
                allPanels[i].SetActive(true);
            }
            else
            {
                allPanels[i].SetActive(false);
            }
        }

        yield return new WaitForSeconds(sec);
    }
    public void addCommand()
    {
        allPanels[activePnl].SetActive(false);
        activePnl = maxPnl;
        allPanels[activePnl].SetActive(true);
        createNewPanel();
        string name = currentCmd.GetComponent<TextMeshProUGUI>().text;
        GameObject cmd = new GameObject(name);
        cmd.transform.SetParent(allPanels[maxPnl].transform, false);
        int cmdpos = (maxPnl * maxCommands) + allPanels[maxPnl].transform.childCount;
        /*
        cmd.AddComponent<Image>();
        cmd.transform.SetParent(cmdPanel.transform, false);

        RectTransform rect = cmd.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(176, 20);

        GameObject txt = new GameObject(name+"_txt"); 
        txt.AddComponent<Text>();
        RectTransform txtRect = txt.GetComponent<RectTransform>();
        Text textCmd = txt.GetComponent<Text>();
        txtRect.sizeDelta = new Vector2(176, 20);

        textCmd.text = name;
        txt.transform.SetParent(cmd.transform, false);
        textCmd.font = font;
        textCmd.color = Color.white;
        */
        cmd.AddComponent<TextMeshPro>();
        TextMeshPro txt = cmd.GetComponent<TextMeshPro>();
        RectTransform txtRect = txt.GetComponent<RectTransform>();
        //txtRect.localScale = new Vector3(2, 1, 1);
        txtRect.sizeDelta = new Vector2(txtRect.rect.x , 35);
        txt.text = cmdpos + ". " + name;
        txt.font = TMP_FontAsset.CreateFontAsset(font);
        txt.enableAutoSizing = true;
        txt.fontSizeMax = 1000;
        //txt.fontSize = 40;
        txt.color = Color.white;
        txt.characterSpacing = 10;

        activePnl = maxPnl;
    }

    public void switchToRightPanel()
    {
        cmdPanel.SetActive(false);
        activePnl++;
        allPanels[activePnl].SetActive(true);
    }
    public void switchToLeftPanel()
    {
        activePnl--;
        allPanels[activePnl].SetActive(true);
    }

    void checkButtonActivity()
    {
        if (activePnl == 0)
        {
            left.interactable = false;
        }
        else
        {
            left.interactable = true;
        }
        if (activePnl == maxPnl)
        {
            right.interactable = false;
        }
        else
        {
            right.interactable = true;
        }
    }

    void createNewPanel()
    {
        if (allPanels[maxPnl].transform.childCount >= maxCommands)
        {
            if (maxPnl < allPanels.Length - 1)
            {
                maxPnl++;
            }
            else
            {
                return;
            }

            allPanels[maxPnl] = Instantiate(allPanels[maxPnl - 1], allPanels[maxPnl - 1].transform);
            allPanels[maxPnl].name = cmdName + maxPnl;
            allPanels[maxPnl].transform.SetParent(allPanels[maxPnl - 1].transform.parent);
            while (allPanels[maxPnl].transform.childCount > 0)
            {
                DestroyImmediate(allPanels[maxPnl].transform.GetChild(0).gameObject);
            }
            activePnl = maxPnl;
            cmdPanel = allPanels[activePnl];
        }
    }
}
