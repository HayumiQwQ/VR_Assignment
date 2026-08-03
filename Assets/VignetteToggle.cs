using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VignetteTog : MonoBehaviour 
{
    [Header("Assign ONE of these in the Inspector")]
    [SerializeField] private MonoBehaviour targetComponent; // For components like Snap Turn Provider
    [SerializeField] private GameObject targetObject;       // For GameObjects like TunnelingVignette
    
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
        SetRedState(); // Starts in the OFF state
    }

    public void HandleToggle() 
    {
        isGreenState = !isGreenState;
        if (isGreenState) 
        { 
            SetGreenState(); 
        } 
        else 
        { 
            SetRedState(); 
        }
    }

    public void SetGreenState() 
    {
        isGreenState = true; 
        if (buttonImage != null) buttonImage.color = Color.green;
        if (buttonText != null) buttonText.text = "ON"; 
        
        // Turn ON either component or GameObject
        if (targetComponent != null) targetComponent.enabled = true; 
        if (targetObject != null) targetObject.SetActive(true);
    }

    public void SetRedState() 
    {
        isGreenState = false; 
        if (buttonImage != null) buttonImage.color = Color.red;
        if (buttonText != null) buttonText.text = "OFF"; 
        
        // Turn OFF either component or GameObject (hides the vignette completely!)
        if (targetComponent != null) targetComponent.enabled = false; 
        if (targetObject != null) targetObject.SetActive(false);
    }
}