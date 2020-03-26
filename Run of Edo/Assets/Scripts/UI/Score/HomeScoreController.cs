using UnityEngine;
using TMPro;
public class HomeScoreController : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI LastScoreTxt;
    [SerializeField]
    protected TextMeshProUGUI HiScoreTxt;
    // Start is called before the first frame update
    void Start()
    {
        ScoreData data = SaveSystem.loadScore();
        if (data != null)
        {
            if (data.HiScore != null)
                HiScoreTxt.text = HiScoreTxt.text.Replace("[SCORE]", data.HiScore.ToString());
            else
                HiScoreTxt.enabled = false;

            if (data.LastScore != null)
                LastScoreTxt.text = LastScoreTxt.text.Replace("[SCORE]", data.LastScore.ToString());
            else
                LastScoreTxt.enabled = false;
        }
        else
        {
            LastScoreTxt.enabled = false;
            HiScoreTxt.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
