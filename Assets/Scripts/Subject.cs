using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Subject : MonoBehaviour
{
    List<Observer> m_Observers = new List<Observer>();

    public abstract void Attach(Observer listener);

    public abstract void Detach(Observer theObserver);

    public abstract void Notify(PlayerState playerState);
}