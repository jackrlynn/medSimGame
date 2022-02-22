using UnityEngine;
using System.Collections;

public class TOF3A : MonoBehaviour
{
    Event @event;
    public GameObject heart_rate;
    public GameObject oxygen;

    public void Start()
    {
        Patient pt = new Patient("TOFAOxyTest", "", heart_rate, oxygen);
        pt.setHR(90);
        pt.setBloodOxy(78);
        @event = new Event("TOF2", 2, "Blood Oxygen Test", pt);
        @event.setDescription("The user has incorrectly chose an issue with the lungs.");
        @event.setQuestion("n/a");
        @event.addEvent("Redirect Path", 4);
    }

    public void Update()
    {
        @event.getPatient().updatePatient();
    }

    public void heartIssue()
    {
        Time.timeScale = 1;
        this.@event.chooseNextEvent(0);
    }


}
