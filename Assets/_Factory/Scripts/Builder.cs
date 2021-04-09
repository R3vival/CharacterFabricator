using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterFactory {
    public class Builder : MonoBehaviour {
        [Header("Assets")]
        [SerializeField] private GameObject MaleBase;
        [SerializeField] private GameObject FemaleBase;

        [Space]
        [SerializeField] private Color NinjaColor;
        [SerializeField] private Color GolemColor;
        [SerializeField] private Color ZombieColor;
        [SerializeField] private Color ArcherColor;
        [SerializeField] private Color NymphColor;

        [Header("Builder Setup")]
        [SerializeField][Range(0f,1f)] private float maleProbability,femaleProbability;

        [SerializeField] public GameObject selectedBase;
        [SerializeField] private SkinnedMeshRenderer selectedSurface;
        [SerializeField] public Character selectedCharacter;

        private void Start() {
            ///Hide The base
            MaleBase.SetActive(false);
            FemaleBase.SetActive(false);
        }
        public void CreateCharacter(string btnName) {
            CharacterType type = StringToType(btnName);
            GenderType gender = GetGenderProbability();
            SetCharacter(gender);
            switch (type) {
                case CharacterType.Ninja:

                    Ninja ninja = selectedBase.AddComponent<Ninja>();
                    ninja = new Ninja(gender, NinjaColor, selectedSurface, selectedBase.GetComponent<Animator>());
                    selectedCharacter = ninja;
                    break;
                case CharacterType.Golem:
                    Golem golem = selectedBase.AddComponent<Golem>();
                    golem = new Golem(gender, GolemColor, selectedSurface, selectedBase.GetComponent<Animator>());
                    selectedCharacter = golem;
                    break;
                case CharacterType.Zombie:
                    Zombie zombie = selectedBase.AddComponent<Zombie>();
                    zombie = new Zombie(gender, ZombieColor, selectedSurface, selectedBase.GetComponent<Animator>());
                    selectedCharacter = zombie;
                    break;
                case CharacterType.Archer:
                    Archer archer = selectedBase.AddComponent<Archer>();
                    archer = new Archer(gender, ArcherColor, selectedSurface, selectedBase.GetComponent<Animator>());
                    selectedCharacter = archer;
                    break;
                case CharacterType.Nymph:
                    Nymph nymph = selectedBase.AddComponent<Nymph>();
                    nymph = new Nymph(gender, NymphColor, selectedSurface, selectedBase.GetComponent<Animator>());
                    selectedCharacter = nymph;
                    break;
            }
        }
        private CharacterType StringToType(string type) {
            switch (type) {
                case "SetNinja":
                    return CharacterType.Ninja;
                case "SetGolem":
                    return CharacterType.Golem;
                case "SetZombie":
                    return CharacterType.Zombie;
                case "SetArcher":
                    return CharacterType.Archer;
                case "SetNymph":
                    return CharacterType.Nymph;
                default:
                    return CharacterType.Ninja;
            }
        }
        private void SetCharacter(GenderType gender) {
            if (selectedBase != null)
                Destroy(selectedBase);

            if (gender == GenderType.Male) {
                selectedBase = Instantiate(MaleBase, SceneController.instance.characterCreationPosition);
                selectedBase.SetActive(true);

                selectedSurface = selectedBase.transform.Find("Alpha_Surface").GetComponent<SkinnedMeshRenderer>();
            } else {
                selectedBase = Instantiate(FemaleBase, SceneController.instance.characterCreationPosition);
                selectedBase.SetActive(true);

                selectedSurface = selectedBase.transform.Find("Beta_Surface").GetComponent<SkinnedMeshRenderer>();
            }

        }
        private GenderType GetGenderProbability() {
            float randomMale = Random.Range(0,maleProbability), randomFemale = Random.Range(0, femaleProbability);
            if (randomMale > randomFemale)
                return GenderType.Male;
            else
                return GenderType.Female;
        }

        public void CharacterKill() {
            if (selectedBase != null)
                selectedCharacter.Die();
        }
        public void CharacterAttack() {
            if (selectedBase != null)
                selectedCharacter.Attack();
        }
        public void CharacterDance() {
            if (selectedBase != null)
                selectedCharacter.ExtraAction();
        }
    }
    public enum CharacterType {
        Ninja,
        Golem,
        Zombie,
        Archer,
        Nymph
    }
}
