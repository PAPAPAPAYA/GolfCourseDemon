using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
        #region GENERAL
        public bool mouseDown = false; // if mouse is held down
        public Vector2 mousePos = Vector2.zero; // mouse position
        public Vector2 mouseDownPos = Vector2.zero; // mouse held down position
        public Vector2 mouseDragDir = Vector2.zero; // mouse dragged direction
        public float mouseDragDuration = 0; // how long mouse held down
        #endregion
        #region SINGLETON
        public static InputManagerScript me;
        private void Awake()
        {
                me = this;
        }
        #endregion
        void Start()
        {
                
        }
	
        void Update()
        {
                // mouse status tracking
                mouseDown = Input.GetMouseButton(0); // updates if dragging
                mousePos = Input.mousePosition; // updates mouse pos
                if (Input.GetMouseButtonDown(0)) // mouse down frame
                {
                        mouseDownPos = mousePos;
                        mouseDragDuration = 0;
                }
                if (mouseDown) // mouse hold
                {
                        mouseDragDuration += Time.deltaTime;
                }
                if (Input.GetMouseButtonUp(0)) // mouse up frame
                {
                        mouseDragDuration = 0;
                }
                mouseDragDir = (mouseDownPos - mousePos).normalized;
        }
}