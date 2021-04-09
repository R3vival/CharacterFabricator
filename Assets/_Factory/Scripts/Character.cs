using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterFactory {
    public abstract class Character : MonoBehaviour {
        #region Declarations
        protected GenderType gender;
        protected Color32 color;
        private SkinnedMeshRenderer surfaceJoints;
        private Animator animatorController;
        #endregion

        #region Encapsulamiento
        public Color32 Color { get => color; set => color = value; }
        public GenderType Gender { get => gender; set => gender = value; }
        protected SkinnedMeshRenderer SurfaceJoints { get => surfaceJoints; set => surfaceJoints = value; }
        protected Animator AnimatorController { get => animatorController; set => animatorController = value; }
        #endregion
        #region Constructor
        public Character(GenderType gender, Color32 color, SkinnedMeshRenderer surfaceJoints, Animator aminatorController) {
            Gender = gender;
            Color = color;
            SurfaceJoints = surfaceJoints;
            AnimatorController = aminatorController;

            SetColor();
        }
        public void SetColor() {
            SurfaceJoints.materials[0].color = Color;
        }
        #endregion
        #region Character Functions
        public void ChangeIdle() {
            AnimatorController.SetInteger("Idle", Random.Range(0, 3));
        }
        public void Die() { AnimatorController.SetTrigger("Die"); }
        public void Attack() { AnimatorController.SetTrigger("Attack"); }
        public abstract void ExtraAction();

        #endregion
    }
    public class Ninja : Character {
        public Ninja(GenderType gender, Color32 color, SkinnedMeshRenderer surfaceJoints, Animator aminatorController) : base(gender, color, surfaceJoints, aminatorController) {
        }
        public override void ExtraAction() {
            AnimatorController.SetTrigger("Dance_1");
        }
    }
    public class Golem : Character {
        public Golem(GenderType gender, Color32 color, SkinnedMeshRenderer surfaceJoints, Animator aminatorController) : base(gender, color, surfaceJoints, aminatorController) {
        }
        public override void ExtraAction() {
        }
    }
    public class Zombie : Character {
        public Zombie(GenderType gender, Color32 color, SkinnedMeshRenderer surfaceJoints, Animator aminatorController) : base(gender, color, surfaceJoints, aminatorController) {
        }
        public override void ExtraAction() {
            AnimatorController.SetTrigger("Dance_2");
        }
    }
    public class Archer : Character {
        public Archer(GenderType gender, Color32 color, SkinnedMeshRenderer surfaceJoints, Animator aminatorController) : base(gender, color, surfaceJoints, aminatorController) {
        }

        public override void ExtraAction() {
            AnimatorController.SetTrigger("Dance_1");
        }
    }
    public class Nymph : Character {
        public Nymph(GenderType gender, Color32 color, SkinnedMeshRenderer surfaceJoints, Animator aminatorController) : base(gender, color, surfaceJoints, aminatorController) {
        }

        public override void ExtraAction() {
        }
    }

    public enum GenderType {
        Male,
        Female
    }

}