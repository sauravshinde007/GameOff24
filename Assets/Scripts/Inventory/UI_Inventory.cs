using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    //for UI
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    [Header("Popup UI")]
    [SerializeField] private GameObject itemPopup;
    [SerializeField] private Image popupImage;
    [SerializeField] private Button closePopUPButton;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");

        //Inactive the Popup UI
        if(itemPopup != null)
        {
            itemPopup.SetActive(false);
            closePopUPButton.onClick.AddListener(() => itemPopup.SetActive(false)); // Close the popup when the button is clicked
        }
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += Inventory_OnItemListChanged;

        RefreshInventoryItems(); //adding items in proper way in the UI container
    }

    private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
    {
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        if (inventory == null)
        {
            Debug.LogError("Inventory is null in RefreshInventoryItems().");
            return;
        }

        if (itemSlotContainer == null || itemSlotTemplate == null)
        {
            Debug.LogError("itemSlotContainer or itemSlotTemplate is null. Check your UI setup.");
            return;
        }

        // Destroy existing slots except the template
        foreach (Transform child in itemSlotContainer)
        {
            if (child == itemSlotTemplate) continue;
            Destroy(child.gameObject);
        }

        List<Item> itemList = inventory.GetItemList();

        int x = 0;
        int y = 0;
        float itemSlotCellSize = 150f;

        foreach (Item item in itemList)
        {
            if (item == null)
            {
                Debug.LogError("Found null item in inventory list.");
                continue;
            }

            RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
            itemSlotRectTransform.gameObject.SetActive(true);

            // Set click functionality to open the popup
            itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
            {
                ShowItemPopup(item);
            };

            itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);

            Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
            if (image != null)
            {
                image.sprite = item.GetSprite();
            }
            else
            {
                Debug.LogError("Image component not found in itemSlotTemplate. Check the prefab setup.");
            }

            x++;
            if (x > 4)
            {
                x = 0;
                y--;
            }
        }

    }

    private void ShowItemPopup(Item item)
    {
        if (itemPopup == null || popupImage == null)
        {
            Debug.LogError("Popup UI is not set up correctly.");
            return;
        }

        // Get the popup sprite directly from the item
        Sprite popupSprite = item.GetPopupSprite();

        if (popupSprite == null)
        {
            Debug.LogError("Popup sprite not found for item: " + item.itemType);
            return;
        }

        // Display the item's popup image
        popupImage.sprite = popupSprite;
        itemPopup.SetActive(true);
    }
}
