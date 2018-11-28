using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement
{

    // Variables
    string m_title;
    string m_description;
    int m_goal;
    int m_currentProgress;
    bool m_isUnlocked;

    // Default constructor
    public Achievement()
    {
        m_title = "This needs a title";
        m_description = "This needs a description";
    }

    public Achievement(string title, string description, int goal, bool isUnlocked)
    {
        m_title = title;
        m_description = description;
        m_goal = goal;
        m_currentProgress = PlayerPrefs.GetInt(title);
        if (m_currentProgress >= m_goal)
            m_isUnlocked = true;
    }

    // Getters and Setters
    public string Title
    {
        get { return m_title; }
    }
    public string Description
    {
        get { return m_description; }
    }
    public int Goal
    {
        get { return m_goal; }
    }
    public bool IsUnlocked
    {
        get { return m_isUnlocked; }
    }
    public int CurrentProgress
    {
        get { return m_currentProgress; }
        set
        {
            if (m_currentProgress < m_goal)
            {
                m_currentProgress = value;

                if (m_currentProgress >= m_goal)
                {
                    m_currentProgress = m_goal;
                    m_isUnlocked = true;
                }

                PlayerPrefs.SetInt(m_title, m_currentProgress);
                PlayerPrefs.Save();
            }
        }
    }
}

