using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TOF3B : MonoBehaviour
{
    Event @event;
    public GameObject heart_rate;
    public GameObject oxygen;
    public bool makeDecision;
    public GameObject decisionMenu;


    public void Start()
    {
        Patient pt = new Patient("TOFAOxyTest", "", heart_rate, oxygen);
        pt.setHR(90);
        pt.setBloodOxy(78);
        @event = new Event("TOF1", 1, "Incoming Patient w/ Cyanosis", pt);
        @event.setDescription("The user has correctly identified the issue as related to the heart. Now the user must identify the type of heart defect.");
        @event.setQuestion("How do we determine what type of defect the patient has?");
        makeDecision = false;
    }

    public void Update()
    {
        @event.getPatient().updatePatient();
        if (Input.GetButtonDown("Cancel"))
        {
            if (makeDecision)
            {
                Time.timeScale = 1;
                makeDecision = false;
                Cursor.visible = false;
                decisionMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                makeDecision = true;
                Cursor.visible = true;
                decisionMenu.SetActive(true);
            }
        }
    }

    // Update later
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }


}
