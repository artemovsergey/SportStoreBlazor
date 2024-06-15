using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using SportStore.Blazor.State;
using System.Reflection.Metadata;
using SportStore.Domen.Models;

namespace SportStore.Blazor.Components;

public class FormStateTracker : ComponentBase
{
    [Inject]
    public AppState AppState { get; set; }

    [CascadingParameter]
    private EditContext CascadedEditContext{ get; set; }

    protected override void OnInitialized()
    {
        if (CascadedEditContext is null)
        {
            throw new InvalidOperationException($"{nameof(FormStateTracker)} requires a cascading parameter of type { nameof(EditContext) }");
        }
        CascadedEditContext.OnFieldChanged += CascadedEditContext_OnFieldChanged;
    }
    private void CascadedEditContext_OnFieldChanged(object sender, FieldChangedEventArgs e)
    {
        var trail = (User)e.FieldIdentifier.Model;
        if (trail.Id == 0)
        {
            AppState.SaveUser(trail);
            Console.WriteLine("SaveUser");
            Console.WriteLine($"GetUser: {AppState.GetUser().Name}");
            
        }
    }
}
