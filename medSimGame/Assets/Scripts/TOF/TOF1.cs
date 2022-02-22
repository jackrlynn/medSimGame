using UnityEngine;
using System.Collections;

public class TOF1 : MonoBehaviour
{
    Event @event;
    public GameObject heart_rate;
    public GameObject oxygen;
    public bool makeDecision;
    public GameObject decisionMenu;


    public void Start()
    {
        Patient pt = new Patient("TOFA", "", heart_rate, oxygen);
        pt.setHR(90);
        pt.setBloodOxy(75);
        @event = new Event("TOF1", 1, "Incoming Patient w/ Cyanosis", pt);
        @event.setDescription("The incoming patient has blue - ish skin, indicative of cyanosis.They also have blood oxygen levels around 75 %.");
        @event.setQuestion("How do we determine if the cyanosis is related to issues with the heart or the lungs ?");
        @event.addEvent("Deliver 0.1 L / min of O2 to PatientDeliver 0.1 L / min of O2 to Patient", 2);
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

    public void giveOxygen()
    {
        Time.timeScale = 1;
        this.@event.chooseNextEvent(0);
    }


}
