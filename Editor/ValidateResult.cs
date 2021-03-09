﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace VRCAvatars3Validator
{
    public class ValidateResult
    {
        public enum ValidateResultType
        {
            Success,
            Warning,
            Error,
        }

        public Object Target { get; private set; }

        public ValidateResultType ResultType { get; private set; }

        public string Result { get; private set; }
        public string Solution { get; private set; }
        public bool CanAutoFix { get; private set; }

        public Action AutoFix { get; private set; }

        public ValidateResult(Object target, ValidateResultType resultType, string result, string solution = "", Action autoFix = null)
        {
            Target = target;
            ResultType = resultType;
            Result = result;
            Solution = solution;
            AutoFix = autoFix;
            CanAutoFix = autoFix != null;
        }

        public void FocusTarget()
        {
            Selection.activeObject = Target;
            EditorGUIUtility.PingObject(Target);
        }
    }
}