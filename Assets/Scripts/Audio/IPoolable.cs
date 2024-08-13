using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    public Action Deactivate
    {
        get; set;
    }

    public Action RemoveTrace
    {
        get; set;
    }

}