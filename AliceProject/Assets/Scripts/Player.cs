using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;


public class Player : MonoBehaviour
{

    public bool canPick = false;

    public bool picked = false;
    public bool won = false;

    public XRController leftHandController;
    public XRController rightHandController;

    // Start is called before the first frame update
    void Start()
    {
        // interactor = GetComponent<XRDirectInteractor>();
        // interactor.selectEntered.AddListener(OnSelectEntered);
    }

    // Update is called once per frame
    void Update()
    {
        CheckTriggerInput(leftHandController);
        CheckTriggerInput(rightHandController);
        
    }

    private void CheckTriggerInput(XRController controller) {
        if(canPick==true) {
            if(controller.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerButtonValue) && triggerButtonValue)
            {
                RaycastHit hit;
                //controller.inputDevice.TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 position) ? position : controller.transform.position, controller.inputDevice.TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rotation) ? rotation * Vector3.forward : controller.transform.forward, out hit
                if (Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
                {
                    Cup cup = hit.transform.GetComponent<Cup> ();
                    if(cup!=null) {
                        canPick = false;
                        picked = true;
                        won = (cup.pocketWatch != null);
                        cup.MoveUp();
                    }
                }
            }
        }
        
    }
}
    