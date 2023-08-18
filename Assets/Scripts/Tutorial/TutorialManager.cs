using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private Queue<string> sentences;
    public TextMeshProUGUI text;
    public BoxCollider pass;
    public TechInventory tech;

    private void Awake()
    {
        sentences = new Queue<string>();
        pass.enabled = false;
    }
    private void Update()
    {
        if(Vector3.Distance(tech.transform.position, pass.transform.position) <= 0.5f)
        {
            tech.enabled = false;
        }
    }
    public void StartDialogue(Dialogues dialogues)
    {
        sentences.Clear();

        foreach (string sentence in dialogues.sentences)
        {
            sentences.Enqueue(sentence);
        }

        StartNextDialogue();
    }

    public void StartNextDialogue()
    {
        if(sentences.Count == 0)
        {
            pass.enabled = true;
            Destroy(GameObject.Find("TutorialBox"));
            return;
        }

        StopAllCoroutines();
        StartCoroutine(DialogueDelay(sentences.Dequeue()));
    }

    IEnumerator DialogueDelay(string sentence)
    {
        text.text = "";
        foreach(char ch in sentence)
        {
            text.text += ch;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
