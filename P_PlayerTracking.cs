// Copyright © 2021 Pokeyi - https://pokeyi.dev - pokeyi@pm.me - This work is licensed under the MIT License.

// using System;
using UdonSharp;
using UnityEngine;
// using UnityEngine.UI;
using VRC.SDKBase;
// using VRC.SDK3.Components;
// using VRC.Udon.Common.Interfaces;

namespace Pokeyi.UdonSharp
{
    [AddComponentMenu("Pokeyi.VRChat/P.VRC Player Tracking")]
    [UdonBehaviourSyncMode(BehaviourSyncMode.NoVariableSync)] // No variables are serialized over network.

    public class P_PlayerTracking : UdonSharpBehaviour
    {   // Local player body-part tracking for VRChat:
        [Header(":: VRC Player Tracking by Pokeyi ::")]
        [Space]
        [Tooltip("Toggle use of attachments to tracked positions.")]
        [SerializeField] private bool useAttachments = true;
        [Tooltip("Game object attached to origin position.")]
        [SerializeField] private GameObject originAttachment;
        [Tooltip("Game object attached to head position.")]
        [SerializeField] private GameObject headAttachment;
        [Tooltip("Game object attached to left-hand position.")]
        [SerializeField] private GameObject leftHandAttachment;
        [Tooltip("Game object attached to right-hand position.")]
        [SerializeField] private GameObject rightHandAttachment;
        [Tooltip("Game object attached to left-foot position.")]
        [SerializeField] private GameObject leftFootAttachment;
        [Tooltip("Game object attached to right-foot position.")]
        [SerializeField] private GameObject rightFootAttachment;
        [Tooltip("Game object attached to left-lower-arm position.")]
        [SerializeField] private GameObject leftLowerArmAttachment;
        [Tooltip("Game object attached to right-lower-arm position.")]
        [SerializeField] private GameObject rightLowerArmAttachment;
        [Tooltip("Game object attached to left-upper-arm position.")]
        [SerializeField] private GameObject leftUpperArmAttachment;
        [Tooltip("Game object attached to right-upper-arm position.")]
        [SerializeField] private GameObject rightUpperArmAttachment;
        [Tooltip("Game object attached to left-lower-leg position.")]
        [SerializeField] private GameObject leftLowerLegAttachment;
        [Tooltip("Game object attached to right-lower-leg position.")]
        [SerializeField] private GameObject rightLowerLegAttachment;
        [Tooltip("Game object attached to left-upper-leg position.")]
        [SerializeField] private GameObject leftUpperLegAttachment;
        [Tooltip("Game object attached to right-upper-leg position.")]
        [SerializeField] private GameObject rightUpperLegAttachment;
        [Tooltip("Game object attached to chest position.")]
        [SerializeField] private GameObject chestAttachment;

        private VRCPlayerApi playerLocal; // Reference to local player.
        [HideInInspector] public VRCPlayerApi.TrackingData originData; // Origin tracking data.
        [HideInInspector] public VRCPlayerApi.TrackingData headData; // Head tracking data.
        [HideInInspector] public VRCPlayerApi.TrackingData leftHandData; // Left-hand tracking data.
        [HideInInspector] public VRCPlayerApi.TrackingData rightHandData; // Right-hand tracking data.
        private HumanBodyBones leftFootBone = HumanBodyBones.LeftFoot; // Left-foot bone.
        private HumanBodyBones rightFootBone = HumanBodyBones.RightFoot; // Right-foot bone.
        private HumanBodyBones leftLowerArmBone = HumanBodyBones.LeftLowerArm; // Left-lower-arm bone.
        private HumanBodyBones rightLowerArmBone = HumanBodyBones.RightLowerArm; // Right-lower-arm bone.
        private HumanBodyBones leftUpperArmBone = HumanBodyBones.LeftUpperArm; // Left-upper-arm bone.
        private HumanBodyBones rightUpperArmBone = HumanBodyBones.RightUpperArm; // Right-upper-arm bone.
        private HumanBodyBones leftLowerLegBone = HumanBodyBones.LeftLowerLeg; // Left-lower-leg bone.
        private HumanBodyBones rightLowerLegBone = HumanBodyBones.RightLowerLeg; // Right-lower-leg bone.
        private HumanBodyBones leftUpperLegBone = HumanBodyBones.LeftUpperLeg; // Left-upper-leg bone.
        private HumanBodyBones rightUpperLegBone = HumanBodyBones.RightUpperLeg; // Right-upper-leg bone.
        private HumanBodyBones chestBone = HumanBodyBones.Chest; // Chest bone.

        public void Start()
        {   // Assign reference to local player:
            playerLocal = Networking.LocalPlayer;
        }

        public override void PostLateUpdate()
        {   // Per-frame tracking:
            originData = playerLocal.GetTrackingData(VRCPlayerApi.TrackingDataType.Origin);
            headData = playerLocal.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
            leftHandData = playerLocal.GetTrackingData(VRCPlayerApi.TrackingDataType.LeftHand);
            rightHandData = playerLocal.GetTrackingData(VRCPlayerApi.TrackingDataType.RightHand);
            if (useAttachments) UpdateAttachments();
        }

        private void UpdateAttachments()
        {   // Update attachment positions to reflect tracking data:
            if (originAttachment != null) originAttachment.transform.SetPositionAndRotation(originData.position, originData.rotation);
            if (headAttachment != null) headAttachment.transform.SetPositionAndRotation(headData.position, headData.rotation);
            if (leftHandAttachment != null) leftHandAttachment.transform.SetPositionAndRotation(leftHandData.position, leftHandData.rotation);
            if (rightHandAttachment != null) rightHandAttachment.transform.SetPositionAndRotation(rightHandData.position, rightHandData.rotation);
            if (leftFootAttachment != null) leftFootAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(leftFootBone), playerLocal.GetBoneRotation(leftFootBone));
            if (rightFootAttachment != null) rightFootAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(rightFootBone), playerLocal.GetBoneRotation(rightFootBone));
            if (leftLowerArmAttachment != null) leftLowerArmAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(leftLowerArmBone), playerLocal.GetBoneRotation(leftLowerArmBone));
            if (rightLowerArmAttachment != null) rightLowerArmAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(rightLowerArmBone), playerLocal.GetBoneRotation(rightLowerArmBone));
            if (leftUpperArmAttachment != null) leftUpperArmAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(leftUpperArmBone), playerLocal.GetBoneRotation(leftUpperArmBone));
            if (rightUpperArmAttachment != null) rightUpperArmAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(rightUpperArmBone), playerLocal.GetBoneRotation(rightUpperArmBone));
            if (leftLowerLegAttachment != null) leftLowerLegAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(leftLowerLegBone), playerLocal.GetBoneRotation(leftLowerLegBone));
            if (rightLowerLegAttachment != null) rightLowerLegAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(rightLowerLegBone), playerLocal.GetBoneRotation(rightLowerLegBone));
            if (leftUpperLegAttachment != null) leftUpperLegAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(leftUpperLegBone), playerLocal.GetBoneRotation(leftUpperLegBone));
            if (rightUpperLegAttachment != null) rightUpperLegAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(rightUpperLegBone), playerLocal.GetBoneRotation(rightUpperLegBone));
            if (chestAttachment != null) chestAttachment.transform.SetPositionAndRotation(playerLocal.GetBonePosition(chestBone), playerLocal.GetBoneRotation(chestBone));
        }
    }
}

/* MIT License

Copyright (c) 2021 Pokeyi - https://pokeyi.dev - pokeyi@pm.me

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. */