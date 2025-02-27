using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

public class TopicService
{
    public event Action? OnTopicChanged;

    private string? _selectedTopic;

    public string? SelectedTopic
    {
        get => _selectedTopic;
        set
        {
            if (_selectedTopic != value)
            {
                _selectedTopic = value;
                NotifyTopicChanged();
            }
        }
    }

    private void NotifyTopicChanged()
    {
        try
        {
            OnTopicChanged?.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in NotifyTopicChanged: {ex.Message}");
        }
    }

}
