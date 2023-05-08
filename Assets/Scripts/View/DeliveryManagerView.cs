using UnityEngine;

public class DeliveryManagerView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _recipeTemplate;

    private void Awake()
    {
        _recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        ViewModel.ViewModel.DeliveryManagerContext.OnRecipeSpawned += (_, _) => UpdateView();
        ViewModel.ViewModel.DeliveryManagerContext.OnRecipeCompleted += (_, _) => UpdateView();
        UpdateView();
    }

    private void UpdateView()
    {
        foreach (Transform child in _container)
        {
            if (child == _recipeTemplate)
                continue;
            
            Destroy(child.gameObject);
        }

        foreach (var recipeSo in ViewModel.ViewModel.DeliveryManagerContext.GetWaitingRecipesSo())
        {
            var recipeTransform = Instantiate(_recipeTemplate, _container);
            recipeTransform.gameObject.SetActive(true);
            recipeTransform.GetComponent<DeliveryManagerSingleView>().SetRecipeSO(recipeSo);
        }
    }
}
