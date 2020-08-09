﻿using Newtonsoft.Json;
using System;
using System.ComponentModel;
using UnityEngine;

namespace traVRsal.SDK
{
    [Serializable]
    public class ObjectSpec
    {
        public enum PivotType
        {
            BOTTOM_FRONT_LEFT, BOTTOM_FRONT_CENTER, CENTER, BOTTOM_CENTER
        }

        [HideInInspector]
        public string objectKey;
        [JsonIgnore]
        [HideInInspector]
        public GameObject gameObject;
        public Vector3 position;
        public Vector3 rotation;
        [DefaultValue("Vector3.one")]
        public Vector3 scale = Vector3.one;
        [DefaultValue(1)]
        public int height = 1;
        public bool atCeiling = false;
        public bool pinToSide = false;
        public bool snapSideways = false;
        [DefaultValue(true)]
        public bool adjustMaterials = true;
        public PivotType pivotType = PivotType.BOTTOM_FRONT_LEFT;

        [NonSerialized]
        public SingleBehaviors behaviors;

        public ObjectSpec() { }

        public ObjectSpec(string objectKey) : this()
        {
            this.objectKey = objectKey;
        }

        public bool IsDefault()
        {
            if (position != Vector3.zero) return false;
            if (rotation != Vector3.zero) return false;
            if (scale != Vector3.one) return false;
            if (height != 1) return false;
            if (atCeiling) return false;
            if (pinToSide) return false;
            if (snapSideways) return false;
            if (!adjustMaterials) return false;
            if (pivotType != PivotType.BOTTOM_FRONT_LEFT) return false;

            return true;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(objectKey))
            {
                return $"Spec for soft-referenced {objectKey} (pivot: {pivotType}, pin-to-side: {pinToSide})";
            }
            else
            {
                return $"Spec for {gameObject} (pivot: {pivotType}, pin-to-side: {pinToSide})";
            }
        }
    }
}