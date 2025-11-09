using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClubManagerScript : MonoBehaviour
{
        #region SINGLETON
        public static ClubManagerScript me;
        #endregion
        public float minForce; // min force to apply to ball
        public float maxForce; // max force
        public float holdToForceRatio; // hold time to force boost mod
        public Rigidbody2D rbToMove;
        private InputManagerScript _inputMan;
        
        // debug
        public float forceDebug;

        private void Awake()
        {
                me = this;
        }
        private void Start()
        {
                _inputMan = InputManagerScript.me;
        }

        private void Update()
        {
                if (Input.GetMouseButtonUp(0))
                {
                        Strike();
                }
                forceDebug = CalculateForce();
        }

        public float CalculateForce()
        {
                float force = 0;
                force = minForce + _inputMan.mouseDragDuration * holdToForceRatio;
                force = Mathf.Clamp(force, minForce, maxForce);
                return force;
        }

        private void Strike()
        {
                // rotate
                transform.rotation = Quaternion.Euler(0, 0, -UtilityFuncManagerScript.me.ConvertV2ToAngle(_inputMan.mouseDragDir));
                // move
                rbToMove.AddForce(_inputMan.mouseDragDir * CalculateForce(), ForceMode2D.Impulse);
        }
}
