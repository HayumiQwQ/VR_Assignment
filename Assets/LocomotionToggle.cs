using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit; // <--- ADD THIS

public class LocomotionToggle : MonoBehaviour 
{
    // Now it specifically asks for the Snap Turn component!
    [SerializeField] private ActionBasedSnapTurnProvider snapTurnProvider; 
    [SerializeField] private GameObject targetObject;   
    
    private Button myButton;
    private Image buttonImage;
    private TextMeshProUGUI buttonText;
    private bool isGreenState = false;

    void Awake() 
    {
        myButton = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        
        myButton.onClick.AddListener(HandleToggle);
        SetRedState(); 
    }

    public void HandleToggle() 
    {
        isGreenState = !isGreenState;
        if (isGreenState) SetGreenState(); 
        else SetRedState(); 
    }

    public void SetGreenState() 
    {
        isGreenState = true; 
        if (buttonImage != null) buttonImage.color = Color.green;
        if (buttonText != null) buttonText.text = "ON"; 
        
        if (targetObject != null) targetObject.SetActive(true);
        if (snapTurnProvider != null) snapTurnProvider.enabled = true;
    }

    public void SetRedState() 
    {
        isGreenState = false; 
        if (buttonImage != null) buttonImage.color = Color.red;
        if (buttonText != null) buttonText.text = "OFF"; 
        
        if (targetObject != null) targetObject.SetActive(false);
        if (snapTurnProvider != null) snapTurnProvider.enabled = false;
    }
}