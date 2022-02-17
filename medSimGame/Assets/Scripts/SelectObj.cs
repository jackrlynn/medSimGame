using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectObj : MonoBehaviour
{
    public Camera mainCamera;
    public Text showSelectionName;
    public string info = "Selected Object£º ";
    // Use this for initialization
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] raycastHits = null;
            raycastHits = Physics.RaycastAll(ray);
            float nearest = 10000f;
            float a = 0f;
            GameObject selected = null;
            if (raycastHits != null)
            {
                for (int i = 0; i < raycastHits.Length; i++)
                {
                    a = (raycastHits[i].transform.position - Camera.main.transform.position).magnitude;
                    if (a < nearest)
                    {
                        nearest = a;
                        selected = raycastHits[i].transform.gameObject;
                    }
                }
            }
            else
            {
                selected = null;
            }

            if (selected != null)
            {
                if (showSelectionName != null)
                {
                    showSelectionName.text = info + selected.name;
                }
                Debug.Log(selected.name);
            }
        }
    }
}
