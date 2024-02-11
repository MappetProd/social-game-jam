using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interactions
{
    interface IInteractable
    {
        public void Interact(GameObject gameObject);
    }
}