using UnityEngine;

public class Commands : MonoBehaviour
{
    public GameObject textCommands;
    public GameObject player;
    public Transform totalCmd;
    public string command;
    public string[][] word;
    public static string[] cmd;

    public void doMoves()
    {

        cmd = command.Split('|', System.StringSplitOptions.RemoveEmptyEntries);
        word = new string[cmd.Length][];
        for(int i = 0; i < cmd.Length; i++)
        {
            word[i] = cmd[i].Split();
            for(int j = 0; j < word[i].Length; j++)
            {
                word[i][j] = word[i][j].ToUpper();
            }
        }
    }

    public void addCommand()
    {
        command += textCommands.GetComponent<TMPro.TMP_InputField>().text + "|";
        textCommands.GetComponent<TMPro.TMP_InputField>().text = "";
    }

    public void clearCommand()
    {
        textCommands.GetComponent<TMPro.TMP_InputField>().text = "";
    }
}
