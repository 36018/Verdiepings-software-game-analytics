using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UnityConsent;

public class AnalyticsManager : MonoBehaviour
{
    public static AnalyticsManager Instance;
    public object AnalyticsConsent { get; private set; }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private async void Start()
    {
        await UnityServices.InitializeAsync();
        // Set consent state for analytics (replace with appropriate ConsentStatus value)
        EndUserConsent.SetConsentState(new ConsentState
        {
            AnalyticsIntent = ConsentStatus.Granted
        }
        ); // or ConsentStatus.Denied as needed
        
    }

    public void Option1()
    {
        AnalyticsService.Instance.RecordEvent("Chosen_option1"); // Makes it so you can see which option was chosen in the dashboard
        AnalyticsService.Instance.Flush(); // Ensure all analytics events are sent before quitting
        Debug.Log("Option 1 chosen");
    }

    public void Option2()
    {
        AnalyticsService.Instance.RecordEvent("Chosen_option2");
        AnalyticsService.Instance.Flush();
        Debug.Log("Option 2 chosen");
    }

}
