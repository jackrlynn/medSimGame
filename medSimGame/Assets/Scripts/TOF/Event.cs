using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{

    // Member variables

    // ID and title to summarize where the event falls and what is happening
    private readonly string id; // readonly = final in Java
    private readonly string title;
    private readonly int num_id;

    // String that holds the describes what the node is doing
    private string description;

    // String that holds what question MIGHT be asked
    private string question;

    // Reference patient
    // SHOULD MAKE ALL CHANGES TO PATIENT THROUGH PATIENT CLASS; EVENT CLASS IS ONLY FOR NAVIGATION
    private readonly Patient pt;

    // Dynamically allocated list of event instances
    // Comes with a description of a choice and an instance of the event that represents the consequences of that choices
    // NOTE: The Event instance acts as a reference, not a pointer; pointers are reserved for non-reference class in C#
    // If the list is empty, then this is a stop node
    private LinkedList<Tuple<string, int>> next_actions;

    // Constructors
    // Must set id, title, and patient reference, because those cannot change
    public Event(string id, int num_id, string title, Patient pt)
    {
        this.id = id;
        this.num_id = num_id;
        this.title = title;
        this.pt = pt;
        this.next_actions = new LinkedList<Tuple<string, int>>();
        this.description = "";
        this.question = "";
    }

    // Setters
    public void setDescription(string description)
    {
        this.description = description;
    }

    public void setQuestion(string question)
    {
        this.question = question;
    }

    // Getters

    public string getID()
    {
        return this.id;
    }

    public int getNumID()
    {
        return this.num_id;
    }

    public string getTitle()
    {
        return this.id;
    }

    public Patient getPatient()
    {
        return this.pt;
    }

    public string getDescription()
    {
        return this.description;
    }

    public string getQuestion()
    {
        return this.question;
    }

    public LinkedList<Tuple<string, int>> getNextActions()
    {
        return this.next_actions;
    }

    // Member functions

    // Adding choices

    // Add event instance function to list of choices
    // Inputs: choice - string - description of what that choice is
    //         next_event - Event - instance of Event class that describes the consequences of that choice
    // Outputs: n/a
    public void addEvent(string choice, int next_event)
    {
        this.next_actions.AddLast(new Tuple<string, int>(choice, next_event));
    }

    public void clearNextActions()
    {
        this.next_actions.Clear();
    }

    public void chooseNextEvent(int i)
    {
        if (i > -1 && i < this.next_actions.Count)
        {
            SceneManager.LoadScene(this.next_actions.ElementAt(i).Item2);
        }
    }

    // Start is called before the first frame update
    void Start()
    {        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
