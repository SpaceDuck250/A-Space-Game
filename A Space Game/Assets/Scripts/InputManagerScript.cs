using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    public SpaceActions spaceActionInput;
    public SpaceActions.ShipMapActions shipMap;

    public ShipEngineControlScript shipEngineControls;

    private void Awake()
    {
        spaceActionInput = new SpaceActions();

        shipMap = spaceActionInput.ShipMap;
    }

    private void Update()
    {
        shipEngineControls.RotateEngine(shipMap.RotateEngine.ReadValue<float>());
        //shipEngineControls.ActivateEngine(shipMap.EngineActivate.ReadValue<float>());
        if (shipMap.EngineActivate.WasPressedThisFrame())
        {
            shipEngineControls.ActivateEngine(true);
        }

        if (shipMap.EngineActivate.WasReleasedThisFrame())
        {
            shipEngineControls.ActivateEngine(false);

        }
    }

    private void OnEnable()
    {
        spaceActionInput.Enable();
    }

    private void OnDestroy()
    {
        spaceActionInput.Disable();

    }
}
