using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;

public class ClothingChecklistManager : MonoBehaviour
{
    [System.Serializable]
    public class ChecklistItem
    {
        public string clothingID; // e.g., "Helmet", "Chestplate", "Gloves"
        public TextMeshProUGUI itemText;
        [HideInInspector] public Color originalColor; // Stores initial text color automatically
    }

    [SerializeField] private List<ChecklistItem> checklist;
    [SerializeField] private Color completedColor = Color.green;

    private void Awake()
    {
        // Cache the original inspector color for each text item on startup
        for (int i = 0; i < checklist.Count; i++)
        {
            if (checklist[i].itemText != null)
            {
                checklist[i].originalColor = checklist[i].itemText.color;
            }
        }
    }

    // Call this from XR Interactor Select Entered event
    public void CompleteItemFromXR(SelectEnterEventArgs args)
    {
        string objectName = args.interactableObject.transform.gameObject.name;
        CompleteItem(objectName);
    }

    // Call this from XR Interactor Select Exited event
    public void UncompleteItemFromXR(SelectExitEventArgs args)
    {
        string objectName = args.interactableObject.transform.gameObject.name;
        UncompleteItem(objectName);
    }

    public void CompleteItem(string clothingID)
    {
        for (int i = 0; i < checklist.Count; i++)
        {
            if (checklist[i].clothingID.Equals(clothingID, System.StringComparison.OrdinalIgnoreCase) 
                && checklist[i].itemText != null)
            {
                checklist[i].itemText.fontStyle |= FontStyles.Strikethrough;
                checklist[i].itemText.color = completedColor;
                break;
            }
        }
    }

    public void UncompleteItem(string clothingID)
    {
        for (int i = 0; i < checklist.Count; i++)
        {
            if (checklist[i].clothingID.Equals(clothingID, System.StringComparison.OrdinalIgnoreCase) 
                && checklist[i].itemText != null)
            {
                checklist[i].itemText.fontStyle &= ~FontStyles.Strikethrough;
                checklist[i].itemText.color = checklist[i].originalColor; // Reverts back to initial Red
                break;
            }
        }
    }
}