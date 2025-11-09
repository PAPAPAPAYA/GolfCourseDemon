using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputUIManagerScript : MonoBehaviour
{
        public GameObject DirIndicator;
        public float forceToIndicatorLengthRatio = 1f;
        private InputManagerScript inputMan;

        private void Start()
        {
                inputMan = InputManagerScript.me;
        }
        private void Update()
        {
                UpdateDirIndicator();
        }
        private void UpdateDirIndicator()
        {
                Vector3 ogPos = Vector3.zero;
                if (Input.GetMouseButtonDown(0))
                {
                        ogPos = DirIndicator.transform.localPosition;
                }
                if (inputMan.mouseDown )
                {
                        // show indicator
                        DirIndicator.transform.localScale = new Vector2(1, 1);
                        // change local y based on drag duration
                        Vector3 offset = inputMan.mouseDragDir * ClubManagerScript.me.CalculateForce() * forceToIndicatorLengthRatio;
                        DirIndicator.transform.localPosition = ogPos + offset;
                        // change indicator direction, opposite of drag dir
                        DirIndicator.transform.rotation = Quaternion.Euler(0, 0,
                                -UtilityFuncManagerScript.me.ConvertV2ToAngle(inputMan.mouseDragDir));
                }
                else
                {
                        // hide indicator
                        DirIndicator.transform.localScale = new Vector2(1, 0);
                }
        }
}