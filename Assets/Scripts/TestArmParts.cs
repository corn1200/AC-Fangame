using FramePartsInterface;
using System;
using UnityEngine;

namespace DefaultNamespace
{
    [Serializable]
    public class TestArmParts : MonoBehaviour, IFrameArmSpec
    {
        public float ArmsLoadLimit { get; set; }
        public float RecoilControl { get; set; }
        public float FirearmSpecialization { get; set; }
        public float MeleeSpecialization { get; set; }
    }
}