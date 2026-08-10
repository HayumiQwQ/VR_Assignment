using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RayToggle : MonoBehaviour 
{
    [Header("Assign Target Objects in the Inspector")]
    [Tooltip("Drag both RightRay and LeftRay GameObjects here.")]
    [SerializeField] private GameObject[] rayObjects; 

    private Button myButton;
    private Image buttonImage;
    private TextMeshProUGUI buttonText;
    private bool isGreenState = true; // Set default state variable to true

    void Awake() 
    {
        myButton = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        
        if (myButton != null)
        {
            myButton.onClick.AddListener(HandleToggle);
        }

        // Starts in the ON state when the game begins
        SetGreenState(); 
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
        
        // Ensure rays are active
        ToggleRays(true);
    }

    public void SetRedState() 
    {
        isGreenState = false; 
        if (buttonImage != null) buttonImage.color = Color.red;
        if (buttonText != null) buttonText.text = "OFF"; 
        
        // Turn OFF rays
        ToggleRays(false);
    }

    private void ToggleRays(bool activeState)
    {
        if (rayObjects == null) return;

        foreach (GameObject ray in rayObjects)
        {
            if (ray != null)
            {
                ray.SetActive(activeState);
            }
        }
    }
}