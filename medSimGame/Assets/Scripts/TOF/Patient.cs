using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Patient : MonoBehaviour
{
    // Identifier
    private readonly string id;

    // Some basic vitals (more will likely be added later)
    private int hr; // Heart rate
    public enum SkinCondition { Normal, LightCyanosis, Cyanosis } // More to be added later
    private SkinCondition skin_color; // Skin coloration
    private int blood_oxy; // Blood oxygen level
    private readonly string scan_file;

    // Unity variables
    public GameObject heart_rate;
    public GameObject oxygen;

    public Patient(string id, string scan_file, GameObject heart_rate, GameObject oxygen)
    {
        this.id = id;
        this.scan_file = scan_file;
        this.setHR(80);
        this.setSkinColor("Normal");
        this.setBloodOxy(100);
        this.heart_rate = heart_rate;
        this.oxygen = oxygen;
    }

    // Setters
    public void setHR(int hr)
    {
        if (hr >= 0 && hr < 250) // Makes sure heart rate is not impossible
        {
            this.hr = hr;
        }
    }

    // Key:
    //   (1) "Normal" or "": normal skin tone
    //   (2) "Light Cyanosis" or "Light Blue": moderate cyanosis
    //   (3) "Cyanosis" or "Blue": cyanosis
    public void setSkinColor(string skin_color)
    {
        if (skin_color.Equals("Normal") || skin_color.Equals(""))
        {
            this.skin_color = SkinCondition.Normal;
        }
        else if (skin_color.Equals("Light Cyanosis") || skin_color.Equals("Light Blue"))
        {
            this.skin_color = SkinCondition.LightCyanosis;
        }
        else if (skin_color.Equals("Cyanosis") || skin_color.Equals("Blue"))
        {
            this.skin_color = SkinCondition.Cyanosis;
        }
    }

    public void setBloodOxy(int blood_oxy)
    {
        if (hr >= 0 && hr <= 100) // Has to be a pencentage between 0 and 100, inclusive
        {
            this.blood_oxy = blood_oxy;
        }
    }

    // Getters
    public string getID()
    {
        return this.id;
    }

    public int getHR()
    {
        return this.hr;
    }

    public SkinCondition getSkinColor()
    {
        return this.skin_color;
    }

    public string getScanFile()
    {
        return this.scan_file;
    }

    public void updatePatient()
    {
        this.oxygen.GetComponent<Text>().text = this.blood_oxy.ToString();
        this.heart_rate.GetComponent<Text>().text = this.hr.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

}
