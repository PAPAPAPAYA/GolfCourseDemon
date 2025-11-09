using System;
using UnityEngine;

public class HoleScript : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other)
        {
                if (other.CompareTag("Ball"))
                {
                        print("good");
                }
        }
}
