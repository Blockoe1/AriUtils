/*****************************************************************************
// File Name : KeySelectorAttribute.cs
// Author : Arcadia Koederitz
// Creation Date : 10/25/2026
// Last Modified : 10/25/2026
//
// Brief Description : Custom attributte for selecting an index or key from a collection that displays a name for designer friendliness.
*****************************************************************************/
using UnityEngine;
using System;

namespace AriUtils
{
    [AttributeUsage(AttributeTargets.Field)]
    public class IDSelectorAttribute : PropertyAttribute
    {
        
    }
}
