using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Andras.ModTools
{
    public class Mod
    {
        public string fileName;
        public bool isActive;

        public Mod(string _fileName, bool _isActive)
        {
            fileName = _fileName;
            isActive = _isActive;
        }
    }
}