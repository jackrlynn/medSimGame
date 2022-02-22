using UnityEngine;
using System.Collections;

public class TOF2 : MonoBehaviour
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
        @event = new Event("TOF2", 2, "Blood Oxygen Test", pt);
        @event.setDescription("The patient has been given oxygen to determine if the issue is related to lungs or heart. Heart issues would have barely any changes in blood oxygen and cyanosis whereas lungs would have a large change");
        @event.setQuestion("Is the issue related to the heart or the lungs");
        @event.addEvent("Issue with Lungs", 3);
        @event.addEvent("Issue with Lungs", 4);
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

    public void lungIssue()
    {
        Time.timeScale = 1;
        this.@event.chooseNextEvent(0);
    }

    public void heartIssue()
    {
        Time.timeScale = 1;
        this.@event.chooseNextEvent(1);
    }


}
