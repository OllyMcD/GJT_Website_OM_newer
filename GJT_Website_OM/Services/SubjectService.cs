using System;

public class SubjectService
{
    public event Action? OnSubjectChanged;

    private string? _selectedSubject;

    public string? SelectedSubject
    {
        get => _selectedSubject;
        set
        {
            if (_selectedSubject != value)
            {
                _selectedSubject = value;
                NotifySubjectChanged();
            }
        }
    }

    private void NotifySubjectChanged()
    {
        try
        {
            OnSubjectChanged?.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in NotifySubjectChanged: {ex.Message}");
        }
    }
}
