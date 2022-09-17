using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName, dialouge, ButtonText;
    public Image speakerSprite;

    private int currentIndex;
    private static DialogueManager instance;
    private Conversation currentConvo;
    private Animator anim;
    private Coroutine typing;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public static void StartConversation(Conversation convo)
    {
        instance.anim.SetBool("isOpen", true);
        instance.currentIndex = 0;
        instance.currentConvo = convo;
        instance.speakerName.text = "";
        instance.dialouge.text = "";
        instance.ButtonText.text = ">";

        instance.ReadNext();
    }
    
    public void ReadNext()
    {
        if (currentIndex > currentConvo.GetLenght())
        {
            instance.anim.SetBool("isOpen", false);
            return;
        }
        speakerName.text = currentConvo.GetLineByIndex(currentIndex).speaker.GetName();
        if (typing == null)
        {
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialouge));
        }
        else
        {
            instance.StopCoroutine(typing);
            typing = null;
            typing = instance.StartCoroutine(TypeText(currentConvo.GetLineByIndex(currentIndex).dialouge));
        }
        speakerSprite.sprite = currentConvo.GetLineByIndex(currentIndex).speaker.GetSprite();
        currentIndex++;

        if (currentIndex >= currentConvo.GetLenght())
        {
            ButtonText.text = "X";
        }
    }

    private IEnumerator TypeText(string text)
    {
        dialouge.text = "";
        bool complete = false;
        int index = 0;

        while (!complete)
        {
            dialouge.text += text[index];
            index++;
            yield return new WaitForSeconds(0.04f);

            if (index == text.Length - 1)
            {
                complete= true;
            }
        }
        typing = null;
    }
}
