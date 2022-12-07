using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public interface IObserver
{
    public void UpdateState(ISubject subject);
}
