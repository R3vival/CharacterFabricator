using CharacterFactory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    #region Declarations
    /// <summary>
    /// Singleton
    /// </summary>
    public static SceneController instance;

    [SerializeField] Animator PpalPanelAnimator;
    [SerializeField] Builder builder;
    public Transform characterCreationPosition;
    [Range(0,2)]
    public float TimeScale = 1f;
    public float changeIdle = 1f;
    public float timer = 0;

    #endregion
    #region Unity Functions
    private void Awake() {
        ///Singleton SetUp
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }
    private void Update() {
        timer += Time.deltaTime * SceneController.instance.TimeScale;
        if (builder.selectedBase != null)
            if (timer >= changeIdle) {
                builder.selectedCharacter.ChangeIdle();
                timer = 0;
            }
    }
    #endregion
    #region SceneFunctions

    public void HidePpalPanel() {
        PpalPanelAnimator.SetTrigger("Hide");
    }
    #endregion
}
